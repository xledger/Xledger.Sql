using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExecutableStringList : ExecutableEntity, IEquatable<ExecutableStringList> {
        protected IReadOnlyList<ValueExpression> strings;
    
        public IReadOnlyList<ValueExpression> Strings => strings;
    
        public ExecutableStringList(IReadOnlyList<ValueExpression> strings = null, IReadOnlyList<ExecuteParameter> parameters = null) {
            this.strings = ImmList<ValueExpression>.FromList(strings);
            this.parameters = ImmList<ExecuteParameter>.FromList(parameters);
        }
    
        public ScriptDom.ExecutableStringList ToMutableConcrete() {
            var ret = new ScriptDom.ExecutableStringList();
            ret.Strings.AddRange(strings.SelectList(c => (ScriptDom.ValueExpression)c?.ToMutable()));
            ret.Parameters.AddRange(parameters.SelectList(c => (ScriptDom.ExecuteParameter)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + strings.GetHashCode();
            h = h * 23 + parameters.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExecutableStringList);
        } 
        
        public bool Equals(ExecutableStringList other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<ValueExpression>>.Default.Equals(other.Strings, strings)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ExecuteParameter>>.Default.Equals(other.Parameters, parameters)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExecutableStringList left, ExecutableStringList right) {
            return EqualityComparer<ExecutableStringList>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExecutableStringList left, ExecutableStringList right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ExecutableStringList)that;
            compare = Comparer.DefaultInvariant.Compare(this.strings, othr.strings);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.parameters, othr.parameters);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ExecutableStringList left, ExecutableStringList right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ExecutableStringList left, ExecutableStringList right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ExecutableStringList left, ExecutableStringList right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ExecutableStringList left, ExecutableStringList right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ExecutableStringList FromMutable(ScriptDom.ExecutableStringList fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ExecutableStringList)) { throw new NotImplementedException("Unexpected subtype of ExecutableStringList not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExecutableStringList(
                strings: fragment.Strings.SelectList(ImmutableDom.ValueExpression.FromMutable),
                parameters: fragment.Parameters.SelectList(ImmutableDom.ExecuteParameter.FromMutable)
            );
        }
    
    }

}
