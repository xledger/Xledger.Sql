using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SetErrorLevelStatement : TSqlStatement, IEquatable<SetErrorLevelStatement> {
        protected ScalarExpression level;
    
        public ScalarExpression Level => level;
    
        public SetErrorLevelStatement(ScalarExpression level = null) {
            this.level = level;
        }
    
        public ScriptDom.SetErrorLevelStatement ToMutableConcrete() {
            var ret = new ScriptDom.SetErrorLevelStatement();
            ret.Level = (ScriptDom.ScalarExpression)level?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(level is null)) {
                h = h * 23 + level.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SetErrorLevelStatement);
        } 
        
        public bool Equals(SetErrorLevelStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Level, level)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SetErrorLevelStatement left, SetErrorLevelStatement right) {
            return EqualityComparer<SetErrorLevelStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SetErrorLevelStatement left, SetErrorLevelStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SetErrorLevelStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.level, othr.level);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (SetErrorLevelStatement left, SetErrorLevelStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SetErrorLevelStatement left, SetErrorLevelStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SetErrorLevelStatement left, SetErrorLevelStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SetErrorLevelStatement left, SetErrorLevelStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SetErrorLevelStatement FromMutable(ScriptDom.SetErrorLevelStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.SetErrorLevelStatement)) { throw new NotImplementedException("Unexpected subtype of SetErrorLevelStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SetErrorLevelStatement(
                level: ImmutableDom.ScalarExpression.FromMutable(fragment.Level)
            );
        }
    
    }

}
