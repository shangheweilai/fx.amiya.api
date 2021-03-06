using Fx.Amiya.Dto.LiveAnchor;
using Fx.Common;
using Fx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
   public interface ILiveAnchorService
    {
        /// <summary>
        /// 根据内容平台id获取有效的主播列表
        /// </summary>
        /// <param name="contentPlatFormId">内容平台id</param>
        /// <returns></returns>
        Task<List<LiveAnchorDto>> GetValidListAsync(string contentPlatFormId, int employeeId);

        /// <summary>
        /// 获取有效的主播列表
        /// </summary>
        /// <returns></returns>
        Task<List<LiveAnchorDto>> GetValidAsync();

        /// <summary>
        /// 获取主播列表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<FxPageInfo<LiveAnchorDto>> GetListAsync(string name, int employeeId,string contentPlatformId, bool valid, int pageNum, int pageSize);

        Task DeleteAsync(int id);
        Task AddAsync(AddLiveAnchorDto addDto);
        Task<LiveAnchorDto> GetByIdAsync(int id);
        Task UpdateAsync(UpdateLiveAnchorDto updateDto);

    }
}
