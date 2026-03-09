using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Spec
    {
  
       private string product;//产品规格
       private int formulatrunc;//规格代码
        private int formulasqure;
        private int formulapolisher;
        public string Product
        {
            get { return product; }
            set { product = value; }
        }
        public int Formulatrunc
        {
            get { return formulatrunc; }
            set { formulatrunc = value; }
        }
        public int Formulasqure
        {
            get { return formulasqure; }
            set { formulasqure = value; }
        }
        public int Formulapolisher
        {
            get { return formulapolisher; }
            set { formulapolisher = value; }
        }
    }
}
