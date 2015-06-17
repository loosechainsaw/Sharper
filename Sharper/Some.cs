using System;
using System.Collections.Generic;

namespace Sharper
{

    public class Some<A> : Option<A>
    {

        public Some(A value)
        {
            this.value = value;
        }

        public override Option<B> Map<B>(Func<A,B> f) => new Some<B>(f(value));

        public override Option<B> FlatMap<B>(Func<A,Option<B>> f) => f(value);

        public override A GetValueOrDefault(A _) => value;

        public override Option<A> OrElse(Option<A> other) => other;

        public override Option<A> Filter(Func<A, bool> predicate) => predicate(value) ? (Option<A>)this : new None<A>();

        public override bool Equals(object obj)
        {
            var other = obj as Some<A>;

            if(other == null)
                return false;

            return Object.Equals(other.value, value);

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

        public A Value{ get { return value; } }

        private readonly A value;
    }
    
}
