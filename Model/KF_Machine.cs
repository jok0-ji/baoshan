using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class KF_Machine
    {
        private int online;//联机/脱机
        private  int state;//正在加工/待机
        private string code;//正在加工晶体精编
        private int length;//
        private int spec;//规格代码
        private string machine_id;//机台号
        private int id;
        public KF_Machine()
        {
            online = 0;
            state = 0;
            code = "";
            length = 0;
            spec = 0;
            machine_id = "";
        }
        public void initKF_Machine()
        {
            Online = 0;
            State = 0;
            Code = "";
            Length = 0;
            Spec = 0;
            Machine_id = "";
        }
        public int Online
        {
            get { return online; }
            set { online = value; }
        }
        public int State
        {
            get { return state; }
            set { state = value; }
        }
        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        public int Length
        {
            get { return length; }
            set { length = value; }
        }
        public int Spec
        {
            get { return spec; }
            set { spec = value; }
        }
        public string Machine_id
        {
            get { return machine_id; }
            set { machine_id = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
