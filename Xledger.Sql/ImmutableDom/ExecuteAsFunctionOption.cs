using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExecuteAsFunctionOption : FunctionOption, IEquatable<ExecuteAsFunctionOption> {
        protected ExecuteAsClause executeAs;
    
        public ExecuteAsClause ExecuteAs => executeAs;
    
        public ExecuteAsFunctionOption(ExecuteAsClause executeAs = null, ScriptDom.FunctionOptionKind optionKind = ScriptDom.FunctionOptionKind.Encryption) {
            this.executeAs = executeAs;
            this.optionKind = optionKind;
        }
    
        public new ScriptDom.ExecuteAsFunctionOption ToMutableConcrete() {
            var ret = new ScriptDom.ExecuteAsFunctionOption();
            ret.ExecuteAs = (ScriptDom.ExecuteAsClause)executeAs?.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(executeAs is null)) {
                h = h * 23 + executeAs.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExecuteAsFunctionOption);
        } 
        
        public bool Equals(ExecuteAsFunctionOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ExecuteAsClause>.Default.Equals(other.ExecuteAs, executeAs)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.FunctionOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExecuteAsFunctionOption left, ExecuteAsFunctionOption right) {
            return EqualityComparer<ExecuteAsFunctionOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExecuteAsFunctionOption left, ExecuteAsFunctionOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ExecuteAsFunctionOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.executeAs, othr.executeAs);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ExecuteAsFunctionOption left, ExecuteAsFunctionOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ExecuteAsFunctionOption left, ExecuteAsFunctionOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ExecuteAsFunctionOption left, ExecuteAsFunctionOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ExecuteAsFunctionOption left, ExecuteAsFunctionOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ExecuteAsFunctionOption FromMutable(ScriptDom.ExecuteAsFunctionOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ExecuteAsFunctionOption)) { throw new NotImplementedException("Unexpected subtype of ExecuteAsFunctionOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExecuteAsFunctionOption(
                executeAs: ImmutableDom.ExecuteAsClause.FromMutable(fragment.ExecuteAs),
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
