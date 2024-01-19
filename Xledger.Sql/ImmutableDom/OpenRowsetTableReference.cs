using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OpenRowsetTableReference : TableReferenceWithAliasAndColumns, IEquatable<OpenRowsetTableReference> {
        protected StringLiteral providerName;
        protected StringLiteral dataSource;
        protected StringLiteral userId;
        protected StringLiteral password;
        protected StringLiteral providerString;
        protected StringLiteral query;
        protected SchemaObjectName @object;
        protected IReadOnlyList<OpenRowsetColumnDefinition> withColumns;
    
        public StringLiteral ProviderName => providerName;
        public StringLiteral DataSource => dataSource;
        public StringLiteral UserId => userId;
        public StringLiteral Password => password;
        public StringLiteral ProviderString => providerString;
        public StringLiteral Query => query;
        public SchemaObjectName Object => @object;
        public IReadOnlyList<OpenRowsetColumnDefinition> WithColumns => withColumns;
    
        public OpenRowsetTableReference(StringLiteral providerName = null, StringLiteral dataSource = null, StringLiteral userId = null, StringLiteral password = null, StringLiteral providerString = null, StringLiteral query = null, SchemaObjectName @object = null, IReadOnlyList<OpenRowsetColumnDefinition> withColumns = null, IReadOnlyList<Identifier> columns = null, Identifier alias = null, bool forPath = false) {
            this.providerName = providerName;
            this.dataSource = dataSource;
            this.userId = userId;
            this.password = password;
            this.providerString = providerString;
            this.query = query;
            this.@object = @object;
            this.withColumns = ImmList<OpenRowsetColumnDefinition>.FromList(withColumns);
            this.columns = ImmList<Identifier>.FromList(columns);
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.OpenRowsetTableReference ToMutableConcrete() {
            var ret = new ScriptDom.OpenRowsetTableReference();
            ret.ProviderName = (ScriptDom.StringLiteral)providerName?.ToMutable();
            ret.DataSource = (ScriptDom.StringLiteral)dataSource?.ToMutable();
            ret.UserId = (ScriptDom.StringLiteral)userId?.ToMutable();
            ret.Password = (ScriptDom.StringLiteral)password?.ToMutable();
            ret.ProviderString = (ScriptDom.StringLiteral)providerString?.ToMutable();
            ret.Query = (ScriptDom.StringLiteral)query?.ToMutable();
            ret.Object = (ScriptDom.SchemaObjectName)@object?.ToMutable();
            ret.WithColumns.AddRange(withColumns.SelectList(c => (ScriptDom.OpenRowsetColumnDefinition)c?.ToMutable()));
            ret.Columns.AddRange(columns.SelectList(c => (ScriptDom.Identifier)c?.ToMutable()));
            ret.Alias = (ScriptDom.Identifier)alias?.ToMutable();
            ret.ForPath = forPath;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(providerName is null)) {
                h = h * 23 + providerName.GetHashCode();
            }
            if (!(dataSource is null)) {
                h = h * 23 + dataSource.GetHashCode();
            }
            if (!(userId is null)) {
                h = h * 23 + userId.GetHashCode();
            }
            if (!(password is null)) {
                h = h * 23 + password.GetHashCode();
            }
            if (!(providerString is null)) {
                h = h * 23 + providerString.GetHashCode();
            }
            if (!(query is null)) {
                h = h * 23 + query.GetHashCode();
            }
            if (!(@object is null)) {
                h = h * 23 + @object.GetHashCode();
            }
            h = h * 23 + withColumns.GetHashCode();
            h = h * 23 + columns.GetHashCode();
            if (!(alias is null)) {
                h = h * 23 + alias.GetHashCode();
            }
            h = h * 23 + forPath.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OpenRowsetTableReference);
        } 
        
        public bool Equals(OpenRowsetTableReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.ProviderName, providerName)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.DataSource, dataSource)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.UserId, userId)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.Password, password)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.ProviderString, providerString)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.Query, query)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Object, @object)) {
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
        
        public static bool operator ==(OpenRowsetTableReference left, OpenRowsetTableReference right) {
            return EqualityComparer<OpenRowsetTableReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OpenRowsetTableReference left, OpenRowsetTableReference right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OpenRowsetTableReference)that;
            compare = Comparer.DefaultInvariant.Compare(this.providerName, othr.providerName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.dataSource, othr.dataSource);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.userId, othr.userId);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.password, othr.password);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.providerString, othr.providerString);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.query, othr.query);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.@object, othr.@object);
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
        
        public static bool operator < (OpenRowsetTableReference left, OpenRowsetTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(OpenRowsetTableReference left, OpenRowsetTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (OpenRowsetTableReference left, OpenRowsetTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(OpenRowsetTableReference left, OpenRowsetTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static OpenRowsetTableReference FromMutable(ScriptDom.OpenRowsetTableReference fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.OpenRowsetTableReference)) { throw new NotImplementedException("Unexpected subtype of OpenRowsetTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OpenRowsetTableReference(
                providerName: ImmutableDom.StringLiteral.FromMutable(fragment.ProviderName),
                dataSource: ImmutableDom.StringLiteral.FromMutable(fragment.DataSource),
                userId: ImmutableDom.StringLiteral.FromMutable(fragment.UserId),
                password: ImmutableDom.StringLiteral.FromMutable(fragment.Password),
                providerString: ImmutableDom.StringLiteral.FromMutable(fragment.ProviderString),
                query: ImmutableDom.StringLiteral.FromMutable(fragment.Query),
                @object: ImmutableDom.SchemaObjectName.FromMutable(fragment.Object),
                withColumns: fragment.WithColumns.SelectList(ImmutableDom.OpenRowsetColumnDefinition.FromMutable),
                columns: fragment.Columns.SelectList(ImmutableDom.Identifier.FromMutable),
                alias: ImmutableDom.Identifier.FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
    
    }

}
