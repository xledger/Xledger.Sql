using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class InlineResultSetDefinition : ResultSetDefinition, IEquatable<InlineResultSetDefinition> {
        protected IReadOnlyList<ResultColumnDefinition> resultColumnDefinitions;
    
        public IReadOnlyList<ResultColumnDefinition> ResultColumnDefinitions => resultColumnDefinitions;
    
        public InlineResultSetDefinition(IReadOnlyList<ResultColumnDefinition> resultColumnDefinitions = null, ScriptDom.ResultSetType resultSetType = ScriptDom.ResultSetType.Inline) {
            this.resultColumnDefinitions = resultColumnDefinitions is null ? ImmList<ResultColumnDefinition>.Empty : ImmList<ResultColumnDefinition>.FromList(resultColumnDefinitions);
            this.resultSetType = resultSetType;
        }
    
        public ScriptDom.InlineResultSetDefinition ToMutableConcrete() {
            var ret = new ScriptDom.InlineResultSetDefinition();
            ret.ResultColumnDefinitions.AddRange(resultColumnDefinitions.SelectList(c => (ScriptDom.ResultColumnDefinition)c.ToMutable()));
            ret.ResultSetType = resultSetType;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + resultColumnDefinitions.GetHashCode();
            h = h * 23 + resultSetType.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as InlineResultSetDefinition);
        } 
        
        public bool Equals(InlineResultSetDefinition other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<ResultColumnDefinition>>.Default.Equals(other.ResultColumnDefinitions, resultColumnDefinitions)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ResultSetType>.Default.Equals(other.ResultSetType, resultSetType)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(InlineResultSetDefinition left, InlineResultSetDefinition right) {
            return EqualityComparer<InlineResultSetDefinition>.Default.Equals(left, right);
        }
        
        public static bool operator !=(InlineResultSetDefinition left, InlineResultSetDefinition right) {
            return !(left == right);
        }
    
    }

}
