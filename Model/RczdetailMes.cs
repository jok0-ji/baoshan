using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RczdetailMes//从MES获取圆棒表实体类
    {
        /// <summary>
        /// 晶编
        /// </summary>
        public string ProductLevel { get; set; }
        /// <summary>
        /// 产品规格
        /// </summary>
        public string NuType { get; set; }
        /// <summary>
        /// 电阻性能
        /// </summary>
        public string SurplusRate { get; set; }
        /// <summary>
        /// 长度
        /// </summary>
        public string ProductParentName { get; set; }
        public string LotLenth { get; set; }
        /// <summary>
        /// 如果有错误MES会返回错误信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 应答
        /// </summary>
        public int AckCode { get; set; }
        public string ResultData { get; set; }

    }
}
