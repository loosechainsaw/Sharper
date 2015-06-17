using System;

namespace Sharper
{
    public class IO<A>
    {
        public IO(Func<A> f)
        {
            this.f = f;
        }

        public virtual IO<B> Map<B>(Func<A,B> m) => new IO<B>( () => m(f()));

        public virtual IO<B> FlatMap<B>(Func<A,IO<B>> m) => new IO<B>( () => m(f()).f());

        protected internal Func<A> f;
    }

}

