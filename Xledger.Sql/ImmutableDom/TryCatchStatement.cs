using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TryCatchStatement : TSqlStatement, IEquatable<TryCatchStatement> {
        protected StatementList tryStatements;
        protected StatementList catchStatements;
    
        public StatementList TryStatements => tryStatements;
        public StatementList CatchStatements => catchStatements;
    
        public TryCatchStatement(StatementList tryStatements = null, StatementList catchStatements = null) {
            this.tryStatements = tryStatements;
            this.catchStatements = catchStatements;
        }
    
        public ScriptDom.TryCatchStatement ToMutableConcrete() {
            var ret = new ScriptDom.TryCatchStatement();
            ret.TryStatements = (ScriptDom.StatementList)tryStatements.ToMutable();
            ret.CatchStatements = (ScriptDom.StatementList)catchStatements.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(tryStatements is null)) {
                h = h * 23 + tryStatements.GetHashCode();
            }
            if (!(catchStatements is null)) {
                h = h * 23 + catchStatements.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TryCatchStatement);
        } 
        
        public bool Equals(TryCatchStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<StatementList>.Default.Equals(other.TryStatements, tryStatements)) {
                return false;
            }
            if (!EqualityComparer<StatementList>.Default.Equals(other.CatchStatements, catchStatements)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TryCatchStatement left, TryCatchStatement right) {
            return EqualityComparer<TryCatchStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TryCatchStatement left, TryCatchStatement right) {
            return !(left == right);
        }
    
        public static TryCatchStatement FromMutable(ScriptDom.TryCatchStatement fragment) {
            return (TryCatchStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
