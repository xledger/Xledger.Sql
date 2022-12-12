using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class RaiseErrorStatement : TSqlStatement, IEquatable<RaiseErrorStatement> {
        protected ScalarExpression firstParameter;
        protected ScalarExpression secondParameter;
        protected ScalarExpression thirdParameter;
        protected IReadOnlyList<ScalarExpression> optionalParameters;
        protected ScriptDom.RaiseErrorOptions raiseErrorOptions = ScriptDom.RaiseErrorOptions.None;
    
        public ScalarExpression FirstParameter => firstParameter;
        public ScalarExpression SecondParameter => secondParameter;
        public ScalarExpression ThirdParameter => thirdParameter;
        public IReadOnlyList<ScalarExpression> OptionalParameters => optionalParameters;
        public ScriptDom.RaiseErrorOptions RaiseErrorOptions => raiseErrorOptions;
    
        public RaiseErrorStatement(ScalarExpression firstParameter = null, ScalarExpression secondParameter = null, ScalarExpression thirdParameter = null, IReadOnlyList<ScalarExpression> optionalParameters = null, ScriptDom.RaiseErrorOptions raiseErrorOptions = ScriptDom.RaiseErrorOptions.None) {
            this.firstParameter = firstParameter;
            this.secondParameter = secondParameter;
            this.thirdParameter = thirdParameter;
            this.optionalParameters = optionalParameters is null ? ImmList<ScalarExpression>.Empty : ImmList<ScalarExpression>.FromList(optionalParameters);
            this.raiseErrorOptions = raiseErrorOptions;
        }
    
        public ScriptDom.RaiseErrorStatement ToMutableConcrete() {
            var ret = new ScriptDom.RaiseErrorStatement();
            ret.FirstParameter = (ScriptDom.ScalarExpression)firstParameter.ToMutable();
            ret.SecondParameter = (ScriptDom.ScalarExpression)secondParameter.ToMutable();
            ret.ThirdParameter = (ScriptDom.ScalarExpression)thirdParameter.ToMutable();
            ret.OptionalParameters.AddRange(optionalParameters.SelectList(c => (ScriptDom.ScalarExpression)c.ToMutable()));
            ret.RaiseErrorOptions = raiseErrorOptions;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(firstParameter is null)) {
                h = h * 23 + firstParameter.GetHashCode();
            }
            if (!(secondParameter is null)) {
                h = h * 23 + secondParameter.GetHashCode();
            }
            if (!(thirdParameter is null)) {
                h = h * 23 + thirdParameter.GetHashCode();
            }
            h = h * 23 + optionalParameters.GetHashCode();
            h = h * 23 + raiseErrorOptions.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as RaiseErrorStatement);
        } 
        
        public bool Equals(RaiseErrorStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.FirstParameter, firstParameter)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.SecondParameter, secondParameter)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.ThirdParameter, thirdParameter)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ScalarExpression>>.Default.Equals(other.OptionalParameters, optionalParameters)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.RaiseErrorOptions>.Default.Equals(other.RaiseErrorOptions, raiseErrorOptions)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(RaiseErrorStatement left, RaiseErrorStatement right) {
            return EqualityComparer<RaiseErrorStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(RaiseErrorStatement left, RaiseErrorStatement right) {
            return !(left == right);
        }
    
    }

}
