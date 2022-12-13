using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class RightFunctionCall : PrimaryExpression, IEquatable<RightFunctionCall> {
        protected IReadOnlyList<ScalarExpression> parameters;
    
        public IReadOnlyList<ScalarExpression> Parameters => parameters;
    
        public RightFunctionCall(IReadOnlyList<ScalarExpression> parameters = null, Identifier collation = null) {
            this.parameters = parameters is null ? ImmList<ScalarExpression>.Empty : ImmList<ScalarExpression>.FromList(parameters);
            this.collation = collation;
        }
    
        public ScriptDom.RightFunctionCall ToMutableConcrete() {
            var ret = new ScriptDom.RightFunctionCall();
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
            return Equals(obj as RightFunctionCall);
        } 
        
        public bool Equals(RightFunctionCall other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<ScalarExpression>>.Default.Equals(other.Parameters, parameters)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(RightFunctionCall left, RightFunctionCall right) {
            return EqualityComparer<RightFunctionCall>.Default.Equals(left, right);
        }
        
        public static bool operator !=(RightFunctionCall left, RightFunctionCall right) {
            return !(left == right);
        }
    
        public static RightFunctionCall FromMutable(ScriptDom.RightFunctionCall fragment) {
            return (RightFunctionCall)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
