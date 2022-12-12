using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class JsonForClauseOption : ForClause, IEquatable<JsonForClauseOption> {
        ScriptDom.JsonForClauseOptions optionKind = ScriptDom.JsonForClauseOptions.None;
        Literal @value;
    
        public ScriptDom.JsonForClauseOptions OptionKind => optionKind;
        public Literal Value => @value;
    
        public JsonForClauseOption(ScriptDom.JsonForClauseOptions optionKind = ScriptDom.JsonForClauseOptions.None, Literal @value = null) {
            this.optionKind = optionKind;
            this.@value = @value;
        }
    
        public ScriptDom.JsonForClauseOption ToMutableConcrete() {
            var ret = new ScriptDom.JsonForClauseOption();
            ret.OptionKind = optionKind;
            ret.Value = (ScriptDom.Literal)@value.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionKind.GetHashCode();
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as JsonForClauseOption);
        } 
        
        public bool Equals(JsonForClauseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.JsonForClauseOptions>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(JsonForClauseOption left, JsonForClauseOption right) {
            return EqualityComparer<JsonForClauseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(JsonForClauseOption left, JsonForClauseOption right) {
            return !(left == right);
        }
    
    }

}
