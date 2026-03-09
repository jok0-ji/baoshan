using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class JDFinishReport
    {
        private string crystalid;
        private string product;
        private string sectionlength;
        private string processstarttime;
        private string processmachine;
        private string processendtime;
        private string creattime;
        private short tomss; 

        public string Crystalid { get => crystalid; set => crystalid = value; }
        public string Product { get => product; set => product = value; }
        public string Sectionlength { get => sectionlength; set => sectionlength = value; }
        public string Processstarttime { get => processstarttime; set => processstarttime = value; }
        public string Processmachine { get => processmachine; set => processmachine = value; }
        public string Processendtime { get => processendtime; set => processendtime = value; }
        public string Creattime { get => creattime; set => creattime = value; }
        public short Tomss { get => tomss; set => tomss = value; }
    }
}
