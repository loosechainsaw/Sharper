using System;

namespace Sharper
{

    public class IO<A>
    {
        public IO(Func<A> f)
        {
            this.f = f;
        }

        public A PerformUnsafeIO()
        {
            return f();
        }

        public virtual IO<B> Map<B>(Func<A, B> m)
        {
            return new IO<B>(() => m(f()));
        }

        public virtual IO<B> FlatMap<B>(Func<A, IO<B>> m)
        {
            return new IO<B>(() => m(f()).f());
        }

        protected internal Func<A> f;
    }


}

