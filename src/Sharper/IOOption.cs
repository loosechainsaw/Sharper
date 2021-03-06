using System;

namespace Sharper
{

    public class IOOption<A>
    {
        public IOOption(IO<Option<A>> monad)
        {
            this.monad = monad;
        }

        public Option<A> PerformUnsafeIO()
        {
            return monad.run();
        }

        public IOOption<B> Map<B>(Func<A,B> func)
        {
            return monad.Map(z => z.Map(func)).OptionT();
        }

        public IOOption<B> FlatMap<B>(Func<A,IOOption<B>> func)
        {
            return new IOOption<B>(
                new IO<Option<B>>(() => {
                    var option = monad.run();

                    return Match.Object(option)
                                .Case(x => x.IsNone, () => new None<B>().ToOptionIO())
                                .Case(x => x.IsSome, _ => func(_.ToSome().Value))
                                .Yield()
                                .monad.run();

                })
            );
        }

        public IO<A> GetValueOrDefault(A value)
        {
            return new IO<A>(() => PerformUnsafeIO().GetValueOrDefault(value));
        }

        public IOOption<A> OrElse(Option<A> value)
        {
            return monad.Map(x => x.OrElse(value)).OptionT();
        }

        public static implicit operator IO<Option<A>>(IOOption<A> trans)
        {
            return trans.monad;
        }

        private readonly IO<Option<A>> monad;
     
    }

}
