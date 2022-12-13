using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ReadOnlyForClause : ForClause, IEquatable<ReadOnlyForClause> {
        public ReadOnlyForClause() {

        }
    
        public ScriptDom.ReadOnlyForClause ToMutableConcrete() {
            var ret = new ScriptDom.ReadOnlyForClause();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ReadOnlyForClause);
        } 
        
        public bool Equals(ReadOnlyForClause other) {
            if (other is null) { return false; }
            return true;
        } 
        
        public static bool operator ==(ReadOnlyForClause left, ReadOnlyForClause right) {
            return EqualityComparer<ReadOnlyForClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ReadOnlyForClause left, ReadOnlyForClause right) {
            return !(left == right);
        }
    
        public static ReadOnlyForClause FromMutable(ScriptDom.ReadOnlyForClause fragment) {
            return (ReadOnlyForClause)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
