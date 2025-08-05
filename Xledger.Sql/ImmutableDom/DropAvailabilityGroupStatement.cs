using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropAvailabilityGroupStatement : DropUnownedObjectStatement, IEquatable<DropAvailabilityGroupStatement> {
        public DropAvailabilityGroupStatement(Identifier name = null, bool isIfExists = false) {
            this.name = name;
            this.isIfExists = isIfExists;
        }
    
        public ScriptDom.DropAvailabilityGroupStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropAvailabilityGroupStatement();
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
            return Equals(obj as DropAvailabilityGroupStatement);
        } 
        
        public bool Equals(DropAvailabilityGroupStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsIfExists, isIfExists)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropAvailabilityGroupStatement left, DropAvailabilityGroupStatement right) {
            return EqualityComparer<DropAvailabilityGroupStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropAvailabilityGroupStatement left, DropAvailabilityGroupStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DropAvailabilityGroupStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isIfExists, othr.isIfExists);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (DropAvailabilityGroupStatement left, DropAvailabilityGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DropAvailabilityGroupStatement left, DropAvailabilityGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DropAvailabilityGroupStatement left, DropAvailabilityGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DropAvailabilityGroupStatement left, DropAvailabilityGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static DropAvailabilityGroupStatement FromMutable(ScriptDom.DropAvailabilityGroupStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.DropAvailabilityGroupStatement)) { throw new NotImplementedException("Unexpected subtype of DropAvailabilityGroupStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropAvailabilityGroupStatement(
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                isIfExists: fragment.IsIfExists
            );
        }
    
    }

}
