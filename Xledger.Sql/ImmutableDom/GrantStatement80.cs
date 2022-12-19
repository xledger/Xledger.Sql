using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class GrantStatement80 : SecurityStatementBody80, IEquatable<GrantStatement80> {
        protected bool withGrantOption = false;
        protected Identifier asClause;
    
        public bool WithGrantOption => withGrantOption;
        public Identifier AsClause => asClause;
    
        public GrantStatement80(bool withGrantOption = false, Identifier asClause = null, SecurityElement80 securityElement80 = null, SecurityUserClause80 securityUserClause80 = null) {
            this.withGrantOption = withGrantOption;
            this.asClause = asClause;
            this.securityElement80 = securityElement80;
            this.securityUserClause80 = securityUserClause80;
        }
    
        public ScriptDom.GrantStatement80 ToMutableConcrete() {
            var ret = new ScriptDom.GrantStatement80();
            ret.WithGrantOption = withGrantOption;
            ret.AsClause = (ScriptDom.Identifier)asClause?.ToMutable();
            ret.SecurityElement80 = (ScriptDom.SecurityElement80)securityElement80?.ToMutable();
            ret.SecurityUserClause80 = (ScriptDom.SecurityUserClause80)securityUserClause80?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + withGrantOption.GetHashCode();
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
            return Equals(obj as GrantStatement80);
        } 
        
        public bool Equals(GrantStatement80 other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.WithGrantOption, withGrantOption)) {
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
        
        public static bool operator ==(GrantStatement80 left, GrantStatement80 right) {
            return EqualityComparer<GrantStatement80>.Default.Equals(left, right);
        }
        
        public static bool operator !=(GrantStatement80 left, GrantStatement80 right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (GrantStatement80)that;
            compare = Comparer.DefaultInvariant.Compare(this.withGrantOption, othr.withGrantOption);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.asClause, othr.asClause);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.securityElement80, othr.securityElement80);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.securityUserClause80, othr.securityUserClause80);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (GrantStatement80 left, GrantStatement80 right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(GrantStatement80 left, GrantStatement80 right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (GrantStatement80 left, GrantStatement80 right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(GrantStatement80 left, GrantStatement80 right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static GrantStatement80 FromMutable(ScriptDom.GrantStatement80 fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.GrantStatement80)) { throw new NotImplementedException("Unexpected subtype of GrantStatement80 not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new GrantStatement80(
                withGrantOption: fragment.WithGrantOption,
                asClause: ImmutableDom.Identifier.FromMutable(fragment.AsClause),
                securityElement80: ImmutableDom.SecurityElement80.FromMutable(fragment.SecurityElement80),
                securityUserClause80: ImmutableDom.SecurityUserClause80.FromMutable(fragment.SecurityUserClause80)
            );
        }
    
    }

}
