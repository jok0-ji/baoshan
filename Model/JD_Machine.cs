namespace Model
{
    public class JD_Machine
    {
        private int online;//联机/脱机
        private int state;//正在加工/待机
        private string[] code;//正在加工晶体精编
        private int[] length;//
        private int spec;//规格代码
        private string machine_ID;//机台号
        private short id;
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
        public string[] Code
        {
            get { return code; }
            set { code = value; }
        }
        public int[] Length
        {
            get { return length; }
            set { length = value; }
        }
        public int Spec
        {
            get { return spec; }
            set { spec = value; }
        }
        public string Machine_ID
        {
            get { return machine_ID; }
            set { machine_ID = value; }
        }

        public short Id { get => id; set => id = value; }

        public JD_Machine()
        {
            online = 0;
            state = 0;
            code = new string[2];
            code[0] = "";
            code[1] = "";
            length = new int[2];
            length[0] = 0;
            length[1] = 0;
            spec = 0;
            Machine_ID = "";
        }
        public void initJDMachine()
        {
            online = 0;//联机/脱机
            state = 0;//正在加工/待机
            code[0] = "";//正在加工晶体精编
            code[1] = "";
            length[0] = 0;//
            length[1] = 0;
            spec = 0;//规格代码
            machine_ID = "";//机台号            
        }


    }
}
