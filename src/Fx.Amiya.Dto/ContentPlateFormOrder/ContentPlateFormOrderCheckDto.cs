using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ContentPlateFormOrder
{
    public class ContentPlateFormOrderCheckDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int CheckState { get; set; }
        /// <summary>
        /// 审核金额
        /// </summary>

        public decimal CheckPrice { get; set; }
        /// <summary>
        /// 结算金额
        /// </summary>

        public decimal SettlePrice { get; set; }

        /// <summary>
        /// 审核人员
        /// </summary>
        public int employeeId { get; set; }
        /// <summary>
        /// 审核信息
        /// </summary>
        public string CheckRemark { get; set; }

        /// <summary>
        /// 审核图片
        /// </summary>
        public List<string> CheckPicture { get; set; }

    }
}
