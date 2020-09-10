using Identity.Common;
using Identity.Core;
using Identity.Core.Model;
using Identity.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Identity.Service.Implements
{
    public class UserService: DBcontext, IUserService
    {
        public async Task<ApiResult<UserLoginBackDto>> LoginAsync(UserLoginDto parm)
        {
            var res = new ApiResult<UserLoginBackDto>() { statusCode = 500 };
            try
            {
                var back = new UserLoginBackDto();
                var user = await Db.Queryable<User>()
                    .Where(p => p.LoginName == parm.username).FirstAsync();
                if(user == null)
                {
                    res.message = "账号错误";
                    return res;
                }
                if(user.LoginPwd != parm.password)
                {
                    res.message = "密码错误";
                    return res;
                }
                res.statusCode = 200;
                back.username = user.LoginName;
                res.data = back;
                return res;
            }
            catch (Exception ex)
            {
                res.message = ex.Message;
            }
            return res;
        }
    }
}
