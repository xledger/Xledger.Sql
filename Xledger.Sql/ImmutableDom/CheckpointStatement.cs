using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CheckpointStatement : TSqlStatement, IEquatable<CheckpointStatement> {
        protected Literal duration;
    
        public Literal Duration => duration;
    
        public CheckpointStatement(Literal duration = null) {
            this.duration = duration;
        }
    
        public ScriptDom.CheckpointStatement ToMutableConcrete() {
            var ret = new ScriptDom.CheckpointStatement();
            ret.Duration = (ScriptDom.Literal)duration.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(duration is null)) {
                h = h * 23 + duration.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CheckpointStatement);
        } 
        
        public bool Equals(CheckpointStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Duration, duration)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CheckpointStatement left, CheckpointStatement right) {
            return EqualityComparer<CheckpointStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CheckpointStatement left, CheckpointStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CheckpointStatement)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.duration, othr.duration);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static CheckpointStatement FromMutable(ScriptDom.CheckpointStatement fragment) {
            return (CheckpointStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
