using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SurfaceChecked
    {
        private string crystalid;
        private int checkeresult;
        private string checkereason;
        private bool tomss;
        private DateTime createtime;
        public DateTime Createtime
        {
            get { return createtime; }
            set { createtime = value; }
        }
        public string Crystalid
        {
            get { return crystalid; }
            set { crystalid = value; }
        }
        public int Checkeresult
        {
            get { return checkeresult; }
            set { checkeresult = value; }
        }
        public string Checkereason
        {
            get { return checkereason; }
            set { checkereason = value; }
        }
        public bool Tomss
        {
            get { return tomss; }
            set { tomss = value; }
        }
        public void initSurfaceChecked()
        {
            Crystalid = "";
            Checkeresult = ' ';
            Checkereason = "";
            Tomss = false;
        }
    }
}
