using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AIGenerateFixedChunksTableReference : AIGenerateChunksTableReference, IEquatable<AIGenerateFixedChunksTableReference> {
        protected ScalarExpression chunkSize;
        protected ScalarExpression overlap;
        protected ScalarExpression enableChunkSetId;
    
        public ScalarExpression ChunkSize => chunkSize;
        public ScalarExpression Overlap => overlap;
        public ScalarExpression EnableChunkSetId => enableChunkSetId;
    
        public AIGenerateFixedChunksTableReference(ScalarExpression chunkSize = null, ScalarExpression overlap = null, ScalarExpression enableChunkSetId = null, ScalarExpression source = null, Identifier chunkType = null, Identifier alias = null, bool forPath = false) {
            this.chunkSize = chunkSize;
            this.overlap = overlap;
            this.enableChunkSetId = enableChunkSetId;
            this.source = source;
            this.chunkType = chunkType;
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public new ScriptDom.AIGenerateFixedChunksTableReference ToMutableConcrete() {
            var ret = new ScriptDom.AIGenerateFixedChunksTableReference();
            ret.ChunkSize = (ScriptDom.ScalarExpression)chunkSize?.ToMutable();
            ret.Overlap = (ScriptDom.ScalarExpression)overlap?.ToMutable();
            ret.EnableChunkSetId = (ScriptDom.ScalarExpression)enableChunkSetId?.ToMutable();
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
            if (!(chunkSize is null)) {
                h = h * 23 + chunkSize.GetHashCode();
            }
            if (!(overlap is null)) {
                h = h * 23 + overlap.GetHashCode();
            }
            if (!(enableChunkSetId is null)) {
                h = h * 23 + enableChunkSetId.GetHashCode();
            }
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
            return Equals(obj as AIGenerateFixedChunksTableReference);
        } 
        
        public bool Equals(AIGenerateFixedChunksTableReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.ChunkSize, chunkSize)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Overlap, overlap)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.EnableChunkSetId, enableChunkSetId)) {
                return false;
            }
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
        
        public static bool operator ==(AIGenerateFixedChunksTableReference left, AIGenerateFixedChunksTableReference right) {
            return EqualityComparer<AIGenerateFixedChunksTableReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AIGenerateFixedChunksTableReference left, AIGenerateFixedChunksTableReference right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AIGenerateFixedChunksTableReference)that;
            compare = Comparer.DefaultInvariant.Compare(this.chunkSize, othr.chunkSize);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.overlap, othr.overlap);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.enableChunkSetId, othr.enableChunkSetId);
            if (compare != 0) { return compare; }
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
        
        public static bool operator < (AIGenerateFixedChunksTableReference left, AIGenerateFixedChunksTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AIGenerateFixedChunksTableReference left, AIGenerateFixedChunksTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AIGenerateFixedChunksTableReference left, AIGenerateFixedChunksTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AIGenerateFixedChunksTableReference left, AIGenerateFixedChunksTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AIGenerateFixedChunksTableReference FromMutable(ScriptDom.AIGenerateFixedChunksTableReference fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AIGenerateFixedChunksTableReference)) { throw new NotImplementedException("Unexpected subtype of AIGenerateFixedChunksTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AIGenerateFixedChunksTableReference(
                chunkSize: ImmutableDom.ScalarExpression.FromMutable(fragment.ChunkSize),
                overlap: ImmutableDom.ScalarExpression.FromMutable(fragment.Overlap),
                enableChunkSetId: ImmutableDom.ScalarExpression.FromMutable(fragment.EnableChunkSetId),
                source: ImmutableDom.ScalarExpression.FromMutable(fragment.Source),
                chunkType: ImmutableDom.Identifier.FromMutable(fragment.ChunkType),
                alias: ImmutableDom.Identifier.FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
    
    }

}
