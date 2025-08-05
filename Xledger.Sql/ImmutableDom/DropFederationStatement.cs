using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropFederationStatement : DropUnownedObjectStatement, IEquatable<DropFederationStatement> {
        public DropFederationStatement(Identifier name = null, bool isIfExists = false) {
            this.name = name;
            this.isIfExists = isIfExists;
        }
    
        public ScriptDom.DropFederationStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropFederationStatement();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.IsIfExists = isIfExists;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + isIfExists.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropFederationStatement);
        } 
        
        public bool Equals(DropFederationStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsIfExists, isIfExists)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropFederationStatement left, DropFederationStatement right) {
            return EqualityComparer<DropFederationStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropFederationStatement left, DropFederationStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DropFederationStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isIfExists, othr.isIfExists);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (DropFederationStatement left, DropFederationStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DropFederationStatement left, DropFederationStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DropFederationStatement left, DropFederationStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DropFederationStatement left, DropFederationStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static DropFederationStatement FromMutable(ScriptDom.DropFederationStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.DropFederationStatement)) { throw new NotImplementedException("Unexpected subtype of DropFederationStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropFederationStatement(
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
    
    }

}
