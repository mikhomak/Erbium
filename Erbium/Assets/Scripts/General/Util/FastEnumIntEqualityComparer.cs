using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace General.Util
{
    internal struct FastEnumIntEqualityComparer<TEnum> : IEqualityComparer<TEnum>
        where TEnum : struct
    {
        private static class BoxAvoidance
        {
            private static readonly Func<TEnum, int> Wrapper;

            public static int toInt(TEnum enu)
            {
                return Wrapper(enu);
            }

            static BoxAvoidance()
            {
                var p = Expression.Parameter(typeof(TEnum), null);
                var c = Expression.ConvertChecked(p, typeof(int));

                Wrapper = Expression.Lambda<Func<TEnum, int>>(c, p).Compile();
            }
        }

        public bool Equals(TEnum firstEnum, TEnum secondEnum)
        {
            return BoxAvoidance.toInt(firstEnum) ==
                   BoxAvoidance.toInt(secondEnum);
        }

        public int GetHashCode(TEnum firstEnum)
        {
            return BoxAvoidance.toInt(firstEnum);
        }
    }
}