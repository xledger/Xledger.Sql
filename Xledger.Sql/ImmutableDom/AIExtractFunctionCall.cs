using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AIExtractFunctionCall : PrimaryExpression, IEquatable<AIExtractFunctionCall> {
        protected ScalarExpression input;
        protected IReadOnlyList<ScalarExpression> labels;
    
        public ScalarExpression Input => input;
        public IReadOnlyList<ScalarExpression> Labels => labels;
    
        public AIExtractFunctionCall(ScalarExpression input = null, IReadOnlyList<ScalarExpression> labels = null, Identifier collation = null) {
            this.input = input;
            this.labels = labels.ToImmArray<ScalarExpression>();
            this.collation = collation;
        }
    
        public ScriptDom.AIExtractFunctionCall ToMutableConcrete() {
            var ret = new ScriptDom.AIExtractFunctionCall();
            ret.Input = (ScriptDom.ScalarExpression)input?.ToMutable();
            ret.Labels.AddRange(labels.Select(c => (ScriptDom.ScalarExpression)c?.ToMutable()));
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
            h = h * 23 + labels.GetHashCode();
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AIExtractFunctionCall);
        } 
        
        public bool Equals(AIExtractFunctionCall other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Input, input)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ScalarExpression>>.Default.Equals(other.Labels, labels)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AIExtractFunctionCall left, AIExtractFunctionCall right) {
            return EqualityComparer<AIExtractFunctionCall>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AIExtractFunctionCall left, AIExtractFunctionCall right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AIExtractFunctionCall)that;
            compare = Comparer.DefaultInvariant.Compare(this.input, othr.input);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.labels, othr.labels);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AIExtractFunctionCall left, AIExtractFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AIExtractFunctionCall left, AIExtractFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AIExtractFunctionCall left, AIExtractFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AIExtractFunctionCall left, AIExtractFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AIExtractFunctionCall FromMutable(ScriptDom.AIExtractFunctionCall fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AIExtractFunctionCall)) { throw new NotImplementedException("Unexpected subtype of AIExtractFunctionCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AIExtractFunctionCall(
                input: ImmutableDom.ScalarExpression.FromMutable(fragment.Input),
                labels: fragment.Labels.ToImmArray(ImmutableDom.ScalarExpression.FromMutable),
                collation: ImmutableDom.Identifier.FromMutable(fragment.Collation)
            );
        }
    
    }

}
