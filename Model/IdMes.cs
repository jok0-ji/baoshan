using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class IdMES
    {
        /// <summary>
        /// 晶编
        /// </summary>
        public string Crystalid { get; set; }
        public string TokenKey { get; set; }
        public string PartnerId { get; set; }
        public IdMES()
        {
            TokenKey = "2934da6463d260ec697cea6e8c5d13c0";
            PartnerId = "DuoEnDuo";
        }
    }
}
