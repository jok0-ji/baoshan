using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAT;
using Model;
using System.Text.RegularExpressions;
//using Newtonsoft.Json;


namespace BLL
{

    public class PLC_Process
    {
        private Communicat communicat;
        List<ModbusTcp> modbusTcpnew = new List<ModbusTcp>();
        private ModbusTcp modbusTcp = null;
        private SQLString sqlstr;//sql语句
        static string[,] last_down_command = new string[13, 2];
        private address Address;//地址
        private string errMassage;
        private string strCode;
        private int brkTimes;
        private short endhour;
        private short endminl;
        private short endsec;
        private short starthour;
        private short startminl;
        private short startsec;
        private short length1 ;
        private short length2;
        private string[] macIP =
            {"192.168.108.170","192.168.108.169","192.168.108.168", "192.168.108.167", "192.168.108.166", "192.168.108.165",
            "192.168.108.171","192.168.108.172","192.168.108.173","192.168.108.174","192.168.108.175" ,"192.168.108.176","192.168.108.177",};//0-12
        private string[] macSpec =
            { "QFJB01", "QFJB02", "QFJB03", "QFJB04", "QFJB05", "QFJB06",
            "QFJA01", "QFJA02", "QFJA03", "QFJA04", "QFJA05" ,"QFJA06", "QFJA07"};
        private int lineLeft;

        public double weightcoff { get; private set; }
        public int temp { get; private set; }
        public double calweight { get; private set; }



        public PLC_Process()
        {
            for (int i = 0; i < 13; i++)
            {
                try
                {
                    modbusTcp = new ModbusTcp(macIP[i], 502);
                    modbusTcpnew.Add(modbusTcp);
                }
                catch
                {
                    AppLog.WriteInfo(string.Format("切方机{0}({1})IP连接失败！", macIP[i], macSpec[i]), true);
                }

            }
            communicat = new Communicat();
            Address = new address();
            sqlstr = new SQLString();
            Address.readAddressFromIni();

        }



        public bool[] command = new bool[16];
        public void generateQfDown()//生成切方下料报表
        {
            //PLC只需发送晶编号，机台号，金刚线的几个参数即可，再通过两个标志位来握手

            short generate_down_command = 0;  //切方报表请求标志位\
            int[] generate_down_rok = new int[2]; //生成切方报表读取完成标志位          
            SqlDataReader sdr = null;
            SqlDataReader sdr2 = null;
            DataSet dstspec = null;

            try
            {
                for (int i = 0; i < 13; i++)
                {
                    try
                    {
                        if (modbusTcpnew[i].IsConnected == false)
                            modbusTcpnew[i].Connect();
                    }
                    catch (Exception ex)
                    {
                        AppLog.WriteError(string.Format("切方机{0}({1})connect()失败！,{2}", macIP[i], macSpec[i], ex), true);
                    }
                    for (int j = 0; j < 2; j++)
                    {
                        QFDownReport qfdr1 = new QFDownReport();
                        //try
                        //{
                        //    modbusTcpnew[i].ReadValue<short>(Convert.ToInt32(Address.QfDownCommand[j]), out generate_down_command, out errMassage);//获取请求标志位
                        //    for (byte m = 0; m < 16; m++)
                        //    {
                        //        command[m] = ExtendedInt.GetBit(generate_down_command, m);

                        //    }
                        //    // AppLog.WriteInfo(string.Format("切方机{0}({1})工位{2} ：{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18}", macIP[i], macSpec[i], j + 1, 
                        //    // command[0], command[1], command[2], command[3], command[4], command[5], command[6], command[7], command[8], command[9], command[10], command[11], command[12], command[13], command[14], command[15]), true);


                        //}
                        //catch
                        //{
                        //    AppLog.WriteInfo(string.Format("切方机{0}({1})请求标志位工位{2}获取失败！", macIP[i], macSpec[i], j + 1), true);

                        //}

                        //    if (command == false)
                        //    {
                        //        //AppLog.WriteInfo(string.Format("切方机{0}({1})没有跳变！", macIP[i], macSpec[i]), true);
                        //    }
                        try
                        {
                            modbusTcpnew[i].ReadLongString(Convert.ToInt32(Address.QfDownCode[j]), 20, out strCode, out errMassage);
                            //qfdr1.Code1 = strCode.Trim().Replace(" ","");
                            qfdr1.Code1 = Regex.Replace(strCode, @"\s", "");
                            // AppLog.WriteInfo(string.Format("切方机{0}({1})进入主函数得到工位{3}晶编号为'{2}'", macIP[i], macSpec[i], qfdr1.Code1, j + 1), true);
                            modbusTcpnew[i].ReadValue<short>(Convert.ToInt32(Address.QfendHour), out endhour, out errMassage);
                            modbusTcpnew[i].ReadValue<short>(Convert.ToInt32(Address.Qfendmin), out endminl, out errMassage);
                            modbusTcpnew[i].ReadValue<short>(Convert.ToInt32(Address.Qfendsec), out endsec, out errMassage);
                            modbusTcpnew[i].ReadValue<short>(Convert.ToInt32(Address.QfstartHour), out starthour, out errMassage);
                            modbusTcpnew[i].ReadValue<short>(Convert.ToInt32(Address.Qfstartmin), out startminl, out errMassage);
                            modbusTcpnew[i].ReadValue<short>(50008, out startsec, out errMassage);
                             DateTime beginTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, starthour, startminl, 0);
                             DateTime endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, endhour, endminl, 0);
                            qfdr1.endTime = endTime;
                            qfdr1.beginTime = beginTime;
                           // AppLog.WriteInfo(string.Format("开始时{0}，分{1}，秒{2}，结束时{3}，分{4}，秒{5}", starthour, startminl, startsec, endhour, endminl, endsec), true);
                        }
                        catch(Exception ex)
                        {
                            AppLog.WriteError(string.Format("切方机{0}({1})进入主函数得到工位{2}晶编号失败{3}", macIP[i], macSpec[i], j + 1,ex), true);
                        }
                        if (qfdr1.endTime> qfdr1.beginTime && qfdr1.Code1.Length > 5 && ((qfdr1.Code1[0] >= 'A') && (qfdr1.Code1[0] <= 'Z')) && (((qfdr1.Code1[4] >= 'A') && (qfdr1.Code1[4] <= 'Z')) || (((qfdr1.Code1[4] >= '0') && (qfdr1.Code1[4] <= '9')))) && !(qfdr1.Code1 == " ") && last_down_command[i, j] != qfdr1.Code1)//有跳变
                        {
                            //AppLog.WriteInfo(string.Format("切方机{0}({1})读到工位{2}跳变进入处理工序！", macIP[i], macSpec[i], j + 1), true);
                            AppLog.WriteInfo(string.Format("切方机{0}({1})进入主函数得到工位{3}晶编号为'{2}'，上一次晶编为'{4}'，开始时间为{6}，结束时间为{5}", macIP[i], macSpec[i], qfdr1.Code1, j + 1, last_down_command[i, j], qfdr1.endTime, qfdr1.beginTime), true);

                            //        //**************获取机台号
                            qfdr1.MacID1 = macSpec[i];

                            //        //**************获取车间号，班次
                            qfdr1.MacShop1 = "机加一车间";//现在只改造车间一
                            qfdr1.Length1 = 0;


                            int hour = DateTime.Now.Hour;
                            if (hour >= 8 && hour < 20)
                            {
                                qfdr1.Flight1 = "DAY";
                            }
                            else
                            {
                                qfdr1.Flight1 = "NIGHT";
                            }

                            //        //**************获取规格和长度

                            sdr = DataBase.SelectForReader(sqlstr.selectQfYuan(qfdr1.Code1));
                            sdr.Read();
                            if (sdr.HasRows)//
                            {
                                qfdr1.Spec1 = sdr["spec"].ToString();
                                qfdr1.Length1 = Convert.ToInt32(sdr["ValidLength"]);
                                if (qfdr1.Length1 == 0)
                                {
                                    qfdr1.Length1 = Convert.ToInt32(sdr["length"]);
                                }
                                qfdr1.RepairMark1 = Convert.ToInt32(sdr["RepairMark"]);

                                AppLog.WriteInfo(string.Format("切方机{0}({1})得到工位{3}晶棒长度为'{2}'", macIP[i], macSpec[i], qfdr1.Length1, j + 1), true);


                            }
                            else
                            {
                                AppLog.WriteInfo(string.Format("生成切方下料报表环节查询圆棒表失败工位{0}!", j + 1), true);
                            }
                            //        //**************获取重量
                            dstspec = DataBase.ExecuteTable(sqlstr.selectProductSpec(), "productspec");
                            qfdr1.CalWeight1 = 0;

                            try
                            {
                                for (int x = 0; x < dstspec.Tables[0].Rows.Count; x++)
                                {

                                    if (qfdr1.Spec1 == dstspec.Tables[0].Rows[x]["ProductSpec"].ToString())
                                    {
                                        weightcoff = Convert.ToDouble(dstspec.Tables[0].Rows[x]["FWeightCoff"].ToString());

                                        break;
                                    }

                                }
                            }
                            catch
                            {
                                AppLog.WriteInfo(string.Format("查询规格表失败"), true);
                            }

                            if (weightcoff <= 0)
                            {
                                weightcoff = 1;
                            }
                            calweight = Convert.ToDouble(qfdr1.Length1) / weightcoff;                       
                            qfdr1.CalWeight1 = calweight;


                            //        //***********至此处理完calweight****************************

                            try
                            {
                                modbusTcpnew[i].ReadValue<int>(50002, out brkTimes, out errMassage);//断线次数
                                modbusTcpnew[i].ReadValue<float>(50020, out float lineCost, out errMassage);//使用线长
                                modbusTcpnew[i].ReadValue<float>(50018, out float f2, out errMassage);//剩余线量

                                modbusTcpnew[i].ReadValue<short>(Convert.ToInt32(Address.QfWidth1[j]), out length1, out errMassage);//剩余边距1
                                modbusTcpnew[i].ReadValue<short>(Convert.ToInt32(Address.QfWidth2[j]), out length2, out errMassage);//剩余边距1
                                qfdr1.Width1 = length1;
                                qfdr1.Width2 = length2;
                                qfdr1.WireBreakTimes1 = brkTimes;
                                qfdr1.WireCost1 = lineCost;
                                qfdr1.WireLeft1 = f2;
                                //if (j == 0)
                                //    qfdr1.MacTMID = "1";
                               /// else
                               //     qfdr1.MacTMID = "2";
                                AppLog.WriteInfo(string.Format("线耗为{0}，剩余线量为{1}", qfdr1.WireCost1, qfdr1.WireLeft1), true);
                            }
                            catch (Exception ex)
                            {
                                AppLog.WriteError(string.Format("错误为：{0}", ex), true);
                            }
                        
                            //        //**************插入数据库
                            try
                            {
                                int result;
                                int name;
                                modbusTcpnew[i].ReadValue<int>(Convert.ToInt32("50046"), out name, out errMassage);
                                modbusTcpnew[i].ReadValue<float>(Convert.ToInt32("50016"), out float f1, out errMassage);//
                                string str = "";
                                if (j == 0)
                                    str = "1";
                                else
                                    str = "2";
                                DataBase.Update(sqlstr.insertQfFinishReport(qfdr1,str,f1,name.ToString()));//这里Update函数用了双层try函数

                            }
                            catch (Exception ex)
                            {
                                AppLog.WriteInfo(string.Format("切方机{0}({1})工位{2}插入切方下料完工表失败:", macIP[i], macSpec[i], j + 1), true);

                            }


                          

                        }
                        last_down_command[i, j] = qfdr1.Code1;
                    }
                    //modbusTcpnew[i].DisConnect();
                }
            }
            catch (Exception ex) 
            {
                AppLog.WriteError(string.Format("错误为{0}",ex),true);
            }
            }
    }
}
