using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropSymmetricKeyStatement : DropUnownedObjectStatement, IEquatable<DropSymmetricKeyStatement> {
        protected bool removeProviderKey = false;
    
        public bool RemoveProviderKey => removeProviderKey;
    
        public DropSymmetricKeyStatement(bool removeProviderKey = false, Identifier name = null, bool isIfExists = false) {
            this.removeProviderKey = removeProviderKey;
            this.name = name;
            this.isIfExists = isIfExists;
        }
    
        public ScriptDom.DropSymmetricKeyStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropSymmetricKeyStatement();
            ret.RemoveProviderKey = removeProviderKey;
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.IsIfExists = isIfExists;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + removeProviderKey.GetHashCode();
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + isIfExists.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropSymmetricKeyStatement);
        } 
        
        public bool Equals(DropSymmetricKeyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.RemoveProviderKey, removeProviderKey)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsIfExists, isIfExists)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropSymmetricKeyStatement left, DropSymmetricKeyStatement right) {
            return EqualityComparer<DropSymmetricKeyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropSymmetricKeyStatement left, DropSymmetricKeyStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DropSymmetricKeyStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.removeProviderKey, othr.removeProviderKey);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isIfExists, othr.isIfExists);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (DropSymmetricKeyStatement left, DropSymmetricKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DropSymmetricKeyStatement left, DropSymmetricKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DropSymmetricKeyStatement left, DropSymmetricKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DropSymmetricKeyStatement left, DropSymmetricKeyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static DropSymmetricKeyStatement FromMutable(ScriptDom.DropSymmetricKeyStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.DropSymmetricKeyStatement)) { throw new NotImplementedException("Unexpected subtype of DropSymmetricKeyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropSymmetricKeyStatement(
                removeProviderKey: fragment.RemoveProviderKey,
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
    
    }

}
