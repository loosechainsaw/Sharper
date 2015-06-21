using System.Collections.Generic;

namespace Sharper
{

    public static class DictionaryExtensions
    {
        public static Option<B> SafeGet<A,B>(this Dictionary<A,B> d, A key)
        {
            return (d.ContainsKey(key)) ? (Option<B>)new Some<B>(d[key]) : new None<B>();
        }
    }
}
