using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DenyStatement80 : SecurityStatementBody80, IEquatable<DenyStatement80> {
        protected bool cascadeOption = false;
    
        public bool CascadeOption => cascadeOption;
    
        public DenyStatement80(bool cascadeOption = false, SecurityElement80 securityElement80 = null, SecurityUserClause80 securityUserClause80 = null) {
            this.cascadeOption = cascadeOption;
            this.securityElement80 = securityElement80;
            this.securityUserClause80 = securityUserClause80;
        }
    
        public ScriptDom.DenyStatement80 ToMutableConcrete() {
            var ret = new ScriptDom.DenyStatement80();
            ret.CascadeOption = cascadeOption;
            ret.SecurityElement80 = (ScriptDom.SecurityElement80)securityElement80?.ToMutable();
            ret.SecurityUserClause80 = (ScriptDom.SecurityUserClause80)securityUserClause80?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + cascadeOption.GetHashCode();
            if (!(securityElement80 is null)) {
                h = h * 23 + securityElement80.GetHashCode();
            }
            if (!(securityUserClause80 is null)) {
                h = h * 23 + securityUserClause80.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DenyStatement80);
        } 
        
        public bool Equals(DenyStatement80 other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.CascadeOption, cascadeOption)) {
                return false;
            }
            if (!EqualityComparer<SecurityElement80>.Default.Equals(other.SecurityElement80, securityElement80)) {
                return false;
            }
            if (!EqualityComparer<SecurityUserClause80>.Default.Equals(other.SecurityUserClause80, securityUserClause80)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DenyStatement80 left, DenyStatement80 right) {
            return EqualityComparer<DenyStatement80>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DenyStatement80 left, DenyStatement80 right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DenyStatement80)that;
            compare = Comparer.DefaultInvariant.Compare(this.cascadeOption, othr.cascadeOption);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.securityElement80, othr.securityElement80);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.securityUserClause80, othr.securityUserClause80);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (DenyStatement80 left, DenyStatement80 right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DenyStatement80 left, DenyStatement80 right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DenyStatement80 left, DenyStatement80 right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DenyStatement80 left, DenyStatement80 right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
