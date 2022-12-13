using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExtractFromExpression : ScalarExpression, IEquatable<ExtractFromExpression> {
        protected ScalarExpression expression;
        protected Identifier extractedElement;
    
        public ScalarExpression Expression => expression;
        public Identifier ExtractedElement => extractedElement;
    
        public ExtractFromExpression(ScalarExpression expression = null, Identifier extractedElement = null) {
            this.expression = expression;
            this.extractedElement = extractedElement;
        }
    
        public ScriptDom.ExtractFromExpression ToMutableConcrete() {
            var ret = new ScriptDom.ExtractFromExpression();
            ret.Expression = (ScriptDom.ScalarExpression)expression.ToMutable();
            ret.ExtractedElement = (ScriptDom.Identifier)extractedElement.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(expression is null)) {
                h = h * 23 + expression.GetHashCode();
            }
            if (!(extractedElement is null)) {
                h = h * 23 + extractedElement.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExtractFromExpression);
        } 
        
        public bool Equals(ExtractFromExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Expression, expression)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.ExtractedElement, extractedElement)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExtractFromExpression left, ExtractFromExpression right) {
            return EqualityComparer<ExtractFromExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExtractFromExpression left, ExtractFromExpression right) {
            return !(left == right);
        }
    
        public static ExtractFromExpression FromMutable(ScriptDom.ExtractFromExpression fragment) {
            return (ExtractFromExpression)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
