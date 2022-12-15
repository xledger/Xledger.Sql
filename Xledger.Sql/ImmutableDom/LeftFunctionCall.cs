using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LeftFunctionCall : PrimaryExpression, IEquatable<LeftFunctionCall> {
        protected IReadOnlyList<ScalarExpression> parameters;
    
        public IReadOnlyList<ScalarExpression> Parameters => parameters;
    
        public LeftFunctionCall(IReadOnlyList<ScalarExpression> parameters = null, Identifier collation = null) {
            this.parameters = ImmList<ScalarExpression>.FromList(parameters);
            this.collation = collation;
        }
    
        public ScriptDom.LeftFunctionCall ToMutableConcrete() {
            var ret = new ScriptDom.LeftFunctionCall();
            ret.Parameters.AddRange(parameters.SelectList(c => (ScriptDom.ScalarExpression)c.ToMutable()));
            ret.Collation = (ScriptDom.Identifier)collation.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + parameters.GetHashCode();
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as LeftFunctionCall);
        } 
        
        public bool Equals(LeftFunctionCall other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<ScalarExpression>>.Default.Equals(other.Parameters, parameters)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LeftFunctionCall left, LeftFunctionCall right) {
            return EqualityComparer<LeftFunctionCall>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LeftFunctionCall left, LeftFunctionCall right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (LeftFunctionCall)that;
            compare = Comparer.DefaultInvariant.Compare(this.parameters, othr.parameters);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (LeftFunctionCall left, LeftFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(LeftFunctionCall left, LeftFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (LeftFunctionCall left, LeftFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(LeftFunctionCall left, LeftFunctionCall right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
