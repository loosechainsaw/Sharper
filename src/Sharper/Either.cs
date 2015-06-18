using System;

namespace Sharper
{

    public abstract class Either<A,B>
    {
        public abstract Either<A,C> Map<C>(Func<B,C> f);

        public abstract Either<A,C> FlatMap<C>(Func<B,Either<A,C>> f);

        public abstract B GetValueOrDefault(B value);

        public abstract Either<A,B> OrElse(Either<A,B> other);

        public abstract bool IsLeft{ get; }

        public abstract bool IsRight{ get; }
    }

    
}
