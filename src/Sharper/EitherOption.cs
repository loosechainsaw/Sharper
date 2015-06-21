using System;

namespace Sharper
{

    public class EitherOption<A,B>
    {
        public EitherOption(Either<A, Option<B>> monad)
        {
            this.monad = monad;
        }

        public EitherOption<A,C> Map<C>(Func<B,C> func)
        {
            return monad.Map(z => z.Map(func)).OptionT();
        }

        public EitherOption<A,C> FlatMap<C>(Func<B,EitherOption<A,C>> func)
        {
            return 
            Match.Object(monad)
                 .Returning<EitherOption<A,C>>()
                 .When<Left<A,Option<B>>>(x => new Left<A,Option<C>>(x.ToLeft().GetError()).OptionT())
                 .When<Right<A,Option<B>>>(x => 
                     Match.Object(x.ToRight().Value())
                          .Case(y => y.IsNone, y => new Right<A,Option<C>>(new None<C>()).OptionT())
                          .Case(y => y.IsSome, y => func(y.ToSome().Value))
                          .Yield()
            )
                .Yield();

        }

        private readonly Either<A, Option<B>> monad;
    }
        
}
