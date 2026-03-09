using log4net;
using log4net.Appender;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AppLog
    {
        private static string filepath = AppDomain.CurrentDomain.BaseDirectory + @"\SysLog\";

        private static string webapifilepath = AppDomain.CurrentDomain.BaseDirectory + @"\WebApi\";

        private static readonly log4net.ILog logComm = log4net.LogManager.GetLogger("AppLog");

        static AppLog()
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo("log4net.config"));

            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }

            if (!Directory.Exists(webapifilepath))
            {
                Directory.CreateDirectory(webapifilepath);
            }
        }

        /// <summary>
        /// 输出系统日志
        /// </summary>
        /// <param name="msg">信息内容</param>
        /// <param name="source">信息来源</param>
        private static void WriteLog(string msg, bool isWrite, Action<object> action,UInt16 flag)
        {
            if (isWrite)
            {
                string filename="";
                switch (flag)
                {
                    case 0: 
                         filename = "AppLog_Err" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                        break;
                    case 1:
                         filename = "AppLog_Info" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                        break;
                    case 2:
                        filename = "AppLog_Warm" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                        break;
                    case 3:
                        filename = "AppLog_WebApi" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                        break;
                    case 4:
                        filename = "AppLog_Spare" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                        break;
                }
                var repository = LogManager.GetRepository();

                #region MyRegion
                var appenders = repository.GetAppenders();
                if (appenders.Length > 0)
                {
                    RollingFileAppender targetApder = null;
                    foreach (var Apder in appenders)
                    {
                        if (Apder.Name == "AppLog")
                        {
                            targetApder = Apder as RollingFileAppender;
                            break;
                        }
                    }
                    if (targetApder.Name == "AppLog")//如果是文件输出类型日志，则更改输出路径
                    {
                        if (targetApder != null)
                        {
                            if (!targetApder.File.Contains(filename))
                            {
                                targetApder.File = @"SysLog\" + filename;
                                targetApder.ActivateOptions();
                            }
                        }
                    }
                }

                #endregion
                action(msg);
                //logComm.Error(msg + "\n");
            }
        }

        public static void WriteError(string msg, bool isWrite)
        {
            WriteLog(msg, isWrite, logComm.Error,0);//错误日志
        }
        public static void WriteInfo(string msg, bool isWrite)
        {
            WriteLog(msg, isWrite, logComm.Info,1);//信息日志
        }
        public static void WriteWarn(string msg, bool isWrite)
        {
            WriteLog(msg, isWrite, logComm.Warn,2);//警告日志          
        }
        public static void WriteWebApi(string msg, bool isWrite)
        {
            WriteLog(msg, isWrite, logComm.Info, 3);//WebAApi日志
        }
        public static void spare(string msg, bool isWrite)//备用日志
        {
            WriteLog(msg, isWrite, logComm.Info, 4);
        }
    }

}
