using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Xledger.Sql.Collections {
    internal class ImmList<T> : IReadOnlyList<T>, IEquatable<ImmList<T>> {
        T[] data;

        ImmList(T[] data) {
            this.data = data;
        }

        internal static IReadOnlyList<T> FromList(IReadOnlyList<T> list) {
            if (list is ImmList<T>) {
                return list;
            } else {
                if (list is null) {
                    throw new ArgumentNullException(nameof(list));
                }

                if (list.Count == 0) {
                    return Empty;
                }

                var data = new T[list.Count];
                for (int i = 0; i < list.Count; i++) {
                    data[i] = list[i];
                }
                return new ImmList<T>(data);
            }
        }

        internal static ImmList<T> Empty = new ImmList<T>(new T[0]);

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

        public static bool operator ==(ImmList<T> left, ImmList<T> right) {
            return EqualityComparer<ImmList<T>>.Default.Equals(left, right);
        }

        public static bool operator !=(ImmList<T> left, ImmList<T> right) {
            return !(left == right);
        }
    }
}
