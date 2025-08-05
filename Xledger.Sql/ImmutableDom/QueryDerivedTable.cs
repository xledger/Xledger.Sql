using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class QueryDerivedTable : TableReferenceWithAliasAndColumns, IEquatable<QueryDerivedTable> {
        protected QueryExpression queryExpression;
    
        public QueryExpression QueryExpression => queryExpression;
    
        public QueryDerivedTable(QueryExpression queryExpression = null, IReadOnlyList<Identifier> columns = null, Identifier alias = null, bool forPath = false) {
            this.queryExpression = queryExpression;
            this.columns = columns.ToImmArray<Identifier>();
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.QueryDerivedTable ToMutableConcrete() {
            var ret = new ScriptDom.QueryDerivedTable();
            ret.QueryExpression = (ScriptDom.QueryExpression)queryExpression?.ToMutable();
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
            if (!(queryExpression is null)) {
                h = h * 23 + queryExpression.GetHashCode();
            }
            h = h * 23 + columns.GetHashCode();
            if (!(alias is null)) {
                h = h * 23 + alias.GetHashCode();
            }
            h = h * 23 + forPath.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as QueryDerivedTable);
        } 
        
        public bool Equals(QueryDerivedTable other) {
            if (other is null) { return false; }
            if (!EqualityComparer<QueryExpression>.Default.Equals(other.QueryExpression, queryExpression)) {
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
        
        public static bool operator ==(QueryDerivedTable left, QueryDerivedTable right) {
            return EqualityComparer<QueryDerivedTable>.Default.Equals(left, right);
        }
        
        public static bool operator !=(QueryDerivedTable left, QueryDerivedTable right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (QueryDerivedTable)that;
            compare = Comparer.DefaultInvariant.Compare(this.queryExpression, othr.queryExpression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.columns, othr.columns);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.alias, othr.alias);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.forPath, othr.forPath);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (QueryDerivedTable left, QueryDerivedTable right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(QueryDerivedTable left, QueryDerivedTable right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (QueryDerivedTable left, QueryDerivedTable right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(QueryDerivedTable left, QueryDerivedTable right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static QueryDerivedTable FromMutable(ScriptDom.QueryDerivedTable fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.QueryDerivedTable)) { throw new NotImplementedException("Unexpected subtype of QueryDerivedTable not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new QueryDerivedTable(
                queryExpression: ImmutableDom.QueryExpression.FromMutable(fragment.QueryExpression),
                columns: fragment.Columns.ToImmArray(ImmutableDom.Identifier.FromMutable),
                alias: ImmutableDom.Identifier.FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
    
    }

}
