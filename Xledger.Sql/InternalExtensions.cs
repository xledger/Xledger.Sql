using System.Collections.Generic;

namespace Xledger.Sql {
    internal static class InternalExtensions {
        internal static void AddRange<T>(this IList<T> @this, IEnumerable<T> xs) {
            foreach (var x in xs) {
                @this.Add(x);
            }
        }
    }
}
