using System;


namespace Sharper
{

    public class None<A> : Option<A>
    {
        public override Option<B> Map<B>(Func<A, B> _)
        {
            return  new None<B>();
        }

        public override Option<B> FlatMap<B>(Func<A, Option<B>> _)
        {
            return  new None<B>();
        }

        public override A GetValueOrDefault(A value)
        {
            return value;
        }

        public override Option<A> OrElse(Option<A> other)
        {
            return other;
        }

        public override Option<A> Filter(Func<A, bool> predicate)
        {
            return this;
        }

        public override bool IsNone {
            get {
                return true;
            }
        }

        public override bool IsSome {
            get {
                return false;
            }
        }
    }
    
}
