using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OptimizeForOptimizerHint : OptimizerHint, IEquatable<OptimizeForOptimizerHint> {
        IReadOnlyList<VariableValuePair> pairs;
        bool isForUnknown = false;
    
        public IReadOnlyList<VariableValuePair> Pairs => pairs;
        public bool IsForUnknown => isForUnknown;
    
        public OptimizeForOptimizerHint(IReadOnlyList<VariableValuePair> pairs = null, bool isForUnknown = false, ScriptDom.OptimizerHintKind hintKind = ScriptDom.OptimizerHintKind.Unspecified) {
            this.pairs = pairs is null ? ImmList<VariableValuePair>.Empty : ImmList<VariableValuePair>.FromList(pairs);
            this.isForUnknown = isForUnknown;
            this.hintKind = hintKind;
        }
    
        public ScriptDom.OptimizeForOptimizerHint ToMutableConcrete() {
            var ret = new ScriptDom.OptimizeForOptimizerHint();
            ret.Pairs.AddRange(pairs.Select(c => (ScriptDom.VariableValuePair)c.ToMutable()));
            ret.IsForUnknown = isForUnknown;
            ret.HintKind = hintKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + pairs.GetHashCode();
            h = h * 23 + isForUnknown.GetHashCode();
            h = h * 23 + hintKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OptimizeForOptimizerHint);
        } 
        
        public bool Equals(OptimizeForOptimizerHint other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<VariableValuePair>>.Default.Equals(other.Pairs, pairs)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsForUnknown, isForUnknown)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.OptimizerHintKind>.Default.Equals(other.HintKind, hintKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OptimizeForOptimizerHint left, OptimizeForOptimizerHint right) {
            return EqualityComparer<OptimizeForOptimizerHint>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OptimizeForOptimizerHint left, OptimizeForOptimizerHint right) {
            return !(left == right);
        }
    
    }

}
