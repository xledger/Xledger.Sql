using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class StatementList : TSqlFragment, IEquatable<StatementList> {
        protected IReadOnlyList<TSqlStatement> statements;
    
        public IReadOnlyList<TSqlStatement> Statements => statements;
    
        public StatementList(IReadOnlyList<TSqlStatement> statements = null) {
            this.statements = statements is null ? ImmList<TSqlStatement>.Empty : ImmList<TSqlStatement>.FromList(statements);
        }
    
        public ScriptDom.StatementList ToMutableConcrete() {
            var ret = new ScriptDom.StatementList();
            ret.Statements.AddRange(statements.SelectList(c => (ScriptDom.TSqlStatement)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + statements.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as StatementList);
        } 
        
        public bool Equals(StatementList other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<TSqlStatement>>.Default.Equals(other.Statements, statements)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(StatementList left, StatementList right) {
            return EqualityComparer<StatementList>.Default.Equals(left, right);
        }
        
        public static bool operator !=(StatementList left, StatementList right) {
            return !(left == right);
        }
    
        public static StatementList FromMutable(ScriptDom.StatementList fragment) {
            return (StatementList)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
