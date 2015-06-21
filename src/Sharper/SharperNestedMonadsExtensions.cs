using System;
using System.Threading.Tasks;

namespace Sharper
{

    public static class SharperNestedMonadsExtensions
    {
        public static IOOption<A> OptionT<A>(this IO<Option<A>> n)
        {
            return new IOOption<A>(n);
        }

        public static EitherOption<A,B> OptionT<A,B>(this Either<A, Option<B>> n)
        {
            return new EitherOption<A, B>(n);
        }

        public static IOEither<A,B> OptionT<A,B>(this IO<Either<A,B>> n)
        {
            return new IOEither<A,B>(n);
        }

        public static TaskOption<A> OptionT<A>(this Task<Option<A>> t)
        {
            return new TaskOption<A>(t);
        }

        public static TaskEither<A,B> EitherT<A,B>(this Task<Either<A,B>> t)
        {
            return new TaskEither<A, B>(t);
        }
    }
}
