using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model
{
    
    public class QFDownReport
    {
        private string Code;//*
        private string Flight;//*
        private string MacShop;//*
        private string Spec;//*
        private string MacID;//*
        private int RepairMark;//*
        private int Length;//*
        private double CalWeight;
        private float WireCost;//线耗*
        private float WireLeft;//线余量
        private int WireBreakTimes;//*
        private string macTMID;//加工台面
        private int width1;//边距1
        private int width2;//边距2
        public DateTime beginTime;
        public DateTime endTime;

        public string MacTMID { get => macTMID; set => MacTMID = value; }
        public int Width1 { get => width1; set => width1 = value; }
        public int Width2 { get => width2; set => width2 = value; }
        public string Code1 { get => Code; set => Code = value; }
        public string Flight1 { get => Flight; set => Flight = value; }
        public string MacShop1 { get => MacShop; set => MacShop = value; }
        public string Spec1 { get => Spec; set => Spec = value; }
        public string MacID1 { get => MacID; set => MacID = value; }
        public int RepairMark1 { get => RepairMark; set => RepairMark = value; }
        public int Length1 { get => Length; set => Length = value; }
        public double CalWeight1 { get => CalWeight; set => CalWeight = value; }
        public float WireCost1 { get => WireCost; set => WireCost = value; }
        public float WireLeft1 { get => WireLeft; set => WireLeft = value; }
        public int WireBreakTimes1 { get => WireBreakTimes; set => WireBreakTimes = value; }
    }
}
