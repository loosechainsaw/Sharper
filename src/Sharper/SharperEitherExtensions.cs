using System;

namespace Sharper
{

    public static class SharperEitherExtensions
    {

        public static Left<A,C> ToLeft<A,C>(this Either<A,C> o)
        {
            var s = o as Left<A,C>;

            return s;
        }

        public static Right<A,C> ToRight<A,C>(this Either<A,C> o)
        {
            var s = o as Right<A,C>;

            return s;
        }

        public static Either<A,C> ToEither<A,C>(C value)
        {
            return new Right<A, C>(value);
        }

        public static Either<A,C> Select<A,B,C>(this Either<A,B> o, Func<B,C> f)
        {
            return o.Map(f);
        }

        public static Either<A,D> SelectMany<A,B,C,D>(this Either<A,B> o, Func<B, Either<A,C>> f, Func<B,C,D> m)
        {
            return o.FlatMap(z => f(z).Map(y => m(z, y)));
        }
    }
    
}
