using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class StopRestoreOption : RestoreOption, IEquatable<StopRestoreOption> {
        protected ValueExpression mark;
        protected ValueExpression after;
        protected bool isStopAt = false;
    
        public ValueExpression Mark => mark;
        public ValueExpression After => after;
        public bool IsStopAt => isStopAt;
    
        public StopRestoreOption(ValueExpression mark = null, ValueExpression after = null, bool isStopAt = false, ScriptDom.RestoreOptionKind optionKind = 0) {
            this.mark = mark;
            this.after = after;
            this.isStopAt = isStopAt;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.StopRestoreOption ToMutableConcrete() {
            var ret = new ScriptDom.StopRestoreOption();
            ret.Mark = (ScriptDom.ValueExpression)mark.ToMutable();
            ret.After = (ScriptDom.ValueExpression)after.ToMutable();
            ret.IsStopAt = isStopAt;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(mark is null)) {
                h = h * 23 + mark.GetHashCode();
            }
            if (!(after is null)) {
                h = h * 23 + after.GetHashCode();
            }
            h = h * 23 + isStopAt.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as StopRestoreOption);
        } 
        
        public bool Equals(StopRestoreOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.Mark, mark)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.After, after)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsStopAt, isStopAt)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.RestoreOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(StopRestoreOption left, StopRestoreOption right) {
            return EqualityComparer<StopRestoreOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(StopRestoreOption left, StopRestoreOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (StopRestoreOption)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.mark, othr.mark);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.after, othr.after);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.isStopAt, othr.isStopAt);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static StopRestoreOption FromMutable(ScriptDom.StopRestoreOption fragment) {
            return (StopRestoreOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
