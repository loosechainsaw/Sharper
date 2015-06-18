using System;

namespace Sharper
{

    public static class SharperIOEitherExtensions
    {
        public static IOEither<A,C> Select<A,B,C>(this IOEither<A,B> o, Func<B,C> f)
        {
            return o.Map(f);
        }

        public static IOEither<A,D> SelectMany<A,B,C,D>(this IOEither<A,B> o, Func<B, IOEither<A,C>> f, Func<B,C,D> m)
        {
            return o.FlatMap(z => f(z).Map(y => m(z, y)));
        }
    }
}
