using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class QFDntoMes
    {
        public string Create_Time { get; set; }
        public int Receive_Tag  { get; set; }
        public string Crystal_Number { get; set; }
        public string Flight { get; set; }

        public string Macshop { get; set; }
        public string Statu { get; set; }
        public float Length_Butt { get; set; }
        public string Part_Number { get; set; }
        public int Init_Line { get; set; }
        public int End_Line_Loss { get; set; }
        public int Consumption { get; set; }
        public int Bolt_Number { get; set; }
        public string Equipment { get; set; }

        //'%s', %d, '%s', '%s', '%s', '%s', %f, '%s', %d, %d, %d, %d, '%s')",
        //L"PART_NUMBER, INIT_LINE_LOSS, END_LINE_LOSS, CONSUMPTION, BOLT_NUMBER, EQUIPMENT

        public QFDntoMes()
        {

        }
    }
}
