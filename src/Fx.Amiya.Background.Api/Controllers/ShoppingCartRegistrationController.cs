using Fx.Amiya.Background.Api.Vo.ShoppingCartRegistration;
using Fx.Amiya.Dto.ShoppingCartRegistration;
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
    /// 小黄车登记板块数据接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [FxInternalAuthorize]
    public class ShoppingCartRegistrationController : ControllerBase
    {
        private IShoppingCartRegistrationService shoppingCartRegistrationService;
        private IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="shoppingCartRegistrationService"></param>
        public ShoppingCartRegistrationController(IShoppingCartRegistrationService shoppingCartRegistrationService,
            IHttpContextAccessor httpContextAccessor)
        {
            this.shoppingCartRegistrationService = shoppingCartRegistrationService;
            this.httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// 获取小黄车登记信息列表（分页）
        /// </summary>
        /// <param name="startDate">登记开始时间</param>
        /// <param name="endDate">登记结束时间</param>
        /// <param name="LiveAnchorId">主播id</param>
        /// <param name="keyword">关键词</param>
        /// <param name="contentPlatFormId">内容平台id</param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("listWithPage")]
        public async Task<ResultData<FxPageInfo<ShoppingCartRegistrationVo>>> GetListWithPageAsync(DateTime? startDate, DateTime? endDate, int? LiveAnchorId, bool? isAddWechat, bool? isWriteOff, bool? isConsultation, bool? isReturnBackPrice, string keyword, string contentPlatFormId, int pageNum, int pageSize)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                var q = await shoppingCartRegistrationService.GetListWithPageAsync(startDate, endDate, LiveAnchorId, employeeId, isAddWechat, isWriteOff, isConsultation, isReturnBackPrice, keyword, contentPlatFormId, pageNum, pageSize);

                var shoppingCartRegistration = from d in q.List
                                               select new ShoppingCartRegistrationVo
                                               {
                                                   Id = d.Id,
                                                   RecordDate = d.RecordDate,
                                                   ContentPlatFormName = d.ContentPlatFormName,
                                                   LiveAnchorName = d.LiveAnchorName,
                                                   LiveAnchorWechatNo = d.LiveAnchorWechatNo,
                                                   CustomerNickName = d.CustomerNickName,
                                                   Phone = d.Phone,
                                                   Price = d.Price,
                                                   ConsultationType = d.ConsultationType,
                                                   IsWriteOff = d.IsWriteOff,
                                                   IsConsultation = d.IsConsultation,
                                                   IsAddWeChat = d.IsAddWeChat,
                                                   IsReturnBackPrice = d.IsReturnBackPrice,
                                                   Remark = d.Remark,
                                                   CreateBy = d.CreateByName,
                                                   CreateDate = d.CreateDate,
                                               };

                FxPageInfo<ShoppingCartRegistrationVo> shoppingCartRegistrationPageInfo = new FxPageInfo<ShoppingCartRegistrationVo>();
                shoppingCartRegistrationPageInfo.TotalCount = q.TotalCount;
                shoppingCartRegistrationPageInfo.List = shoppingCartRegistration;

                return ResultData<FxPageInfo<ShoppingCartRegistrationVo>>.Success().AddData("shoppingCartRegistrationInfo", shoppingCartRegistrationPageInfo);
            }
            catch (Exception ex)
            {
                return ResultData<FxPageInfo<ShoppingCartRegistrationVo>>.Fail(ex.Message);
            }
        }




        /// <summary>
        /// 添加小黄车登记信息
        /// </summary>
        /// <param name="addVo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResultData> AddAsync(AddShoppingCartRegistrationVo addVo)
        {
            try
            {
                var employee = httpContextAccessor.HttpContext.User as FxAmiyaEmployeeIdentity;
                int employeeId = Convert.ToInt32(employee.Id);
                AddShoppingCartRegistrationDto addDto = new AddShoppingCartRegistrationDto();
                addDto.RecordDate = addVo.RecordDate;
                addDto.ContentPlatFormId = addVo.ContentPlatFormId;
                addDto.LiveAnchorId = addVo.LiveAnchorId;
                addDto.LiveAnchorWechatNo = addVo.LiveAnchorWechatNo;
                addDto.CustomerNickName = addVo.CustomerNickName;
                addDto.Phone = addVo.Phone;
                addDto.Price = addVo.Price;
                addDto.ConsultationType = addVo.ConsultationType;
                addDto.IsWriteOff = addVo.IsWriteOff;
                addDto.IsAddWeChat = addVo.IsAddWeChat;
                addDto.IsConsultation = addVo.IsConsultation;
                addDto.IsReturnBackPrice = addVo.IsReturnBackPrice;
                addDto.Remark = addVo.Remark;
                addDto.CreateBy = employeeId;

                await shoppingCartRegistrationService.AddAsync(addDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }



        /// <summary>
        /// 根据小黄车登记编号获取小黄车登记信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("byId/{id}")]
        public async Task<ResultData<ShoppingCartRegistrationVo>> GetByIdAsync(string id)
        {
            try
            {
                var shoppingCartRegistration = await shoppingCartRegistrationService.GetByIdAsync(id);
                ShoppingCartRegistrationVo shoppingCartRegistrationVo = new ShoppingCartRegistrationVo();
                shoppingCartRegistrationVo.Id = shoppingCartRegistration.Id;
                shoppingCartRegistrationVo.RecordDate = shoppingCartRegistration.RecordDate;
                shoppingCartRegistrationVo.ContentPlatFormId = shoppingCartRegistration.ContentPlatFormId;
                shoppingCartRegistrationVo.LiveAnchorId = shoppingCartRegistration.LiveAnchorId;
                shoppingCartRegistrationVo.LiveAnchorWechatNo = shoppingCartRegistration.LiveAnchorWechatNo;
                shoppingCartRegistrationVo.CustomerNickName = shoppingCartRegistration.CustomerNickName;
                shoppingCartRegistrationVo.Phone = shoppingCartRegistration.Phone;
                shoppingCartRegistrationVo.IsAddWeChat = shoppingCartRegistration.IsAddWeChat;
                shoppingCartRegistrationVo.Price = shoppingCartRegistration.Price;
                shoppingCartRegistrationVo.ConsultationType = shoppingCartRegistration.ConsultationType;
                shoppingCartRegistrationVo.IsWriteOff = shoppingCartRegistration.IsWriteOff;
                shoppingCartRegistrationVo.IsConsultation = shoppingCartRegistration.IsConsultation;
                shoppingCartRegistrationVo.IsReturnBackPrice = shoppingCartRegistration.IsReturnBackPrice;
                shoppingCartRegistrationVo.Remark = shoppingCartRegistration.Remark;
                shoppingCartRegistrationVo.CreateDate = shoppingCartRegistration.CreateDate;

                return ResultData<ShoppingCartRegistrationVo>.Success().AddData("shoppingCartRegistrationInfo", shoppingCartRegistrationVo);
            }
            catch (Exception ex)
            {
                return ResultData<ShoppingCartRegistrationVo>.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 修改小黄车登记信息
        /// </summary>
        /// <param name="updateVo"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ResultData> UpdateAsync(UpdateShoppingCartRegistrationVo updateVo)
        {
            try
            {
                UpdateShoppingCartRegistrationDto updateDto = new UpdateShoppingCartRegistrationDto();
                updateDto.Id = updateVo.Id;
                updateDto.RecordDate = updateVo.RecordDate;
                updateDto.ContentPlatFormId = updateVo.ContentPlatFormId;
                updateDto.LiveAnchorId = updateVo.LiveAnchorId;
                updateDto.LiveAnchorWechatNo = updateVo.LiveAnchorWechatNo;
                updateDto.CustomerNickName = updateVo.CustomerNickName;
                updateDto.IsAddWeChat = updateVo.IsAddWeChat;
                updateDto.Phone = updateVo.Phone;
                updateDto.Price = updateVo.Price;
                updateDto.ConsultationType = updateVo.ConsultationType;
                updateDto.IsWriteOff = updateVo.IsWriteOff;
                updateDto.IsConsultation = updateVo.IsConsultation;
                updateDto.IsReturnBackPrice = updateVo.IsReturnBackPrice;
                updateDto.Remark = updateVo.Remark;
                await shoppingCartRegistrationService.UpdateAsync(updateDto);
                return ResultData.Success();
            }
            catch (Exception ex)
            {
                return ResultData.Fail(ex.Message);
            }
        }


        /// <summary>
        /// 删除小黄车登记信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ResultData> DeleteAsync(string id)
        {
            try
            {
                await shoppingCartRegistrationService.DeleteAsync(id);
                return ResultData.Success();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
