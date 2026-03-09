using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SurToMes
    {
        //外观检测结果发送至MES
        public string TokenKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PartnerId { get; set; }
        /// <summary>
        /// 
        /// </summary>
       public int IsNg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LotSn{ get; set; }//晶编
        public string NgMessage{ get; set; }//外观检测结果
        public DateTime CheckTime{ get; set; }
        public SurToMes()
        {
            TokenKey = "2934da6463d260ec697cea6e8c5d13c0";
            PartnerId = "DuoEnDuo";
            //Runer = "DuoEnDuo";
        }
    }
}
