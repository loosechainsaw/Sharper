using System;

namespace Sharper
{

    public class Some<A> : Option<A>
    {

        public Some(A value)
        {
            this._value = value;
        }

        public override Option<B> Map<B>(Func<A, B> f)
        {
            return new Some<B>(f(_value));
        }

        public override Option<B> FlatMap<B>(Func<A, Option<B>> f)
        {
            return f(_value);
        }

        public override A GetValueOrDefault(A _)
        {
            return _value;
        }

        public override Option<A> OrElse(Option<A> other)
        {
            return this;
        }

        public override Option<A> Filter(Func<A, bool> predicate)
        {
            return predicate(_value) ? (Option<A>)this : new None<A>();
        } 

        public override bool Equals(object obj)
        {
            var other = obj as Some<A>;

            if(other == null)
                return false;

            return Equals(other._value, _value);

        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override bool IsNone {
            get {
                return false;
            }
        }

        public override bool IsSome {
            get {
                return true;
            }
        }

        public A Value{ get { return _value; } }

        private readonly A _value;
    }
    
}
