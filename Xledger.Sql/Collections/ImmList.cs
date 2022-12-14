using System;
using System.Collections;
using System.Collections.Generic;

namespace Xledger.Sql.Collections {
    internal sealed class ImmList<T> : IReadOnlyList<T>, IEquatable<ImmList<T>>, IComparable, IComparable<ImmList<T>> {
        readonly T[] data;

        ImmList(T[] data) {
            this.data = data;
        }

        internal static IReadOnlyList<T> FromList(IReadOnlyList<T> list) {
            if (list is null || list.Count == 0) {
                return Empty;
            } else if (list is ImmList<T> immList) {
                return immList;
            } else {
                var data = new T[list.Count];
                for (int i = 0; i < list.Count; i++) {
                    data[i] = list[i];
                }
                return new ImmList<T>(data);
            }
        }

        internal static IReadOnlyList<T> FromList(IList<T> list) {
            if (list is null || list.Count == 0) {
                return Empty;
            } else if (list is ImmList<T> immList) {
                return immList;
            } else {
                var data = new T[list.Count];
                for (int i = 0; i < list.Count; i++) {
                    data[i] = list[i];
                }
                return new ImmList<T>(data);
            }
        }

        /// <summary>
        /// Returns a mapped list, treating null empty;
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="list"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static IReadOnlyList<U> SelectList<U>(IReadOnlyList<T> list, Func<T, U> f) {
            if (f is null) {
                throw new ArgumentNullException(nameof(f));
            }
            if (list is null || list.Count == 0) {
                return ImmList<U>.Empty;
            }
            var data = new U[list.Count];
            for (int i = 0; i < list.Count; i++) {
                data[i] = f(list[i]);
            }
            return new ImmList<U>(data);
        }

        /// <summary>
        /// Returns a mapped list, treating null empty;
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="list"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static IReadOnlyList<U> SelectList<U>(IList<T> list, Func<T, U> f) {
            if (f is null) {
                throw new ArgumentNullException(nameof(f));
            }
            if (list is null || list.Count == 0) {
                return ImmList<U>.Empty;
            }
            var data = new U[list.Count];
            for (int i = 0; i < list.Count; i++) {
                data[i] = f(list[i]);
            }
            return new ImmList<U>(data);
        }

        internal static ImmList<T> Empty = new ImmList<T>(Array.Empty<T>());

        public T this[int index] => data[index];

        public int Count => data.Length;

        public IEnumerator<T> GetEnumerator() {
            foreach (var e in data) {
                yield return e;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return data.GetEnumerator();
        }

        public override bool Equals(object obj) {
            return Equals(obj as ImmList<T>);
        }

        public bool Equals(ImmList<T> other) {
            if (other is null) {
                return false;
            }
            if (other.Count != data.Length) {
                return false;
            }
            for (int i = 0; i < data.Length; i++) {
                if (!EqualityComparer<T>.Default.Equals(other[i], data[i])) {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode() {
            var h = 17;
            foreach (var e in data) {
                if (e == null) {
                    h = h * 23 + e.GetHashCode();
                }
            }
            return h;
        }

        public int CompareTo(object that) {
            return CompareTo((ImmList<T>)that);
        }

        public int CompareTo(ImmList<T> that) {
            return StructuralComparisons.StructuralComparer.Compare(this.data, that.data);
        }

        public static bool operator ==(ImmList<T> left, ImmList<T> right) {
            return EqualityComparer<ImmList<T>>.Default.Equals(left, right);
        }

        public static bool operator !=(ImmList<T> left, ImmList<T> right) {
            return !(left == right);
        }
    }
}
