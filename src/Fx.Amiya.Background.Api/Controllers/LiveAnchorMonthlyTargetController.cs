﻿using Fx.Amiya.Background.Api.Vo;
using Fx.Amiya.Background.Api.Vo.ExpressInfo;
using Fx.Amiya.Background.Api.Vo.LiveAnchorMonthlyTarget;
using Fx.Amiya.Dto.ExpressManage;
using Fx.Amiya.Dto.LiveAnchorMonthlyTarget;
using Fx.Amiya.IService;
using Fx.Authorization.Attributes;
using Fx.Common;
using Fx.Open.Infrastructure.Web;
using jos_sdk_net.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Controllers
{
    /// <summary>
    /// 主播月度运营目标情况数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class LiveAnchorMonthlyTargetController : ControllerBase
    {
        private ILiveAnchorMonthlyTargetService _liveAnchorMonthlyTargetService;
        private ILiveAnchorDailyTargetService _liveAnchorDailyTargetService;

        /// <summary>
        /// 构造函数
        /// </summary>
        public LiveAnchorMonthlyTargetController(ILiveAnchorMonthlyTargetService liveAnchorMonthlyTargetService, ILiveAnchorDailyTargetService liveAnchorDailyTargetService)
        {
            _liveAnchorMonthlyTargetService = liveAnchorMonthlyTargetService;
            _liveAnchorDailyTargetService = liveAnchorDailyTargetService;
        }

        /// <summary>
        /// 获取主播月度运营目标情况
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="liveAnchorId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<LiveAnchorMonthlyTargetVo>>> GetListWithPageAsync(int year, int month, int? liveAnchorId, int pageNum, int pageSize)
        {
            try
            {
                var q = await _liveAnchorMonthlyTargetService.GetListWithPageAsync(year, month, liveAnchorId, pageNum, pageSize);

                var liveAnchorMonthlyTarget = from d in q.List
                                              select new LiveAnchorMonthlyTargetVo
                                              {
                                                  Id = d.Id,
                                                  Year = d.Year,
                                                  Month = d.Month,
                                                  MonthlyTargetName = d.MonthlyTargetName,
                                                  LiveAnchorId = d.LiveAnchorId,
                                                  LiveAnchorName = d.LiveAnchorName,
                                                  ReleaseTarget = d.ReleaseTarget,
                                                  CumulativeRelease = d.CumulativeRelease,
                                                  ReleaseCompleteRate = d.ReleaseCompleteRate,
                                                  FlowInvestmentTarget = d.FlowInvestmentTarget,
                                                  CumulativeFlowInvestment = d.CumulativeFlowInvestment,
                                                  FlowInvestmentCompleteRate = d.FlowInvestmentCompleteRate,
                                                  LivingRoomCumulativeFlowInvestment = d.LivingRoomCumulativeFlowInvestment,
                                                  LivingRoomFlowInvestmentTarget = d.LivingRoomFlowInvestmentTarget,
                                                  LivingRoomFlowInvestmentCompleteRate = d.LivingRoomFlowInvestmentCompleteRate,
                                                  CluesTarget = d.CluesTarget,
                                                  CumulativeClues = d.CumulativeClues,
                                                  CluesCompleteRate = d.CluesCompleteRate,
                                                  AddFansTarget = d.AddFansTarget,
                                                  CumulativeAddFans = d.CumulativeAddFans,
                                                  AddFansCompleteRate = d.AddFansCompleteRate,
                                                  AddWechatTarget = d.AddWechatTarget,
                                                  CumulativeAddWechat = d.CumulativeAddWechat,
                                                  AddWechatCompleteRate = d.AddWechatCompleteRate,
                                                  ConsultationTarget = d.ConsultationTarget,
                                                  CumulativeConsultation = d.CumulativeConsultation,
                                                  ConsultationCompleteRate = d.ConsultationCompleteRate,
                                                  ConsultationCardConsumedTarget = d.ConsultationCardConsumedTarget,
                                                  CumulativeConsultationCardConsumed = d.CumulativeConsultationCardConsumed,
                                                  ConsultationCardConsumedCompleteRate = d.ConsultationCardConsumedCompleteRate,
                                                  ActivateHistoricalConsultationTarget = d.ActivateHistoricalConsultationTarget,
                                                  CumulativeActivateHistoricalConsultation = d.CumulativeActivateHistoricalConsultation,
                                                  ActivateHistoricalConsultationCompleteRate = d.ActivateHistoricalConsultationCompleteRate,
                                                  SendOrderTarget = d.SendOrderTarget,
                                                  CumulativeSendOrder = d.CumulativeSendOrder,
                                                  SendOrderCompleteRate = d.SendOrderCompleteRate,
                                                  VisitTarget = d.VisitTarget,
                                                  CumulativeVisit = d.CumulativeVisit,
                                                  VisitCompleteRate = d.VisitCompleteRate,
                                                  DealTarget = d.DealTarget,
                                                  CumulativeDealTarget = d.CumulativeDealTarget,
                                                  DealRate = d.DealRate,
                                                  CargoSettlementCommissionTarget = d.CargoSettlementCommissionTarget,
                                                  CumulativeCargoSettlementCommission = d.CumulativeCargoSettlementCommission,
                                                  CargoSettlementCommissionCompleteRate = d.CargoSettlementCommissionCompleteRate,
                                                  PerformanceTarget = d.PerformanceTarget,
                                                  CumulativePerformance = d.CumulativePerformance,
                                                  PerformanceCompleteRate = d.PerformanceCompleteRate,
                                                  MinivanRefundTarget = d.MinivanRefundTarget,
                                                  CumulativeMinivanRefund = d.CumulativeMinivanRefund,
                                                  MinivanRefundCompleteRate = d.MinivanRefundCompleteRate,
                                                  MiniVanBadReviewsTarget = d.MiniVanBadReviewsTarget,
                                                  CumulativeMiniVanBadReviews = d.CumulativeMiniVanBadReviews,
                                                  MiniVanBadReviewsCompleteRate = d.MiniVanBadReviewsCompleteRate,
                                                  CreateDate = d.CreateDate,
                                              };

                FxPageInfo<LiveAnchorMonthlyTargetVo> liveAnchorMonthlyTargetPageInfo = new FxPageInfo<LiveAnchorMonthlyTargetVo>();
                liveAnchorMonthlyTargetPageInfo.TotalCount = q.TotalCount;
                liveAnchorMonthlyTargetPageInfo.List = liveAnchorMonthlyTarget;

                return ResultData<FxPageInfo<LiveAnchorMonthlyTargetVo>>.Success().AddData("liveAnchorMonthlyTargetInfo", liveAnchorMonthlyTargetPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<LiveAnchorMonthlyTargetVo>>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 根据年月获取id和名称（下拉框使用）
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns></returns>
        [HttpGet("getLiveAnchorMonthlyTarget")]
        public async Task<ResultData<List<LiveAnchorMonthlyTargetKeyAndValueVo>>> getExpressList(int year, int month)
        {
            try
            {
                if (year == 0 || month == 0)
                { 
                    throw new Exception("请选择年月后再进行月目标选取！");
                }
                var q = await _liveAnchorMonthlyTargetService.GetIdAndNames(year,month);

                var liveAnchorMonthlyTarget = from d in q
                                              select new LiveAnchorMonthlyTargetKeyAndValueVo
                                              {
                                                  Id = d.Id,
                                                  Name = d.Name
                                              };

                return ResultData<List<LiveAnchorMonthlyTargetKeyAndValueVo>>.Success().AddData("liveAnchorMonthlyTarget", liveAnchorMonthlyTarget.ToList());
            }
            catch (Exception ex)
            {
                return ResultData<List<LiveAnchorMonthlyTargetKeyAndValueVo>>.Fail().AddData("liveAnchorMonthlyTarget", new List<LiveAnchorMonthlyTargetKeyAndValueVo>());
            }
        }


        /// <summary>
        /// 添加主播月度运营目标情况
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddLiveAnchorMonthlyTargetVo addVo)
        {
            try
            {
                AddLiveAnchorMonthlyTargetDto addDto = new AddLiveAnchorMonthlyTargetDto();
                addDto.Year = addVo.Year;
                addDto.Month = addVo.Month;
                addDto.MonthlyTargetName = addVo.MonthlyTargetName;
                addDto.LiveAnchorId = addVo.LiveAnchorId;
                addDto.ReleaseTarget = addVo.ReleaseTarget;
                addDto.FlowInvestmentTarget = addVo.FlowInvestmentTarget;
                addDto.LivingRoomFlowInvestmentTarget = addVo.LivingRoomFlowInvestmentTarget;
                addDto.CluesTarget = addVo.CluesTarget;
                addDto.AddFansTarget = addVo.AddFansTarget;
                addDto.AddWechatTarget = addVo.AddWechatTarget;
                addDto.ConsultationTarget = addVo.ConsultationTarget;
                addDto.ConsultationCardConsumedTarget = addVo.ConsultationCardConsumedTarget;
                addDto.ActivateHistoricalConsultationTarget = addVo.ActivateHistoricalConsultationTarget;
                addDto.SendOrderTarget = addVo.SendOrderTarget;
                addDto.VisitTarget = addVo.VisitTarget;
                addDto.DealTarget = addVo.DealTarget;
                addDto.PerformanceTarget = addVo.PerformanceTarget;
                addDto.MiniVanBadReviewsTarget = addVo.MiniVanBadReviewsTarget;
                addDto.MinivanRefundTarget = addVo.MinivanRefundTarget;
                addDto.CargoSettlementCommissionTarget = addVo.CargoSettlementCommissionTarget;
                await _liveAnchorMonthlyTargetService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据id获取主播月度运营目标情况
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<LiveAnchorMonthlyTargetVo>> GetByIdAsync(string id)
        {
            try
            {
                var liveAnchorMonthlyTarget = await _liveAnchorMonthlyTargetService.GetByIdAsync(id);
                LiveAnchorMonthlyTargetVo liveAnchorMonthlyTargetVo = new LiveAnchorMonthlyTargetVo();
                liveAnchorMonthlyTargetVo.Id = liveAnchorMonthlyTarget.Id;
                liveAnchorMonthlyTargetVo.Year = liveAnchorMonthlyTarget.Year;
                liveAnchorMonthlyTargetVo.Month = liveAnchorMonthlyTarget.Month;
                liveAnchorMonthlyTargetVo.MonthlyTargetName = liveAnchorMonthlyTarget.MonthlyTargetName;
                liveAnchorMonthlyTargetVo.LiveAnchorId = liveAnchorMonthlyTarget.LiveAnchorId;
                liveAnchorMonthlyTargetVo.ContentPlatFormId = liveAnchorMonthlyTarget.ContentPlatFormId;
                liveAnchorMonthlyTargetVo.ReleaseTarget = liveAnchorMonthlyTarget.ReleaseTarget;
                liveAnchorMonthlyTargetVo.CumulativeRelease = liveAnchorMonthlyTarget.CumulativeRelease;
                liveAnchorMonthlyTargetVo.ReleaseCompleteRate = liveAnchorMonthlyTarget.ReleaseCompleteRate;
                liveAnchorMonthlyTargetVo.FlowInvestmentTarget = liveAnchorMonthlyTarget.FlowInvestmentTarget;
                liveAnchorMonthlyTargetVo.CumulativeFlowInvestment = liveAnchorMonthlyTarget.CumulativeFlowInvestment;
                liveAnchorMonthlyTargetVo.FlowInvestmentCompleteRate = liveAnchorMonthlyTarget.FlowInvestmentCompleteRate;
                liveAnchorMonthlyTargetVo.LivingRoomFlowInvestmentTarget = liveAnchorMonthlyTarget.LivingRoomFlowInvestmentTarget;
                liveAnchorMonthlyTargetVo.LivingRoomCumulativeFlowInvestment = liveAnchorMonthlyTarget.LivingRoomCumulativeFlowInvestment;
                liveAnchorMonthlyTargetVo.LivingRoomFlowInvestmentCompleteRate = liveAnchorMonthlyTarget.LivingRoomFlowInvestmentCompleteRate;
                liveAnchorMonthlyTargetVo.CluesTarget = liveAnchorMonthlyTarget.CluesTarget;
                liveAnchorMonthlyTargetVo.CumulativeClues = liveAnchorMonthlyTarget.CumulativeClues;
                liveAnchorMonthlyTargetVo.CluesCompleteRate = liveAnchorMonthlyTarget.CluesCompleteRate;
                liveAnchorMonthlyTargetVo.AddFansTarget = liveAnchorMonthlyTarget.AddFansTarget;
                liveAnchorMonthlyTargetVo.CumulativeAddFans = liveAnchorMonthlyTarget.CumulativeAddFans;
                liveAnchorMonthlyTargetVo.AddFansCompleteRate = liveAnchorMonthlyTarget.AddFansCompleteRate;
                liveAnchorMonthlyTargetVo.AddWechatTarget = liveAnchorMonthlyTarget.AddWechatTarget;
                liveAnchorMonthlyTargetVo.CumulativeAddWechat = liveAnchorMonthlyTarget.CumulativeAddWechat;
                liveAnchorMonthlyTargetVo.AddWechatCompleteRate = liveAnchorMonthlyTarget.AddWechatCompleteRate;
                liveAnchorMonthlyTargetVo.ConsultationTarget = liveAnchorMonthlyTarget.ConsultationTarget;
                liveAnchorMonthlyTargetVo.CumulativeConsultation = liveAnchorMonthlyTarget.CumulativeConsultation;
                liveAnchorMonthlyTargetVo.ConsultationCompleteRate = liveAnchorMonthlyTarget.ConsultationCompleteRate;
                liveAnchorMonthlyTargetVo.ConsultationCardConsumedTarget = liveAnchorMonthlyTarget.ConsultationCardConsumedTarget;
                liveAnchorMonthlyTargetVo.CumulativeConsultationCardConsumed = liveAnchorMonthlyTarget.CumulativeConsultationCardConsumed;
                liveAnchorMonthlyTargetVo.ConsultationCardConsumedCompleteRate = liveAnchorMonthlyTarget.ConsultationCardConsumedCompleteRate;
                liveAnchorMonthlyTargetVo.ActivateHistoricalConsultationTarget = liveAnchorMonthlyTarget.ActivateHistoricalConsultationTarget;
                liveAnchorMonthlyTargetVo.CumulativeActivateHistoricalConsultation = liveAnchorMonthlyTarget.CumulativeActivateHistoricalConsultation;
                liveAnchorMonthlyTargetVo.ActivateHistoricalConsultationCompleteRate = liveAnchorMonthlyTarget.ActivateHistoricalConsultationCompleteRate;
                liveAnchorMonthlyTargetVo.SendOrderTarget = liveAnchorMonthlyTarget.SendOrderTarget;
                liveAnchorMonthlyTargetVo.CumulativeSendOrder = liveAnchorMonthlyTarget.CumulativeSendOrder;
                liveAnchorMonthlyTargetVo.SendOrderCompleteRate = liveAnchorMonthlyTarget.SendOrderCompleteRate;
                liveAnchorMonthlyTargetVo.VisitTarget = liveAnchorMonthlyTarget.VisitTarget;
                liveAnchorMonthlyTargetVo.CumulativeVisit = liveAnchorMonthlyTarget.CumulativeVisit;
                liveAnchorMonthlyTargetVo.VisitCompleteRate = liveAnchorMonthlyTarget.VisitCompleteRate;
                liveAnchorMonthlyTargetVo.DealTarget = liveAnchorMonthlyTarget.DealTarget;
                liveAnchorMonthlyTargetVo.CumulativeDealTarget = liveAnchorMonthlyTarget.CumulativeDealTarget;
                liveAnchorMonthlyTargetVo.DealRate = liveAnchorMonthlyTarget.DealRate;
                liveAnchorMonthlyTargetVo.CargoSettlementCommissionTarget = liveAnchorMonthlyTarget.CargoSettlementCommissionTarget;
                liveAnchorMonthlyTargetVo.CumulativeCargoSettlementCommission = liveAnchorMonthlyTarget.CumulativeCargoSettlementCommission;
                liveAnchorMonthlyTargetVo.CargoSettlementCommissionCompleteRate = liveAnchorMonthlyTarget.CargoSettlementCommissionCompleteRate;
                liveAnchorMonthlyTargetVo.PerformanceTarget = liveAnchorMonthlyTarget.PerformanceTarget;
                liveAnchorMonthlyTargetVo.CumulativePerformance = liveAnchorMonthlyTarget.CumulativePerformance;
                liveAnchorMonthlyTargetVo.PerformanceCompleteRate = liveAnchorMonthlyTarget.PerformanceCompleteRate;
                liveAnchorMonthlyTargetVo.MinivanRefundTarget = liveAnchorMonthlyTarget.MinivanRefundTarget;
                liveAnchorMonthlyTargetVo.CumulativeMinivanRefund = liveAnchorMonthlyTarget.CumulativeMinivanRefund;
                liveAnchorMonthlyTargetVo.MinivanRefundCompleteRate = liveAnchorMonthlyTarget.MinivanRefundCompleteRate;
                liveAnchorMonthlyTargetVo.MiniVanBadReviewsTarget = liveAnchorMonthlyTarget.MiniVanBadReviewsTarget;
                liveAnchorMonthlyTargetVo.CumulativeMiniVanBadReviews = liveAnchorMonthlyTarget.CumulativeMiniVanBadReviews;
                liveAnchorMonthlyTargetVo.MiniVanBadReviewsCompleteRate = liveAnchorMonthlyTarget.MiniVanBadReviewsCompleteRate;
                liveAnchorMonthlyTargetVo.CreateDate = liveAnchorMonthlyTarget.CreateDate;

                return ResultData<LiveAnchorMonthlyTargetVo>.Success().AddData("liveAnchorMonthlyTargetInfo", liveAnchorMonthlyTargetVo);
            }
            catch (Exception ex)
            {
                return ResultData<LiveAnchorMonthlyTargetVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改主播月度运营目标情况
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateLiveAnchorMonthlyTargetVo updateVo)
        {
            try
            {
                UpdateLiveAnchorMonthlyTargetDto updateDto = new UpdateLiveAnchorMonthlyTargetDto();
                updateDto.Id = updateVo.Id;
                updateDto.Year = updateVo.Year;
                updateDto.Month = updateVo.Month;
                updateDto.MonthlyTargetName = updateVo.MonthlyTargetName;
                updateDto.LiveAnchorId = updateVo.LiveAnchorId;
                updateDto.ReleaseTarget = updateVo.ReleaseTarget;
                updateDto.FlowInvestmentTarget = updateVo.FlowInvestmentTarget;
                updateDto.LivingRoomFlowInvestmentTarget = updateVo.LivingRoomFlowInvestmentTarget;
                updateDto.CluesTarget = updateVo.CluesTarget;
                updateDto.AddFansTarget = updateVo.AddFansTarget;
                updateDto.AddWechatTarget = updateVo.AddWechatTarget;
                updateDto.ConsultationTarget = updateVo.ConsultationTarget;
                updateDto.ConsultationCardConsumedTarget = updateVo.ConsultationCardConsumedTarget;
                updateDto.ActivateHistoricalConsultationTarget = updateVo.ActivateHistoricalConsultationTarget;
                updateDto.SendOrderTarget = updateVo.SendOrderTarget;
                updateDto.VisitTarget = updateVo.VisitTarget;
                updateDto.DealTarget = updateVo.DealTarget;
                updateDto.CargoSettlementCommissionTarget = updateVo.CargoSettlementCommissionTarget;
                updateDto.PerformanceTarget = updateVo.PerformanceTarget;
                updateDto.MinivanRefundTarget = updateVo.MinivanRefundTarget;
                updateDto.MiniVanBadReviewsTarget = updateVo.MiniVanBadReviewsTarget;
                await _liveAnchorMonthlyTargetService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除主播月度运营目标情况
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                var dailyTarget = await _liveAnchorDailyTargetService.GetByMonthTargetAsync(id);
                if (!string.IsNullOrEmpty(dailyTarget.Id))
                {
                    throw new Exception("该条数据下已产生相应的日数据，请先删除日数据后再删除该条数据！");
                }
                await _liveAnchorMonthlyTargetService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}