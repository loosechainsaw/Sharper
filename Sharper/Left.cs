using System;
using System.Collections.Generic;

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

        private A error;
    }

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

        private B value;
    }
}

