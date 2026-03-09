using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WayOxygenResult//获取分选通道与氧结果
    {
        /// <summary>
        /// 晶编
        /// </summary>
        //public string CrystalId { get; set; }
        /// <summary>
        /// 产品规格
        /// </summary>
       // public string Product { get; set; }
        /// <summary>
        /// 氧结果
        /// </summary>
        public short ResultData { get; set; }
        /// <summary>
        /// 分选通道结果
        /// </summary>
        //public short Way { get; set; }
        /// <summary>
        /// MES应答信号
        /// </summary>
        public int AckCode { get; set; }
        /// <summary>
        /// 如果有错误MES会返回错误信息
        /// </summary>
        public string Message { get; set; }
    }
}
