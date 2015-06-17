using System;

namespace Sharper
{

    public static class EitherIOTExtensions
    {
        public static EitherIOT<A,C> Select<A,B,C>(this EitherIOT<A,B> o, Func<B,C> f)
        {
            return o.Map(f);
        }

        public static EitherIOT<A,D> SelectMany<A,B,C,D>(this EitherIOT<A,B> o, Func<B, EitherIOT<A,C>> f, Func<B,C,D> m)
        {
            return o.FlatMap(z => f(z).Map(y => m(z, y)));
        }
    }
}
