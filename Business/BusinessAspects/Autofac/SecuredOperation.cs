using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Constants;

namespace Business.BusinessAspects.Autofac
{//JWT İÇİN 
    public class SecuredOperation : MethodInterception   //aspecte injection yapamıyoruz o yüzden servicetool ekledir.
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor; //HERKESE CONTEXT OLUŞTURUYOR

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return; // metou çalıştırmaya devam et
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
