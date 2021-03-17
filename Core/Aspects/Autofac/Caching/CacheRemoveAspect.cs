using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect:MethodInterception
    {
        private string _pattern;
        private ICacheManager _cache;
        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cache = ServiceTool.ServiceProvider.GetService<MemoryCacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            _cache.RemoveByPattern(_pattern);
        }
    }
}
