using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ParameterlessCall : PrimaryExpression, IEquatable<ParameterlessCall> {
        protected ScriptDom.ParameterlessCallType parameterlessCallType = ScriptDom.ParameterlessCallType.User;
    
        public ScriptDom.ParameterlessCallType ParameterlessCallType => parameterlessCallType;
    
        public ParameterlessCall(ScriptDom.ParameterlessCallType parameterlessCallType = ScriptDom.ParameterlessCallType.User, Identifier collation = null) {
            this.parameterlessCallType = parameterlessCallType;
            this.collation = collation;
        }
    
        public ScriptDom.ParameterlessCall ToMutableConcrete() {
            var ret = new ScriptDom.ParameterlessCall();
            ret.ParameterlessCallType = parameterlessCallType;
            ret.Collation = (ScriptDom.Identifier)collation.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + parameterlessCallType.GetHashCode();
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ParameterlessCall);
        } 
        
        public bool Equals(ParameterlessCall other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ParameterlessCallType>.Default.Equals(other.ParameterlessCallType, parameterlessCallType)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ParameterlessCall left, ParameterlessCall right) {
            return EqualityComparer<ParameterlessCall>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ParameterlessCall left, ParameterlessCall right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ParameterlessCall)that;
            compare = Comparer.DefaultInvariant.Compare(this.parameterlessCallType, othr.parameterlessCallType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ParameterlessCall left, ParameterlessCall right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ParameterlessCall left, ParameterlessCall right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ParameterlessCall left, ParameterlessCall right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ParameterlessCall left, ParameterlessCall right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ParameterlessCall FromMutable(ScriptDom.ParameterlessCall fragment) {
            return (ParameterlessCall)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
