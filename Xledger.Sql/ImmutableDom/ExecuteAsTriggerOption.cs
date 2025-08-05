using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExecuteAsTriggerOption : TriggerOption, IEquatable<ExecuteAsTriggerOption> {
        protected ExecuteAsClause executeAsClause;
    
        public ExecuteAsClause ExecuteAsClause => executeAsClause;
    
        public ExecuteAsTriggerOption(ExecuteAsClause executeAsClause = null, ScriptDom.TriggerOptionKind optionKind = ScriptDom.TriggerOptionKind.Encryption) {
            this.executeAsClause = executeAsClause;
            this.optionKind = optionKind;
        }
    
        public new ScriptDom.ExecuteAsTriggerOption ToMutableConcrete() {
            var ret = new ScriptDom.ExecuteAsTriggerOption();
            ret.ExecuteAsClause = (ScriptDom.ExecuteAsClause)executeAsClause?.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(executeAsClause is null)) {
                h = h * 23 + executeAsClause.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExecuteAsTriggerOption);
        } 
        
        public bool Equals(ExecuteAsTriggerOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ExecuteAsClause>.Default.Equals(other.ExecuteAsClause, executeAsClause)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TriggerOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExecuteAsTriggerOption left, ExecuteAsTriggerOption right) {
            return EqualityComparer<ExecuteAsTriggerOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExecuteAsTriggerOption left, ExecuteAsTriggerOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ExecuteAsTriggerOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.executeAsClause, othr.executeAsClause);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ExecuteAsTriggerOption left, ExecuteAsTriggerOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ExecuteAsTriggerOption left, ExecuteAsTriggerOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ExecuteAsTriggerOption left, ExecuteAsTriggerOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ExecuteAsTriggerOption left, ExecuteAsTriggerOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ExecuteAsTriggerOption FromMutable(ScriptDom.ExecuteAsTriggerOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ExecuteAsTriggerOption)) { throw new NotImplementedException("Unexpected subtype of ExecuteAsTriggerOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExecuteAsTriggerOption(
                executeAsClause: ImmutableDom.ExecuteAsClause.FromMutable(fragment.ExecuteAsClause),
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
