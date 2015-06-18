using System;

namespace Sharper
{

    public static class SharperIOOptionExtensions
    {
        public static IOOption<B> Select<A,B>(this IOOption<A> o, Func<A,B> f)
        {
            return o.Map(f);
        }

        public static IOOption<C> SelectMany<A,B,C>(this IOOption<A> o, Func<A, IOOption<B>> f, Func<A,B,C> m)
        {
            return o.FlatMap(z => f(z).Map(y => m(z, y)));
        }
    }

}
