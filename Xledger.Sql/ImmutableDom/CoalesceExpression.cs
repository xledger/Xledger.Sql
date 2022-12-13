using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CoalesceExpression : PrimaryExpression, IEquatable<CoalesceExpression> {
        protected IReadOnlyList<ScalarExpression> expressions;
    
        public IReadOnlyList<ScalarExpression> Expressions => expressions;
    
        public CoalesceExpression(IReadOnlyList<ScalarExpression> expressions = null, Identifier collation = null) {
            this.expressions = expressions is null ? ImmList<ScalarExpression>.Empty : ImmList<ScalarExpression>.FromList(expressions);
            this.collation = collation;
        }
    
        public ScriptDom.CoalesceExpression ToMutableConcrete() {
            var ret = new ScriptDom.CoalesceExpression();
            ret.Expressions.AddRange(expressions.SelectList(c => (ScriptDom.ScalarExpression)c.ToMutable()));
            ret.Collation = (ScriptDom.Identifier)collation.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + expressions.GetHashCode();
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CoalesceExpression);
        } 
        
        public bool Equals(CoalesceExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<ScalarExpression>>.Default.Equals(other.Expressions, expressions)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CoalesceExpression left, CoalesceExpression right) {
            return EqualityComparer<CoalesceExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CoalesceExpression left, CoalesceExpression right) {
            return !(left == right);
        }
    
        public static CoalesceExpression FromMutable(ScriptDom.CoalesceExpression fragment) {
            return (CoalesceExpression)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
