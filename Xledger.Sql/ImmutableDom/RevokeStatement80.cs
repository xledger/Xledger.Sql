using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class RevokeStatement80 : SecurityStatementBody80, IEquatable<RevokeStatement80> {
        protected bool grantOptionFor = false;
        protected bool cascadeOption = false;
        protected Identifier asClause;
    
        public bool GrantOptionFor => grantOptionFor;
        public bool CascadeOption => cascadeOption;
        public Identifier AsClause => asClause;
    
        public RevokeStatement80(bool grantOptionFor = false, bool cascadeOption = false, Identifier asClause = null, SecurityElement80 securityElement80 = null, SecurityUserClause80 securityUserClause80 = null) {
            this.grantOptionFor = grantOptionFor;
            this.cascadeOption = cascadeOption;
            this.asClause = asClause;
            this.securityElement80 = securityElement80;
            this.securityUserClause80 = securityUserClause80;
        }
    
        public ScriptDom.RevokeStatement80 ToMutableConcrete() {
            var ret = new ScriptDom.RevokeStatement80();
            ret.GrantOptionFor = grantOptionFor;
            ret.CascadeOption = cascadeOption;
            ret.AsClause = (ScriptDom.Identifier)asClause.ToMutable();
            ret.SecurityElement80 = (ScriptDom.SecurityElement80)securityElement80.ToMutable();
            ret.SecurityUserClause80 = (ScriptDom.SecurityUserClause80)securityUserClause80.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + grantOptionFor.GetHashCode();
            h = h * 23 + cascadeOption.GetHashCode();
            if (!(asClause is null)) {
                h = h * 23 + asClause.GetHashCode();
            }
            if (!(securityElement80 is null)) {
                h = h * 23 + securityElement80.GetHashCode();
            }
            if (!(securityUserClause80 is null)) {
                h = h * 23 + securityUserClause80.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as RevokeStatement80);
        } 
        
        public bool Equals(RevokeStatement80 other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.GrantOptionFor, grantOptionFor)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.CascadeOption, cascadeOption)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.AsClause, asClause)) {
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
        
        public static bool operator ==(RevokeStatement80 left, RevokeStatement80 right) {
            return EqualityComparer<RevokeStatement80>.Default.Equals(left, right);
        }
        
        public static bool operator !=(RevokeStatement80 left, RevokeStatement80 right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (RevokeStatement80)that;
            compare = Comparer.DefaultInvariant.Compare(this.grantOptionFor, othr.grantOptionFor);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.cascadeOption, othr.cascadeOption);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.asClause, othr.asClause);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.securityElement80, othr.securityElement80);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.securityUserClause80, othr.securityUserClause80);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (RevokeStatement80 left, RevokeStatement80 right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(RevokeStatement80 left, RevokeStatement80 right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (RevokeStatement80 left, RevokeStatement80 right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(RevokeStatement80 left, RevokeStatement80 right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
