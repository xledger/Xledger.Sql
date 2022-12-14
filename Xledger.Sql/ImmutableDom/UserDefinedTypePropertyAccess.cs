using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class UserDefinedTypePropertyAccess : PrimaryExpression, IEquatable<UserDefinedTypePropertyAccess> {
        protected CallTarget callTarget;
        protected Identifier propertyName;
    
        public CallTarget CallTarget => callTarget;
        public Identifier PropertyName => propertyName;
    
        public UserDefinedTypePropertyAccess(CallTarget callTarget = null, Identifier propertyName = null, Identifier collation = null) {
            this.callTarget = callTarget;
            this.propertyName = propertyName;
            this.collation = collation;
        }
    
        public ScriptDom.UserDefinedTypePropertyAccess ToMutableConcrete() {
            var ret = new ScriptDom.UserDefinedTypePropertyAccess();
            ret.CallTarget = (ScriptDom.CallTarget)callTarget.ToMutable();
            ret.PropertyName = (ScriptDom.Identifier)propertyName.ToMutable();
            ret.Collation = (ScriptDom.Identifier)collation.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(callTarget is null)) {
                h = h * 23 + callTarget.GetHashCode();
            }
            if (!(propertyName is null)) {
                h = h * 23 + propertyName.GetHashCode();
            }
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as UserDefinedTypePropertyAccess);
        } 
        
        public bool Equals(UserDefinedTypePropertyAccess other) {
            if (other is null) { return false; }
            if (!EqualityComparer<CallTarget>.Default.Equals(other.CallTarget, callTarget)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.PropertyName, propertyName)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(UserDefinedTypePropertyAccess left, UserDefinedTypePropertyAccess right) {
            return EqualityComparer<UserDefinedTypePropertyAccess>.Default.Equals(left, right);
        }
        
        public static bool operator !=(UserDefinedTypePropertyAccess left, UserDefinedTypePropertyAccess right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (UserDefinedTypePropertyAccess)that;
            compare = Comparer.DefaultInvariant.Compare(this.callTarget, othr.callTarget);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.propertyName, othr.propertyName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (UserDefinedTypePropertyAccess left, UserDefinedTypePropertyAccess right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(UserDefinedTypePropertyAccess left, UserDefinedTypePropertyAccess right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (UserDefinedTypePropertyAccess left, UserDefinedTypePropertyAccess right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(UserDefinedTypePropertyAccess left, UserDefinedTypePropertyAccess right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static UserDefinedTypePropertyAccess FromMutable(ScriptDom.UserDefinedTypePropertyAccess fragment) {
            return (UserDefinedTypePropertyAccess)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
