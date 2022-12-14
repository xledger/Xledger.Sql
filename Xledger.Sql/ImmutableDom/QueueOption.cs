using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class QueueOption : TSqlFragment, IEquatable<QueueOption> {
        protected ScriptDom.QueueOptionKind optionKind = ScriptDom.QueueOptionKind.Status;
    
        public ScriptDom.QueueOptionKind OptionKind => optionKind;
    
        public QueueOption(ScriptDom.QueueOptionKind optionKind = ScriptDom.QueueOptionKind.Status) {
            this.optionKind = optionKind;
        }
    
        public ScriptDom.QueueOption ToMutableConcrete() {
            var ret = new ScriptDom.QueueOption();
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
            return Equals(obj as QueueOption);
        } 
        
        public bool Equals(QueueOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.QueueOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(QueueOption left, QueueOption right) {
            return EqualityComparer<QueueOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(QueueOption left, QueueOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (QueueOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (QueueOption left, QueueOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(QueueOption left, QueueOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (QueueOption left, QueueOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(QueueOption left, QueueOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static QueueOption FromMutable(ScriptDom.QueueOption fragment) {
            return (QueueOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
