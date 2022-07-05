﻿using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.LiveAnchorMonthlyTarget;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Fx.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class LiveAnchorMonthlyTargetService : ILiveAnchorMonthlyTargetService
    {
        private IDalLiveAnchorMonthlyTarget dalLiveAnchorMonthlyTarget;
        private ILiveAnchorService _liveanchorService;

        public LiveAnchorMonthlyTargetService(IDalLiveAnchorMonthlyTarget dalLiveAnchorMonthlyTarget,
            ILiveAnchorService liveAnchorService)
        {
            this.dalLiveAnchorMonthlyTarget = dalLiveAnchorMonthlyTarget;
            _liveanchorService = liveAnchorService;
        }



        public async Task<FxPageInfo<LiveAnchorMonthlyTargetDto>> GetListWithPageAsync(int Year, int Month, int? LiveAnchorId, int pageNum, int pageSize)
        {
            try
            {
                var liveAnchorMonthlyTarget = from d in dalLiveAnchorMonthlyTarget.GetAll()
                                              where (d.Year == Year) && (d.Month == Month) && (LiveAnchorId.HasValue == false || d.LiveAnchorId == LiveAnchorId)
                                              select new LiveAnchorMonthlyTargetDto
                                              {
                                                  Id = d.Id,
                                                  Year = d.Year,
                                                  Month = d.Month,
                                                  MonthlyTargetName = d.MonthlyTargetName,
                                                  LiveAnchorId = d.LiveAnchorId,
                                                  ReleaseTarget = d.ReleaseTarget,
                                                  CumulativeRelease = d.CumulativeRelease,
                                                  ReleaseCompleteRate = d.ReleaseCompleteRate,
                                                  FlowInvestmentTarget = d.FlowInvestmentTarget,
                                                  CumulativeFlowInvestment = d.CumulativeFlowInvestment,
                                                  FlowInvestmentCompleteRate = d.FlowInvestmentCompleteRate,
                                                  LivingRoomCumulativeFlowInvestment = d.LivingRoomCumulativeFlowInvestment,
                                                  LivingRoomFlowInvestmentTarget = d.LivingRoomFlowInvestmentTarget,
                                                  LivingRoomFlowInvestmentCompleteRate = d.LivingRoomFlowInvestmentCompleteRate,
                                                  AddWechatTarget = d.AddWechatTarget,
                                                  CumulativeAddWechat = d.CumulativeAddWechat,
                                                  CluesTarget = d.CluesTarget,
                                                  CumulativeClues = d.CumulativeClues,
                                                  CluesCompleteRate = d.CluesCompleteRate,
                                                  AddFansTarget = d.AddFansTarget,
                                                  CumulativeAddFans = d.CumulativeAddFans,
                                                  AddFansCompleteRate = d.AddFansCompleteRate,
                                                  AddWechatCompleteRate = d.AddWechatCompleteRate,
                                                  ConsultationTarget = d.ConsultationTarget,
                                                  ConsultationCompleteRate = d.ConsultationCompleteRate,
                                                  CumulativeConsultation = d.CumulativeConsultation,
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

                FxPageInfo<LiveAnchorMonthlyTargetDto> liveAnchorMonthlyTargetPageInfo = new FxPageInfo<LiveAnchorMonthlyTargetDto>();
                liveAnchorMonthlyTargetPageInfo.TotalCount = await liveAnchorMonthlyTarget.CountAsync();
                liveAnchorMonthlyTargetPageInfo.List = await liveAnchorMonthlyTarget.OrderByDescending(x => x.CreateDate).Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
                foreach (var x in liveAnchorMonthlyTargetPageInfo.List)
                {
                    var liveAnchor = await _liveanchorService.GetByIdAsync(x.LiveAnchorId);
                    x.LiveAnchorName = liveAnchor.Name.ToString();
                }
                return liveAnchorMonthlyTargetPageInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task AddAsync(AddLiveAnchorMonthlyTargetDto addDto)
        {
            try
            {
                LiveAnchorMonthlyTarget liveAnchorMonthlyTarget = new LiveAnchorMonthlyTarget();
                liveAnchorMonthlyTarget.Id = Guid.NewGuid().ToString();
                liveAnchorMonthlyTarget.Year = addDto.Year;
                liveAnchorMonthlyTarget.Month = addDto.Month;
                liveAnchorMonthlyTarget.MonthlyTargetName = addDto.MonthlyTargetName;
                liveAnchorMonthlyTarget.LiveAnchorId = addDto.LiveAnchorId;
                liveAnchorMonthlyTarget.ReleaseTarget = addDto.ReleaseTarget;
                liveAnchorMonthlyTarget.CumulativeRelease = 0;
                liveAnchorMonthlyTarget.ReleaseCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.FlowInvestmentTarget = addDto.FlowInvestmentTarget;
                liveAnchorMonthlyTarget.CumulativeFlowInvestment = 0;
                liveAnchorMonthlyTarget.FlowInvestmentCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.LivingRoomFlowInvestmentTarget = addDto.LivingRoomFlowInvestmentTarget;
                liveAnchorMonthlyTarget.LivingRoomCumulativeFlowInvestment = 0;
                liveAnchorMonthlyTarget.LivingRoomFlowInvestmentCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.CluesTarget = addDto.CluesTarget;
                liveAnchorMonthlyTarget.CumulativeClues = 0;
                liveAnchorMonthlyTarget.CluesCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.AddFansTarget = addDto.AddFansTarget;
                liveAnchorMonthlyTarget.CumulativeAddFans = 0;
                liveAnchorMonthlyTarget.AddFansCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.AddWechatTarget = addDto.AddWechatTarget;
                liveAnchorMonthlyTarget.CumulativeAddWechat = 0;
                liveAnchorMonthlyTarget.AddWechatCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.ConsultationTarget = addDto.ConsultationTarget;
                liveAnchorMonthlyTarget.CumulativeConsultation = 0;
                liveAnchorMonthlyTarget.ConsultationCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.ConsultationCardConsumedTarget = addDto.ConsultationCardConsumedTarget;
                liveAnchorMonthlyTarget.CumulativeConsultationCardConsumed = 0;
                liveAnchorMonthlyTarget.ConsultationCardConsumedCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.ActivateHistoricalConsultationTarget = addDto.ActivateHistoricalConsultationTarget;
                liveAnchorMonthlyTarget.CumulativeActivateHistoricalConsultation = 0;
                liveAnchorMonthlyTarget.ActivateHistoricalConsultationCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.SendOrderTarget = addDto.SendOrderTarget;
                liveAnchorMonthlyTarget.CumulativeSendOrder = 0;
                liveAnchorMonthlyTarget.SendOrderCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.VisitTarget = addDto.VisitTarget;
                liveAnchorMonthlyTarget.CumulativeVisit = 0;
                liveAnchorMonthlyTarget.VisitCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.DealTarget = addDto.DealTarget;
                liveAnchorMonthlyTarget.CumulativeDealTarget = 0;
                liveAnchorMonthlyTarget.DealRate = 0.00M;
                liveAnchorMonthlyTarget.CargoSettlementCommissionTarget = addDto.PerformanceTarget;
                liveAnchorMonthlyTarget.CumulativeCargoSettlementCommission = 0.00M;
                liveAnchorMonthlyTarget.CargoSettlementCommissionCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.PerformanceTarget = addDto.PerformanceTarget;
                liveAnchorMonthlyTarget.CumulativePerformance = 0.00M;
                liveAnchorMonthlyTarget.PerformanceCompleteRate = 0.00M;

                liveAnchorMonthlyTarget.MinivanRefundTarget = addDto.MinivanRefundTarget;
                liveAnchorMonthlyTarget.CumulativeMinivanRefund = 0;
                liveAnchorMonthlyTarget.MinivanRefundCompleteRate = 0.00M;

                liveAnchorMonthlyTarget.MiniVanBadReviewsTarget = addDto.MiniVanBadReviewsTarget;
                liveAnchorMonthlyTarget.CumulativeMiniVanBadReviews = 0;
                liveAnchorMonthlyTarget.MiniVanBadReviewsCompleteRate = 0.00M;
                liveAnchorMonthlyTarget.CreateDate = DateTime.Now;

                await dalLiveAnchorMonthlyTarget.AddAsync(liveAnchorMonthlyTarget, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<LiveAnchorMonthlyTargetKeyAndValueDto>> GetIdAndNames(int year, int month)
        {
            try
            {
                var liveAnchorMonthlyTarget = from d in dalLiveAnchorMonthlyTarget.GetAll()
                                              where (d.Year == year && d.Month == month)
                                              select new LiveAnchorMonthlyTargetKeyAndValueDto
                                              {
                                                  Id = d.Id,
                                                  Name = d.MonthlyTargetName
                                              };
                return liveAnchorMonthlyTarget.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<LiveAnchorMonthlyTargetDto> GetByIdAsync(string id)
        {
            try
            {
                var liveAnchorMonthlyTarget = await dalLiveAnchorMonthlyTarget.GetAll().SingleOrDefaultAsync(e => e.Id == id);
                if (liveAnchorMonthlyTarget == null)
                {
                    throw new Exception("主播月度运营目标情况编号错误！");
                }

                LiveAnchorMonthlyTargetDto liveAnchorMonthlyTargetDto = new LiveAnchorMonthlyTargetDto();
                liveAnchorMonthlyTargetDto.Id = liveAnchorMonthlyTarget.Id;
                liveAnchorMonthlyTargetDto.Year = liveAnchorMonthlyTarget.Year;
                liveAnchorMonthlyTargetDto.Month = liveAnchorMonthlyTarget.Month;
                liveAnchorMonthlyTargetDto.MonthlyTargetName = liveAnchorMonthlyTarget.MonthlyTargetName;
                liveAnchorMonthlyTargetDto.LiveAnchorId = liveAnchorMonthlyTarget.LiveAnchorId;
                liveAnchorMonthlyTargetDto.ReleaseTarget = liveAnchorMonthlyTarget.ReleaseTarget;
                liveAnchorMonthlyTargetDto.CumulativeRelease = liveAnchorMonthlyTarget.CumulativeRelease;
                liveAnchorMonthlyTargetDto.ReleaseCompleteRate = liveAnchorMonthlyTarget.ReleaseCompleteRate;
                liveAnchorMonthlyTargetDto.FlowInvestmentTarget = liveAnchorMonthlyTarget.FlowInvestmentTarget;
                liveAnchorMonthlyTargetDto.CumulativeFlowInvestment = liveAnchorMonthlyTarget.CumulativeFlowInvestment;
                liveAnchorMonthlyTargetDto.FlowInvestmentCompleteRate = liveAnchorMonthlyTarget.FlowInvestmentCompleteRate;
                liveAnchorMonthlyTargetDto.LivingRoomCumulativeFlowInvestment = liveAnchorMonthlyTarget.LivingRoomCumulativeFlowInvestment;
                liveAnchorMonthlyTargetDto.LivingRoomFlowInvestmentTarget = liveAnchorMonthlyTarget.LivingRoomFlowInvestmentTarget;
                liveAnchorMonthlyTargetDto.LivingRoomFlowInvestmentCompleteRate = liveAnchorMonthlyTarget.LivingRoomFlowInvestmentCompleteRate;
                liveAnchorMonthlyTargetDto.CluesTarget = liveAnchorMonthlyTarget.CluesTarget;
                liveAnchorMonthlyTargetDto.CumulativeClues = liveAnchorMonthlyTarget.CumulativeClues;
                liveAnchorMonthlyTargetDto.CluesCompleteRate = liveAnchorMonthlyTarget.CluesCompleteRate;
                liveAnchorMonthlyTargetDto.AddFansTarget = liveAnchorMonthlyTarget.AddFansTarget;
                liveAnchorMonthlyTargetDto.CumulativeAddFans = liveAnchorMonthlyTarget.CumulativeAddFans;
                liveAnchorMonthlyTargetDto.AddFansCompleteRate = liveAnchorMonthlyTarget.AddFansCompleteRate;
                liveAnchorMonthlyTargetDto.AddWechatTarget = liveAnchorMonthlyTarget.AddWechatTarget;
                liveAnchorMonthlyTargetDto.CumulativeAddWechat = liveAnchorMonthlyTarget.CumulativeAddWechat;
                liveAnchorMonthlyTargetDto.AddWechatCompleteRate = liveAnchorMonthlyTarget.AddWechatCompleteRate;
                liveAnchorMonthlyTargetDto.ConsultationTarget = liveAnchorMonthlyTarget.ConsultationTarget;
                liveAnchorMonthlyTargetDto.ConsultationCompleteRate = liveAnchorMonthlyTarget.ConsultationCompleteRate;
                liveAnchorMonthlyTargetDto.CumulativeConsultation = liveAnchorMonthlyTarget.CumulativeConsultation;
                liveAnchorMonthlyTargetDto.ConsultationCardConsumedTarget = liveAnchorMonthlyTarget.ConsultationCardConsumedTarget;
                liveAnchorMonthlyTargetDto.CumulativeConsultationCardConsumed = liveAnchorMonthlyTarget.CumulativeConsultationCardConsumed;
                liveAnchorMonthlyTargetDto.ConsultationCardConsumedCompleteRate = liveAnchorMonthlyTarget.ConsultationCardConsumedCompleteRate;
                liveAnchorMonthlyTargetDto.ActivateHistoricalConsultationTarget = liveAnchorMonthlyTarget.ActivateHistoricalConsultationTarget;
                liveAnchorMonthlyTargetDto.CumulativeActivateHistoricalConsultation = liveAnchorMonthlyTarget.CumulativeActivateHistoricalConsultation;
                liveAnchorMonthlyTargetDto.ActivateHistoricalConsultationCompleteRate = liveAnchorMonthlyTarget.ActivateHistoricalConsultationCompleteRate;
                liveAnchorMonthlyTargetDto.SendOrderTarget = liveAnchorMonthlyTarget.SendOrderTarget;
                liveAnchorMonthlyTargetDto.CumulativeSendOrder = liveAnchorMonthlyTarget.CumulativeSendOrder;
                liveAnchorMonthlyTargetDto.SendOrderCompleteRate = liveAnchorMonthlyTarget.SendOrderCompleteRate;
                liveAnchorMonthlyTargetDto.VisitTarget = liveAnchorMonthlyTarget.VisitTarget;
                liveAnchorMonthlyTargetDto.CumulativeVisit = liveAnchorMonthlyTarget.CumulativeVisit;
                liveAnchorMonthlyTargetDto.VisitCompleteRate = liveAnchorMonthlyTarget.VisitCompleteRate;
                liveAnchorMonthlyTargetDto.DealTarget = liveAnchorMonthlyTarget.DealTarget;
                liveAnchorMonthlyTargetDto.CumulativeDealTarget = liveAnchorMonthlyTarget.CumulativeDealTarget;
                liveAnchorMonthlyTargetDto.DealRate = liveAnchorMonthlyTarget.DealRate;
                liveAnchorMonthlyTargetDto.CargoSettlementCommissionTarget = liveAnchorMonthlyTarget.CargoSettlementCommissionTarget;
                liveAnchorMonthlyTargetDto.CumulativeCargoSettlementCommission = liveAnchorMonthlyTarget.CumulativeCargoSettlementCommission;
                liveAnchorMonthlyTargetDto.CargoSettlementCommissionCompleteRate = liveAnchorMonthlyTarget.CargoSettlementCommissionCompleteRate;
                liveAnchorMonthlyTargetDto.PerformanceTarget = liveAnchorMonthlyTarget.PerformanceTarget;
                liveAnchorMonthlyTargetDto.CumulativePerformance = liveAnchorMonthlyTarget.CumulativePerformance;
                liveAnchorMonthlyTargetDto.PerformanceCompleteRate = liveAnchorMonthlyTarget.PerformanceCompleteRate;
                liveAnchorMonthlyTargetDto.MinivanRefundTarget = liveAnchorMonthlyTarget.MinivanRefundTarget;
                liveAnchorMonthlyTargetDto.CumulativeMinivanRefund = liveAnchorMonthlyTarget.CumulativeMinivanRefund;
                liveAnchorMonthlyTargetDto.MinivanRefundCompleteRate = liveAnchorMonthlyTarget.MinivanRefundCompleteRate;
                liveAnchorMonthlyTargetDto.MiniVanBadReviewsTarget = liveAnchorMonthlyTarget.MiniVanBadReviewsTarget;
                liveAnchorMonthlyTargetDto.CumulativeMiniVanBadReviews = liveAnchorMonthlyTarget.CumulativeMiniVanBadReviews;
                liveAnchorMonthlyTargetDto.MiniVanBadReviewsCompleteRate = liveAnchorMonthlyTarget.MiniVanBadReviewsCompleteRate;
                liveAnchorMonthlyTargetDto.CreateDate = liveAnchorMonthlyTarget.CreateDate;
                var liveAnchor = await _liveanchorService.GetByIdAsync(liveAnchorMonthlyTargetDto.LiveAnchorId);
                liveAnchorMonthlyTargetDto.ContentPlatFormId = liveAnchor.ContentPlateFormId;
                return liveAnchorMonthlyTargetDto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateAsync(UpdateLiveAnchorMonthlyTargetDto updateDto)
        {
            try
            {
                var liveAnchorMonthlyTarget = await dalLiveAnchorMonthlyTarget.GetAll().SingleOrDefaultAsync(e => e.Id == updateDto.Id);
                if (liveAnchorMonthlyTarget == null)
                    throw new Exception("主播月度运营目标情况编号错误！");

                liveAnchorMonthlyTarget.Year = updateDto.Year;
                liveAnchorMonthlyTarget.Month = updateDto.Month;
                liveAnchorMonthlyTarget.MonthlyTargetName = updateDto.MonthlyTargetName;
                liveAnchorMonthlyTarget.LiveAnchorId = updateDto.LiveAnchorId;
                liveAnchorMonthlyTarget.ReleaseTarget = updateDto.ReleaseTarget;
                liveAnchorMonthlyTarget.FlowInvestmentTarget = updateDto.FlowInvestmentTarget;
                liveAnchorMonthlyTarget.LivingRoomFlowInvestmentTarget = updateDto.LivingRoomFlowInvestmentTarget;
                liveAnchorMonthlyTarget.CluesTarget = updateDto.CluesTarget;
                liveAnchorMonthlyTarget.AddFansTarget = updateDto.AddFansTarget;
                liveAnchorMonthlyTarget.AddWechatTarget = updateDto.AddWechatTarget;
                liveAnchorMonthlyTarget.ConsultationTarget = updateDto.ConsultationTarget;
                liveAnchorMonthlyTarget.ConsultationCardConsumedTarget = updateDto.ConsultationCardConsumedTarget;
                liveAnchorMonthlyTarget.ActivateHistoricalConsultationTarget = updateDto.ActivateHistoricalConsultationTarget;
                liveAnchorMonthlyTarget.SendOrderTarget = updateDto.SendOrderTarget;
                liveAnchorMonthlyTarget.VisitTarget = updateDto.VisitTarget;
                liveAnchorMonthlyTarget.DealTarget = updateDto.DealTarget;
                liveAnchorMonthlyTarget.CargoSettlementCommissionTarget = updateDto.CargoSettlementCommissionTarget;
                liveAnchorMonthlyTarget.MinivanRefundTarget = updateDto.MinivanRefundTarget;
                liveAnchorMonthlyTarget.MiniVanBadReviewsTarget = updateDto.MiniVanBadReviewsTarget;
                liveAnchorMonthlyTarget.PerformanceTarget = updateDto.PerformanceTarget;
                await dalLiveAnchorMonthlyTarget.UpdateAsync(liveAnchorMonthlyTarget, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 更新每日数据时调用并且添加累计信息
        /// </summary>
        /// <param name="editDto"></param>
        /// <returns></returns>
        public async Task EditAsync(UpdateLiveAnchorMonthlyTargetRateAndNumDto editDto)
        {
            try
            {
                var liveAnchorMonthlyTarget = await dalLiveAnchorMonthlyTarget.GetAll().SingleOrDefaultAsync(e => e.Id == editDto.Id);
                if (liveAnchorMonthlyTarget == null)
                    throw new Exception("主播月度运营目标情况编号错误！");
                #region #发布
                liveAnchorMonthlyTarget.CumulativeRelease += editDto.CumulativeRelease;
                if (liveAnchorMonthlyTarget.CumulativeRelease <= 0)
                {
                    liveAnchorMonthlyTarget.ReleaseCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.ReleaseCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeRelease) / Convert.ToDecimal(liveAnchorMonthlyTarget.ReleaseTarget)) * 100, 2);
                }
                #endregion

                #region #视频号投流
                liveAnchorMonthlyTarget.CumulativeFlowInvestment += editDto.CumulativeFlowInvestment;
                if (liveAnchorMonthlyTarget.CumulativeFlowInvestment <= 0)
                {
                    liveAnchorMonthlyTarget.FlowInvestmentCompleteRate = 0.00M;
                }
                else
                {

                    liveAnchorMonthlyTarget.FlowInvestmentCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeFlowInvestment) / Convert.ToDecimal(liveAnchorMonthlyTarget.FlowInvestmentTarget)) * 100, 2);
                }
                #endregion

                #region #直播间投流
                liveAnchorMonthlyTarget.LivingRoomCumulativeFlowInvestment += editDto.LivingRoomCumulativeFlowInvestment;
                if (liveAnchorMonthlyTarget.LivingRoomCumulativeFlowInvestment <= 0)
                {
                    liveAnchorMonthlyTarget.LivingRoomFlowInvestmentCompleteRate = 0.00M;
                }
                else
                {

                    liveAnchorMonthlyTarget.LivingRoomFlowInvestmentCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.LivingRoomCumulativeFlowInvestment) / Convert.ToDecimal(liveAnchorMonthlyTarget.LivingRoomFlowInvestmentTarget)) * 100, 2);
                }
                #endregion

                #region #线索量
                liveAnchorMonthlyTarget.CumulativeClues += editDto.CumulativeCluesNum;
                if (liveAnchorMonthlyTarget.CumulativeClues <= 0)
                {
                    liveAnchorMonthlyTarget.CluesCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.CluesCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeClues) / Convert.ToDecimal(liveAnchorMonthlyTarget.CluesTarget)) * 100, 2);
                }
                #endregion

                #region #涨粉量
                liveAnchorMonthlyTarget.CumulativeAddFans += editDto.CumulativeAddFansNum;
                if (liveAnchorMonthlyTarget.CumulativeAddFans <= 0)
                {
                    liveAnchorMonthlyTarget.AddFansCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.AddFansCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeAddFans) / Convert.ToDecimal(liveAnchorMonthlyTarget.AddFansTarget)) * 100, 2);
                }
                #endregion

                #region #加V量
                liveAnchorMonthlyTarget.CumulativeAddWechat += editDto.CumulativeAddWechat;
                if (liveAnchorMonthlyTarget.CumulativeAddWechat <= 0)
                {
                    liveAnchorMonthlyTarget.AddWechatCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.AddWechatCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeAddWechat) / Convert.ToDecimal(liveAnchorMonthlyTarget.AddWechatTarget)) * 100, 2);
                }
                #endregion

                #region #面诊卡
                liveAnchorMonthlyTarget.CumulativeConsultation += editDto.CumulativeConsultation;
                if (liveAnchorMonthlyTarget.CumulativeConsultation <= 0)
                {
                    liveAnchorMonthlyTarget.ConsultationCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.ConsultationCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeConsultation) / Convert.ToDecimal(liveAnchorMonthlyTarget.ConsultationTarget)) * 100, 2);
                }
                #endregion

                #region #消耗卡
                liveAnchorMonthlyTarget.CumulativeConsultationCardConsumed += editDto.CumulativeConsultationCardConsumed;
                if (liveAnchorMonthlyTarget.CumulativeConsultationCardConsumed <= 0)
                {
                    liveAnchorMonthlyTarget.ConsultationCardConsumedCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.ConsultationCardConsumedCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeConsultationCardConsumed) / Convert.ToDecimal(liveAnchorMonthlyTarget.ConsultationCardConsumedTarget)) * 100, 2);
                }
                #endregion

                #region #激活历史面诊数量
                liveAnchorMonthlyTarget.CumulativeActivateHistoricalConsultation += editDto.CumulativeActivateHistoricalConsultation;
                if (liveAnchorMonthlyTarget.CumulativeActivateHistoricalConsultation <= 0)
                {
                    liveAnchorMonthlyTarget.ActivateHistoricalConsultationCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.ActivateHistoricalConsultationCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeActivateHistoricalConsultation) / Convert.ToDecimal(liveAnchorMonthlyTarget.ActivateHistoricalConsultationTarget)) * 100, 2);
                }
                #endregion

                #region #派单量
                liveAnchorMonthlyTarget.CumulativeSendOrder += editDto.CumulativeSendOrder;
                if (liveAnchorMonthlyTarget.CumulativeSendOrder <= 0)
                {
                    liveAnchorMonthlyTarget.SendOrderCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.SendOrderCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeSendOrder) / Convert.ToDecimal(liveAnchorMonthlyTarget.SendOrderTarget)) * 100, 2);
                }
                #endregion

                #region #上门数
                liveAnchorMonthlyTarget.CumulativeVisit += editDto.CumulativeVisit;
                if (liveAnchorMonthlyTarget.CumulativeVisit <= 0)
                {
                    liveAnchorMonthlyTarget.VisitCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.VisitCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeVisit) / Convert.ToDecimal(liveAnchorMonthlyTarget.VisitTarget)) * 100, 2);
                }
                #endregion

                #region #成交数
                liveAnchorMonthlyTarget.CumulativeDealTarget += editDto.CumulativeDealTarget;
                if (liveAnchorMonthlyTarget.CumulativeDealTarget <= 0 || liveAnchorMonthlyTarget.CumulativeVisit <= 0)
                {
                    liveAnchorMonthlyTarget.DealRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.DealRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeDealTarget) / Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeVisit)) * 100, 2);
                }
                #endregion

                #region #带货佣金结算
                liveAnchorMonthlyTarget.CumulativeCargoSettlementCommission += editDto.CumulativeCargoSettlementCommission;
                if (liveAnchorMonthlyTarget.CumulativeCargoSettlementCommission <= 0)
                {
                    liveAnchorMonthlyTarget.CargoSettlementCommissionCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.CargoSettlementCommissionCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeCargoSettlementCommission) / Convert.ToDecimal(liveAnchorMonthlyTarget.CargoSettlementCommissionTarget)) * 100, 2);
                }
                #endregion

                #region #小黄车退单
                liveAnchorMonthlyTarget.CumulativeMinivanRefund += editDto.CumulativeMinivanRefund;
                if (liveAnchorMonthlyTarget.CumulativeMinivanRefund <= 0)
                {
                    liveAnchorMonthlyTarget.MinivanRefundCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.MinivanRefundCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeMinivanRefund) / Convert.ToDecimal(liveAnchorMonthlyTarget.MinivanRefundTarget)) * 100, 2);
                }
                #endregion

                #region #小黄车差评
                liveAnchorMonthlyTarget.CumulativeMiniVanBadReviews += editDto.CumulativeMiniVanBadReviews;
                if (liveAnchorMonthlyTarget.CumulativeMiniVanBadReviews <= 0)
                {
                    liveAnchorMonthlyTarget.MiniVanBadReviewsCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.MiniVanBadReviewsCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativeMiniVanBadReviews) / Convert.ToDecimal(liveAnchorMonthlyTarget.MiniVanBadReviewsTarget)) * 100, 2);
                }
                #endregion

                #region #业绩量
                liveAnchorMonthlyTarget.CumulativePerformance += editDto.CumulativePerformance;
                if (liveAnchorMonthlyTarget.CumulativePerformance <= 0)
                {
                    liveAnchorMonthlyTarget.PerformanceCompleteRate = 0.00M;
                }
                else
                {
                    liveAnchorMonthlyTarget.PerformanceCompleteRate = Math.Round((Convert.ToDecimal(liveAnchorMonthlyTarget.CumulativePerformance) / Convert.ToDecimal(liveAnchorMonthlyTarget.PerformanceTarget)) * 100, 2);
                }
                #endregion

                await dalLiveAnchorMonthlyTarget.UpdateAsync(liveAnchorMonthlyTarget, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                var liveAnchorMonthlyTarget = await dalLiveAnchorMonthlyTarget.GetAll().SingleOrDefaultAsync(e => e.Id == id);

                if (liveAnchorMonthlyTarget == null)
                    throw new Exception("主播月度运营目标情况编号错误");

                await dalLiveAnchorMonthlyTarget.DeleteAsync(liveAnchorMonthlyTarget, true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}