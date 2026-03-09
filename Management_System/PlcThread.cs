using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_System
{
    public class PlcThread
    {
        private bool state;
        public PLC_Process pLC = new PLC_Process();
        

        public void PlcThreadmain()
        {
            state = true;
            int i = 0;
            while (true)
            {
                if (i >= 100)
                {
                    pLC.generateQfDown();
                    i = 0;
                    //count++;
                }
                i++;
            }

        }

    }
}

