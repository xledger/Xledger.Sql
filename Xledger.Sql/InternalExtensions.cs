using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xledger.Sql.Collections;

namespace Xledger.Sql {
    internal static class InternalExtensions {
        internal static void AddRange<T>(this IList<T> @this, IEnumerable<T> xs) {
            foreach (var x in xs) {
                @this.Add(x);
            }
        }

        internal static IReadOnlyList<U> SelectList<T, U>(this IList<T> @this, Func<T, U> f) {
            return ImmList<T>.SelectList(@this, f);
        }

        internal static IReadOnlyList<U> SelectList<T, U>(this IReadOnlyList<T> @this, Func<T, U> f) {
            return ImmList<T>.SelectList(@this, f);
        }
    }
}
