using System;
using System.Collections.Generic;

namespace Sharper
{
    public static class SharperListExtensions
    {
        public static PersistentList<A> Cons<A>(this A value, PersistentList<A> tail)
        {
            return new Cons<A>(value, tail);
        }

        public static B FoldLeft<A, B>(this PersistentList<A> list, B zero, Func<B, A, B> f)
        {

            if (list.IsNil)
                return zero;

            PersistentList<A> l = list.AsCons();
            var accum = zero;


            while (l.IsCons)
            {
                accum = f(accum, l.AsCons().Head);
                l = l.AsCons().Tail;
            }

            return accum;

        }

        public static PersistentList<A> Apply<A>(this IEnumerable<A> elements)
        {
            PersistentList<A> result = new Nil<A>();

            foreach (var element in elements)
                result = element.Cons(result);

            return result;
        }

        public static PersistentList<A> Take<A>(this PersistentList<A> list, int n)
        {
            if (list.IsNil)
                return new Nil<A>();

            PersistentList<A> result = new Nil<A>();
            var remainder = list;

            for (var i = 0; i < n; ++i)
            {
                if (remainder.IsNil)
                    break;

                var h = remainder.AsCons().Head;
                result = h.Cons(result);

                remainder = remainder.AsCons().Tail;
            }

            return result;

        }

        public static PersistentList<A> Drop<A>(this PersistentList<A> list, int n)
        {
            if (list.IsNil)
                return new Nil<A>();

            var remainder = list;

            for (var i = 0; i < n; ++i)
            {
                if (remainder.IsNil)
                    break;

                remainder = remainder.AsCons().Tail;
            }

            return remainder;

        }

        public static PersistentList<A> Reverse<A>(this PersistentList<A> list)
        {
            if (list.IsNil)
                return new Nil<A>();

            PersistentList<A> result = new Nil<A>();
            var remainder = list;

            while (remainder.IsCons)
            {
                var c = remainder.AsCons();
                result = c.Head.Cons(result);
                remainder = c.Tail;
            }

            return result;
        }

        public static PersistentList<A> Append<A>(this PersistentList<A> first, PersistentList<A> second)
        {

            if (first.IsNil)
                return second;

            PersistentList<A> result = new Nil<A>();
            var remainder = first;

            while (remainder.IsCons)
            {
                var h = remainder.AsCons().Head;
                result = h.Cons(result);

                remainder = remainder.AsCons().Tail;
            }

            remainder = second;

            while (remainder.IsCons)
            {
                var h = remainder.AsCons().Head;
                result = h.Cons(result);

                remainder = remainder.AsCons().Tail;
            }


            return result;


        }

        public static PersistentList<A> Foreach<A>(this PersistentList<A> list, Action<A> action)
        {
            if (list.IsNil)
                return new Nil<A>();

            var remainder = list;

            while (remainder.IsCons)
            {
                var c = remainder.AsCons();
                action(c.Head);
                remainder = c.Tail;
            }

            return list;
        }

        public static int Count<A>(this PersistentList<A> list)
        {
            if (list.IsNil)
                return 0;

            var result = 0;
            var remainder = list;

            while (remainder.IsCons)
            {
                var c = remainder.AsCons();
                ++result;
                remainder = c.Tail;
            }

            return result;
        }

        public static Cons<A> AsCons<A>(this PersistentList<A> l)
        {
            return (Cons<A>)l;
        }

    }
}