using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FunctionOption : TSqlFragment, IEquatable<FunctionOption> {
        protected ScriptDom.FunctionOptionKind optionKind = ScriptDom.FunctionOptionKind.Encryption;
    
        public ScriptDom.FunctionOptionKind OptionKind => optionKind;
    
        public FunctionOption(ScriptDom.FunctionOptionKind optionKind = ScriptDom.FunctionOptionKind.Encryption) {
            this.optionKind = optionKind;
        }
    
        public ScriptDom.FunctionOption ToMutableConcrete() {
            var ret = new ScriptDom.FunctionOption();
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
            return Equals(obj as FunctionOption);
        } 
        
        public bool Equals(FunctionOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.FunctionOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(FunctionOption left, FunctionOption right) {
            return EqualityComparer<FunctionOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FunctionOption left, FunctionOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (FunctionOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (FunctionOption left, FunctionOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(FunctionOption left, FunctionOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (FunctionOption left, FunctionOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(FunctionOption left, FunctionOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static FunctionOption FromMutable(ScriptDom.FunctionOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.FunctionOption)) { return TSqlFragment.FromMutable(fragment) as FunctionOption; }
            return new FunctionOption(
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
