using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BeginEndBlockStatement : TSqlStatement, IEquatable<BeginEndBlockStatement> {
        protected StatementList statementList;
    
        public StatementList StatementList => statementList;
    
        public BeginEndBlockStatement(StatementList statementList = null) {
            this.statementList = statementList;
        }
    
        public ScriptDom.BeginEndBlockStatement ToMutableConcrete() {
            var ret = new ScriptDom.BeginEndBlockStatement();
            ret.StatementList = (ScriptDom.StatementList)statementList.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(statementList is null)) {
                h = h * 23 + statementList.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as BeginEndBlockStatement);
        } 
        
        public bool Equals(BeginEndBlockStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<StatementList>.Default.Equals(other.StatementList, statementList)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(BeginEndBlockStatement left, BeginEndBlockStatement right) {
            return EqualityComparer<BeginEndBlockStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BeginEndBlockStatement left, BeginEndBlockStatement right) {
            return !(left == right);
        }
    
        public static BeginEndBlockStatement FromMutable(ScriptDom.BeginEndBlockStatement fragment) {
            return (BeginEndBlockStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
