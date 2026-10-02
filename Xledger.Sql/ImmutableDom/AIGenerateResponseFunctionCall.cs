using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AIGenerateResponseFunctionCall : PrimaryExpression, IEquatable<AIGenerateResponseFunctionCall> {
        protected ScalarExpression promptPart1;
        protected ScalarExpression promptPart2;
    
        public ScalarExpression PromptPart1 => promptPart1;
        public ScalarExpression PromptPart2 => promptPart2;
    
        public AIGenerateResponseFunctionCall(ScalarExpression promptPart1 = null, ScalarExpression promptPart2 = null, Identifier collation = null) {
            this.promptPart1 = promptPart1;
            this.promptPart2 = promptPart2;
            this.collation = collation;
        }
    
        public ScriptDom.AIGenerateResponseFunctionCall ToMutableConcrete() {
            var ret = new ScriptDom.AIGenerateResponseFunctionCall();
            ret.PromptPart1 = (ScriptDom.ScalarExpression)promptPart1?.ToMutable();
            ret.PromptPart2 = (ScriptDom.ScalarExpression)promptPart2?.ToMutable();
            ret.Collation = (ScriptDom.Identifier)collation?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(promptPart1 is null)) {
                h = h * 23 + promptPart1.GetHashCode();
            }
            if (!(promptPart2 is null)) {
                h = h * 23 + promptPart2.GetHashCode();
            }
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AIGenerateResponseFunctionCall);
        } 
        
        public bool Equals(AIGenerateResponseFunctionCall other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.PromptPart1, promptPart1)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.PromptPart2, promptPart2)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AIGenerateResponseFunctionCall left, AIGenerateResponseFunctionCall right) {
            return EqualityComparer<AIGenerateResponseFunctionCall>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AIGenerateResponseFunctionCall left, AIGenerateResponseFunctionCall right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AIGenerateResponseFunctionCall)that;
            compare = Comparer.DefaultInvariant.Compare(this.promptPart1, othr.promptPart1);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.promptPart2, othr.promptPart2);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AIGenerateResponseFunctionCall left, AIGenerateResponseFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AIGenerateResponseFunctionCall left, AIGenerateResponseFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AIGenerateResponseFunctionCall left, AIGenerateResponseFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AIGenerateResponseFunctionCall left, AIGenerateResponseFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AIGenerateResponseFunctionCall FromMutable(ScriptDom.AIGenerateResponseFunctionCall fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AIGenerateResponseFunctionCall)) { throw new NotImplementedException("Unexpected subtype of AIGenerateResponseFunctionCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AIGenerateResponseFunctionCall(
                promptPart1: ImmutableDom.ScalarExpression.FromMutable(fragment.PromptPart1),
                promptPart2: ImmutableDom.ScalarExpression.FromMutable(fragment.PromptPart2),
                collation: ImmutableDom.Identifier.FromMutable(fragment.Collation)
            );
        }
    
    }

}
