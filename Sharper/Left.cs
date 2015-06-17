using System;

namespace Sharper
{

    public class Left<A,B> : Either<A,B>
    {

        public Left(A error)
        {
            this.error = error;
        }

        public override Either<A,C> Map<C>(Func<B,C> f)
        {
            return new Left<A, C>(error);
        }

        public override Either<A,C> FlatMap<C>(Func<B,Either<A,C>> f)
        {
            return new Left<A, C>(error);
        }

        public override B GetValueOrDefault(B value)
        {
            return value;
        }

        public override Either<A,B> OrElse(Either<A,B> other)
        {
            return other;
        }

        public override bool IsLeft{ get { return true; } }

        public override bool IsRight{ get { return false; } }

        internal A error;
    }

}

