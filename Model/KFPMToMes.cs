using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{//单独的开方MES
    public class KFPMToMes
    {
        /// <summary>
        /// 
        /// </summary>
        public string TokenKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PartnerId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TimeSpan{ get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CrystalId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MachienNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Operator { get; set; }
        public string Moid { get; set; }

       

        public KFPMToMes()
        {
            Operator = "DuoEnDuo";
              Moid = null;
            TokenKey = "2934da6463d260ec697cea6e8c5d13c0";
            PartnerId = "DuoEnDuo";
            TimeSpan = "15564812345";
        }
    }
}
