using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class WhileStatement : TSqlStatement, IEquatable<WhileStatement> {
        protected BooleanExpression predicate;
        protected TSqlStatement statement;
    
        public BooleanExpression Predicate => predicate;
        public TSqlStatement Statement => statement;
    
        public WhileStatement(BooleanExpression predicate = null, TSqlStatement statement = null) {
            this.predicate = predicate;
            this.statement = statement;
        }
    
        public ScriptDom.WhileStatement ToMutableConcrete() {
            var ret = new ScriptDom.WhileStatement();
            ret.Predicate = (ScriptDom.BooleanExpression)predicate.ToMutable();
            ret.Statement = (ScriptDom.TSqlStatement)statement.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(predicate is null)) {
                h = h * 23 + predicate.GetHashCode();
            }
            if (!(statement is null)) {
                h = h * 23 + statement.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as WhileStatement);
        } 
        
        public bool Equals(WhileStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<BooleanExpression>.Default.Equals(other.Predicate, predicate)) {
                return false;
            }
            if (!EqualityComparer<TSqlStatement>.Default.Equals(other.Statement, statement)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(WhileStatement left, WhileStatement right) {
            return EqualityComparer<WhileStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(WhileStatement left, WhileStatement right) {
            return !(left == right);
        }
    
    }

}
