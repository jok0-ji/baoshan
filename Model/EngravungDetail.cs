using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EngravungDetail
    {
       private string crystalid;
       private string product;
       private int sectionlength;
       private DateTime createtime;
       private bool tomss;
        public string Crystalid
        {
            get { return crystalid; }
            set { crystalid = value; }
        }
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
        public DateTime Createtime
        {
            get { return createtime; }
            set { createtime = value; }
        }
        public bool Tomss
        {
            get { return tomss; }
            set { tomss = value; }
        }
        public void initEngravungDetail()
        {
            Crystalid = "";
            Product = "";
            sectionlength = 0;
            Createtime = DateTime.Now;
            Tomss = false;
    }

    }
}
