using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class IIfCall : PrimaryExpression, IEquatable<IIfCall> {
        protected BooleanExpression predicate;
        protected ScalarExpression thenExpression;
        protected ScalarExpression elseExpression;
    
        public BooleanExpression Predicate => predicate;
        public ScalarExpression ThenExpression => thenExpression;
        public ScalarExpression ElseExpression => elseExpression;
    
        public IIfCall(BooleanExpression predicate = null, ScalarExpression thenExpression = null, ScalarExpression elseExpression = null, Identifier collation = null) {
            this.predicate = predicate;
            this.thenExpression = thenExpression;
            this.elseExpression = elseExpression;
            this.collation = collation;
        }
    
        public ScriptDom.IIfCall ToMutableConcrete() {
            var ret = new ScriptDom.IIfCall();
            ret.Predicate = (ScriptDom.BooleanExpression)predicate?.ToMutable();
            ret.ThenExpression = (ScriptDom.ScalarExpression)thenExpression?.ToMutable();
            ret.ElseExpression = (ScriptDom.ScalarExpression)elseExpression?.ToMutable();
            ret.Collation = (ScriptDom.Identifier)collation?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(predicate is null)) {
                h = h * 23 + predicate.GetHashCode();
            }
            if (!(thenExpression is null)) {
                h = h * 23 + thenExpression.GetHashCode();
            }
            if (!(elseExpression is null)) {
                h = h * 23 + elseExpression.GetHashCode();
            }
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as IIfCall);
        } 
        
        public bool Equals(IIfCall other) {
            if (other is null) { return false; }
            if (!EqualityComparer<BooleanExpression>.Default.Equals(other.Predicate, predicate)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.ThenExpression, thenExpression)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.ElseExpression, elseExpression)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(IIfCall left, IIfCall right) {
            return EqualityComparer<IIfCall>.Default.Equals(left, right);
        }
        
        public static bool operator !=(IIfCall left, IIfCall right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (IIfCall)that;
            compare = Comparer.DefaultInvariant.Compare(this.predicate, othr.predicate);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.thenExpression, othr.thenExpression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.elseExpression, othr.elseExpression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (IIfCall left, IIfCall right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(IIfCall left, IIfCall right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (IIfCall left, IIfCall right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(IIfCall left, IIfCall right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
