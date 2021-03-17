using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        void Add(string key, object data, int duration);
        void Remove(string key);
        object Get(string key);
        T Get<T>(string key);
        bool IsAdd(string key);
        void RemoveByPattern(string pattern);
    }
}
