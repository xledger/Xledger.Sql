using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropSearchPropertyListStatement : DropUnownedObjectStatement, IEquatable<DropSearchPropertyListStatement> {
        public DropSearchPropertyListStatement(Identifier name = null, bool isIfExists = false) {
            this.name = name;
            this.isIfExists = isIfExists;
        }
    
        public ScriptDom.DropSearchPropertyListStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropSearchPropertyListStatement();
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
            return Equals(obj as DropSearchPropertyListStatement);
        } 
        
        public bool Equals(DropSearchPropertyListStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsIfExists, isIfExists)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropSearchPropertyListStatement left, DropSearchPropertyListStatement right) {
            return EqualityComparer<DropSearchPropertyListStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropSearchPropertyListStatement left, DropSearchPropertyListStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DropSearchPropertyListStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isIfExists, othr.isIfExists);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (DropSearchPropertyListStatement left, DropSearchPropertyListStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DropSearchPropertyListStatement left, DropSearchPropertyListStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DropSearchPropertyListStatement left, DropSearchPropertyListStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DropSearchPropertyListStatement left, DropSearchPropertyListStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static DropSearchPropertyListStatement FromMutable(ScriptDom.DropSearchPropertyListStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.DropSearchPropertyListStatement)) { throw new NotImplementedException("Unexpected subtype of DropSearchPropertyListStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropSearchPropertyListStatement(
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
    
    }

}
