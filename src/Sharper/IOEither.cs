using System;

namespace Sharper
{
    public class IOEither<A,B>
    {
        public IOEither(IO<Either<A,B>> monad)
        {
            this.monad = monad;
        }

        public IOEither<A,C> Map<C>(Func<B,C> f)
        {
            return new IO<Either<A, C>>(() => monad.run().Map(f)).EitherT();
        }

        public IOEither<A,C> FlatMap<C>(Func<B,IOEither<A,C>> f)
        {
            return new IO<Either<A, C>>(() => 
                Match.Object(monad.run())
                     .Case<Either<A, C>>(x => x.IsLeft, _ => new Left<A, C>(_.ToLeft().error))
                     .Case(x => x.IsRight, _ => f(_.ToRight().value).monad.run())
                     .Yield())
                    .EitherT();
        }

        private readonly IO<Either<A,B>> monad;
    }

}
