using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AIGenerateChunksTableReference : TableReferenceWithAlias, IEquatable<AIGenerateChunksTableReference> {
        protected ScalarExpression source;
        protected Identifier chunkType;
    
        public ScalarExpression Source => source;
        public Identifier ChunkType => chunkType;
    
        public AIGenerateChunksTableReference(ScalarExpression source = null, Identifier chunkType = null, Identifier alias = null, bool forPath = false) {
            this.source = source;
            this.chunkType = chunkType;
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.AIGenerateChunksTableReference ToMutableConcrete() {
            var ret = new ScriptDom.AIGenerateChunksTableReference();
            ret.Source = (ScriptDom.ScalarExpression)source?.ToMutable();
            ret.ChunkType = (ScriptDom.Identifier)chunkType?.ToMutable();
            ret.Alias = (ScriptDom.Identifier)alias?.ToMutable();
            ret.ForPath = forPath;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(source is null)) {
                h = h * 23 + source.GetHashCode();
            }
            if (!(chunkType is null)) {
                h = h * 23 + chunkType.GetHashCode();
            }
            if (!(alias is null)) {
                h = h * 23 + alias.GetHashCode();
            }
            h = h * 23 + forPath.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AIGenerateChunksTableReference);
        } 
        
        public bool Equals(AIGenerateChunksTableReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Source, source)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.ChunkType, chunkType)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Alias, alias)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.ForPath, forPath)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AIGenerateChunksTableReference left, AIGenerateChunksTableReference right) {
            return EqualityComparer<AIGenerateChunksTableReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AIGenerateChunksTableReference left, AIGenerateChunksTableReference right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AIGenerateChunksTableReference)that;
            compare = Comparer.DefaultInvariant.Compare(this.source, othr.source);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.chunkType, othr.chunkType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.alias, othr.alias);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.forPath, othr.forPath);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AIGenerateChunksTableReference left, AIGenerateChunksTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AIGenerateChunksTableReference left, AIGenerateChunksTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AIGenerateChunksTableReference left, AIGenerateChunksTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AIGenerateChunksTableReference left, AIGenerateChunksTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AIGenerateChunksTableReference FromMutable(ScriptDom.AIGenerateChunksTableReference fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AIGenerateChunksTableReference)) { return TSqlFragment.FromMutable(fragment) as AIGenerateChunksTableReference; }
            return new AIGenerateChunksTableReference(
                source: ImmutableDom.ScalarExpression.FromMutable(fragment.Source),
                chunkType: ImmutableDom.Identifier.FromMutable(fragment.ChunkType),
                alias: ImmutableDom.Identifier.FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
    
    }

}
