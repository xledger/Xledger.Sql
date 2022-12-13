using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterSearchPropertyListStatement : TSqlStatement, IEquatable<AlterSearchPropertyListStatement> {
        protected Identifier name;
        protected SearchPropertyListAction action;
    
        public Identifier Name => name;
        public SearchPropertyListAction Action => action;
    
        public AlterSearchPropertyListStatement(Identifier name = null, SearchPropertyListAction action = null) {
            this.name = name;
            this.action = action;
        }
    
        public ScriptDom.AlterSearchPropertyListStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterSearchPropertyListStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.Action = (ScriptDom.SearchPropertyListAction)action.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            if (!(action is null)) {
                h = h * 23 + action.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterSearchPropertyListStatement);
        } 
        
        public bool Equals(AlterSearchPropertyListStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<SearchPropertyListAction>.Default.Equals(other.Action, action)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterSearchPropertyListStatement left, AlterSearchPropertyListStatement right) {
            return EqualityComparer<AlterSearchPropertyListStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterSearchPropertyListStatement left, AlterSearchPropertyListStatement right) {
            return !(left == right);
        }
    
        public static AlterSearchPropertyListStatement FromMutable(ScriptDom.AlterSearchPropertyListStatement fragment) {
            return (AlterSearchPropertyListStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
