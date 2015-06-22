using System;
using System.Collections.Generic;

namespace Sharper
{

    public static class SharperFunctionExtensions
    {

        public static Func<A, C> Compose<A, B, C>(this Func<B, C> f, Func<A, B> g)
        {
            return a => f(g(a));
        }

        public static Func<A, B, A> Const<A, B>(this Func<A, B, A> f)
        {
            return (a, b) => a;
        }

        public static Func<A, B> Identity<A, B>(this Func<A, B> f)
        {
            return f;
        }

        public static Func<A, B, C> Identity<A, B, C>(this Func<A, B, C> f)
        {
            return f;
        }

        public static Func<A, B, C, D> Identity<A, B, C, D>(this Func<A, B, C, D> f)
        {
            return f;
        }

        public static Func<B, A, C> Flip<A, B, C>(this Func<A, B, C> f)
        {
            return (b, a) => f(a, b);
        }

        public static Func<B, C> Partial<A, B, C>(this Func<A, B, C> f, A value)
        {
            return Partially.Apply(f, value);
        }

        public static Func<A, Func<B, C>> Curry<A, B, C>(this Func<A, B, C> f)
        {
            return Sharper.Curry.Function(f);
        }

        public static Func<A, Func<B, Func<C, D>>> Curry<A, B, C, D>(this Func<A, B, C, D> f)
        {
            return Sharper.Curry.Function(f);
        }

        public static Func<A, Func<B, C>> Curry<A, B, C>(this Func<Tuple<A, B>, C> f)
        {
            return Sharper.Curry.Function(f);
        }

        public static IEnumerable<A> Iterate<A>(this Func<A, A> f, A value)
        {
            yield return value;

            for(; ;) {
                value = f(value);
                yield return value;
            }
        }

        public static Func<Option<A>, Option<B>> Lift<A,B>(this Func<A,B> f)
        {
            return x => x.Map(f);
        }

    }

}
