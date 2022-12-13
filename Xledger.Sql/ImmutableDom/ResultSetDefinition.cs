using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ResultSetDefinition : TSqlFragment, IEquatable<ResultSetDefinition> {
        protected ScriptDom.ResultSetType resultSetType = ScriptDom.ResultSetType.Inline;
    
        public ScriptDom.ResultSetType ResultSetType => resultSetType;
    
        public ResultSetDefinition(ScriptDom.ResultSetType resultSetType = ScriptDom.ResultSetType.Inline) {
            this.resultSetType = resultSetType;
        }
    
        public ScriptDom.ResultSetDefinition ToMutableConcrete() {
            var ret = new ScriptDom.ResultSetDefinition();
            ret.ResultSetType = resultSetType;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + resultSetType.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ResultSetDefinition);
        } 
        
        public bool Equals(ResultSetDefinition other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ResultSetType>.Default.Equals(other.ResultSetType, resultSetType)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ResultSetDefinition left, ResultSetDefinition right) {
            return EqualityComparer<ResultSetDefinition>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ResultSetDefinition left, ResultSetDefinition right) {
            return !(left == right);
        }
    
        public static ResultSetDefinition FromMutable(ScriptDom.ResultSetDefinition fragment) {
            return (ResultSetDefinition)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
