using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StupMessage
    {
        private string cryatalid;
        private string parentcrystaid;
        private string product;
        private int sectionlength;
        private int measurelength;
        private string resistlv;
        private DateTime creattime;
        private int tomss;
        public string Product
        {
            get { return product; }
            set { product = value; }
        }
        public string Cryatalid
        {
            get { return cryatalid; }
            set { cryatalid = value; }
        }
        public string Parentcrystaid
        {
            get { return parentcrystaid; }
            set { parentcrystaid = value; }
        }
        public int Sectionlength
        {
            get { return sectionlength; }
            set { sectionlength = value; }
        }
        public int Measurelength
        {
            get { return measurelength; }
            set { measurelength = value; }
        }
        public string Resistlv
        {
            get { return resistlv; }
            set { resistlv = value; }
        }
        public DateTime Creattime
        {
            get { return creattime; }
            set { creattime = value; }
        }
        public int Tomss
        {
            get { return tomss; }
            set { tomss = value; }
        }
        public void initStupMessage()
        {
            Cryatalid = "";
            Parentcrystaid = "";
            Product = "";
            Sectionlength = 0;
            measurelength = 0;
            resistlv = "";
            creattime = DateTime.Now;
            tomss = 0;
        }
    }
}
