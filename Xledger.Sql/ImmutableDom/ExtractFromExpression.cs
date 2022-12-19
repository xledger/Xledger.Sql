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
            ret.Expression = (ScriptDom.ScalarExpression)expression?.ToMutable();
            ret.ExtractedElement = (ScriptDom.Identifier)extractedElement?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ExtractFromExpression)that;
            compare = Comparer.DefaultInvariant.Compare(this.expression, othr.expression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.extractedElement, othr.extractedElement);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ExtractFromExpression left, ExtractFromExpression right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ExtractFromExpression left, ExtractFromExpression right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ExtractFromExpression left, ExtractFromExpression right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ExtractFromExpression left, ExtractFromExpression right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ExtractFromExpression FromMutable(ScriptDom.ExtractFromExpression fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ExtractFromExpression)) { throw new NotImplementedException("Unexpected subtype of ExtractFromExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExtractFromExpression(
                expression: ImmutableDom.ScalarExpression.FromMutable(fragment.Expression),
                extractedElement: ImmutableDom.Identifier.FromMutable(fragment.ExtractedElement)
            );
        }
    
    }

}
