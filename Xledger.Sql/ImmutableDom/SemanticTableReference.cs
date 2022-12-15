using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SemanticTableReference : TableReferenceWithAlias, IEquatable<SemanticTableReference> {
        protected ScriptDom.SemanticFunctionType semanticFunctionType = ScriptDom.SemanticFunctionType.None;
        protected SchemaObjectName tableName;
        protected IReadOnlyList<ColumnReferenceExpression> columns;
        protected ScalarExpression sourceKey;
        protected ColumnReferenceExpression matchedColumn;
        protected ScalarExpression matchedKey;
    
        public ScriptDom.SemanticFunctionType SemanticFunctionType => semanticFunctionType;
        public SchemaObjectName TableName => tableName;
        public IReadOnlyList<ColumnReferenceExpression> Columns => columns;
        public ScalarExpression SourceKey => sourceKey;
        public ColumnReferenceExpression MatchedColumn => matchedColumn;
        public ScalarExpression MatchedKey => matchedKey;
    
        public SemanticTableReference(ScriptDom.SemanticFunctionType semanticFunctionType = ScriptDom.SemanticFunctionType.None, SchemaObjectName tableName = null, IReadOnlyList<ColumnReferenceExpression> columns = null, ScalarExpression sourceKey = null, ColumnReferenceExpression matchedColumn = null, ScalarExpression matchedKey = null, Identifier alias = null, bool forPath = false) {
            this.semanticFunctionType = semanticFunctionType;
            this.tableName = tableName;
            this.columns = ImmList<ColumnReferenceExpression>.FromList(columns);
            this.sourceKey = sourceKey;
            this.matchedColumn = matchedColumn;
            this.matchedKey = matchedKey;
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.SemanticTableReference ToMutableConcrete() {
            var ret = new ScriptDom.SemanticTableReference();
            ret.SemanticFunctionType = semanticFunctionType;
            ret.TableName = (ScriptDom.SchemaObjectName)tableName.ToMutable();
            ret.Columns.AddRange(columns.SelectList(c => (ScriptDom.ColumnReferenceExpression)c.ToMutable()));
            ret.SourceKey = (ScriptDom.ScalarExpression)sourceKey.ToMutable();
            ret.MatchedColumn = (ScriptDom.ColumnReferenceExpression)matchedColumn.ToMutable();
            ret.MatchedKey = (ScriptDom.ScalarExpression)matchedKey.ToMutable();
            ret.Alias = (ScriptDom.Identifier)alias.ToMutable();
            ret.ForPath = forPath;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + semanticFunctionType.GetHashCode();
            if (!(tableName is null)) {
                h = h * 23 + tableName.GetHashCode();
            }
            h = h * 23 + columns.GetHashCode();
            if (!(sourceKey is null)) {
                h = h * 23 + sourceKey.GetHashCode();
            }
            if (!(matchedColumn is null)) {
                h = h * 23 + matchedColumn.GetHashCode();
            }
            if (!(matchedKey is null)) {
                h = h * 23 + matchedKey.GetHashCode();
            }
            if (!(alias is null)) {
                h = h * 23 + alias.GetHashCode();
            }
            h = h * 23 + forPath.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SemanticTableReference);
        } 
        
        public bool Equals(SemanticTableReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.SemanticFunctionType>.Default.Equals(other.SemanticFunctionType, semanticFunctionType)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.TableName, tableName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ColumnReferenceExpression>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.SourceKey, sourceKey)) {
                return false;
            }
            if (!EqualityComparer<ColumnReferenceExpression>.Default.Equals(other.MatchedColumn, matchedColumn)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.MatchedKey, matchedKey)) {
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
        
        public static bool operator ==(SemanticTableReference left, SemanticTableReference right) {
            return EqualityComparer<SemanticTableReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SemanticTableReference left, SemanticTableReference right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SemanticTableReference)that;
            compare = Comparer.DefaultInvariant.Compare(this.semanticFunctionType, othr.semanticFunctionType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.tableName, othr.tableName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.columns, othr.columns);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.sourceKey, othr.sourceKey);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.matchedColumn, othr.matchedColumn);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.matchedKey, othr.matchedKey);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.alias, othr.alias);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.forPath, othr.forPath);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (SemanticTableReference left, SemanticTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SemanticTableReference left, SemanticTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SemanticTableReference left, SemanticTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SemanticTableReference left, SemanticTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
