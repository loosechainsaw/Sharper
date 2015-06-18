using System;
using System.Collections.Generic;
using System.Linq;

namespace Sharper
{

    public static class SharperIOExtensions
    {
        public static IO<A> ToIO<A>(this A value)
        {
            return new IO<A>(() => value);
        }

        public static IO<A> Sequence<A>(IEnumerable<IO<A>> operations)
        {
            IO<A> t = null;

            foreach(var element in operations) {
                t = element;
                break;
            }

            foreach(var item in operations.Skip(1)) {
                t.FlatMap(z => item);
            }

            if(t == null)
                throw new EmptySeqException();

            return t;
        }

        public static IO<A> Sequence<A>(IEnumerable<IO<A>> operations, A default_)
        {
            IO<A> t = null;

            foreach(var element in operations) {
                t = element;
                break;
            }

            if(t == null)
                t = default_.ToIO();

            foreach(var item in operations.Skip(1)) {
                t.FlatMap(z => item);
            }
                
            return t;
        }

        public static IO<B> Select<A,B>(this IO<A> o, Func<A,B> f)
        {
            return o.Map(f);
        }

        public static IO<C> SelectMany<A,B,C>(this IO<A> o, Func<A, IO<B>> f, Func<A,B,C> m)
        {
            return o.FlatMap(z => f(z).Map(y => m(z, y)));
        }
    }

}
