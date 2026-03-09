using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    static class ExtendedInt
    {
        public static bool GetBit(this short value, byte bit)
        {
            return (value & (1 << bit)) != 0;
        }
    }
}
