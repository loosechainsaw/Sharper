using System;

namespace Sharper
{

    public class ExecuteAfter : IDisposable
    {

        public ExecuteAfter(Action action)
        {
            _f = action;
        }

        public void Dispose()
        {
            _f();
        }

        private readonly Action _f;
    }

}
