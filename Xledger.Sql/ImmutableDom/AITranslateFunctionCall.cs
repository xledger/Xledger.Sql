using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AITranslateFunctionCall : PrimaryExpression, IEquatable<AITranslateFunctionCall> {
        protected ScalarExpression input;
        protected ScalarExpression language;
    
        public ScalarExpression Input => input;
        public ScalarExpression Language => language;
    
        public AITranslateFunctionCall(ScalarExpression input = null, ScalarExpression language = null, Identifier collation = null) {
            this.input = input;
            this.language = language;
            this.collation = collation;
        }
    
        public ScriptDom.AITranslateFunctionCall ToMutableConcrete() {
            var ret = new ScriptDom.AITranslateFunctionCall();
            ret.Input = (ScriptDom.ScalarExpression)input?.ToMutable();
            ret.Language = (ScriptDom.ScalarExpression)language?.ToMutable();
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
            if (!(language is null)) {
                h = h * 23 + language.GetHashCode();
            }
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AITranslateFunctionCall);
        } 
        
        public bool Equals(AITranslateFunctionCall other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Input, input)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Language, language)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AITranslateFunctionCall left, AITranslateFunctionCall right) {
            return EqualityComparer<AITranslateFunctionCall>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AITranslateFunctionCall left, AITranslateFunctionCall right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AITranslateFunctionCall)that;
            compare = Comparer.DefaultInvariant.Compare(this.input, othr.input);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.language, othr.language);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AITranslateFunctionCall left, AITranslateFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AITranslateFunctionCall left, AITranslateFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AITranslateFunctionCall left, AITranslateFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AITranslateFunctionCall left, AITranslateFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AITranslateFunctionCall FromMutable(ScriptDom.AITranslateFunctionCall fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AITranslateFunctionCall)) { throw new NotImplementedException("Unexpected subtype of AITranslateFunctionCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AITranslateFunctionCall(
                input: ImmutableDom.ScalarExpression.FromMutable(fragment.Input),
                language: ImmutableDom.ScalarExpression.FromMutable(fragment.Language),
                collation: ImmutableDom.Identifier.FromMutable(fragment.Collation)
            );
        }
    
    }

}
