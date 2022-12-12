using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class QueryDerivedTable : TableReferenceWithAliasAndColumns, IEquatable<QueryDerivedTable> {
        QueryExpression queryExpression;
    
        public QueryExpression QueryExpression => queryExpression;
    
        public QueryDerivedTable(QueryExpression queryExpression = null, IReadOnlyList<Identifier> columns = null, Identifier alias = null, bool forPath = false) {
            this.queryExpression = queryExpression;
            this.columns = columns is null ? ImmList<Identifier>.Empty : ImmList<Identifier>.FromList(columns);
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.QueryDerivedTable ToMutableConcrete() {
            var ret = new ScriptDom.QueryDerivedTable();
            ret.QueryExpression = (ScriptDom.QueryExpression)queryExpression.ToMutable();
            ret.Columns.AddRange(columns.Select(c => (ScriptDom.Identifier)c.ToMutable()));
            ret.Alias = (ScriptDom.Identifier)alias.ToMutable();
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
    
    }

}
