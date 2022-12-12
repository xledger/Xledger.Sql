using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SimpleAlterFullTextIndexAction : AlterFullTextIndexAction, IEquatable<SimpleAlterFullTextIndexAction> {
        protected ScriptDom.SimpleAlterFullTextIndexActionKind actionKind = ScriptDom.SimpleAlterFullTextIndexActionKind.None;
    
        public ScriptDom.SimpleAlterFullTextIndexActionKind ActionKind => actionKind;
    
        public SimpleAlterFullTextIndexAction(ScriptDom.SimpleAlterFullTextIndexActionKind actionKind = ScriptDom.SimpleAlterFullTextIndexActionKind.None) {
            this.actionKind = actionKind;
        }
    
        public ScriptDom.SimpleAlterFullTextIndexAction ToMutableConcrete() {
            var ret = new ScriptDom.SimpleAlterFullTextIndexAction();
            ret.ActionKind = actionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + actionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SimpleAlterFullTextIndexAction);
        } 
        
        public bool Equals(SimpleAlterFullTextIndexAction other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.SimpleAlterFullTextIndexActionKind>.Default.Equals(other.ActionKind, actionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SimpleAlterFullTextIndexAction left, SimpleAlterFullTextIndexAction right) {
            return EqualityComparer<SimpleAlterFullTextIndexAction>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SimpleAlterFullTextIndexAction left, SimpleAlterFullTextIndexAction right) {
            return !(left == right);
        }
    
    }

}
