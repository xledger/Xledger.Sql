using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ThrowStatement : TSqlStatement, IEquatable<ThrowStatement> {
        protected ValueExpression errorNumber;
        protected ValueExpression message;
        protected ValueExpression state;
    
        public ValueExpression ErrorNumber => errorNumber;
        public ValueExpression Message => message;
        public ValueExpression State => state;
    
        public ThrowStatement(ValueExpression errorNumber = null, ValueExpression message = null, ValueExpression state = null) {
            this.errorNumber = errorNumber;
            this.message = message;
            this.state = state;
        }
    
        public ScriptDom.ThrowStatement ToMutableConcrete() {
            var ret = new ScriptDom.ThrowStatement();
            ret.ErrorNumber = (ScriptDom.ValueExpression)errorNumber.ToMutable();
            ret.Message = (ScriptDom.ValueExpression)message.ToMutable();
            ret.State = (ScriptDom.ValueExpression)state.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(errorNumber is null)) {
                h = h * 23 + errorNumber.GetHashCode();
            }
            if (!(message is null)) {
                h = h * 23 + message.GetHashCode();
            }
            if (!(state is null)) {
                h = h * 23 + state.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ThrowStatement);
        } 
        
        public bool Equals(ThrowStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.ErrorNumber, errorNumber)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.Message, message)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.State, state)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ThrowStatement left, ThrowStatement right) {
            return EqualityComparer<ThrowStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ThrowStatement left, ThrowStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ThrowStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.errorNumber, othr.errorNumber);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.message, othr.message);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.state, othr.state);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ThrowStatement left, ThrowStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ThrowStatement left, ThrowStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ThrowStatement left, ThrowStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ThrowStatement left, ThrowStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
