using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class Privilege80 : TSqlFragment, IEquatable<Privilege80> {
        protected IReadOnlyList<Identifier> columns;
        protected ScriptDom.PrivilegeType80 privilegeType80 = ScriptDom.PrivilegeType80.All;
    
        public IReadOnlyList<Identifier> Columns => columns;
        public ScriptDom.PrivilegeType80 PrivilegeType80 => privilegeType80;
    
        public Privilege80(IReadOnlyList<Identifier> columns = null, ScriptDom.PrivilegeType80 privilegeType80 = ScriptDom.PrivilegeType80.All) {
            this.columns = ImmList<Identifier>.FromList(columns);
            this.privilegeType80 = privilegeType80;
        }
    
        public ScriptDom.Privilege80 ToMutableConcrete() {
            var ret = new ScriptDom.Privilege80();
            ret.Columns.AddRange(columns.SelectList(c => (ScriptDom.Identifier)c?.ToMutable()));
            ret.PrivilegeType80 = privilegeType80;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + columns.GetHashCode();
            h = h * 23 + privilegeType80.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as Privilege80);
        } 
        
        public bool Equals(Privilege80 other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.PrivilegeType80>.Default.Equals(other.PrivilegeType80, privilegeType80)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(Privilege80 left, Privilege80 right) {
            return EqualityComparer<Privilege80>.Default.Equals(left, right);
        }
        
        public static bool operator !=(Privilege80 left, Privilege80 right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (Privilege80)that;
            compare = Comparer.DefaultInvariant.Compare(this.columns, othr.columns);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.privilegeType80, othr.privilegeType80);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (Privilege80 left, Privilege80 right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(Privilege80 left, Privilege80 right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (Privilege80 left, Privilege80 right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(Privilege80 left, Privilege80 right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
