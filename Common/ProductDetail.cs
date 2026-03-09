using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 圆棒表的表名，各个字段名
    /// </summary>
   public class ProductDetail
    {
        public readonly string table_name= "ProductDetail";
        public readonly string crystalid = "CrystalId";
        public readonly string parentcrystaid = "ParentCrystaId";
        public readonly string product = "Product";
        public readonly string sectionlength = "SectionLength";
        public readonly string measurelength = "MeasureLength";
        public readonly string resistlv = "ResistLv";
        public readonly string createtime = "CreateTime";
        public readonly string tomss = "Tomss";
    }
}
