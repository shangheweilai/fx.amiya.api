using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.HospitalPartakeItem;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Fx.Infrastructure;
using Fx.Common;
using Fx.Amiya.Dto.ItemInfo;

namespace Fx.Amiya.Service
{
    public class HospitalPartakeItemService : IHospitalPartakeItemService
    {
        private IDalHospitalPartakeItem dalHospitalPartakeItem;
        private IDalActivityItemDetail dalActivityItemDetail;
        public HospitalPartakeItemService(IDalHospitalPartakeItem dalHospitalPartakeItem,
            IDalActivityItemDetail dalActivityItemDetail)
        {
            this.dalHospitalPartakeItem = dalHospitalPartakeItem;
            this.dalActivityItemDetail = dalActivityItemDetail;
        }

        public async Task AddAsync(AddHospitalPartakeItemDto addDto, int hospitalId)
        {
            DateTime date = DateTime.Now;

            var activityDetails = await dalActivityItemDetail.GetAll().Where(e => e.ActityId == addDto.ActivityId).ToListAsync();

            var hospitalPartakeItems = await dalHospitalPartakeItem.GetAll()
                .Where(e => e.ActivityId == addDto.ActivityId && e.HospitalId == hospitalId)
                .ToListAsync();

            foreach (var item in hospitalPartakeItems)
            {
                // if (!addDto.ItemInfoList.Exists(e => e.ItemId == item.ItemId))
                await dalHospitalPartakeItem.DeleteAsync(item, true);
            }
            List<HospitalPartakeItem> hospitalPartakeItemList = new List<HospitalPartakeItem>();
            foreach (var item in addDto.ItemInfoList)
            {
                if (activityDetails.Exists(e => e.ItemId == item.ItemId))
                {
                    HospitalPartakeItem hospitalPartakeItem = new HospitalPartakeItem();
                    hospitalPartakeItem.HospitalId = hospitalId;
                    hospitalPartakeItem.ActivityId = addDto.ActivityId;
                    hospitalPartakeItem.ItemId = item.ItemId;
                    hospitalPartakeItem.IsAgreeLivingPrice = item.IsAgreeLivingPrice;
                    hospitalPartakeItem.HospitalPrice = item.HospitalPrice;
                    hospitalPartakeItem.CreateDate = date;
                    hospitalPartakeItem.ForenoonCanAppointmentQuantity = 10;
                    hospitalPartakeItem.AfternoonCanAppointmentQuantity = 10;
                    hospitalPartakeItemList.Add(hospitalPartakeItem);
                }
            }

            await dalHospitalPartakeItem.AddCollectionAsync(hospitalPartakeItemList, true);
        }


        /// <summary>
        /// 根据活动编号获取医院参与的项目
        /// </summary>
        /// <param name="hospitalId"></param>
        /// <param name="actityId"></param>
        /// <param name="keyword"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<HospitalPartakeItemDto>> GetListByActivityIdAsync(int hospitalId, int activityId, string keyword, int pageNum, int pageSize)
        {
            var q = from d in dalHospitalPartakeItem.GetAll()
                    where d.HospitalId == hospitalId
                    && d.ActivityId == activityId
                    && (keyword == null || d.ItemInfo.Name.Contains(keyword) || d.ItemInfo.Description.Contains(keyword))
                    select new HospitalPartakeItemDto
                    {
                        Id = d.Id,
                        HospitalId = d.HospitalId,
                        HospitalName = d.HospitalInfo.Name,
                        ItemId = d.ItemId,
                        ThumbPicUrl = d.ItemInfo.ThumbPicUrl,
                        Name = d.ItemInfo.Name,
                        Description = d.ItemInfo.Description,
                        Standard = d.ItemInfo.Standard,
                        Parts = d.ItemInfo.Parts,
                        SalePrice = d.ItemInfo.SalePrice,
                        LivePrice = d.ActivityInfo.ActivityItemDetailList.SingleOrDefault(e => e.ItemId == d.ItemId).LivePrice,
                        IsLimitBuy = d.ItemInfo.IsLimitBuy,
                        LimitBuyQuantity = d.ItemInfo.LimitBuyQuantity,
                        ForenoonCanAppointmentQuantity = d.ForenoonCanAppointmentQuantity,
                        AfternoonCanAppointmentQuantity = d.AfternoonCanAppointmentQuantity,
                        IsAgreeLivingPrice = d.IsAgreeLivingPrice,
                        HospitalPrice = d.HospitalPrice
                    };
            FxPageInfo<HospitalPartakeItemDto> pageInfo = new FxPageInfo<HospitalPartakeItemDto>();
            pageInfo.TotalCount = await q.CountAsync();
            pageInfo.List = await q.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return pageInfo;
        }



        public async Task<List<ItemSimpleListDto>> GetItemIdListByHospitalIdAsync(int hospitalId, int activityId)
        {
            var hospitalPartakeItems = await dalHospitalPartakeItem.GetAll()
                .Include(e => e.ItemInfo)
                .Where(e => e.HospitalId == hospitalId && e.ItemInfo.Valid && e.ActivityId == activityId)
                .ToListAsync();

            var activityDetails = await dalActivityItemDetail.GetAll().Where(e => e.ActityId == activityId).ToListAsync();
            List<ItemSimpleListDto> simpleList = new List<ItemSimpleListDto>();
            foreach (var item in hospitalPartakeItems)
            {
                if (activityDetails.Exists(e => e.ItemId == item.ItemId))
                {
                    ItemSimpleListDto addDto = new ItemSimpleListDto();
                    addDto.Id = item.ItemId;
                    addDto.IsAgreeLivingPrice = item.IsAgreeLivingPrice;
                    addDto.HospitalPrice = item.HospitalPrice;
                    simpleList.Add(addDto);


                }
            }
            return simpleList;

        }







        /// <summary>
        /// 根据项目编号获取参与的医院列表（分页）
        /// </summary>
        /// <param name="activityId">活动</param>
        /// <param name="itemId">项目</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<PartakeHospitalInfoDto>> GetHospitalListByItemIdWithPageAsync(int? activityId, int itemId, int pageNum, int pageSize)
        {
            var hospitalPartakeItems = from d in dalHospitalPartakeItem.GetAll()
                                       where (d.ItemId == 0 || d.ItemId == itemId)
                                       select d;

            IQueryable<PartakeHospitalInfoDto> partakeHospitals;
            if (activityId != null)
            {
                partakeHospitals = from d in hospitalPartakeItems
                                   where d.ActivityId == activityId
                                   select new PartakeHospitalInfoDto
                                   {
                                       HospitalId = d.HospitalId,
                                       HospitalName = d.HospitalInfo.Name,
                                       ThumbPicUrl = d.HospitalInfo.ThumbPicUrl,
                                       Address = d.HospitalInfo.Address,
                                       LivingPrice = d.ActivityInfo.ActivityItemDetailList.SingleOrDefault(e => e.ItemId == d.ItemId).LivePrice,
                                       IsAgreeLivingPrice = d.IsAgreeLivingPrice,
                                       HospitalPrice = d.HospitalPrice
                                   };

            }
            else
            {
                partakeHospitals = from d in hospitalPartakeItems
                                   group d by new { d.HospitalId, d.HospitalInfo.Name, d.HospitalInfo.ThumbPicUrl, d.HospitalInfo.Address, d.ActivityInfo, d.ItemId, d.IsAgreeLivingPrice, d.HospitalPrice } into g
                                   select new PartakeHospitalInfoDto
                                   {
                                       HospitalId = g.Key.HospitalId,
                                       HospitalName = g.Key.Name,
                                       ThumbPicUrl = g.Key.ThumbPicUrl,
                                       Address = g.Key.Address,
                                       LivingPrice = g.Key.ActivityInfo.ActivityItemDetailList.SingleOrDefault(e => e.ItemId == g.Key.ItemId).LivePrice,
                                       IsAgreeLivingPrice = g.Key.IsAgreeLivingPrice,
                                       HospitalPrice = g.Key.HospitalPrice
                                   };

            }
            FxPageInfo<PartakeHospitalInfoDto> pageInfo = new FxPageInfo<PartakeHospitalInfoDto>();
            pageInfo.TotalCount = await partakeHospitals.CountAsync();
            pageInfo.List = await partakeHospitals.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return pageInfo;
        }



        /// <summary>
        /// 根据项目编号获取参与的医院列表
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public async Task<List<PartakeHospitalInfoDto>> GetHospitalListByItemIdAsync(int? activityId, int itemId)
        {
            var hospitalPartakeItems = from d in dalHospitalPartakeItem.GetAll()
                                       where d.ItemId == itemId
                                       select d;

            IQueryable<PartakeHospitalInfoDto> partakeHospitals;
            if (activityId != null)
            {
                partakeHospitals = from d in hospitalPartakeItems
                                   where d.ActivityId == activityId
                                   select new PartakeHospitalInfoDto
                                   {
                                       HospitalId = d.HospitalId,
                                       HospitalName = d.HospitalInfo.Name,
                                       ThumbPicUrl = d.HospitalInfo.ThumbPicUrl,
                                       Address = d.HospitalInfo.Address,
                                       IsAgreeLivingPrice=d.IsAgreeLivingPrice,
                                       LivingPrice = d.ActivityInfo.ActivityItemDetailList.SingleOrDefault(e => e.ItemId == d.ItemId).LivePrice,
                                       HospitalPrice =d.HospitalPrice
                                   };
            }
            else
            {
                partakeHospitals = from d in hospitalPartakeItems
                                   group d by new { d.HospitalId, d.HospitalInfo.Name, d.HospitalInfo.ThumbPicUrl, d.HospitalInfo.Address, d.ActivityInfo, d.ItemId, d.IsAgreeLivingPrice, d.HospitalPrice } into g
                                   select new PartakeHospitalInfoDto
                                   {
                                       HospitalId = g.Key.HospitalId,
                                       HospitalName = g.Key.Name,
                                       ThumbPicUrl = g.Key.ThumbPicUrl,
                                       Address = g.Key.Address,
                                       LivingPrice = g.Key.ActivityInfo.ActivityItemDetailList.SingleOrDefault(e => e.ItemId == g.Key.ItemId).LivePrice,
                                       IsAgreeLivingPrice = g.Key.IsAgreeLivingPrice,
                                       HospitalPrice = g.Key.HospitalPrice
                                   };

            }
            return await partakeHospitals.ToListAsync();

        }




        /// <summary>
        /// 根据医院编号获取参与的项目列表（分页）
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="hospitalId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<PartakeItemInfoDto>> GetItemListByHospitalIdWithPageAsync(int? activityId, int hospitalId, int pageNum, int pageSize)
        {
            var hospitalPartakeItems = from d in dalHospitalPartakeItem.GetAll()
                                       where d.HospitalId == hospitalId
                                       select d;

            IQueryable<PartakeItemInfoDto> partakeItems;
            if (activityId != null)
            {
                partakeItems = from d in hospitalPartakeItems
                               where d.ActivityId == activityId
                               select new PartakeItemInfoDto
                               {
                                   ItemId = d.ItemId,
                                   ThumbPicUrl = d.ItemInfo.ThumbPicUrl,
                                   Name = d.ItemInfo.Name,
                                   Description = d.ItemInfo.Description,
                                   Standard = d.ItemInfo.Standard,
                                   Parts = d.ItemInfo.Parts,
                                   LivePrice = d.ActivityInfo.ActivityItemDetailList.SingleOrDefault(e => e.ItemId == d.ItemId).LivePrice,
                                   IsAgreeLivingPrice = d.IsAgreeLivingPrice,
                                   HospitalPrice = d.HospitalPrice,
                                   IsLimitBuy = d.ItemInfo.IsLimitBuy,
                                   LimitBuyQuantity = d.ItemInfo.LimitBuyQuantity,

                               };
            }
            else
            {
                partakeItems = from d in hospitalPartakeItems
                               group d by new
                               {
                                   d.ItemId,
                                   d.ItemInfo.Name,
                                   d.ItemInfo.ThumbPicUrl,
                                   d.ItemInfo.Description,
                                   d.ItemInfo.Standard,
                                   d.ItemInfo.Parts,
                                   d.ItemInfo.SalePrice,
                                   d.ItemInfo.IsLimitBuy,
                                   d.ItemInfo.LimitBuyQuantity,
                                   d.HospitalPrice,
                                   d.IsAgreeLivingPrice
                               } into g
                               select new PartakeItemInfoDto
                               {
                                   ItemId = g.Key.ItemId,
                                   Name = g.Key.Name,
                                   ThumbPicUrl = g.Key.ThumbPicUrl,
                                   Description = g.Key.Description,
                                   Standard = g.Key.Standard,
                                   Parts = g.Key.Parts,
                                   SalePrice = g.Key.SalePrice,
                                   IsLimitBuy = g.Key.IsLimitBuy,
                                   LimitBuyQuantity = g.Key.LimitBuyQuantity,
                                   HospitalPrice = g.Key.HospitalPrice,
                                   IsAgreeLivingPrice = g.Key.IsAgreeLivingPrice
                               };
            }

            FxPageInfo<PartakeItemInfoDto> partakeItemPageInfo = new FxPageInfo<PartakeItemInfoDto>();
            partakeItemPageInfo.TotalCount = await partakeItems.CountAsync();
            partakeItemPageInfo.List = await partakeItems.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return partakeItemPageInfo;
        }



        /// <summary>
        /// 根据医院编号获取参与的项目列表（不分页）
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="hospitalId"></param>
        /// <returns></returns>
        public async Task<List<PartakeItemInfoDto>> GetItemListByHospitalIdAsync(int? activityId, int hospitalId)
        {
            var hospitalPartakeItems = from d in dalHospitalPartakeItem.GetAll()
                                       where d.HospitalId == hospitalId
                                       select d;

            IQueryable<PartakeItemInfoDto> partakeItems;
            if (activityId != null)
            {
                partakeItems = from d in hospitalPartakeItems
                               where d.ActivityId == activityId
                               select new PartakeItemInfoDto
                               {
                                   ItemId = d.ItemId,
                                   ThumbPicUrl = d.ItemInfo.ThumbPicUrl,
                                   Name = d.ItemInfo.Name,
                                   Description = d.ItemInfo.Description,
                                   Standard = d.ItemInfo.Standard,
                                   Parts = d.ItemInfo.Parts,
                                   SalePrice = d.ItemInfo.SalePrice,
                                   LivePrice = d.ActivityInfo.ActivityItemDetailList.SingleOrDefault(e => e.ItemId == d.ItemId).LivePrice,
                                   IsLimitBuy = d.ItemInfo.IsLimitBuy,
                                   LimitBuyQuantity = d.ItemInfo.LimitBuyQuantity,
                                   IsAgreeLivingPrice=d.IsAgreeLivingPrice,
                                   HospitalPrice=d.HospitalPrice
                               };
            }
            else
            {
                partakeItems = from d in hospitalPartakeItems
                               group d by new
                               {
                                   d.ItemId,
                                   d.ItemInfo.Name,
                                   d.ItemInfo.ThumbPicUrl,
                                   d.ItemInfo.Description,
                                   d.ItemInfo.Standard,
                                   d.ItemInfo.Parts,
                                   d.ItemInfo.SalePrice,
                                   d.ItemInfo.IsLimitBuy,
                                   d.ItemInfo.LimitBuyQuantity,
                                   d.ActivityInfo,
                                   d.IsAgreeLivingPrice,
                                   d.HospitalPrice
                               } into g
                               select new PartakeItemInfoDto
                               {
                                   ItemId = g.Key.ItemId,
                                   Name = g.Key.Name,
                                   ThumbPicUrl = g.Key.ThumbPicUrl,
                                   Description = g.Key.Description,
                                   Standard = g.Key.Standard,
                                   Parts = g.Key.Parts,
                                   SalePrice = g.Key.SalePrice,
                                   IsLimitBuy = g.Key.IsLimitBuy,
                                   LimitBuyQuantity = g.Key.LimitBuyQuantity,
                                   LivePrice = g.Key.ActivityInfo.ActivityItemDetailList.SingleOrDefault(e => e.ItemId == g.Key.ItemId).LivePrice,
                                   IsAgreeLivingPrice=g.Key.IsAgreeLivingPrice,
                                   HospitalPrice=g.Key.HospitalPrice
                               };
            }
            return await partakeItems.ToListAsync();
        }




        /// <summary>
        /// 根据城市和项目获取参与的医院列表（分页）
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="cityId"></param>
        /// <param name="itemId"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<FxPageInfo<PartakeHospitalInfoDto>> GetHospitalListByCityWithPageAsync(int? activityId, int cityId, int itemId, int pageNum, int pageSize)
        {
            var hospitalPartakeItems = from d in dalHospitalPartakeItem.GetAll()
                                       where d.ItemId == itemId && d.HospitalInfo.CityId == cityId
                                       select d;

            IQueryable<PartakeHospitalInfoDto> partakeHospitals;
            if (activityId != null)
            {
                partakeHospitals = from d in hospitalPartakeItems
                                   where d.ActivityId == activityId
                                   select new PartakeHospitalInfoDto
                                   {
                                       HospitalId = d.HospitalId,
                                       HospitalName = d.HospitalInfo.Name,
                                       ThumbPicUrl = d.HospitalInfo.ThumbPicUrl,
                                       Address = d.HospitalInfo.Address,
                                       LivingPrice = d.ActivityInfo.ActivityItemDetailList.SingleOrDefault(e => e.ItemId == d.ItemId).LivePrice,
                                       IsAgreeLivingPrice = d.IsAgreeLivingPrice,
                                       HospitalPrice = d.HospitalPrice
                                   };
            }
            else
            {
                partakeHospitals = from d in hospitalPartakeItems
                                   group d by new { d.HospitalId, d.HospitalInfo.Name, d.HospitalInfo.ThumbPicUrl, d.HospitalInfo.Address, d.ActivityInfo, d.ItemId, d.IsAgreeLivingPrice, d.HospitalPrice } into g
                                   select new PartakeHospitalInfoDto
                                   {
                                       HospitalId = g.Key.HospitalId,
                                       HospitalName = g.Key.Name,
                                       ThumbPicUrl = g.Key.ThumbPicUrl,
                                       Address = g.Key.Address,
                                       LivingPrice = g.Key.ActivityInfo.ActivityItemDetailList.SingleOrDefault(e => e.ItemId == g.Key.ItemId).LivePrice,
                                       IsAgreeLivingPrice = g.Key.IsAgreeLivingPrice,
                                       HospitalPrice = g.Key.HospitalPrice
                                   };
            }

            FxPageInfo<PartakeHospitalInfoDto> pageInfo = new FxPageInfo<PartakeHospitalInfoDto>();
            pageInfo.TotalCount = await partakeHospitals.CountAsync();
            pageInfo.List = await partakeHospitals.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();
            return pageInfo;
        }



        /// <summary>
        /// 根据城市和项目获取参与的医院列表（不分页）
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="cityId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public async Task<List<PartakeHospitalInfoDto>> GetHospitalListByCityAsync(int? activityId, int cityId, int itemId)
        {
            var hospitalPartakeItems = from d in dalHospitalPartakeItem.GetAll()
                                       where d.ItemId == itemId && d.HospitalInfo.CityId == cityId
                                       select d;

            IQueryable<PartakeHospitalInfoDto> partakeHospitals;
            if (activityId != null)
            {
                partakeHospitals = from d in hospitalPartakeItems
                                   where d.ActivityId == activityId
                                   select new PartakeHospitalInfoDto
                                   {
                                       HospitalId = d.HospitalId,
                                       HospitalName = d.HospitalInfo.Name,
                                       ThumbPicUrl = d.HospitalInfo.ThumbPicUrl,
                                       Address = d.HospitalInfo.Address,
                                       LivingPrice = d.ActivityInfo.ActivityItemDetailList.SingleOrDefault(e => e.ItemId == d.ItemId).LivePrice,
                                       IsAgreeLivingPrice = d.IsAgreeLivingPrice,
                                       HospitalPrice = d.HospitalPrice
                                   };
            }
            else
            {
                partakeHospitals = from d in hospitalPartakeItems
                                   group d by new { d.HospitalId, d.HospitalInfo.Name, d.HospitalInfo.ThumbPicUrl, d.HospitalInfo.Address, d.ActivityInfo,d.ItemId, d.IsAgreeLivingPrice, d.HospitalPrice } into g
                                   select new PartakeHospitalInfoDto
                                   {
                                       HospitalId = g.Key.HospitalId,
                                       HospitalName = g.Key.Name,
                                       ThumbPicUrl = g.Key.ThumbPicUrl,
                                       Address = g.Key.Address,
                                       LivingPrice = g.Key.ActivityInfo.ActivityItemDetailList.SingleOrDefault(e => e.ItemId == g.Key.ItemId).LivePrice,
                                       IsAgreeLivingPrice = g.Key.IsAgreeLivingPrice,
                                       HospitalPrice = g.Key.HospitalPrice
                                   };
            }
            return await partakeHospitals.ToListAsync();
        }


    }
}
