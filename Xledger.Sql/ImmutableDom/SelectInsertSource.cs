using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SelectInsertSource : InsertSource, IEquatable<SelectInsertSource> {
        QueryExpression select;
    
        public QueryExpression Select => select;
    
        public SelectInsertSource(QueryExpression select = null) {
            this.select = select;
        }
    
        public ScriptDom.SelectInsertSource ToMutableConcrete() {
            var ret = new ScriptDom.SelectInsertSource();
            ret.Select = (ScriptDom.QueryExpression)select.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(select is null)) {
                h = h * 23 + select.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SelectInsertSource);
        } 
        
        public bool Equals(SelectInsertSource other) {
            if (other is null) { return false; }
            if (!EqualityComparer<QueryExpression>.Default.Equals(other.Select, select)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SelectInsertSource left, SelectInsertSource right) {
            return EqualityComparer<SelectInsertSource>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SelectInsertSource left, SelectInsertSource right) {
            return !(left == right);
        }
    
    }

}
