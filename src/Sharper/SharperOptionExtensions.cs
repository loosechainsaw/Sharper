using System;
using System.Collections.Generic;
using System.Linq;

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

        public static Option<IEnumerable<A>> Sequence<A>(this IEnumerable<Option<A>> elements)
        {
            Option<A> first = new None<A>();
            var match = false;

            foreach(var element in elements) {
                first = element;
                match = true;
                break;
            }

            if(!match || first.IsNone)
                return new None<IEnumerable<A>>();

            var list = new List<A>();
            list.Add(first.ToSome().Value);

            foreach(var element in elements.Skip(1)) {
                if(element.IsNone)
                    return new None<IEnumerable<A>>();
                list.Add(element.ToSome().Value);
            }

            return list.AsEnumerable().ToOption();
        }

        public static Option<C> Map2<A,B,C>(this Option<A> a, Option<B> b, Func<A,B,C> f)
        {
            return a.FlatMap(z => b.Map(d => f(z, d)));
        }

        public static Option<B> Select<A,B>(this Option<A> o, Func<A,B> f)
        {
            return o.Map(f);
        }

        public static Option<C> SelectMany<A,B,C>(this Option<A> o, Func<A, Option<B>> f, Func<A, B, C> m)
        {
            return o.FlatMap(z => f(z).Map(b => m(z, b)));
        }

        public static IOOption<A> ToOptionIO<A>(this Option<A> o)
        {
            return new IOOption<A>(new IO<Option<A>>(() => o));
        }

        public static Some<A> ToSome<A>(this Option<A> o)
        {
            var s = o as Some<A>;

            return s;
        }
    }


}
