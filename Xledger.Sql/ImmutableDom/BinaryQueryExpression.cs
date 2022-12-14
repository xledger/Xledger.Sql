using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BinaryQueryExpression : QueryExpression, IEquatable<BinaryQueryExpression> {
        protected ScriptDom.BinaryQueryExpressionType binaryQueryExpressionType = ScriptDom.BinaryQueryExpressionType.Union;
        protected bool all = false;
        protected QueryExpression firstQueryExpression;
        protected QueryExpression secondQueryExpression;
    
        public ScriptDom.BinaryQueryExpressionType BinaryQueryExpressionType => binaryQueryExpressionType;
        public bool All => all;
        public QueryExpression FirstQueryExpression => firstQueryExpression;
        public QueryExpression SecondQueryExpression => secondQueryExpression;
    
        public BinaryQueryExpression(ScriptDom.BinaryQueryExpressionType binaryQueryExpressionType = ScriptDom.BinaryQueryExpressionType.Union, bool all = false, QueryExpression firstQueryExpression = null, QueryExpression secondQueryExpression = null, OrderByClause orderByClause = null, OffsetClause offsetClause = null, ForClause forClause = null) {
            this.binaryQueryExpressionType = binaryQueryExpressionType;
            this.all = all;
            this.firstQueryExpression = firstQueryExpression;
            this.secondQueryExpression = secondQueryExpression;
            this.orderByClause = orderByClause;
            this.offsetClause = offsetClause;
            this.forClause = forClause;
        }
    
        public ScriptDom.BinaryQueryExpression ToMutableConcrete() {
            var ret = new ScriptDom.BinaryQueryExpression();
            ret.BinaryQueryExpressionType = binaryQueryExpressionType;
            ret.All = all;
            ret.FirstQueryExpression = (ScriptDom.QueryExpression)firstQueryExpression.ToMutable();
            ret.SecondQueryExpression = (ScriptDom.QueryExpression)secondQueryExpression.ToMutable();
            ret.OrderByClause = (ScriptDom.OrderByClause)orderByClause.ToMutable();
            ret.OffsetClause = (ScriptDom.OffsetClause)offsetClause.ToMutable();
            ret.ForClause = (ScriptDom.ForClause)forClause.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + binaryQueryExpressionType.GetHashCode();
            h = h * 23 + all.GetHashCode();
            if (!(firstQueryExpression is null)) {
                h = h * 23 + firstQueryExpression.GetHashCode();
            }
            if (!(secondQueryExpression is null)) {
                h = h * 23 + secondQueryExpression.GetHashCode();
            }
            if (!(orderByClause is null)) {
                h = h * 23 + orderByClause.GetHashCode();
            }
            if (!(offsetClause is null)) {
                h = h * 23 + offsetClause.GetHashCode();
            }
            if (!(forClause is null)) {
                h = h * 23 + forClause.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as BinaryQueryExpression);
        } 
        
        public bool Equals(BinaryQueryExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.BinaryQueryExpressionType>.Default.Equals(other.BinaryQueryExpressionType, binaryQueryExpressionType)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.All, all)) {
                return false;
            }
            if (!EqualityComparer<QueryExpression>.Default.Equals(other.FirstQueryExpression, firstQueryExpression)) {
                return false;
            }
            if (!EqualityComparer<QueryExpression>.Default.Equals(other.SecondQueryExpression, secondQueryExpression)) {
                return false;
            }
            if (!EqualityComparer<OrderByClause>.Default.Equals(other.OrderByClause, orderByClause)) {
                return false;
            }
            if (!EqualityComparer<OffsetClause>.Default.Equals(other.OffsetClause, offsetClause)) {
                return false;
            }
            if (!EqualityComparer<ForClause>.Default.Equals(other.ForClause, forClause)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(BinaryQueryExpression left, BinaryQueryExpression right) {
            return EqualityComparer<BinaryQueryExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BinaryQueryExpression left, BinaryQueryExpression right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (BinaryQueryExpression)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.binaryQueryExpressionType, othr.binaryQueryExpressionType);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.all, othr.all);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.firstQueryExpression, othr.firstQueryExpression);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.secondQueryExpression, othr.secondQueryExpression);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.orderByClause, othr.orderByClause);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.offsetClause, othr.offsetClause);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.forClause, othr.forClause);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static BinaryQueryExpression FromMutable(ScriptDom.BinaryQueryExpression fragment) {
            return (BinaryQueryExpression)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
