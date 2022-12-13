using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TSqlBatch : TSqlFragment, IEquatable<TSqlBatch> {
        protected IReadOnlyList<TSqlStatement> statements;
    
        public IReadOnlyList<TSqlStatement> Statements => statements;
    
        public TSqlBatch(IReadOnlyList<TSqlStatement> statements = null) {
            this.statements = statements is null ? ImmList<TSqlStatement>.Empty : ImmList<TSqlStatement>.FromList(statements);
        }
    
        public ScriptDom.TSqlBatch ToMutableConcrete() {
            var ret = new ScriptDom.TSqlBatch();
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
            return Equals(obj as TSqlBatch);
        } 
        
        public bool Equals(TSqlBatch other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<TSqlStatement>>.Default.Equals(other.Statements, statements)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TSqlBatch left, TSqlBatch right) {
            return EqualityComparer<TSqlBatch>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TSqlBatch left, TSqlBatch right) {
            return !(left == right);
        }
    
        public static TSqlBatch FromMutable(ScriptDom.TSqlBatch fragment) {
            return (TSqlBatch)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
