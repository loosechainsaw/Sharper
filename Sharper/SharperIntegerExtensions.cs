using System;

namespace Sharper
{

    public static class SharperIntegerExtensions
    {
        public static Int32 Succ(this Int32 value)
        {
            checked
            {
                return value + 1;
            }
        }

        public static Int32 Pred(this Int32 value)
        {
            checked
            {
                return value - 1;
            }
        }

        public static Int32 Negate(this Int32 value)
        {
            return value * (-1);
        }

        public static Boolean IsEven(this Int32 value)
        {
            return value % 2 == 0;
        }

        public static Boolean IsOdd(this Int32 value)
        {
            return !IsEven(value);
        }
    }

}
