using System;

namespace Sharper
{
    public class EitherIOT<A,B>
    {
        public EitherIOT(IO<Either<A,B>> o)
        {
            this.o = o;
        }

        public EitherIOT<A,C> Map<C>(Func<B,C> f)
        {
            return new EitherIOT<A, C>(new IO<Either<A, C>>(() => o.f().Map(f)));
        }

        public EitherIOT<A,C> FlatMap<C>(Func<B,EitherIOT<A,C>> f)
        {
            return new EitherIOT<A, C>(new IO<Either<A, C>>(() => {
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
