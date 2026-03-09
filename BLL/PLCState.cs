using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PLCState
    {
        private Communicat communicate;
        private address Address;
        private PcToMes pcToMes;
        private int count = 0;
        public PLCState()
        {
            communicate = new Communicat();
            Address = new address();
            pcToMes = new PcToMes();
        }
        public bool plcIsOpen()
        {

            if (communicate.plcIfOpen() == 0)
                return true;
            else
                return false;
        }
        public bool cl()

        {
            communicate.plcClose();

            return true;
        }
        //用于存放一些过站的方法
       
        

    }
}
   

