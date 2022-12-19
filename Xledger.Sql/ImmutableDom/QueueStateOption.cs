using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class QueueStateOption : QueueOption, IEquatable<QueueStateOption> {
        protected ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet;
    
        public ScriptDom.OptionState OptionState => optionState;
    
        public QueueStateOption(ScriptDom.OptionState optionState = ScriptDom.OptionState.NotSet, ScriptDom.QueueOptionKind optionKind = ScriptDom.QueueOptionKind.Status) {
            this.optionState = optionState;
            this.optionKind = optionKind;
        }
    
        public new ScriptDom.QueueStateOption ToMutableConcrete() {
            var ret = new ScriptDom.QueueStateOption();
            ret.OptionState = optionState;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionState.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as QueueStateOption);
        } 
        
        public bool Equals(QueueStateOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.OptionState, optionState)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.QueueOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(QueueStateOption left, QueueStateOption right) {
            return EqualityComparer<QueueStateOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(QueueStateOption left, QueueStateOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (QueueStateOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionState, othr.optionState);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (QueueStateOption left, QueueStateOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(QueueStateOption left, QueueStateOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (QueueStateOption left, QueueStateOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(QueueStateOption left, QueueStateOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static QueueStateOption FromMutable(ScriptDom.QueueStateOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.QueueStateOption)) { throw new NotImplementedException("Unexpected subtype of QueueStateOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new QueueStateOption(
                optionState: fragment.OptionState,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
