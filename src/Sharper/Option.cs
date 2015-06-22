using System;

namespace Sharper
{

    public abstract class Option<A>
    {
        public abstract Option<B> Map<B>(Func<A,B> f);

        public abstract Option<B> FlatMap<B>(Func<A,Option<B>> f);

        public abstract A GetValueOrDefault(A value);

        public abstract Option<A> OrElse(Option<A> other);

        public abstract Option<A> Filter(Func<A,Boolean> predicate);

        public abstract bool IsSome{ get; }

        public abstract bool IsNone{ get; }
    }
       
}
