using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class PMDownReport
    {
        private string crystalid;
        private string product;
        private int sectionlength;
        private string processmachine;
        private string processstarttime;
        private string processendtime;
        private string createtime;
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
        public string Processstarttime
        {
            get { return processstarttime; }
            set { processstarttime = value; }
        }
        public string Processendtime
        {
            get { return processendtime; }
            set { processendtime = value; }
        }
        public string Createtime
        {
            get { return createtime; }
            set { createtime = value; }
        }
        public bool Tomss
        {
            get { return tomss; }
            set { tomss = value; }
        }
        public void initPMDownReport()
        {
            Crystalid = "";
            Product = "";
            Sectionlength = 0;
            Processmachine = "";
            Processstarttime = DateTime.Now.ToString();
            Processendtime = DateTime.Now.ToString();
            Createtime = DateTime.Now.ToString();
            Tomss = false;
        }
    }
}
