using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExpressionGroupingSpecification : GroupingSpecification, IEquatable<ExpressionGroupingSpecification> {
        protected ScalarExpression expression;
        protected bool distributedAggregation = false;
    
        public ScalarExpression Expression => expression;
        public bool DistributedAggregation => distributedAggregation;
    
        public ExpressionGroupingSpecification(ScalarExpression expression = null, bool distributedAggregation = false) {
            this.expression = expression;
            this.distributedAggregation = distributedAggregation;
        }
    
        public ScriptDom.ExpressionGroupingSpecification ToMutableConcrete() {
            var ret = new ScriptDom.ExpressionGroupingSpecification();
            ret.Expression = (ScriptDom.ScalarExpression)expression.ToMutable();
            ret.DistributedAggregation = distributedAggregation;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(expression is null)) {
                h = h * 23 + expression.GetHashCode();
            }
            h = h * 23 + distributedAggregation.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExpressionGroupingSpecification);
        } 
        
        public bool Equals(ExpressionGroupingSpecification other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Expression, expression)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.DistributedAggregation, distributedAggregation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExpressionGroupingSpecification left, ExpressionGroupingSpecification right) {
            return EqualityComparer<ExpressionGroupingSpecification>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExpressionGroupingSpecification left, ExpressionGroupingSpecification right) {
            return !(left == right);
        }
    
        public static ExpressionGroupingSpecification FromMutable(ScriptDom.ExpressionGroupingSpecification fragment) {
            return (ExpressionGroupingSpecification)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
