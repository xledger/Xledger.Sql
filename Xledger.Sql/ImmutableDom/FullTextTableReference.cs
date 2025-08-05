using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FullTextTableReference : TableReferenceWithAlias, IEquatable<FullTextTableReference> {
        protected ScriptDom.FullTextFunctionType fullTextFunctionType = ScriptDom.FullTextFunctionType.None;
        protected SchemaObjectName tableName;
        protected IReadOnlyList<ColumnReferenceExpression> columns;
        protected ValueExpression searchCondition;
        protected ValueExpression topN;
        protected ValueExpression language;
        protected StringLiteral propertyName;
    
        public ScriptDom.FullTextFunctionType FullTextFunctionType => fullTextFunctionType;
        public SchemaObjectName TableName => tableName;
        public IReadOnlyList<ColumnReferenceExpression> Columns => columns;
        public ValueExpression SearchCondition => searchCondition;
        public ValueExpression TopN => topN;
        public ValueExpression Language => language;
        public StringLiteral PropertyName => propertyName;
    
        public FullTextTableReference(ScriptDom.FullTextFunctionType fullTextFunctionType = ScriptDom.FullTextFunctionType.None, SchemaObjectName tableName = null, IReadOnlyList<ColumnReferenceExpression> columns = null, ValueExpression searchCondition = null, ValueExpression topN = null, ValueExpression language = null, StringLiteral propertyName = null, Identifier alias = null, bool forPath = false) {
            this.fullTextFunctionType = fullTextFunctionType;
            this.tableName = tableName;
            this.columns = columns.ToImmArray<ColumnReferenceExpression>();
            this.searchCondition = searchCondition;
            this.topN = topN;
            this.language = language;
            this.propertyName = propertyName;
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.FullTextTableReference ToMutableConcrete() {
            var ret = new ScriptDom.FullTextTableReference();
            ret.FullTextFunctionType = fullTextFunctionType;
            ret.TableName = (ScriptDom.SchemaObjectName)tableName?.ToMutable();
            ret.Columns.AddRange(columns.Select(c => (ScriptDom.ColumnReferenceExpression)c?.ToMutable()));
            ret.SearchCondition = (ScriptDom.ValueExpression)searchCondition?.ToMutable();
            ret.TopN = (ScriptDom.ValueExpression)topN?.ToMutable();
            ret.Language = (ScriptDom.ValueExpression)language?.ToMutable();
            ret.PropertyName = (ScriptDom.StringLiteral)propertyName?.ToMutable();
            ret.Alias = (ScriptDom.Identifier)alias?.ToMutable();
            ret.ForPath = forPath;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + fullTextFunctionType.GetHashCode();
            if (!(tableName is null)) {
                h = h * 23 + tableName.GetHashCode();
            }
            h = h * 23 + columns.GetHashCode();
            if (!(searchCondition is null)) {
                h = h * 23 + searchCondition.GetHashCode();
            }
            if (!(topN is null)) {
                h = h * 23 + topN.GetHashCode();
            }
            if (!(language is null)) {
                h = h * 23 + language.GetHashCode();
            }
            if (!(propertyName is null)) {
                h = h * 23 + propertyName.GetHashCode();
            }
            if (!(alias is null)) {
                h = h * 23 + alias.GetHashCode();
            }
            h = h * 23 + forPath.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as FullTextTableReference);
        } 
        
        public bool Equals(FullTextTableReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.FullTextFunctionType>.Default.Equals(other.FullTextFunctionType, fullTextFunctionType)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.TableName, tableName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ColumnReferenceExpression>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.SearchCondition, searchCondition)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.TopN, topN)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.Language, language)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.PropertyName, propertyName)) {
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
        
        public static bool operator ==(FullTextTableReference left, FullTextTableReference right) {
            return EqualityComparer<FullTextTableReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FullTextTableReference left, FullTextTableReference right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (FullTextTableReference)that;
            compare = Comparer.DefaultInvariant.Compare(this.fullTextFunctionType, othr.fullTextFunctionType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.tableName, othr.tableName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.columns, othr.columns);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.searchCondition, othr.searchCondition);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.topN, othr.topN);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.language, othr.language);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.propertyName, othr.propertyName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.alias, othr.alias);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.forPath, othr.forPath);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (FullTextTableReference left, FullTextTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(FullTextTableReference left, FullTextTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (FullTextTableReference left, FullTextTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(FullTextTableReference left, FullTextTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static FullTextTableReference FromMutable(ScriptDom.FullTextTableReference fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.FullTextTableReference)) { throw new NotImplementedException("Unexpected subtype of FullTextTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FullTextTableReference(
                fullTextFunctionType: fragment.FullTextFunctionType,
                tableName: ImmutableDom.SchemaObjectName.FromMutable(fragment.TableName),
                columns: fragment.Columns.ToImmArray(ImmutableDom.ColumnReferenceExpression.FromMutable),
                searchCondition: ImmutableDom.ValueExpression.FromMutable(fragment.SearchCondition),
                topN: ImmutableDom.ValueExpression.FromMutable(fragment.TopN),
                language: ImmutableDom.ValueExpression.FromMutable(fragment.Language),
                propertyName: ImmutableDom.StringLiteral.FromMutable(fragment.PropertyName),
                alias: ImmutableDom.Identifier.FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
    
    }

}
