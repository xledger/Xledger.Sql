using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AIFixGrammarFunctionCall : PrimaryExpression, IEquatable<AIFixGrammarFunctionCall> {
        protected ScalarExpression input;
    
        public ScalarExpression Input => input;
    
        public AIFixGrammarFunctionCall(ScalarExpression input = null, Identifier collation = null) {
            this.input = input;
            this.collation = collation;
        }
    
        public ScriptDom.AIFixGrammarFunctionCall ToMutableConcrete() {
            var ret = new ScriptDom.AIFixGrammarFunctionCall();
            ret.Input = (ScriptDom.ScalarExpression)input?.ToMutable();
            ret.Collation = (ScriptDom.Identifier)collation?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(input is null)) {
                h = h * 23 + input.GetHashCode();
            }
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AIFixGrammarFunctionCall);
        } 
        
        public bool Equals(AIFixGrammarFunctionCall other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Input, input)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AIFixGrammarFunctionCall left, AIFixGrammarFunctionCall right) {
            return EqualityComparer<AIFixGrammarFunctionCall>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AIFixGrammarFunctionCall left, AIFixGrammarFunctionCall right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AIFixGrammarFunctionCall)that;
            compare = Comparer.DefaultInvariant.Compare(this.input, othr.input);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AIFixGrammarFunctionCall left, AIFixGrammarFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AIFixGrammarFunctionCall left, AIFixGrammarFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AIFixGrammarFunctionCall left, AIFixGrammarFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AIFixGrammarFunctionCall left, AIFixGrammarFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AIFixGrammarFunctionCall FromMutable(ScriptDom.AIFixGrammarFunctionCall fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AIFixGrammarFunctionCall)) { throw new NotImplementedException("Unexpected subtype of AIFixGrammarFunctionCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AIFixGrammarFunctionCall(
                input: ImmutableDom.ScalarExpression.FromMutable(fragment.Input),
                collation: ImmutableDom.Identifier.FromMutable(fragment.Collation)
            );
        }
    
    }

}
