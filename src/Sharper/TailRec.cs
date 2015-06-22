using System;
using System.Collections.Generic;

namespace Sharper
{

    public enum TailType
    {
        Return,
        Suspend,
        FlatMap
    }

    public abstract class TailRec<A>
    {
        public TailRec<B> FlatMap<B>(Func<A, TailRec<B>> f)
        {
            return new FlatMap<A,B>(this, f);
        }

        public TailRec<B> Map<B>(Func<A,B> f)
        {
            return FlatMap(x => new Return<B>(f(x)));
        }

        public abstract TailType Type{ get; }
    }

    public class Return<A> : TailRec<A>
    {
        public Return(A value)
        {
            Value = value;
        }

        public override TailType Type{ get { return TailType.Return; } }

        public A Value{ get; private set; }
    }

    public class Suspend<A> : TailRec<A>
    {
        public Suspend(Func<A> run)
        {
            Run = run;
        }

        public override TailType Type{ get { return TailType.Suspend; } }

        public Func<A> Run{ get; private set; }
    }

    public class FlatMap<A,B> : TailRec<B>
    {
        public FlatMap(TailRec<A> sub, Func<A,TailRec<B>> k)
        {
            Sub = sub;
        }

        public override TailType Type{ get { return TailType.FlatMap; } }

        public TailRec<A> Sub{ get; private set; }

        public Func<A,TailRec<B>> K{ get; private set; }
    }

    public static class TailRecExtensions
    {
        public static Return<A> ToReturn<A>(this TailRec<A> t)
        {
            return (Return<A>)t;
        }

        public static Suspend<A> ToSuspend<A>(this TailRec<A> t)
        {
            return (Suspend<A>)t;
        }
    }

    public static class Interpreter
    {
        public static A Run<A>(TailRec<A> function)
        {
            var stack = new Stack<Object>();
            var temp = function;

            do {

                var t = Match.Object(temp)
                    .Case(x => x.Type == TailType.Return, x => x.ToReturn().Value)
                    .Case(x => x.Type == TailType.Suspend, x => x.ToSuspend().Run())
                    .Yield();

                stack.Push(t);

            } while(stack.Count > 0);

            return default(A);
        }
    }
}

