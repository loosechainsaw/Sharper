using System;

namespace Sharper
{

    public class OptionIOT<A>
    {
        public OptionIOT(IO<Option<A>> o)
        {
            this.o = o;
        }

        public Option<A> PerformUnsafeIO()
        {
            return o.f();
        }

        public OptionIOT<B> Map<B>(Func<A,B> m)
        {
            return new OptionIOT<B>(o.Map(z => z.Map(m)));
        }

        public OptionIOT<B> FlatMap<B>(Func<A,OptionIOT<B>> m)
        {
            return new OptionIOT<B>(
                new IO<Option<B>>(() => {
                    var option = o.f();

                    return Match.Object(option)
                                .Case(x => x.IsNone, () => new None<B>().ToOptionIOT())
                                .Case(x => x.IsSome, () => m(option.ConvertToSome().Value))
                                .Yield()
                                .o.f();

                })
            );
        }

        private IO<Option<A>> o;
     
    }

}
