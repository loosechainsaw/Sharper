using System;

namespace Sharper
{

    public static class OptionIOTExtensions
    {
        public static OptionIOT<B> Select<A,B>(this OptionIOT<A> o, Func<A,B> f)
        {
            return o.Map(f);
        }

        public static OptionIOT<C> SelectMany<A,B,C>(this OptionIOT<A> o, Func<A, OptionIOT<B>> f, Func<A,B,C> m)
        {
            return o.FlatMap(z => f(z).Map(y => m(z, y)));
        }
    }
}
