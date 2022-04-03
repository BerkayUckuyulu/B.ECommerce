using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager //başka cache metotları da olduğu için interface ekliyoruz.
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value,int duration);
        //object her veri tipinin base"i ---- duration ne kadar süre tutulacağı.
        bool IsAdd(string key); //cachede var mı?
        void Remove(string key);// cache bırak 
        void RemoveByPattern(string pattern); //örneğin içind eget olanları bırak gibi. Çünkü value değişebiliyor.
    }
}
