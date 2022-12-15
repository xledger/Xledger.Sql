using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TriggerOption : TSqlFragment, IEquatable<TriggerOption> {
        protected ScriptDom.TriggerOptionKind optionKind = ScriptDom.TriggerOptionKind.Encryption;
    
        public ScriptDom.TriggerOptionKind OptionKind => optionKind;
    
        public TriggerOption(ScriptDom.TriggerOptionKind optionKind = ScriptDom.TriggerOptionKind.Encryption) {
            this.optionKind = optionKind;
        }
    
        public ScriptDom.TriggerOption ToMutableConcrete() {
            var ret = new ScriptDom.TriggerOption();
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
            return Equals(obj as TriggerOption);
        } 
        
        public bool Equals(TriggerOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.TriggerOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TriggerOption left, TriggerOption right) {
            return EqualityComparer<TriggerOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TriggerOption left, TriggerOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (TriggerOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (TriggerOption left, TriggerOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(TriggerOption left, TriggerOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (TriggerOption left, TriggerOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(TriggerOption left, TriggerOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
