using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AdHocDataSource : TSqlFragment, IEquatable<AdHocDataSource> {
        protected StringLiteral providerName;
        protected StringLiteral initString;
    
        public StringLiteral ProviderName => providerName;
        public StringLiteral InitString => initString;
    
        public AdHocDataSource(StringLiteral providerName = null, StringLiteral initString = null) {
            this.providerName = providerName;
            this.initString = initString;
        }
    
        public ScriptDom.AdHocDataSource ToMutableConcrete() {
            var ret = new ScriptDom.AdHocDataSource();
            ret.ProviderName = (ScriptDom.StringLiteral)providerName.ToMutable();
            ret.InitString = (ScriptDom.StringLiteral)initString.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(providerName is null)) {
                h = h * 23 + providerName.GetHashCode();
            }
            if (!(initString is null)) {
                h = h * 23 + initString.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AdHocDataSource);
        } 
        
        public bool Equals(AdHocDataSource other) {
            if (other is null) { return false; }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.ProviderName, providerName)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.InitString, initString)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AdHocDataSource left, AdHocDataSource right) {
            return EqualityComparer<AdHocDataSource>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AdHocDataSource left, AdHocDataSource right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AdHocDataSource)that;
            compare = Comparer.DefaultInvariant.Compare(this.providerName, othr.providerName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.initString, othr.initString);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AdHocDataSource left, AdHocDataSource right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AdHocDataSource left, AdHocDataSource right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AdHocDataSource left, AdHocDataSource right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AdHocDataSource left, AdHocDataSource right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
