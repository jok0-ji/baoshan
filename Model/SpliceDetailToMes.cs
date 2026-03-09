using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SpliceDetailToMes
    {
        public string TokenKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PartnerId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TimeSpan { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CrystalId1 { get; set; }
        public string CrystalId2 { get; set; }
        public int SectionLength_1 { get; set; }
        public int SectionLength_2 { get; set; }
        public string Product1 { get; set; }
        public string Product2 { get; set; }
        public DateTime SpliceTime { get; set; }

        public SpliceDetailToMes()
        {
            TokenKey = "2934da6463d260ec697cea6e8c5d13c0";
            PartnerId = "DuoEnDuo";
            TimeSpan = "15564812345";
        }
    }
}
