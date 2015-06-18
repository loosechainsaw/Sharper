using System;

namespace Sharper
{

    public static class SharperOptionExtensions
    {
        public static Option<A> ToOption<A>(this A value)
        {
            if(value == null)
                return new None<A>();
            return new Some<A>(value);
        }

        public static Option<B> Select<A,B>(this Option<A> o, Func<A,B> f)
        {
            return o.Map(f);
        }

        public static Option<C> SelectMany<A,B,C>(this Option<A> o, Func<A, Option<B>> f, Func<A, B, C> m)
        {
            return o.FlatMap(z => f(z).Map(b => m(z, b)));
        }

        public static IOOption<A> ToOptionIOT<A>(this Option<A> o)
        {
            return new IOOption<A>(new IO<Option<A>>(() => o));
        }

        public static Some<A> ConvertToSome<A>(this Option<A> o)
        {
            var s = o as Some<A>;

            return s;
        }
    }
}
