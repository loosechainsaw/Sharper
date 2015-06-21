using System;

namespace Sharper
{

    public static class SharperIOEitherExtensions
    {
        public static IOEither<A,C> Select<A,B,C>(this IOEither<A,B> monad, Func<B,C> f)
        {
            return monad.Map(f);
        }

        public static IOEither<A,D> SelectMany<A,B,C,D>(this IOEither<A,B> monad, 
                                                        Func<B, IOEither<A,C>> f, Func<B,C,D> g)
        {
            return monad.FlatMap(z => f(z).Map(y => g(z, y)));
        }

        public static IOEither<A,D> EitherT<A,D>(this IO<Either<A,D>> monad)
        {
            return new IOEither<A, D>(monad);
        }
    }
}
