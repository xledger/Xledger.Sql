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
            this.strings = strings is null ? ImmList<ValueExpression>.Empty : ImmList<ValueExpression>.FromList(strings);
            this.parameters = parameters is null ? ImmList<ExecuteParameter>.Empty : ImmList<ExecuteParameter>.FromList(parameters);
        }
    
        public ScriptDom.ExecutableStringList ToMutableConcrete() {
            var ret = new ScriptDom.ExecutableStringList();
            ret.Strings.AddRange(strings.SelectList(c => (ScriptDom.ValueExpression)c.ToMutable()));
            ret.Parameters.AddRange(parameters.SelectList(c => (ScriptDom.ExecuteParameter)c.ToMutable()));
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
    
        public static ExecutableStringList FromMutable(ScriptDom.ExecutableStringList fragment) {
            return (ExecutableStringList)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
