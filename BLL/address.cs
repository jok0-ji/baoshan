using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAT;

namespace BLL
{

    public class address
    {
       

        //*新添加的切方下料报表
        public string[] QfDownCommand = new string[2];
        public string[] QfDownFinish = new string[2];//读取完成
        public string[] QfDownCode = new string[2];//切方下料晶编
        public string[] QfDownMacID = new string[2];
        public string[] QfDownWireCost = new string[2];
        public string[] QfDownWireLeft = new string[2];
        public string[] QfDownWireBreakTimes = new string[2];
        public string QfstartHour;
        public string Qfstartmin;
        public string Qfstartsec;
        public string QfendHour;
        public string Qfendmin;
        public string Qfendsec;
        public string[] QfWidth1 = new string[2];
        public string[] QfWidth2 = new string[2];




        public address()
        {
            //从配置文件中读取PLC的地址\]
        }
            //static string filepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sys.ini");
            //static IniHelp ini = new IniHelp(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sys.ini"));


        public bool readAddressFromIni()//从配置文件中读取PLC的地址
        {  //string IniPath=""

            IniHelp ini = new IniHelp(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sys.ini"));
            
            if (ini.ExistINIFile())
            {

                //ScanfeedFinish = ini.IniReadValue("PLCAddress", "ScanfeedFinish", "R20010");//扫码上料信息接受完成
                //切方完工报表
                QfDownCommand[0] = ini.IniReadValue("PLCAddress", "QfDownCommand_0", "4002");
                QfDownCommand[1] = ini.IniReadValue("PLCAddress", "QfDownCommand_1", "4000");               
                QfDownCode[0] = ini.IniReadValue("PLCAddress", "QfDownCode_0", "50022");
                QfDownCode[1] = ini.IniReadValue("PLCAddress", "QfDownCode_1", "50032");
                QfDownWireCost[0]= ini.IniReadValue("PLCAddress", "QfDownWireCost_0", "50020");
                QfDownWireCost[1] = ini.IniReadValue("PLCAddress", "QfDownWireCost_1", "50020");
                QfDownWireLeft[0] = ini.IniReadValue("PLCAddress", "QfDownWireLeft_0", "50018");
                QfDownWireLeft[1] = ini.IniReadValue("PLCAddress", "QfDownWireLeft_1", "50018");
                QfDownWireBreakTimes[0]= ini.IniReadValue("PLCAddress", "QfDownWireBreakTimes_0", "50002");
                QfDownWireBreakTimes[1] = ini.IniReadValue("PLCAddress", "QfDownWireBreakTimes_1", "50002");
                QfWidth1[0]= ini.IniReadValue("PLCAddress", "QfWidth1_0", "50048");
                QfWidth1[1]= ini.IniReadValue("PLCAddress", "QfWidth2_0", "50052");
                QfWidth2[0]= ini.IniReadValue("PLCAddress", "QfWidth1_1", "50050");
                QfWidth2[1] = ini.IniReadValue("PLCAddress", "QfWidth2_1", "50054");
                QfstartHour = ini.IniReadValue("PLCAddress", "QfstartHour", "50004");
                Qfstartmin = ini.IniReadValue("PLCAddress", "Qfstartmin", "50006");
                Qfendmin = ini.IniReadValue("PLCAddress", "Qfstartsec", "50008");
                QfendHour= ini.IniReadValue("PLCAddress", "QfendHour", "50010");
                Qfendmin= ini.IniReadValue("PLCAddress", "Qfendmin", "50012");
                Qfendsec= ini.IniReadValue("PLCAddress", "Qfendsec", "50016");
                return true;
            }
            return false;
        }
        public bool readUrlFromIni()//从配置文件中读取web API的地址
        {
            return false;
        }


    }
}
