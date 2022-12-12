using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class JsonForClause : ForClause, IEquatable<JsonForClause> {
        IReadOnlyList<JsonForClauseOption> options;
    
        public IReadOnlyList<JsonForClauseOption> Options => options;
    
        public JsonForClause(IReadOnlyList<JsonForClauseOption> options = null) {
            this.options = options is null ? ImmList<JsonForClauseOption>.Empty : ImmList<JsonForClauseOption>.FromList(options);
        }
    
        public ScriptDom.JsonForClause ToMutableConcrete() {
            var ret = new ScriptDom.JsonForClause();
            ret.Options.AddRange(options.Select(c => (ScriptDom.JsonForClauseOption)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + options.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as JsonForClause);
        } 
        
        public bool Equals(JsonForClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<JsonForClauseOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(JsonForClause left, JsonForClause right) {
            return EqualityComparer<JsonForClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(JsonForClause left, JsonForClause right) {
            return !(left == right);
        }
    
    }

}
