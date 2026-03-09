using DAT;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL
{
    class PcToMes
    {
        private JDMesResport jdmes;
        private KFPMToMes kftomes;
        private GmMES pmtomes;
        private SurToMes surToMes;
        private SpliceDetailToMes spliceDetailToMes;
        private QFDntoMes qfdntoMes;
        private SQLString sqlstr;
        private WebServerHelp webServer = new WebServerHelp();

        //给MES发送消息
        public PcToMes()
        {
            //构造函数里面，读取配置文件中接口的地址
            jdmes = new JDMesResport();
            kftomes = new KFPMToMes();
            pmtomes = new GmMES();
            sqlstr = new SQLString();
            surToMes = new SurToMes();
            spliceDetailToMes = new SpliceDetailToMes();
            qfdntoMes = new QFDntoMes();
        }
        public void QFDN_MES()//将截断完工表发给mes
        {

        }

        public void JD_MES()//将截断完工棒子发送至MES过账
        {
            //到数据库中查询TOMSS为DBNULL
            SqlDataReader sdr=null;
            string jsonresult="";
            try
            {
                sdr = DataBase.SelectForReader(sqlstr.selectTomss("REPORTTRUNCFINISHED"));
                sdr.Read();
                while (sdr.HasRows)//查询到了内容
                {
                    jdmes.CrystalId = sdr["CRYSTALID"].ToString();
                    jdmes.MachienNum = sdr["PROCESSMACHINE"].ToString();
                   // jdmes.Operator = sdr["PRODUCT"].ToString();
                    jdmes.LenthArray= sdr["SECTIONLENGTH"].ToString();
              
                    string json = JsonConvert.SerializeObject(jdmes).Replace("\\u0000", "");//序列化对象
                    AppLog.WriteWebApi(string.Format("截断的json:{0}+{1}",json,Url.JdUrl) ,true);//将WebApi返回结果放到日志文件中
                    if (webServer.Post(Url.JdUrl,json,"", ref jsonresult))//成功发送给MES，但是不需要管MES回复了什么，只要有发送，有回复就行
                    {
                        setTomss("REPORTTRUNCFINISHED", jdmes.CrystalId, "true");
                        AppLog.WriteWebApi(string.Format("截断的MES结果为{0}", jsonresult), true);

                    }
                    else//出现异常，并没有得到MES的回复，可能丢包或者什么的
                    {
                        setTomss("REPORTTRUNCFINISHED", jdmes.CrystalId, "false");
                    }
                    //  AppLog.WriteWebApi(json, true);//将WebApi返回结果放到日志文件中
                    sdr.Read();
                }
                
            }
            catch (Exception ex)
            {
                AppLog.WriteWebApi(string.Format("截断晶棒上传MES失败：{0}", ex), true);
            }
            finally
            {
                if (sdr != null)
                    if (sdr.IsClosed)
                        sdr.Close();
            }

        }
        //public void KF_MES()//将开方完成的棒子发送至MES
        //{
        //    //到数据库中查询TOMSS为DBNULL
        //    SqlDataReader sdr = null;
        //    string jsonresult = "";
        //    try
        //    {
        //        sdr = DataBase.SelectForReader(sqlstr.selectTomss("REPORTSQUREFINISHED"));
        //        sdr.Read();
               
        //        while (sdr.HasRows)//查询到了内容
        //        {
        //            kftomes.CrystalId = sdr["CRYSTALID"].ToString();
        //            kftomes.MachienNum = sdr["PROCESSMACHINE"].ToString();
        //           // kftomes.Operator = sdr["PRODUCT"].ToString();


        //            string json = JsonConvert.SerializeObject(kftomes).Replace("\\u0000","");//序列化对象
        //            AppLog.WriteWebApi(string.Format("开方的MES过站json为：{0},{1}",json, Url.DpUrl), true);//将WebApi返回结果放到日志文件中,方便之后观察
        //            if (webServer.Post(Url.DpUrl, json, "",ref jsonresult))//成功发送给MES，但是不需要管MES回复了什么，只要有发送，有回复就行
        //            {
        //                setTomss("REPORTSQUREFINISHED", kftomes.CrystalId, "true");
        //                AppLog.WriteWebApi(string.Format("开方的MES结果为{0}", jsonresult), true); //将MES的回复写入到日志文件中
        //            }
        //            else//出现异常，并没有得到MES的回复，可能丢包或者什么的
        //            {
        //                setTomss("REPORTSQUREFINISHED", kftomes.CrystalId, "false");
        //            }
        //           // AppLog.WriteInfo("开方过站4", true);// AppLog.WriteWebApi(json, true);//将WebApi返回结果放到日志文件中,方便之后观察
        //            sdr.Read();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        AppLog.WriteWebApi(string.Format("开方晶棒上传MES失败：{0}", ex), true);
        //    }
        //    finally
        //    {
        //        if (sdr != null)
        //            if (sdr.IsClosed)
        //                sdr.Close();
        //    }

        //}
        //public void PM_MES()//抛光完成棒子发送至MES
        //{
        //    //到数据库中查询TOMSS为DBNULL
        //    SqlDataReader sdr = null;
        //    string jsonresult = "";
        //    try
        //    {
        //        sdr = DataBase.SelectForReader(sqlstr.selectTomss("REPORTPOLISHERFINISHED"));
        //        sdr.Read();
        //        while (sdr.HasRows)//查询到了内容
        //        {
        //            pmtomes.CrystalId = sdr["CRYSTALID"].ToString();
        //            pmtomes.MachienNum = sdr["PROCESSMACHINE"].ToString();
        //            pmtomes.Operator = sdr["PRODUCT"].ToString();
        //           // pmtomes.Length = sdr["SECTIONLENGTH"].ToString();
        //            // kftomes.leng = sdr["SECTIONLENGTH"].ToString();
        //            string json = JsonConvert.SerializeObject(pmtomes).Replace("\\u0000", "");//序列化对象
        //            AppLog.WriteWebApi(json, true);//将WebApi返回结果放到日志文件中
        //            if (webServer.Post(Url.GmUrl, json, "", ref jsonresult))//成功发送给MES，但是不需要管MES回复了什么，只要有发送，有回复就行
        //            {
        //                setTomss("REPORTPOLISHERFINISHED", pmtomes.CrystalId, "true");
        //                //将MES的回复写入到日志文件中
        //                AppLog.WriteWebApi(string.Format("抛光的MES结果为{0}",jsonresult), true);
        //            }
        //            else//出现异常，并没有得到MES的回复，可能丢包或者什么的
        //                setTomss("REPORTPOLISHERFINISHED", pmtomes.CrystalId, "false");
                   
        //            sdr.Read();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        AppLog.WriteWebApi(string.Format("抛光晶棒上传MES失败：{0}", ex), true);
        //    }
        //    finally
        //    {
        //        if (sdr != null)
        //            if (sdr.IsClosed)
        //                sdr.Close();
        //    }
        //}
        //public void SUR_MES()//将外观检测的棒子发送至MES
        //{
        //    SqlDataReader sdr = null;
        //    string jsonresult = "";
        //    try
        //    {
        //        sdr = DataBase.SelectForReader(sqlstr.selectTomss("SURFACECHECKED"));
        //        sdr.Read();
        //        while (sdr.HasRows)//查询到了内容
        //        {
        //            surToMes.LotSn = sdr["CRYSTALID"].ToString();
        //            surToMes.NgMessage = sdr["CHECKEREASON"].ToString();
        //            surToMes.IsNg = Convert.ToInt16(sdr["CHECKERESULT"]);
                        
        //           surToMes.CheckTime = (DateTime)sdr["CREATETIME"];
        //            string json = JsonConvert.SerializeObject(surToMes).Replace("\\u0000", "");//序列化对象
        //            AppLog.WriteWebApi(json, true);//将WebApi返回结果放到日志文件中
        //            if (webServer.Post(Url.SurUrl, json, "", ref jsonresult))//成功发送给MES，但是不需要管MES回复了什么，只要有发送，有回复就行
        //            {
        //                setTomss("SURFACECHECKED", surToMes.LotSn, "true");
        //                AppLog.WriteWebApi(string.Format("外观检测的MES结果为{0}", jsonresult), true); //将MES的回复写入到日志文件中
        //            }
        //            else//出现异常，并没有得到MES的回复，可能丢包或者什么的
        //                setTomss("SURFACECHECKED", surToMes.LotSn, "false");
                    
        //            sdr.Read();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        AppLog.WriteWebApi(string.Format("外观检测信息上传MES失败：{0}", ex), true);
        //    }
        //    finally
        //    {
        //        if (sdr != null)
        //            if (sdr.IsClosed)
        //                sdr.Close();
        //    }
        //}
        //public void Joint_MES()//将拼棒成功的棒子发送给MES
        //{
        //    SqlDataReader sdr = null;
        //    string jsonresult = "";
        //    try
        //    {
        //        sdr = DataBase.SelectForReader(sqlstr.selectTomss("SPLICEDETAIL"));
        //        sdr.Read();
        //        while (sdr.HasRows)//查询到了内容
        //        {
        //            spliceDetailToMes.CrystalId1 = sdr["CRYSTALID_1"].ToString();
        //            spliceDetailToMes.CrystalId2 = sdr["CRYSTALID_2"].ToString();
        //            spliceDetailToMes.SectionLength_1 = (int)sdr["SECTIONLENGTH_1"];
        //            spliceDetailToMes.SectionLength_2 = (int)sdr["SECTIONLENGTH_1"];
        //            spliceDetailToMes.Product1 = sdr["PRODUCT_1"].ToString();
        //            spliceDetailToMes.Product2 = sdr["PRODUCT_1"].ToString();
        //            spliceDetailToMes.SpliceTime = (DateTime)sdr["CREATETIME"];
        //            string json = JsonConvert.SerializeObject(spliceDetailToMes).Replace("\\u0000", "");//序列化对象
        //            AppLog.WriteWebApi(json, true);//将WebApi返回结果放到日志文件中
        //            if (webServer.Post(Url.SpliceuUrl, json, "", ref jsonresult))//成功发送给MES，但是不需要管MES回复了什么，只要有发送，有回复就行
        //            {
        //                setTomss("SPLICEDETAIL", spliceDetailToMes.CrystalId1, "true");
        //                AppLog.WriteWebApi(string.Format("拼棒成功的MES结果为{0}", jsonresult), true);//将MES的回复写入到日志文件中
        //            }
        //            else//出现异常，并没有得到MES的回复，可能丢包或者什么的
        //                setTomss("SPLICEDETAIL", surToMes.LotSn, "false");
        //            sdr.Read();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        AppLog.WriteWebApi(string.Format("拼棒上传MES失败：{0}",ex), true);
        //    }
        //    finally
        //    {
        //        if (sdr != null)
        //            if (sdr.IsClosed)
        //                sdr.Close();
        //    }
        //}
        public void setTomss(string tablename,string stupid, string tomss)//更新tomss
        {
            try
            {
                DataBase.Update(sqlstr.updateTomss(tablename, "Tomss", tomss, "CrystalId", stupid));
            }
            catch (Exception ex)
            {
                AppLog.WriteError(string.Format("短棒{0}更新tomss异常，异常信息{1}", stupid, ex), true);
            }
        }
        public void messageToMes()
        {
            //int count = 20;//一次最多发送四十次数据
            //int singleFinishToMessendcount = 2;
            //int singlesurToMessendcount = 2;
            //int surToMesQueueqcount;
            //int finishToMesQueueqcount;
            //lock (PLC_Process._locker)
            //     surToMesQueueqcount = PLC_Process.surToMesQueueq.Count;
            //lock (PLC_Process._locker)
            //    finishToMesQueueqcount = PLC_Process.finishToMesQueueq.Count;
            //while ((finishToMesQueueqcount != 0 || surToMesQueueqcount != 0)&&count>20)//两个队列不为0， 
            //{
            //    count--;
            //    if (surToMesQueueqcount != 0)
            //    {
            //        //将外观检测结果发送给MES
            //        string jaonstring = PLC_Process.surToMesQueueq.Peek();
            //        if (finishSurToMes(jaonstring))//发送成功则队列出队
            //        {
            //            lock (PLC_Process._locker)
            //                PLC_Process.surToMesQueueq.Dequeue();
            //            surToMesQueueqcount--;//成功出队了，则队列中的数值要减1.
            //            singlesurToMessendcount = 2;//如果有第一次发送失败，但是第二次发送成功了，则将标志位置2
            //        }
            //        else//发送失败则不出队，将重新发送，但是最多重新发送两次
            //            singleFinishToMessendcount--;
            //        if (singleFinishToMessendcount == 0)//已经重新发送两次了，强制出队
            //        {
            //            lock (PLC_Process._locker)
            //                PLC_Process.surToMesQueueq.Dequeue();
            //            surToMesQueueqcount--;//成功出队了，则队列中的数值要减1.
            //            singlesurToMessendcount = 2;
            //        }
            //    }
            //    if (finishToMesQueueqcount != 0)
            //    {
            //        //将加工完晶棒信息发送给MES
            //        string jaonstring = PLC_Process.finishToMesQueueq.Peek();
            //        if (finishStupToMes(jaonstring))//发送成功则队列出队
            //        {
            //            lock (PLC_Process._locker)
            //                PLC_Process.finishToMesQueueq.Dequeue();
            //            finishToMesQueueqcount--;//成功出队了，则队列中的数值要减1.
            //            singleFinishToMessendcount = 2;//如果有第一次发送失败，但是第二次发送成功了，则将标志位置2
            //        }
            //        else//发送失败则不出队，将重新发送，但是最多重新发送两次
            //            singleFinishToMessendcount--;
            //        if (singleFinishToMessendcount == 0)//已经重新发送两次了，强制出队
            //        {
            //            lock (PLC_Process._locker)
            //                PLC_Process.finishToMesQueueq.Dequeue();
            //            finishToMesQueueqcount--;//成功出队了，则队列中的数值要减1.
            //            singleFinishToMessendcount = 2;
            //        }
            //    }
            //    lock (PLC_Process._locker)
            //        surToMesQueueqcount = PLC_Process.surToMesQueueq.Count;;
            //}
        }
        //public bool finishStupToMes(string jsonstring)
        //{
        //    var jDMesResport = JsonConvert.DeserializeObject<JDMesResport>(jsonstring);
        //    string jsonresult = "";
        //    try
        //    {
        //        if (webServer.Post(Url.JdUrl, jsonstring, "", ref jsonresult))//成功发送给MES，但是不需要管MES回复了什么，只要有发送，有回复就行
        //        {
        //            AppLog.WriteInfo(string.Format("finishStupToMes的JSON的返回结果为{0}", jsonresult), true);
        //            setTomss("SURFACECHECKED", surToMes.CrystalId, "true");
        //            将MES的回复写入到日志文件中
        //            AppLog.WriteWebApi(string.Format("{0}通过{1}发送MES成功,返回代码:{2}", jDMesResport.CrystalId, Url.JdUrl, jsonresult), true);
        //            return true;
        //        }
        //        else
        //        {
        //            AppLog.WriteWebApi(string.Format("{0}通过{1}发送MES失败,失败原因:{2}", jDMesResport.CrystalId, Url.JdUrl, jsonresult), true);
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        AppLog.WriteWebApi(string.Format("{0}通过{1}发送MES失败,失败原因:{2}", jDMesResport.CrystalId, Url.JdUrl, ex), true);
        //        return false;
        //    }
        //}
        //public bool finishSurToMes(string jsonstring)
        //{
        //    var surToMes = JsonConvert.DeserializeObject<SurToMes>(jsonstring);
        //    string jsonresult = "";
        //    try
        //    {
        //        if (webServer.Post(Url.SurUrl, jsonstring, "", ref jsonresult))//成功发送给MES，但是不需要管MES回复了什么，只要有发送，有回复就行
        //        {
        //            AppLog.WriteInfo(string.Format("finishSurToMes的JSON的返回结果为{0}", jsonresult), true);
        //            AppLog.WriteWebApi(string.Format("{0}通过{1}发送MES成功,返回代码:{2}", surToMes.LotSn, Url.SurUrl, jsonresult), true);
        //            return true;
        //        }
        //        else
        //        {
        //            AppLog.WriteWebApi(string.Format("{0}通过{1}发送MES失败,失败原因:{2}", surToMes.LotSn, Url.SurUrl, jsonresult), true);
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        AppLog.WriteWebApi(string.Format("{0}通过{1}发送MES失败,失败原因:{2}", surToMes.LotSn, Url.SurUrl, ex), true);
        //        return false;
        //    }
        //}


    }
}
