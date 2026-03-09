using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class PMUpReport
    {
        private string crystalid;
        private string product;
        private int sectionlength;
        private string processmachine;
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
        public string Processmachine
        {
            get { return processmachine; }
            set { processmachine = value; }
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
        public PMUpReport()
        {
            crystalid = "";
            product = "";
            sectionlength = 0;
            processmachine = "";
            createtime = DateTime.Now;
            tomss = false;
        }
        public void initPMUpReport()
        {
            Crystalid = "";
            Product = "";
            Sectionlength = 0;
            Processmachine = "";
            Createtime = DateTime.Now;
            Tomss = false;
        }

    }
}
