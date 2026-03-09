using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class LongStupMessage
    {
        private string crystalid;
        private string product;
        private string resistlv;
        private int crystalleng;
        private int underlineunm;
        private int[] sectionlength;
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
        public string Resistlv
        {
            get { return resistlv; }
            set { resistlv = value; }
        }
        public int Crystalleng
        {
            get { return crystalleng; }
            set { crystalleng = value; }
        }
        public int Underlineunm
        {
            get { return underlineunm; }
            set { underlineunm = value; }
        }
        public bool Tomss
        {
            get { return tomss; }
            set { tomss = value; }
        }
        public int[] Sectionlength
        {
            get { return sectionlength; }
            set { sectionlength = value; }
        }
        public LongStupMessage()
        {
            underlineunm = 0;
            sectionlength = new int[10];
            for (int i = 0; i < 10; i++)
            {
                sectionlength[i] = 0;
            }
            tomss = false;
        }
        public void initLongStepMessage()
        {
            Underlineunm = 0;
            for (int i = 0; i < 10; i++)
            {
                Sectionlength[i] = 0;
            }
            Tomss = false;
        }

    }
}
