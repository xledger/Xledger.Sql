using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SetUserStatement : TSqlStatement, IEquatable<SetUserStatement> {
        protected ValueExpression userName;
        protected bool withNoReset = false;
    
        public ValueExpression UserName => userName;
        public bool WithNoReset => withNoReset;
    
        public SetUserStatement(ValueExpression userName = null, bool withNoReset = false) {
            this.userName = userName;
            this.withNoReset = withNoReset;
        }
    
        public ScriptDom.SetUserStatement ToMutableConcrete() {
            var ret = new ScriptDom.SetUserStatement();
            ret.UserName = (ScriptDom.ValueExpression)userName?.ToMutable();
            ret.WithNoReset = withNoReset;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(userName is null)) {
                h = h * 23 + userName.GetHashCode();
            }
            h = h * 23 + withNoReset.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SetUserStatement);
        } 
        
        public bool Equals(SetUserStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.UserName, userName)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.WithNoReset, withNoReset)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SetUserStatement left, SetUserStatement right) {
            return EqualityComparer<SetUserStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SetUserStatement left, SetUserStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SetUserStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.userName, othr.userName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.withNoReset, othr.withNoReset);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (SetUserStatement left, SetUserStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SetUserStatement left, SetUserStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SetUserStatement left, SetUserStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SetUserStatement left, SetUserStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SetUserStatement FromMutable(ScriptDom.SetUserStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.SetUserStatement)) { throw new NotImplementedException("Unexpected subtype of SetUserStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SetUserStatement(
                userName: ImmutableDom.ValueExpression.FromMutable(fragment.UserName),
                withNoReset: fragment.WithNoReset
            );
        }
    
    }

}
