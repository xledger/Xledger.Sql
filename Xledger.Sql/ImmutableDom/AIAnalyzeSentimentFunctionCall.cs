using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AIAnalyzeSentimentFunctionCall : PrimaryExpression, IEquatable<AIAnalyzeSentimentFunctionCall> {
        protected ScalarExpression input;
    
        public ScalarExpression Input => input;
    
        public AIAnalyzeSentimentFunctionCall(ScalarExpression input = null, Identifier collation = null) {
            this.input = input;
            this.collation = collation;
        }
    
        public ScriptDom.AIAnalyzeSentimentFunctionCall ToMutableConcrete() {
            var ret = new ScriptDom.AIAnalyzeSentimentFunctionCall();
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
            return Equals(obj as AIAnalyzeSentimentFunctionCall);
        } 
        
        public bool Equals(AIAnalyzeSentimentFunctionCall other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Input, input)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AIAnalyzeSentimentFunctionCall left, AIAnalyzeSentimentFunctionCall right) {
            return EqualityComparer<AIAnalyzeSentimentFunctionCall>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AIAnalyzeSentimentFunctionCall left, AIAnalyzeSentimentFunctionCall right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AIAnalyzeSentimentFunctionCall)that;
            compare = Comparer.DefaultInvariant.Compare(this.input, othr.input);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AIAnalyzeSentimentFunctionCall left, AIAnalyzeSentimentFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AIAnalyzeSentimentFunctionCall left, AIAnalyzeSentimentFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AIAnalyzeSentimentFunctionCall left, AIAnalyzeSentimentFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AIAnalyzeSentimentFunctionCall left, AIAnalyzeSentimentFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AIAnalyzeSentimentFunctionCall FromMutable(ScriptDom.AIAnalyzeSentimentFunctionCall fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AIAnalyzeSentimentFunctionCall)) { throw new NotImplementedException("Unexpected subtype of AIAnalyzeSentimentFunctionCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AIAnalyzeSentimentFunctionCall(
                input: ImmutableDom.ScalarExpression.FromMutable(fragment.Input),
                collation: ImmutableDom.Identifier.FromMutable(fragment.Collation)
            );
        }
    
    }

}
