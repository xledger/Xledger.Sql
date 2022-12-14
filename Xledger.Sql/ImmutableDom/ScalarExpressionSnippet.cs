using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ScalarExpressionSnippet : ScalarExpression, IEquatable<ScalarExpressionSnippet> {
        protected string script;
    
        public string Script => script;
    
        public ScalarExpressionSnippet(string script = null) {
            this.script = script;
        }
    
        public ScriptDom.ScalarExpressionSnippet ToMutableConcrete() {
            var ret = new ScriptDom.ScalarExpressionSnippet();
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
            return Equals(obj as ScalarExpressionSnippet);
        } 
        
        public bool Equals(ScalarExpressionSnippet other) {
            if (other is null) { return false; }
            if (!EqualityComparer<string>.Default.Equals(other.Script, script)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ScalarExpressionSnippet left, ScalarExpressionSnippet right) {
            return EqualityComparer<ScalarExpressionSnippet>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ScalarExpressionSnippet left, ScalarExpressionSnippet right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ScalarExpressionSnippet)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.script, othr.script);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static ScalarExpressionSnippet FromMutable(ScriptDom.ScalarExpressionSnippet fragment) {
            return (ScalarExpressionSnippet)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
