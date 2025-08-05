using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class QueueExecuteAsOption : QueueOption, IEquatable<QueueExecuteAsOption> {
        protected ExecuteAsClause optionValue;
    
        public ExecuteAsClause OptionValue => optionValue;
    
        public QueueExecuteAsOption(ExecuteAsClause optionValue = null, ScriptDom.QueueOptionKind optionKind = ScriptDom.QueueOptionKind.Status) {
            this.optionValue = optionValue;
            this.optionKind = optionKind;
        }
    
        public new ScriptDom.QueueExecuteAsOption ToMutableConcrete() {
            var ret = new ScriptDom.QueueExecuteAsOption();
            ret.OptionValue = (ScriptDom.ExecuteAsClause)optionValue?.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(optionValue is null)) {
                h = h * 23 + optionValue.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as QueueExecuteAsOption);
        } 
        
        public bool Equals(QueueExecuteAsOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ExecuteAsClause>.Default.Equals(other.OptionValue, optionValue)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.QueueOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(QueueExecuteAsOption left, QueueExecuteAsOption right) {
            return EqualityComparer<QueueExecuteAsOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(QueueExecuteAsOption left, QueueExecuteAsOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (QueueExecuteAsOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionValue, othr.optionValue);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (QueueExecuteAsOption left, QueueExecuteAsOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(QueueExecuteAsOption left, QueueExecuteAsOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (QueueExecuteAsOption left, QueueExecuteAsOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(QueueExecuteAsOption left, QueueExecuteAsOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static QueueExecuteAsOption FromMutable(ScriptDom.QueueExecuteAsOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.QueueExecuteAsOption)) { throw new NotImplementedException("Unexpected subtype of QueueExecuteAsOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new QueueExecuteAsOption(
                optionValue: ImmutableDom.ExecuteAsClause.FromMutable(fragment.OptionValue),
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
