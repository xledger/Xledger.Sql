using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OpenRowsetCosmos : TableReferenceWithAliasAndColumns, IEquatable<OpenRowsetCosmos> {
        protected IReadOnlyList<OpenRowsetCosmosOption> options;
        protected IReadOnlyList<OpenRowsetColumnDefinition> withColumns;
    
        public IReadOnlyList<OpenRowsetCosmosOption> Options => options;
        public IReadOnlyList<OpenRowsetColumnDefinition> WithColumns => withColumns;
    
        public OpenRowsetCosmos(IReadOnlyList<OpenRowsetCosmosOption> options = null, IReadOnlyList<OpenRowsetColumnDefinition> withColumns = null, IReadOnlyList<Identifier> columns = null, Identifier alias = null, bool forPath = false) {
            this.options = options.ToImmArray<OpenRowsetCosmosOption>();
            this.withColumns = withColumns.ToImmArray<OpenRowsetColumnDefinition>();
            this.columns = columns.ToImmArray<Identifier>();
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.OpenRowsetCosmos ToMutableConcrete() {
            var ret = new ScriptDom.OpenRowsetCosmos();
            ret.Options.AddRange(options.Select(c => (ScriptDom.OpenRowsetCosmosOption)c?.ToMutable()));
            ret.WithColumns.AddRange(withColumns.Select(c => (ScriptDom.OpenRowsetColumnDefinition)c?.ToMutable()));
            ret.Columns.AddRange(columns.Select(c => (ScriptDom.Identifier)c?.ToMutable()));
            ret.Alias = (ScriptDom.Identifier)alias?.ToMutable();
            ret.ForPath = forPath;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + options.GetHashCode();
            h = h * 23 + withColumns.GetHashCode();
            h = h * 23 + columns.GetHashCode();
            if (!(alias is null)) {
                h = h * 23 + alias.GetHashCode();
            }
            h = h * 23 + forPath.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OpenRowsetCosmos);
        } 
        
        public bool Equals(OpenRowsetCosmos other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<OpenRowsetCosmosOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<OpenRowsetColumnDefinition>>.Default.Equals(other.WithColumns, withColumns)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.Columns, columns)) {
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
        
        public static bool operator ==(OpenRowsetCosmos left, OpenRowsetCosmos right) {
            return EqualityComparer<OpenRowsetCosmos>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OpenRowsetCosmos left, OpenRowsetCosmos right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OpenRowsetCosmos)that;
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.withColumns, othr.withColumns);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.columns, othr.columns);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.alias, othr.alias);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.forPath, othr.forPath);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (OpenRowsetCosmos left, OpenRowsetCosmos right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(OpenRowsetCosmos left, OpenRowsetCosmos right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (OpenRowsetCosmos left, OpenRowsetCosmos right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(OpenRowsetCosmos left, OpenRowsetCosmos right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static OpenRowsetCosmos FromMutable(ScriptDom.OpenRowsetCosmos fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.OpenRowsetCosmos)) { throw new NotImplementedException("Unexpected subtype of OpenRowsetCosmos not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OpenRowsetCosmos(
                options: fragment.Options.ToImmArray(ImmutableDom.OpenRowsetCosmosOption.FromMutable),
                withColumns: fragment.WithColumns.ToImmArray(ImmutableDom.OpenRowsetColumnDefinition.FromMutable),
                columns: fragment.Columns.ToImmArray(ImmutableDom.Identifier.FromMutable),
                alias: ImmutableDom.Identifier.FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
    
    }

}
