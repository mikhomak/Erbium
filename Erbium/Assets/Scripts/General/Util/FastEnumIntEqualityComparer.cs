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

            public static int ToInt(TEnum enu)
            {
                return Wrapper(enu);
            }

            static BoxAvoidance()
            {
                ParameterExpression p = Expression.Parameter(typeof(TEnum), null);
                UnaryExpression c = Expression.ConvertChecked(p, typeof(int));

                Wrapper = Expression.Lambda<Func<TEnum, int>>(c, p).Compile();
            }
        }

        public bool Equals(TEnum firstEnum, TEnum secondEnum)
        {
            return BoxAvoidance.ToInt(firstEnum) ==
                   BoxAvoidance.ToInt(secondEnum);
        }

        public int GetHashCode(TEnum firstEnum)
        {
            return BoxAvoidance.ToInt(firstEnum);
        }
    }
}