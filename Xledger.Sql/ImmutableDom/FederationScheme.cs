using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FederationScheme : TSqlFragment, IEquatable<FederationScheme> {
        protected Identifier distributionName;
        protected Identifier columnName;
    
        public Identifier DistributionName => distributionName;
        public Identifier ColumnName => columnName;
    
        public FederationScheme(Identifier distributionName = null, Identifier columnName = null) {
            this.distributionName = distributionName;
            this.columnName = columnName;
        }
    
        public ScriptDom.FederationScheme ToMutableConcrete() {
            var ret = new ScriptDom.FederationScheme();
            ret.DistributionName = (ScriptDom.Identifier)distributionName?.ToMutable();
            ret.ColumnName = (ScriptDom.Identifier)columnName?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(distributionName is null)) {
                h = h * 23 + distributionName.GetHashCode();
            }
            if (!(columnName is null)) {
                h = h * 23 + columnName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as FederationScheme);
        } 
        
        public bool Equals(FederationScheme other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.DistributionName, distributionName)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.ColumnName, columnName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(FederationScheme left, FederationScheme right) {
            return EqualityComparer<FederationScheme>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FederationScheme left, FederationScheme right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (FederationScheme)that;
            compare = Comparer.DefaultInvariant.Compare(this.distributionName, othr.distributionName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.columnName, othr.columnName);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (FederationScheme left, FederationScheme right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(FederationScheme left, FederationScheme right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (FederationScheme left, FederationScheme right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(FederationScheme left, FederationScheme right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static FederationScheme FromMutable(ScriptDom.FederationScheme fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.FederationScheme)) { throw new NotImplementedException("Unexpected subtype of FederationScheme not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FederationScheme(
                distributionName: ImmutableDom.Identifier.FromMutable(fragment.DistributionName),
                columnName: ImmutableDom.Identifier.FromMutable(fragment.ColumnName)
            );
        }
    
    }

}
