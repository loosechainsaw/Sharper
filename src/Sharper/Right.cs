using System;

namespace Sharper
{

    public class Right<A,B> : Either<A,B>
    {

        public Right(B value)
        {
            this.value = value;
        }

        public override Either<A,C> Map<C>(Func<B,C> f)
        {
            return new Right<A, C>(f(value));
        }

        public override Either<A,C> FlatMap<C>(Func<B,Either<A,C>> f)
        {
            return f(value);
        }

        public override B GetValueOrDefault(B value)
        {
            return this.value;
        }

        public override Either<A,B> OrElse(Either<A,B> other)
        {
            return this;
        }

        public override bool IsLeft{ get { return false; } }

        public override bool IsRight{ get { return true; } }

        internal B value;
    }

}
