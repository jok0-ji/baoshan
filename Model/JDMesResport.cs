using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class JDMesResport
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
        public string IpAdress{ get; set; }
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
        public string LenthArray { get; set; }
        public string Operator { get; set; }
        
        public JDMesResport()
        {
            // IpAdress = "172.21.1.25";
            Operator = "DuoEnDuo";

        IpAdress = null;
            TokenKey = "2934da6463d260ec697cea6e8c5d13c0";
            PartnerId = "DuoEnDuo";
           // Runer = "DuoEnDuo";
        }
    }
}
