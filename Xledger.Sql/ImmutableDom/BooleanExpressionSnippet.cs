using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BooleanExpressionSnippet : BooleanExpression, IEquatable<BooleanExpressionSnippet> {
        protected string script;
    
        public string Script => script;
    
        public BooleanExpressionSnippet(string script = null) {
            this.script = script;
        }
    
        public ScriptDom.BooleanExpressionSnippet ToMutableConcrete() {
            var ret = new ScriptDom.BooleanExpressionSnippet();
            ret.Script = script;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(script is null)) {
                h = h * 23 + script.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as BooleanExpressionSnippet);
        } 
        
        public bool Equals(BooleanExpressionSnippet other) {
            if (other is null) { return false; }
            if (!EqualityComparer<string>.Default.Equals(other.Script, script)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(BooleanExpressionSnippet left, BooleanExpressionSnippet right) {
            return EqualityComparer<BooleanExpressionSnippet>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BooleanExpressionSnippet left, BooleanExpressionSnippet right) {
            return !(left == right);
        }
    
    }

}
