using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace General.Util {
    struct FastEnumIntEqualityComparer<TEnum> : IEqualityComparer<TEnum>
        where TEnum : struct {
        static class BoxAvoidance {
            static readonly Func<TEnum, int> _wrapper;

            public static int ToInt(TEnum enu) {
                return _wrapper(enu);
            }

            static BoxAvoidance() {
                var p = Expression.Parameter(typeof(TEnum), null);
                var c = Expression.ConvertChecked(p, typeof(int));

                _wrapper = Expression.Lambda<Func<TEnum, int>>(c, p).Compile();
            }
        }

        public bool Equals(TEnum firstEnum, TEnum secondEnum) {
            return BoxAvoidance.ToInt(firstEnum) ==
                   BoxAvoidance.ToInt(secondEnum);
        }

        public int GetHashCode(TEnum firstEnum) {
            return BoxAvoidance.ToInt(firstEnum);
        }
    }
}