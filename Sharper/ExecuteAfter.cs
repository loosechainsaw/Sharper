using System;
using System.Collections.Generic;

namespace Sharper
{

    public class ExecuteAfter : IDisposable
    {

        public ExecuteAfter(Action action)
        {
            this.f = action;
        }

        public void Dispose()
        {
            f();
        }

        private readonly Action f;
    }
    
}
