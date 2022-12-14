using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExternalTableLiteralOrIdentifierOption : ExternalTableOption, IEquatable<ExternalTableLiteralOrIdentifierOption> {
        protected IdentifierOrValueExpression @value;
    
        public IdentifierOrValueExpression Value => @value;
    
        public ExternalTableLiteralOrIdentifierOption(IdentifierOrValueExpression @value = null, ScriptDom.ExternalTableOptionKind optionKind = ScriptDom.ExternalTableOptionKind.Distribution) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.ExternalTableLiteralOrIdentifierOption ToMutableConcrete() {
            var ret = new ScriptDom.ExternalTableLiteralOrIdentifierOption();
            ret.Value = (ScriptDom.IdentifierOrValueExpression)@value.ToMutable();
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
            return Equals(obj as ExternalTableLiteralOrIdentifierOption);
        } 
        
        public bool Equals(ExternalTableLiteralOrIdentifierOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ExternalTableOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExternalTableLiteralOrIdentifierOption left, ExternalTableLiteralOrIdentifierOption right) {
            return EqualityComparer<ExternalTableLiteralOrIdentifierOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExternalTableLiteralOrIdentifierOption left, ExternalTableLiteralOrIdentifierOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ExternalTableLiteralOrIdentifierOption)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static ExternalTableLiteralOrIdentifierOption FromMutable(ScriptDom.ExternalTableLiteralOrIdentifierOption fragment) {
            return (ExternalTableLiteralOrIdentifierOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
