using Fx.Amiya.Background.Api.Vo.ContentPlateFormOrder;
using Fx.Amiya.Background.Api.Vo.ContentPlatFormOrderSend;
using Fx.Amiya.Dto.ContentPlateFormOrder;
using Fx.Amiya.Dto.ContentPlatFormOrderSend;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using Jd.Api.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 派单API
    /// </summary>

    [Route("[controller]")]
    [ApiController]
    public class ContentPlateFormSendOrderController : ControllerBase
    {

        private IHttpContextAccessor _httpContextAccessor;
        private IContentPlatformOrderSendService _sendOrderInfoService;
        private IHospitalInfoService hospitalInfoService;
        private IContentPlatFormOrderDealInfoService orderDealInfoService;
        public ContentPlateFormSendOrderController(IContentPlatformOrderSendService sendOrderInfoService,
            IContentPlatFormOrderDealInfoService orderDealInfoService,
            IHospitalInfoService hospitalInfoService,
            IHttpContextAccessor httpContextAccessor)
        {
            this._sendOrderInfoService = sendOrderInfoService;
            this.hospitalInfoService = hospitalInfoService;
            this.orderDealInfoService = orderDealInfoService;
            _httpContextAccessor = httpContextAccessor;
        }








        /// <summary>
        /// 根据编号获取简单的派单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("simpleById/{id}")]
        [FxInternalAuthorize]
        public async Task<ResultData<ContentPlatFormSendOrderInfoSimpleVo>> GetSimpleByIdAsync(int id)
        {
            var sendOrderInfo = await _sendOrderInfoService.GetSimpleByIdAsync(id);
            ContentPlatFormSendOrderInfoSimpleVo sendOrderInfoSimpleVo = new ContentPlatFormSendOrderInfoSimpleVo();
            sendOrderInfoSimpleVo.Id = sendOrderInfo.Id;
            sendOrderInfoSimpleVo.HospitalId = sendOrderInfo.HospitalId;
            sendOrderInfoSimpleVo.IsUncertainDate = sendOrderInfo.IsUncertainDate;
            sendOrderInfoSimpleVo.AppointmentDate = sendOrderInfo.AppointmentDate;
            sendOrderInfoSimpleVo.IsUncertainDate = sendOrderInfo.IsUncertainDate;

            return ResultData<ContentPlatFormSendOrderInfoSimpleVo>.Success().AddData("sendOrderInfo", sendOrderInfoSimpleVo);
        }


        /// <summary>
        /// 医院获取派单信息
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="startDate"></param>
        /// <param name="IsToHospital">是否到院， -1查询全部</param>
        /// <param name="toHospitalStartDate">到院时间起</param>
        /// <param name="toHospitalEndDate">到院时间止</param>           
        /// <param name="toHospitalType">到院类型</param>        
        /// <param name="endDate"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listOfHospital")]
        [FxTenantAuthorize]
        public async Task<ResultData<FxPageInfo<ContentPlatFormOrderSendInfoVo>>> GetListByHospitalIdAsync(string keyword, DateTime? startDate, DateTime? endDate, int IsToHospital, DateTime? toHospitalStartDate, DateTime? toHospitalEndDate, int? toHospitalType, int pageNum, int pageSize)
        {
            var employee = _httpContextAccessor.HttpContext.User as FxAmiyaHospitalEmployeeIdentity;
            int hospitalId = employee.HospitalId;
            var q = await _sendOrderInfoService.GetListByHospitalIdAsync(hospitalId, keyword, startDate, endDate, IsToHospital, toHospitalStartDate, toHospitalEndDate, toHospitalType, pageNum, pageSize);
            var sendOrder = from d in q.List
                            select new ContentPlatFormOrderSendInfoVo
                            {
                                Id = d.Id,
                                OrderId = d.OrderId,
                                CustomerName = d.CustomerName,
                                HospitalName = d.HospitalName,
                                SendDate = d.SendDate,
                                IsUncertainDate = d.IsUncertainDate,
                                AppointmentDate = d.AppointmentDate,
                                DepositAmount = d.DepositAmount,
                                DealAmount = d.DealAmount,
                                LateProjectStage = d.LateProjectStage,
                                GoodsName = d.GoodsName,
                                ThumbPicUrl = d.ThumbPicUrl,
                                OrderStatus = d.OrderStatus,
                                Phone = d.Phone,
                                EncryptPhone = d.EncryptPhone,
                                DealPictureUrl = d.DealPictureUrl,
                                RepeateOrderPictureUrl = d.RepeateOrderPictureUrl,
                                UnDealReason = d.UnDealReason,
                                IsHospitalCheckPhone = d.IsHospitalCheckPhone,
                                ConsultingContent = d.ConsultingContent,
                                OrderRemark = d.OrderRemark,
                                SendOrderRemark = d.SendOrderRemark,
                                HospitalRemark = d.HospitalRemark,
                                UnDealPictureUrl = d.UnDealPictureUrl,
                                OrderSourceText = d.OrderSourceText,
                                LiveAnchor=d.LiveAnchor,
                                AcceptConsulting = d.AcceptConsulting,
                                CheckState=d.CheckState,
                            };

            FxPageInfo<ContentPlatFormOrderSendInfoVo> sendOrderPageInfo = new FxPageInfo<ContentPlatFormOrderSendInfoVo>();
            sendOrderPageInfo.TotalCount = q.TotalCount;
            sendOrderPageInfo.List = sendOrder;
            return ResultData<FxPageInfo<ContentPlatFormOrderSendInfoVo>>.Success().AddData("sendOrderInfo", sendOrderPageInfo);
        }

        /// <summary>
        /// 医院导出(内容平台)派单信息
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet("exportOfContentPlatFormHospital")]
        [FxTenantAuthorize]
        public async Task<FileStreamResult> ExportListByHospitalIdAsync(string keyword, DateTime? startDate, DateTime? endDate)
        {
            var employee = _httpContextAccessor.HttpContext.User as FxAmiyaHospitalEmployeeIdentity;
            int hospitalId = employee.HospitalId;
            var q = await _sendOrderInfoService.GetContentPlatFormHospitalOrderReportAsync(startDate, endDate, hospitalId, false);
            var sendOrder = from d in q
                            select new ExportContentPlatFormSendOrderInfoVo
                            {
                                OrderId = d.OrderId,
                                SendDate = d.SendDate,
                                Phone = d.EncryptPhone,
                                CustomerName = d.CustomerName,
                                GoodsName = d.GoodsName,
                                ConsultingContent = d.ConsultingContent,
                                AppointmentDate = d.AppointmentDate,
                                OrderStatusText = d.OrderStatusText,
                                DepositAmount = d.DepositAmount,
                                DealAmount = d.DealAmount,
                                UnDealReason = d.UnDealReason,
                                LateProjectStage = d.LateProjectStage,
                                OrderRemark = d.OrderRemark,
                                SendOrderRemark = d.SendOrderRemark,
                                HospitalRemark = d.HospitalRemark,
                                OrderSourceText = d.OrderSourceText,
                                AcceptConsulting = d.AcceptConsulting
                            };

            var exportSendOrder = sendOrder.ToList();
            var stream = ExportExcelHelper.ExportExcel(exportSendOrder);
            var result = File(stream, "application/vnd.ms-excel", $"" + startDate.Value.ToString("yyyy年MM月dd日") + "-" + endDate.Value.ToString("yyyy年MM月dd日") + "内容平台派单报表.xls");
            return result;
        }


        /// <summary>
        /// 医院获取派单未处理信息条数
        /// </summary>
        /// <returns></returns>
        [HttpGet("getNotRepeatedSendOrder")]
        [FxTenantAuthorize]
        public async Task<ResultData<int>> GetNotRepeatedSendOrderAsync()
        {
            var employee = _httpContextAccessor.HttpContext.User as FxAmiyaHospitalEmployeeIdentity;
            int hospitalId = employee.HospitalId;
            var q = await _sendOrderInfoService.GetCountByHospitalIdAsync(hospitalId);
            return ResultData<int>.Success().AddData("NotRepeatedSendOrder", q);
        }


      

        /// <summary>
        /// 医院填写备注
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut("contentPlateFormOrderRemark")]
        [FxTenantAuthorize]
        public async Task<ResultData> RemarkOrderAsync(ContentPlatFormOrderRemarkVo input)
        {
            ContentPlatFormOrderRemarkDto updateDto = new ContentPlatFormOrderRemarkDto();
            updateDto.HospitalRemark = input.HospitalRemark;
            updateDto.SendOrderId = input.SendOrderId;
            await _sendOrderInfoService.UpdateOrderHospitalRemarkAsync(updateDto);
            return ResultData.Success();
        }

        /// <summary>
        /// 获取内容平台订单已派单信息列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="employeeId"> -1(归属客服)查询全部</param>
        /// <param name="sendBy"> 派单人（空查询全部）</param>
        /// <param name="liveAnchorId">归属主播ID</param>
        /// <param name="orderStatus">订单状态</param>
        /// <param name="contentPlatFormId">内容平台id</param>
        /// <param name="startDate"></param>
        /// <param name="consultationEmpId">面诊员id</param>
        /// <param name="endDate"></param>        
        /// <param name="hospitalId"></param>        
        /// <param name="IsToHospital">是否到院， -1查询全部</param>
        /// <param name="toHospitalStartDate">到院时间起</param>
        /// <param name="toHospitalEndDate">到院时间止</param>           
        /// <param name="toHospitalType">到院类型</param>        
        /// <param name="orderSource">订单来源， -1查询全部</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<SendContentPlatformOrderVo>>> GetSendOrderList(string keyword, int?liveAnchorId ,int? consultationEmpId,int? employeeId, int? sendBy, int? orderStatus , string contentPlatFormId, DateTime? startDate, DateTime? endDate, int? hospitalId,int IsToHospital, DateTime? toHospitalStartDate, DateTime? toHospitalEndDate,int? toHospitalType, int orderSource,int pageNum, int pageSize)
        {
            if (employeeId == null)
            {
                var employee = _httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                employeeId = Convert.ToInt32(employee.Id);
            }
            var orders = await _sendOrderInfoService.GetSendOrderList(liveAnchorId,consultationEmpId,sendBy,keyword, (int)employeeId, orderStatus, contentPlatFormId, startDate, endDate, hospitalId, IsToHospital,toHospitalStartDate,toHospitalEndDate,toHospitalType, orderSource,pageNum, pageSize);

            var contentPlatformOrders = from d in orders.List
                                        select new SendContentPlatformOrderVo
                                        {
                                            Id = d.Id,
                                            OrderId = d.OrderId,
                                            ContentPlatFormName = d.ContentPlatFormName,
                                            LiveAnchorName = d.LiveAnchorName,
                                            CustomerName = d.CustomerName,
                                            Phone = d.Phone,
                                            EncryptPhone = d.EncryptPhone,
                                            SendHospitalId = d.SendHospitalId,
                                            IsHospitalCheckPhone = d.IsHospitalCheckPhone,
                                            AppointmentHospital = d.AppointmentHospital,
                                            AppointmentDate = d.AppointmentDate,
                                            GoodsName = d.GoodsName,
                                            ThumbPictureUrl = d.ThumbPictureUrl,
                                            LateProjectStage = d.LateProjectStage,
                                            OrderTypeText = d.OrderTypeText,
                                            OrderStatusText = d.OrderStatusText,
                                            DepositAmount = d.DepositAmount,
                                            DealAmount = d.DealAmount,
                                            DealPictureUrl = d.DealPictureUrl,
                                            IsToHospital = d.IsToHospital,
                                            ToHospitalTypeText=d.ToHospitalTypeText,
                                            ToHospitalDate = d.ToHospitalDate,
                                            UnDealReason = d.UnDealReason,
                                            Sender = d.Sender,
                                            SenderName = d.SenderName,
                                            SendDate = d.SendDate,
                                            SendHospital = d.SendHospital,
                                            DealDate = d.DealDate,
                                            SendOrderRemark = d.SendOrderRemark,
                                            OrderRemark = d.OrderRemark,
                                            ConsultingContent = d.ConsultingContent,
                                            HospitalRemark = d.HospitalRemark,
                                            UnDealPictureUrl = d.UnDealPictureUrl,
                                            AcceptConsulting = d.AcceptConsulting,
                                            OrderSourceText = d.OrderSourceText,
                                            ConsultationEmpName = d.ConsultationEmpName,
                                            CheckState=d.CheckState,
                                            OtherContentPlatFormOrderId=d.OtherContentPlatFormOrderId,
                                        };
            FxPageInfo<SendContentPlatformOrderVo> pageInfo = new FxPageInfo<SendContentPlatformOrderVo>();
            pageInfo.TotalCount = orders.TotalCount;
            pageInfo.List = contentPlatformOrders;
            return ResultData<FxPageInfo<SendContentPlatformOrderVo>>.Success().AddData("sendOrders", pageInfo);
        }

        /// <summary>
        /// 获取订单成交情况
        /// </summary>
        /// <param name="contentPlatFormOrderId">订单号</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("contentPlatFormOrderDealInfo")]
        [FxInternalAuthorize]
        public async Task<ResultData<FxPageInfo<ContentPlatFormOrderDealInfoVo>>> GetDealInfo(string contentPlatFormOrderId, int pageNum, int pageSize)
        {

            var result = await orderDealInfoService.GetListWithPageAsync(contentPlatFormOrderId, pageNum, pageSize);

            var contentPlatformOrders = from d in result.List
                                        select new ContentPlatFormOrderDealInfoVo
                                        {
                                            Id = d.Id,
                                            ContentPlatFormOrderId = d.ContentPlatFormOrderId,
                                            CreateDate = d.CreateDate,
                                            IsDeal = d.IsDeal,
                                            IsToHospital = d.IsToHospital,
                                            ToHospitalType = d.ToHospitalType,
                                            ToHospitalTypeText = d.ToHospitalTypeText,
                                            TohospitalDate = d.ToHospitalDate,
                                            DealHospital = d.LastDealHospital,
                                            DealPicture = d.DealPicture,
                                            Remark = d.Remark,
                                            Price = d.Price,
                                            OtherOrderId = d.OtherAppOrderId,
                                            DealDate = d.DealDate,
                                        };
            FxPageInfo<ContentPlatFormOrderDealInfoVo> pageInfo = new FxPageInfo<ContentPlatFormOrderDealInfoVo>();
            pageInfo.TotalCount = result.TotalCount;
            pageInfo.List = contentPlatformOrders;
            return ResultData<FxPageInfo<ContentPlatFormOrderDealInfoVo>>.Success().AddData("contentPlatFormOrderDealInfo", pageInfo);
        }


        /// <summary>
        /// 医院端获取订单成交情况
        /// </summary>
        /// <param name="contentPlatFormOrderId">订单号</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("hospitalContentPlatFormOrderDealInfo")]
        [FxTenantAuthorize]
        public async Task<ResultData<FxPageInfo<ContentPlatFormOrderDealInfoVo>>> GetHospitalDealInfo(string contentPlatFormOrderId, int pageNum, int pageSize)
        {

            var result = await orderDealInfoService.GetListWithPageAsync(contentPlatFormOrderId, pageNum, pageSize);

            var contentPlatformOrders = from d in result.List
                                        select new ContentPlatFormOrderDealInfoVo
                                        {
                                            Id = d.Id,
                                            ContentPlatFormOrderId = d.ContentPlatFormOrderId,
                                            CreateDate = d.CreateDate,
                                            IsDeal = d.IsDeal,
                                            TohospitalDate = d.ToHospitalDate,
                                            DealHospital = d.LastDealHospital,
                                            IsToHospital = d.IsToHospital,
                                            ToHospitalType=d.ToHospitalType,
                                            ToHospitalTypeText=d.ToHospitalTypeText,
                                            DealPicture = d.DealPicture,
                                            Remark = d.Remark,
                                            Price = d.Price,
                                            DealDate=d.DealDate,
                                        };
            FxPageInfo<ContentPlatFormOrderDealInfoVo> pageInfo = new FxPageInfo<ContentPlatFormOrderDealInfoVo>();
            pageInfo.TotalCount = result.TotalCount;
            pageInfo.List = contentPlatformOrders;
            return ResultData<FxPageInfo<ContentPlatFormOrderDealInfoVo>>.Success().AddData("contentPlatFormOrderDealInfo", pageInfo);
        }
    }
}
