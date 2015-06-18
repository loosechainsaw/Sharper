using System;

namespace Sharper
{
    public class IOEither<A,B>
    {
        public IOEither(IO<Either<A,B>> o)
        {
            this.o = o;
        }

        public IOEither<A,C> Map<C>(Func<B,C> f)
        {
            return new IOEither<A, C>(new IO<Either<A, C>>(() => o.f().Map(f)));
        }

        public IOEither<A,C> FlatMap<C>(Func<B,IOEither<A,C>> f)
        {
            return new IOEither<A, C>(new IO<Either<A, C>>(() => {
                var a = o.f();
                var b = Match.Object(a)
                    .Case<Either<A,C>>(x => x.IsLeft, () => new Left<A,C>(a.ConvertToLeft().error))
                    .Case(x => x.IsRight, () => f(a.ConvertToRight().value).o.f())
                    .Yield();

                return b;

            }));
        }

        private IO<Either<A,B>> o;
    }

}
