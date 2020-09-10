using Identity.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Service.Interfaces
{
    /// <summary>
    /// 管理员接口
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        Task<ApiResult<UserLoginBackDto>> LoginAsync(UserLoginDto parm);

    }
}
