using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AIGenerateEmbeddingsFunctionCall : PrimaryExpression, IEquatable<AIGenerateEmbeddingsFunctionCall> {
        protected ScalarExpression input;
        protected SchemaObjectName modelName;
        protected ScalarExpression optionalParameters;
    
        public ScalarExpression Input => input;
        public SchemaObjectName ModelName => modelName;
        public ScalarExpression OptionalParameters => optionalParameters;
    
        public AIGenerateEmbeddingsFunctionCall(ScalarExpression input = null, SchemaObjectName modelName = null, ScalarExpression optionalParameters = null, Identifier collation = null) {
            this.input = input;
            this.modelName = modelName;
            this.optionalParameters = optionalParameters;
            this.collation = collation;
        }
    
        public ScriptDom.AIGenerateEmbeddingsFunctionCall ToMutableConcrete() {
            var ret = new ScriptDom.AIGenerateEmbeddingsFunctionCall();
            ret.Input = (ScriptDom.ScalarExpression)input?.ToMutable();
            ret.ModelName = (ScriptDom.SchemaObjectName)modelName?.ToMutable();
            ret.OptionalParameters = (ScriptDom.ScalarExpression)optionalParameters?.ToMutable();
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
            if (!(modelName is null)) {
                h = h * 23 + modelName.GetHashCode();
            }
            if (!(optionalParameters is null)) {
                h = h * 23 + optionalParameters.GetHashCode();
            }
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AIGenerateEmbeddingsFunctionCall);
        } 
        
        public bool Equals(AIGenerateEmbeddingsFunctionCall other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Input, input)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.ModelName, modelName)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.OptionalParameters, optionalParameters)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AIGenerateEmbeddingsFunctionCall left, AIGenerateEmbeddingsFunctionCall right) {
            return EqualityComparer<AIGenerateEmbeddingsFunctionCall>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AIGenerateEmbeddingsFunctionCall left, AIGenerateEmbeddingsFunctionCall right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AIGenerateEmbeddingsFunctionCall)that;
            compare = Comparer.DefaultInvariant.Compare(this.input, othr.input);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.modelName, othr.modelName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionalParameters, othr.optionalParameters);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AIGenerateEmbeddingsFunctionCall left, AIGenerateEmbeddingsFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AIGenerateEmbeddingsFunctionCall left, AIGenerateEmbeddingsFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AIGenerateEmbeddingsFunctionCall left, AIGenerateEmbeddingsFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AIGenerateEmbeddingsFunctionCall left, AIGenerateEmbeddingsFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AIGenerateEmbeddingsFunctionCall FromMutable(ScriptDom.AIGenerateEmbeddingsFunctionCall fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AIGenerateEmbeddingsFunctionCall)) { throw new NotImplementedException("Unexpected subtype of AIGenerateEmbeddingsFunctionCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AIGenerateEmbeddingsFunctionCall(
                input: ImmutableDom.ScalarExpression.FromMutable(fragment.Input),
                modelName: ImmutableDom.SchemaObjectName.FromMutable(fragment.ModelName),
                optionalParameters: ImmutableDom.ScalarExpression.FromMutable(fragment.OptionalParameters),
                collation: ImmutableDom.Identifier.FromMutable(fragment.Collation)
            );
        }
    
    }

}
