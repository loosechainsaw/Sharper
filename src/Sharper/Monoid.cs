using System;

namespace Sharper
{
    public class Monoid<A> : Semigroup<A>
    {
        protected Monoid(Func<A, Func<A, A>> sum, A zero)
            : base(sum)
        {
            Zero = zero;
        }

        public A Zero { get; private set; }

        public static Monoid<A> Create(Func<A, Func<A, A>> sum, A zero)
        {
            return new Monoid<A>(sum, zero);
        }

        public static Monoid<A> Create(Func<A, A, A> sum, A zero)
        {
            return new Monoid<A>(sum.Curry(), zero);
        }
    }
}