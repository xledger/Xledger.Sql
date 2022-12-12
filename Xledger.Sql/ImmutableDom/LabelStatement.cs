using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LabelStatement : TSqlStatement, IEquatable<LabelStatement> {
        string @value;
    
        public string Value => @value;
    
        public LabelStatement(string @value = null) {
            this.@value = @value;
        }
    
        public ScriptDom.LabelStatement ToMutableConcrete() {
            var ret = new ScriptDom.LabelStatement();
            ret.Value = @value;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as LabelStatement);
        } 
        
        public bool Equals(LabelStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<string>.Default.Equals(other.Value, @value)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LabelStatement left, LabelStatement right) {
            return EqualityComparer<LabelStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LabelStatement left, LabelStatement right) {
            return !(left == right);
        }
    
    }

}