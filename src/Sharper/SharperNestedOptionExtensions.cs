using System;

namespace Sharper
{

    public static class SharperNestedOptionExtensions
    {
        public static IOOption<A> OptionT<A>(this IO<Option<A>> n)
        {
            return new IOOption<A>(n);
        }

        public static IOEither<A,B> OptionT<A,B>(this IO<Either<A,B>> n)
        {
            return new IOEither<A,B>(n);
        }

        public static EitherOption<A,B> OptionT<A,B>(this Either<A,Option<B>> n)
        {
            return new EitherOption<A, B>(n);
        }
    }
}
