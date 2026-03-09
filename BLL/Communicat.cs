using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Model;

namespace BLL
{
    class Communicat
    {
        
        private ActProgTypeLib.ActProgType axActUtlType1 = new ActProgTypeLib.ActProgType();
        public Communicat()
        {
            //axActUtlType1.ActLogicalStationNumber = 1;
            //axActUtlType1.ActPassword = "";
            axActUtlType1.ActUnitType = 44;
            axActUtlType1.ActProtocolType = 5;
            axActUtlType1.ActCpuType = 212;
            axActUtlType1.ActHostAddress = "192.168.0.1";
            //axActUtlType1.ActHostAddress = "192.168.10.1";
            axActUtlType1.ActBaudRate = 19200;
            axActUtlType1.ActConnectUnitNumber = 0;
            axActUtlType1.ActControl = 8;
            axActUtlType1.ActCpuTimeOut = 0;
            axActUtlType1.ActDataBits = 8;
            axActUtlType1.ActDestinationIONumber = 0;
            axActUtlType1.ActDestinationPortNumber = 0;
            axActUtlType1.ActDidPropertyBit = 1;
            axActUtlType1.ActDsidPropertyBit = 1;
            //axActUtlType1.ActHostAddress = "192.168.3.39";
            axActUtlType1.ActIntelligentPreferenceBit = 0;
            axActUtlType1.ActIONumber = 1023;
            axActUtlType1.ActMultiDropChannelNumber = 0;
            axActUtlType1.ActNetworkNumber = 0;
            axActUtlType1.ActPacketType = 1;
            axActUtlType1.ActParity = 1;
            axActUtlType1.ActPassword = "";
            axActUtlType1.ActPortNumber = 1;
            axActUtlType1.ActSourceNetworkNumber = 0;
            axActUtlType1.ActSourceStationNumber = 0;
            axActUtlType1.ActStationNumber = 255;
            axActUtlType1.ActStopBits = 0;
            axActUtlType1.ActSumCheck = 0;
            axActUtlType1.ActTargetSimulator = 0;
            axActUtlType1.ActThroughNetworkType = 0;
            axActUtlType1.ActTimeOut = 5000;
            axActUtlType1.ActUnitNumber = 0;
           // int i = axActUtlType1.Open();
            


        }
        public int get_From_Plc(String szDeviceName)//传入参数为地址名,获取返回值
        {
            //axActUtlType1.ActLogicalStationNumber = 1;
            int iReturnCode = -1;			// Return code
            short arrDeviceValue;		// Data for 'DeviceData'
            try
            {
                // Processing of GetDevice2 method
                iReturnCode = axActUtlType1.GetDevice2(szDeviceName, out arrDeviceValue);
                Thread.Sleep(1);


            }
           
            //  Exception processing			
            catch (Exception exception)
            {
                AppLog.WriteError(string.Format("PLC数据读取晶编失败{0}{1}", exception, szDeviceName), true);
                
                return -1;
            }
           
            if (iReturnCode == 0)
            {
                return arrDeviceValue;
            }
            else
            {
                AppLog.WriteError(string.Format("读取plc的晶编时失去了连接"), true);
                //                this.connection.Text = "PLC连接失败";//在正常连接其情况下，都能读到地址值，读不到则为PLC失去连接
                return -1;
            }
        }
        /// <summary>
        /// 将指定值发送到PLC指定地址里面
        /// </summary>
        /// <param name="szDeviceName"></param>
        /// <param name="arrDeviceValue"></param>
        public void write_To_Plc(String szDeviceName, short arrDeviceValue)//传入参数为地址名,获取返回值
        {
            int iReturnCode = -1;			// Return code'
            try
            {
                // Processing of GetDevice2 method
                iReturnCode = axActUtlType1.SetDevice2(szDeviceName, arrDeviceValue);//将指定值发送到PLC指定地址里面
                Thread.Sleep(1);
            }
            //  Exception processing		
           
            catch (Exception ex)
            {
                AppLog.WriteError(string.Format("PLC数据读取失败{0}{1}", ex,szDeviceName), true);
            }
            if (iReturnCode != 0)
            {
                return;
            }
            //            this.connection.Text = "数据库连接失败";//在正常连接其情况下，都能读到地址值，读不到则为PLC失去连接
        }
        /// <summary>
        /// 从PLC获取字符串
        /// </summary>
        /// <param name="szDeviceName"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public string get_String_FromPlc(String szDeviceName, int number)//从PLC的指定位置读取一个指定位数的字符串
        {
            int length = szDeviceName.Length;
            char[] result = new char[number];
            int iReturnCode = -1;
            short arrDeviceValue;
            szDeviceName = szDeviceName.Substring(1, szDeviceName.Length - 1);
            try
            {
                //short str =  ToInt16(szDeviceName.Substring(2,4));
                for (int i = 0; i < number ; i=i+2)//一个地址可以存两个个字符串，所以只需要一半
                {
                    if (i > 0)
                    {
                        szDeviceName = Convert.ToString((Convert.ToInt32(szDeviceName) + Convert.ToInt32("1")));
                    }
                    string newszDeviceName = "R" + szDeviceName.ToUpper();
                    iReturnCode = axActUtlType1.GetDevice2(newszDeviceName, out arrDeviceValue);
                    if (iReturnCode == 0)
                    {
                        result[i] = ((char)(arrDeviceValue & 0x00FF));
                        result[i + 1] = ((char)((arrDeviceValue >> 8) & 0x00FF));
                    }
                }
                Thread.Sleep(1);
                return string.Join("", result);//将得到的字符数组重新组合成字符串
               
            }
            catch(Exception ex)
            {
                AppLog.WriteError(string.Format("PLC数据读取失败{0}", ex), true);
                return "";
            }
        }
        public int plcIfOpen()
        {
            int iReturnCode = -1;
            try
            {
                iReturnCode = axActUtlType1.GetCpuType(out string str1, out int str2);
            }
            catch (Exception ex)
            {
                AppLog.WriteWarn(string.Format("PLC状态异常，异常原因{0}",ex),true);
                iReturnCode = -1;
            }
            return iReturnCode;
        }
       public void plcClose()
        {
            axActUtlType1.Close();
           // axActUtlType1.Disconnect();


        }
    }
}
