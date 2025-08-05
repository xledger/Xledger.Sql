using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateFullTextIndexStatement : TSqlStatement, IEquatable<CreateFullTextIndexStatement> {
        protected SchemaObjectName onName;
        protected IReadOnlyList<FullTextIndexColumn> fullTextIndexColumns;
        protected Identifier keyIndexName;
        protected FullTextCatalogAndFileGroup catalogAndFileGroup;
        protected IReadOnlyList<FullTextIndexOption> options;
    
        public SchemaObjectName OnName => onName;
        public IReadOnlyList<FullTextIndexColumn> FullTextIndexColumns => fullTextIndexColumns;
        public Identifier KeyIndexName => keyIndexName;
        public FullTextCatalogAndFileGroup CatalogAndFileGroup => catalogAndFileGroup;
        public IReadOnlyList<FullTextIndexOption> Options => options;
    
        public CreateFullTextIndexStatement(SchemaObjectName onName = null, IReadOnlyList<FullTextIndexColumn> fullTextIndexColumns = null, Identifier keyIndexName = null, FullTextCatalogAndFileGroup catalogAndFileGroup = null, IReadOnlyList<FullTextIndexOption> options = null) {
            this.onName = onName;
            this.fullTextIndexColumns = fullTextIndexColumns.ToImmArray<FullTextIndexColumn>();
            this.keyIndexName = keyIndexName;
            this.catalogAndFileGroup = catalogAndFileGroup;
            this.options = options.ToImmArray<FullTextIndexOption>();
        }
    
        public ScriptDom.CreateFullTextIndexStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateFullTextIndexStatement();
            ret.OnName = (ScriptDom.SchemaObjectName)onName?.ToMutable();
            ret.FullTextIndexColumns.AddRange(fullTextIndexColumns.Select(c => (ScriptDom.FullTextIndexColumn)c?.ToMutable()));
            ret.KeyIndexName = (ScriptDom.Identifier)keyIndexName?.ToMutable();
            ret.CatalogAndFileGroup = (ScriptDom.FullTextCatalogAndFileGroup)catalogAndFileGroup?.ToMutable();
            ret.Options.AddRange(options.Select(c => (ScriptDom.FullTextIndexOption)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(onName is null)) {
                h = h * 23 + onName.GetHashCode();
            }
            h = h * 23 + fullTextIndexColumns.GetHashCode();
            if (!(keyIndexName is null)) {
                h = h * 23 + keyIndexName.GetHashCode();
            }
            if (!(catalogAndFileGroup is null)) {
                h = h * 23 + catalogAndFileGroup.GetHashCode();
            }
            h = h * 23 + options.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateFullTextIndexStatement);
        } 
        
        public bool Equals(CreateFullTextIndexStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.OnName, onName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<FullTextIndexColumn>>.Default.Equals(other.FullTextIndexColumns, fullTextIndexColumns)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.KeyIndexName, keyIndexName)) {
                return false;
            }
            if (!EqualityComparer<FullTextCatalogAndFileGroup>.Default.Equals(other.CatalogAndFileGroup, catalogAndFileGroup)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<FullTextIndexOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateFullTextIndexStatement left, CreateFullTextIndexStatement right) {
            return EqualityComparer<CreateFullTextIndexStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateFullTextIndexStatement left, CreateFullTextIndexStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateFullTextIndexStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.onName, othr.onName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.fullTextIndexColumns, othr.fullTextIndexColumns);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.keyIndexName, othr.keyIndexName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.catalogAndFileGroup, othr.catalogAndFileGroup);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CreateFullTextIndexStatement left, CreateFullTextIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateFullTextIndexStatement left, CreateFullTextIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateFullTextIndexStatement left, CreateFullTextIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateFullTextIndexStatement left, CreateFullTextIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateFullTextIndexStatement FromMutable(ScriptDom.CreateFullTextIndexStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreateFullTextIndexStatement)) { throw new NotImplementedException("Unexpected subtype of CreateFullTextIndexStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateFullTextIndexStatement(
                onName: ImmutableDom.SchemaObjectName.FromMutable(fragment.OnName),
                fullTextIndexColumns: fragment.FullTextIndexColumns.ToImmArray(ImmutableDom.FullTextIndexColumn.FromMutable),
                keyIndexName: ImmutableDom.Identifier.FromMutable(fragment.KeyIndexName),
                catalogAndFileGroup: ImmutableDom.FullTextCatalogAndFileGroup.FromMutable(fragment.CatalogAndFileGroup),
                options: fragment.Options.ToImmArray(ImmutableDom.FullTextIndexOption.FromMutable)
            );
        }
    
    }

}
