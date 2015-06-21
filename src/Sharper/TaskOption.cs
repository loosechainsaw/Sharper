using System;
using System.Threading.Tasks;

namespace Sharper
{

    public class TaskOption<A>
    {
        public TaskOption(Task<Option<A>> t)
        {
            this.t = t;
        }

        public TaskOption<B> Map<B>(Func<A,B> f)
        {
            return t.Select(u => u.Map(f)).OptionT();
        }

        public TaskOption<B> FlatMap<B>(Func<A,TaskOption<B>> m)
        {
            var z = t.ContinueWith(ant => {
                var opt = ant.Result;
                var result = Match.Object(opt)
                    .Case(x => x.IsNone, () => new TaskOption<B>(Task.FromResult((Option<B>)new None<B>())))
                    .Case(x => x.IsSome, () => m(opt.ToSome().Value))
                    .Yield();
                return result.t;
            }).Unwrap();
            return new TaskOption<B>(z);
        }

        private readonly Task<Option<A>> t;
    }

}
