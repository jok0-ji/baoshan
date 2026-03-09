using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class SignalFeed
    {
       
       private string product;
       private int sectionlength;
       private int engravingiednt;
       private DateTime createtime;
       private bool tomss;

      public string Crystalid { get; set;}
        public string Product
        {
            get { return product; }
            set { product = value; }
        }
        public int Sectionlength
        {
            get { return sectionlength; }
            set { sectionlength = value; }
        }
        public int Engravingiednt
        {
            get { return engravingiednt; }
            set { engravingiednt = value; }
        }
        public DateTime Createtime
        {
            get { return Createtime; }
            set { Createtime = value; }
        }
        public bool Tomss
        {
            get { return tomss; }
            set { tomss = value; }
        }

    }
}
