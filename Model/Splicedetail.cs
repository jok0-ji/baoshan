using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Splicedetail
    {
        private string crystalid_1;
        private string crystalid_2;
        private int sectionlength_1;
        private int sectionlength_2;
        private string product_1;
        private string product_2;
        private string unspliced;
        private string createtime;
        private bool tomss;
        public string Crystalid_1
        {
            get { return crystalid_1; }
            set { crystalid_1 = value; }
        }
        public string Crystalid_2
        {
            get { return crystalid_2; }
            set { crystalid_2 = value; }
        }
        public int Sectionlength_1
        {
            get { return sectionlength_1; }
            set { sectionlength_1 = value; }
        }
        public int Sectionlength_2
        {
            get { return sectionlength_2; }
            set { sectionlength_2 = value; }
        }
        public string Product_1
        {
            get { return product_1; }
            set { product_1 = value; }
        }
        public string Product_2
        {
            get { return product_2; }
            set { product_2 = value; }
        }
        public string Unspliced
        {
            get { return unspliced; }
            set { unspliced = value; }
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
        public void initSplicedetail()
        {
            Crystalid_1 = "";
            Crystalid_2 = "";
            Sectionlength_1 = 0;
            Sectionlength_2 = 0;
            Product_1 = "";
            Product_2 = "";
            Unspliced = "";
            Createtime = "";
            Tomss = false;
        }
    }
}
