using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterDatabaseTermination : TSqlFragment, IEquatable<AlterDatabaseTermination> {
        bool immediateRollback = false;
        Literal rollbackAfter;
        bool noWait = false;
    
        public bool ImmediateRollback => immediateRollback;
        public Literal RollbackAfter => rollbackAfter;
        public bool NoWait => noWait;
    
        public AlterDatabaseTermination(bool immediateRollback = false, Literal rollbackAfter = null, bool noWait = false) {
            this.immediateRollback = immediateRollback;
            this.rollbackAfter = rollbackAfter;
            this.noWait = noWait;
        }
    
        public ScriptDom.AlterDatabaseTermination ToMutableConcrete() {
            var ret = new ScriptDom.AlterDatabaseTermination();
            ret.ImmediateRollback = immediateRollback;
            ret.RollbackAfter = (ScriptDom.Literal)rollbackAfter.ToMutable();
            ret.NoWait = noWait;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + immediateRollback.GetHashCode();
            if (!(rollbackAfter is null)) {
                h = h * 23 + rollbackAfter.GetHashCode();
            }
            h = h * 23 + noWait.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterDatabaseTermination);
        } 
        
        public bool Equals(AlterDatabaseTermination other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.ImmediateRollback, immediateRollback)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.RollbackAfter, rollbackAfter)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.NoWait, noWait)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterDatabaseTermination left, AlterDatabaseTermination right) {
            return EqualityComparer<AlterDatabaseTermination>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterDatabaseTermination left, AlterDatabaseTermination right) {
            return !(left == right);
        }
    
    }

}