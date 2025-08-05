using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SetTransactionIsolationLevelStatement : TSqlStatement, IEquatable<SetTransactionIsolationLevelStatement> {
        protected ScriptDom.IsolationLevel level = ScriptDom.IsolationLevel.None;
    
        public ScriptDom.IsolationLevel Level => level;
    
        public SetTransactionIsolationLevelStatement(ScriptDom.IsolationLevel level = ScriptDom.IsolationLevel.None) {
            this.level = level;
        }
    
        public ScriptDom.SetTransactionIsolationLevelStatement ToMutableConcrete() {
            var ret = new ScriptDom.SetTransactionIsolationLevelStatement();
            ret.Level = level;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + level.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SetTransactionIsolationLevelStatement);
        } 
        
        public bool Equals(SetTransactionIsolationLevelStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.IsolationLevel>.Default.Equals(other.Level, level)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SetTransactionIsolationLevelStatement left, SetTransactionIsolationLevelStatement right) {
            return EqualityComparer<SetTransactionIsolationLevelStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SetTransactionIsolationLevelStatement left, SetTransactionIsolationLevelStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SetTransactionIsolationLevelStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.level, othr.level);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (SetTransactionIsolationLevelStatement left, SetTransactionIsolationLevelStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SetTransactionIsolationLevelStatement left, SetTransactionIsolationLevelStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SetTransactionIsolationLevelStatement left, SetTransactionIsolationLevelStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SetTransactionIsolationLevelStatement left, SetTransactionIsolationLevelStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SetTransactionIsolationLevelStatement FromMutable(ScriptDom.SetTransactionIsolationLevelStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.SetTransactionIsolationLevelStatement)) { throw new NotImplementedException("Unexpected subtype of SetTransactionIsolationLevelStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SetTransactionIsolationLevelStatement(
                level: fragment.Level
            );
        }
    
    }

}
