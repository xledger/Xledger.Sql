using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class Permission : TSqlFragment, IEquatable<Permission> {
        protected IReadOnlyList<Identifier> identifiers;
        protected IReadOnlyList<Identifier> columns;
    
        public IReadOnlyList<Identifier> Identifiers => identifiers;
        public IReadOnlyList<Identifier> Columns => columns;
    
        public Permission(IReadOnlyList<Identifier> identifiers = null, IReadOnlyList<Identifier> columns = null) {
            this.identifiers = ImmList<Identifier>.FromList(identifiers);
            this.columns = ImmList<Identifier>.FromList(columns);
        }
    
        public ScriptDom.Permission ToMutableConcrete() {
            var ret = new ScriptDom.Permission();
            ret.Identifiers.AddRange(identifiers.SelectList(c => (ScriptDom.Identifier)c?.ToMutable()));
            ret.Columns.AddRange(columns.SelectList(c => (ScriptDom.Identifier)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + identifiers.GetHashCode();
            h = h * 23 + columns.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as Permission);
        } 
        
        public bool Equals(Permission other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.Identifiers, identifiers)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(Permission left, Permission right) {
            return EqualityComparer<Permission>.Default.Equals(left, right);
        }
        
        public static bool operator !=(Permission left, Permission right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (Permission)that;
            compare = Comparer.DefaultInvariant.Compare(this.identifiers, othr.identifiers);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.columns, othr.columns);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (Permission left, Permission right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(Permission left, Permission right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (Permission left, Permission right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(Permission left, Permission right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static Permission FromMutable(ScriptDom.Permission fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.Permission)) { throw new NotImplementedException("Unexpected subtype of Permission not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new Permission(
                identifiers: fragment.Identifiers.SelectList(ImmutableDom.Identifier.FromMutable),
                columns: fragment.Columns.SelectList(ImmutableDom.Identifier.FromMutable)
            );
        }
    
    }

}
