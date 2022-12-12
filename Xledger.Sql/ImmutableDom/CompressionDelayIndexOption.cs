using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CompressionDelayIndexOption : IndexOption, IEquatable<CompressionDelayIndexOption> {
        ScalarExpression expression;
        ScriptDom.CompressionDelayTimeUnit timeUnit = ScriptDom.CompressionDelayTimeUnit.Unitless;
    
        public ScalarExpression Expression => expression;
        public ScriptDom.CompressionDelayTimeUnit TimeUnit => timeUnit;
    
        public CompressionDelayIndexOption(ScalarExpression expression = null, ScriptDom.CompressionDelayTimeUnit timeUnit = ScriptDom.CompressionDelayTimeUnit.Unitless, ScriptDom.IndexOptionKind optionKind = ScriptDom.IndexOptionKind.PadIndex) {
            this.expression = expression;
            this.timeUnit = timeUnit;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.CompressionDelayIndexOption ToMutableConcrete() {
            var ret = new ScriptDom.CompressionDelayIndexOption();
            ret.Expression = (ScriptDom.ScalarExpression)expression.ToMutable();
            ret.TimeUnit = timeUnit;
            ret.OptionKind = optionKind;
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
            h = h * 23 + timeUnit.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CompressionDelayIndexOption);
        } 
        
        public bool Equals(CompressionDelayIndexOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Expression, expression)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.CompressionDelayTimeUnit>.Default.Equals(other.TimeUnit, timeUnit)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.IndexOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CompressionDelayIndexOption left, CompressionDelayIndexOption right) {
            return EqualityComparer<CompressionDelayIndexOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CompressionDelayIndexOption left, CompressionDelayIndexOption right) {
            return !(left == right);
        }
    
    }

}
