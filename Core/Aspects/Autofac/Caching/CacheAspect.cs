using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect:MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;
        public CacheAspect(int duration=60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }
        public override void Intercept(IInvocation invocation)
        {
            var fullName = $"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}";
            var parameters = invocation.Arguments.ToList();
            var keyParameters = string.Join(",", parameters.Select(x=> x?.ToString()??"<Null>"));
            var key = $"{fullName}({keyParameters})";

            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }

            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
