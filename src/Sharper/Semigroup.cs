using System;
using System.Collections.Generic;

namespace Sharper
{
    public class Semigroup<A>
    {
        private readonly Func<A, Func<A, A>> sum;

        protected Semigroup(Func<A, Func<A, A>> sum)
        {
            this.sum = sum;
        }

        public A Sum(A value1, A value2)
        {
            return sum(value1)(value2);
        }

        public Func<A, A> Sum(A value1)
        {
            return sum(value1);
        }

        public Func<A, Func<A, A>> Sum()
        {
            return sum;
        }

        public static Semigroup<A> Create(Func<A, Func<A, A>> sum)
        {
            return new Semigroup<A>(sum);
        }

        public static Semigroup<A> Create(Func<A, A, A> sum)
        {
            return new Semigroup<A>(sum.Curry());
        }
    }

    public static class Semigroup
    {
        public static Semigroup<int> IntegerAddtion = Semigroup<int>.Create(x => y => x + y);
        public static Semigroup<int> IntegerMultiplication = Semigroup<int>.Create(x => y => x * y);

        public static Semigroup<double> DoubleAddtion = Semigroup<double>.Create(x => y => x + y);
        public static Semigroup<double> DoublerMultiplication = Semigroup<double>.Create(x => y => x * y);

        public static Semigroup<decimal> DecimalAddtion = Semigroup<decimal>.Create(x => y => x + y);
        public static Semigroup<decimal> DecimalMultiplication = Semigroup<decimal>.Create(x => y => x * y);

        public static Semigroup<long> LongAddtion = Semigroup<long>.Create(x => y => x + y);
        public static Semigroup<long> LongMultiplication = Semigroup<long>.Create(x => y => x * y);

        public static Semigroup<List<A>> List<A>()
        {
            return Semigroup<List<A>>.Create(x => y =>
            {
                var result = new List<A>(x);
                result.AddRange(y);
                return result;
            });
        }
    }
}