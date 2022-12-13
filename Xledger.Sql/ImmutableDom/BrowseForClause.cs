using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BrowseForClause : ForClause, IEquatable<BrowseForClause> {
        public BrowseForClause() {

        }
    
        public ScriptDom.BrowseForClause ToMutableConcrete() {
            var ret = new ScriptDom.BrowseForClause();
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
            return Equals(obj as BrowseForClause);
        } 
        
        public bool Equals(BrowseForClause other) {
            if (other is null) { return false; }
            return true;
        } 
        
        public static bool operator ==(BrowseForClause left, BrowseForClause right) {
            return EqualityComparer<BrowseForClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BrowseForClause left, BrowseForClause right) {
            return !(left == right);
        }
    
        public static BrowseForClause FromMutable(ScriptDom.BrowseForClause fragment) {
            return (BrowseForClause)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
