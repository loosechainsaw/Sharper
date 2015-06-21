using System;
using System.Threading.Tasks;

namespace Sharper
{

    public class TaskEither<A,B>
    {
        public TaskEither(Task<Either<A,B>> t)
        {
            this.t = t;
        }

        public TaskEither<A,C> Map<C>(Func<B,C> f)
        {
            return t.Select(u => u.Map(f)).EitherT();
        }

        public TaskEither<A,C> FlatMap<C>(Func<B,TaskEither<A,C>> m)
        {
//            var z = t.ContinueWith(ant => {
//                var e = ant.Result;
//                var result = Match.Object(e)
//                    .Case(x => x.IsLeft, () => new TaskEither<A,C>(Task.FromResult(e.Map(d => d))))
//                    .Case(x => x.IsRight, () => m(e.ConvertToSome().Value))
//                    .Yield();
//                return result.t;
//            }).Unwrap();
//            return new TaskEither<A,C>(z);
            return null;
        }

        private readonly Task<Either<A,B>> t;
    }
}
