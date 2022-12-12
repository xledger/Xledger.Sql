using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class IfStatement : TSqlStatement, IEquatable<IfStatement> {
        protected BooleanExpression predicate;
        protected TSqlStatement thenStatement;
        protected TSqlStatement elseStatement;
    
        public BooleanExpression Predicate => predicate;
        public TSqlStatement ThenStatement => thenStatement;
        public TSqlStatement ElseStatement => elseStatement;
    
        public IfStatement(BooleanExpression predicate = null, TSqlStatement thenStatement = null, TSqlStatement elseStatement = null) {
            this.predicate = predicate;
            this.thenStatement = thenStatement;
            this.elseStatement = elseStatement;
        }
    
        public ScriptDom.IfStatement ToMutableConcrete() {
            var ret = new ScriptDom.IfStatement();
            ret.Predicate = (ScriptDom.BooleanExpression)predicate.ToMutable();
            ret.ThenStatement = (ScriptDom.TSqlStatement)thenStatement.ToMutable();
            ret.ElseStatement = (ScriptDom.TSqlStatement)elseStatement.ToMutable();
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
            if (!(thenStatement is null)) {
                h = h * 23 + thenStatement.GetHashCode();
            }
            if (!(elseStatement is null)) {
                h = h * 23 + elseStatement.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as IfStatement);
        } 
        
        public bool Equals(IfStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<BooleanExpression>.Default.Equals(other.Predicate, predicate)) {
                return false;
            }
            if (!EqualityComparer<TSqlStatement>.Default.Equals(other.ThenStatement, thenStatement)) {
                return false;
            }
            if (!EqualityComparer<TSqlStatement>.Default.Equals(other.ElseStatement, elseStatement)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(IfStatement left, IfStatement right) {
            return EqualityComparer<IfStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(IfStatement left, IfStatement right) {
            return !(left == right);
        }
    
    }

}
