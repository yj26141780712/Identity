﻿using Identity.Core;
using Identity.Core.Model;
using Identity.Service.Implements;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity
{
    public class ResourceOwnerPasswordValidator :DBcontext, IResourceOwnerPasswordValidator
    {
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            try
            {
                var userName = context.UserName;
                var password = context.Password;

                //验证用户,这么可以到数据库里面验证用户名和密码是否正确
                var claimList = await ValidateUserAsync(userName, password);
                // 验证账号
                context.Result = new GrantValidationResult
                (
                    subject: userName,
                    authenticationMethod: "custom",
                    claims: claimList.ToArray()
                 );
            }
            catch (Exception ex)
            {
                //验证异常结果
                context.Result = new GrantValidationResult()
                {
                    IsError = true,
                    Error = ex.Message
                };
            }
        }

        #region Private Method
        /// <summary>
        /// 验证用户
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private async Task<List<Claim>> ValidateUserAsync(string loginName, string password)
        {
            //TODO 这里可以通过用户名和密码到数据库中去验证是否存在，
            // 以及角色相关信息，我这里还是使用内存中已经存在的用户和密码

            var user = await Db.Queryable<User>()
                    .Where(p => p.LoginName == loginName).FirstAsync();
            if (user == null)
                throw new Exception("登录失败，用户名和密码不正确");
            return new List<Claim>()
            {
                new Claim(ClaimTypes.Name, $"{loginName}"),
            };
        }
        #endregion
    }
}
