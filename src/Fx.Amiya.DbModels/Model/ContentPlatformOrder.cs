using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class ContentPlatformOrder
    {
        public string Id { get; set; }
        public int OrderType { get; set; }
        public string ContentPlateformId { get; set; }
        public int? LiveAnchorId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string GoodsId { get; set; }
        /// <summary>
        /// 医院科室id
        /// </summary>
        public string HospitalDepartmentId { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public int? AppointmentHospitalId { get; set; }
        public int OrderStatus { get; set; }
        public decimal? DepositAmount { get; set; }
        public decimal? DealAmount { get; set; }
        public string DealPictureUrl { get; set; }
        public DateTime? DealDate { get; set; }
        public string RepeatOrderPictureUrl { get; set; }
        public string UnDealReason { get; set; }

        /// <summary>
        /// 订单来源（1：面诊卡，2：非面诊卡）
        /// </summary>
        public int? OrderSource { get; set; }

        /// <summary>
        /// 未派单原因
        /// </summary>
        public string UnSendReason { get; set; }
        /// <summary>
        /// 面诊员
        /// </summary>
        public int? ConsultationEmpId { get; set; }

        /// <summary>
        /// 院方接诊人员
        /// </summary>
        public string AcceptConsulting { get; set; }
        /// <summary>
        /// 未成交截图url
        /// </summary>
        public string UnDealPictureUrl { get; set; }
        public string LateProjectStage { get; set; }
        public string ConsultingContent { get; set; }
        public string Remark { get; set; }
        public bool IsToHospital { get; set; }

        public int ToHospitalType { get; set; }

        /// <summary>
        /// 到院时间（最新）
        /// </summary>
        public DateTime? ToHospitalDate { get; set; }
        /// <summary>
        /// 最终成交医院id
        /// </summary>
        public int? LastDealHospitalId { get; set; }
        public int? CheckState { get; set; }

        public decimal? CheckPrice { get; set; }
        public DateTime? CheckDate { get; set; }

        public decimal? SettlePrice{ get; set; }
        public int? CheckBy { get; set; }
        public string CheckRemark { get; set; }

        public int? BelongEmpId { get; set; }
        public bool IsReturnBackPrice { get; set; }

        public decimal? ReturnBackPrice { get; set; }
        public DateTime? ReturnBackDate { get; set; }


        /// <summary>
        /// 三方订单号
        /// </summary>
        public string OtherContentPlatFormOrderId { get; set; }

        public Contentplatform Contentplatform { get; set; }
        public LiveAnchor LiveAnchor { get; set; }
        public AmiyaGoodsDemand AmiyaGoodsDemand { get; set; }
        public HospitalInfo HospitalInfo { get; set; }
        public List<ContentPlatformOrderSend> ContentPlatformOrderSendList { get; set; }

        public List<ContentPlatFormCustomerPicture>CustomerPictureList { get; set; }
    }
}
