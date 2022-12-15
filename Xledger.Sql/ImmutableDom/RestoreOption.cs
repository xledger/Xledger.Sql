using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class RestoreOption : TSqlFragment, IEquatable<RestoreOption> {
        protected ScriptDom.RestoreOptionKind optionKind = 0;
    
        public ScriptDom.RestoreOptionKind OptionKind => optionKind;
    
        public RestoreOption(ScriptDom.RestoreOptionKind optionKind = 0) {
            this.optionKind = optionKind;
        }
    
        public ScriptDom.RestoreOption ToMutableConcrete() {
            var ret = new ScriptDom.RestoreOption();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as RestoreOption);
        } 
        
        public bool Equals(RestoreOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.RestoreOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(RestoreOption left, RestoreOption right) {
            return EqualityComparer<RestoreOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(RestoreOption left, RestoreOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (RestoreOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (RestoreOption left, RestoreOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(RestoreOption left, RestoreOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (RestoreOption left, RestoreOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(RestoreOption left, RestoreOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
