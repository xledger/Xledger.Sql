using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SemanticIndexColumn : TSqlFragment, IEquatable<SemanticIndexColumn> {
        protected Identifier columnName;
        protected ScriptDom.SemanticIndexSearchType searchType = ScriptDom.SemanticIndexSearchType.NotSpecified;
        protected Identifier typeColumnName;
        protected IdentifierOrValueExpression language;
        protected IReadOnlyList<SemanticIndexChunkOption> chunkOptions;
    
        public Identifier ColumnName => columnName;
        public ScriptDom.SemanticIndexSearchType SearchType => searchType;
        public Identifier TypeColumnName => typeColumnName;
        public IdentifierOrValueExpression Language => language;
        public IReadOnlyList<SemanticIndexChunkOption> ChunkOptions => chunkOptions;
    
        public SemanticIndexColumn(Identifier columnName = null, ScriptDom.SemanticIndexSearchType searchType = ScriptDom.SemanticIndexSearchType.NotSpecified, Identifier typeColumnName = null, IdentifierOrValueExpression language = null, IReadOnlyList<SemanticIndexChunkOption> chunkOptions = null) {
            this.columnName = columnName;
            this.searchType = searchType;
            this.typeColumnName = typeColumnName;
            this.language = language;
            this.chunkOptions = chunkOptions.ToImmArray<SemanticIndexChunkOption>();
        }
    
        public ScriptDom.SemanticIndexColumn ToMutableConcrete() {
            var ret = new ScriptDom.SemanticIndexColumn();
            ret.ColumnName = (ScriptDom.Identifier)columnName?.ToMutable();
            ret.SearchType = searchType;
            ret.TypeColumnName = (ScriptDom.Identifier)typeColumnName?.ToMutable();
            ret.Language = (ScriptDom.IdentifierOrValueExpression)language?.ToMutable();
            ret.ChunkOptions.AddRange(chunkOptions.Select(c => (ScriptDom.SemanticIndexChunkOption)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(columnName is null)) {
                h = h * 23 + columnName.GetHashCode();
            }
            h = h * 23 + searchType.GetHashCode();
            if (!(typeColumnName is null)) {
                h = h * 23 + typeColumnName.GetHashCode();
            }
            if (!(language is null)) {
                h = h * 23 + language.GetHashCode();
            }
            h = h * 23 + chunkOptions.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SemanticIndexColumn);
        } 
        
        public bool Equals(SemanticIndexColumn other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.ColumnName, columnName)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.SemanticIndexSearchType>.Default.Equals(other.SearchType, searchType)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.TypeColumnName, typeColumnName)) {
                return false;
            }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.Language, language)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<SemanticIndexChunkOption>>.Default.Equals(other.ChunkOptions, chunkOptions)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SemanticIndexColumn left, SemanticIndexColumn right) {
            return EqualityComparer<SemanticIndexColumn>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SemanticIndexColumn left, SemanticIndexColumn right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SemanticIndexColumn)that;
            compare = Comparer.DefaultInvariant.Compare(this.columnName, othr.columnName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.searchType, othr.searchType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.typeColumnName, othr.typeColumnName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.language, othr.language);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.chunkOptions, othr.chunkOptions);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (SemanticIndexColumn left, SemanticIndexColumn right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SemanticIndexColumn left, SemanticIndexColumn right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SemanticIndexColumn left, SemanticIndexColumn right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SemanticIndexColumn left, SemanticIndexColumn right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SemanticIndexColumn FromMutable(ScriptDom.SemanticIndexColumn fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.SemanticIndexColumn)) { throw new NotImplementedException("Unexpected subtype of SemanticIndexColumn not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SemanticIndexColumn(
                columnName: ImmutableDom.Identifier.FromMutable(fragment.ColumnName),
                searchType: fragment.SearchType,
                typeColumnName: ImmutableDom.Identifier.FromMutable(fragment.TypeColumnName),
                language: ImmutableDom.IdentifierOrValueExpression.FromMutable(fragment.Language),
                chunkOptions: fragment.ChunkOptions.ToImmArray(ImmutableDom.SemanticIndexChunkOption.FromMutable)
            );
        }
    
    }

}
