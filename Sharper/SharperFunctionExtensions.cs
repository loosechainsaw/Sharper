using System;
using System.Collections.Generic;

namespace Sharper
{

    public static class SharperFunctionExtensions
    {

        public static Func<A,C> Compose<A,B,C>(this  Func<B,C> f, Func<A,B> g) => a => f(g(a));

        public static Func<A,B,A> Const<A,B,A>(this Func<A,B,A> f) => (a,b) => a;

        public static Func<A,B> Identity<A,B>(this Func<A,B> f) => f;

        public static Func<A,B,C> Identity<A,B,C>(this Func<A,B,C> f) => f;

        public static Func<A,B,C,D> Identity<A,B,C,D>(this Func<A,B,C,D> f) => f;

        public static Func<B,A,C> Flip<A,B,C>(this Func<A,B,C> f) => (b, a) => f(a, b);

        public static Func<B,C> Partial<A,B,C>(this Func<A,B,C> f, A value) => Partially.Apply(f, value);

        public static Func<A, Func<B,C>> Curry<A,B,C>(this Func<A,B,C> f) => Curry.Function(f);

        public static Func<A, Func<B,Func<C,D>>> Curry<A,B,C,D>(this Func<A,B,C,D> f) => Curry.Function(f);

        public static Func<A, Func<B, C>> Curry<A,B,C>(this Func<Tuple<A,B>,C> f) => Curry.Function(f);

        public static IEnumerable<A> Iterate<A>(this Func<A,A> f, A value)
        {
            yield return value;

            for(;;) {
                value = f(value);
                yield return value;
            }
        }

    }
    
}
