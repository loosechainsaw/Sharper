using System;

namespace Sharper
{

    public class Unit
    {
        private Unit()
        {
        }

        public static readonly Unit Instance = new Unit();
    }
    
}
