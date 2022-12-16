using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExternalStreamLiteralOrIdentifierOption : ExternalStreamOption, IEquatable<ExternalStreamLiteralOrIdentifierOption> {
        protected IdentifierOrValueExpression @value;
    
        public IdentifierOrValueExpression Value => @value;
    
        public ExternalStreamLiteralOrIdentifierOption(IdentifierOrValueExpression @value = null, ScriptDom.ExternalStreamOptionKind optionKind = ScriptDom.ExternalStreamOptionKind.DataSource) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.ExternalStreamLiteralOrIdentifierOption ToMutableConcrete() {
            var ret = new ScriptDom.ExternalStreamLiteralOrIdentifierOption();
            ret.Value = (ScriptDom.IdentifierOrValueExpression)@value?.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExternalStreamLiteralOrIdentifierOption);
        } 
        
        public bool Equals(ExternalStreamLiteralOrIdentifierOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ExternalStreamOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExternalStreamLiteralOrIdentifierOption left, ExternalStreamLiteralOrIdentifierOption right) {
            return EqualityComparer<ExternalStreamLiteralOrIdentifierOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExternalStreamLiteralOrIdentifierOption left, ExternalStreamLiteralOrIdentifierOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ExternalStreamLiteralOrIdentifierOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ExternalStreamLiteralOrIdentifierOption left, ExternalStreamLiteralOrIdentifierOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ExternalStreamLiteralOrIdentifierOption left, ExternalStreamLiteralOrIdentifierOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ExternalStreamLiteralOrIdentifierOption left, ExternalStreamLiteralOrIdentifierOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ExternalStreamLiteralOrIdentifierOption left, ExternalStreamLiteralOrIdentifierOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
