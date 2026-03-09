using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAT
{
    public class WebServerHelp
    {
        public  bool Post(string Url, string Data, string Referer, ref string retString)
        {
           
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            //request.Method = "POST";
            //request.Referer = Referer;
            //byte[] bytes = Encoding.UTF8.GetBytes(Data);
           // request.ContentType = "application/x-www-form-urlencoded";//在发送到服务器之前，所有字符都会进行编码。
                                                                      //application/json
          //  request.ContentLength = bytes.Length;
           // request.Timeout = 1000;
           request.Method = "POST";
            request.Referer = Referer;
            request.UserAgent = "Mozilla/3.0 (compatible; Indy Library)";
           byte[] bytes = Encoding.UTF8.GetBytes(Data);
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.ContentType = "application/json";//在发送到服务器之前，所有字符都会进行编码
                                                     //application/json
           request.ContentLength = bytes.Length;
            request.Timeout = 3000;
            request.ReadWriteTimeout = 3000;
            request.ContinueTimeout = 3000;
            HttpWebResponse response = null;
            Stream myResponseStream = null;
            StreamReader myStreamReader = null;
            try
            {
                myResponseStream = request.GetRequestStream();
                myResponseStream.Write(bytes, 0, bytes.Length);

                response = (HttpWebResponse)request.GetResponse();
                if (response != null)
                {
                    myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    retString = myStreamReader.ReadToEnd();//获取结果
                    return true;
                }
                else
                    return false;
            }
            catch(Exception ex)
            {
               
                return false;
                throw;
            }
            finally
            {
                if(myStreamReader!=null)
                myStreamReader.Close();
                if(myResponseStream!=null)
                myResponseStream.Close();
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
        }
    }
}
