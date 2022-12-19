using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExternalDataSourceLiteralOrIdentifierOption : ExternalDataSourceOption, IEquatable<ExternalDataSourceLiteralOrIdentifierOption> {
        protected IdentifierOrValueExpression @value;
    
        public IdentifierOrValueExpression Value => @value;
    
        public ExternalDataSourceLiteralOrIdentifierOption(IdentifierOrValueExpression @value = null, ScriptDom.ExternalDataSourceOptionKind optionKind = ScriptDom.ExternalDataSourceOptionKind.ResourceManagerLocation) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.ExternalDataSourceLiteralOrIdentifierOption ToMutableConcrete() {
            var ret = new ScriptDom.ExternalDataSourceLiteralOrIdentifierOption();
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
            return Equals(obj as ExternalDataSourceLiteralOrIdentifierOption);
        } 
        
        public bool Equals(ExternalDataSourceLiteralOrIdentifierOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ExternalDataSourceOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExternalDataSourceLiteralOrIdentifierOption left, ExternalDataSourceLiteralOrIdentifierOption right) {
            return EqualityComparer<ExternalDataSourceLiteralOrIdentifierOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExternalDataSourceLiteralOrIdentifierOption left, ExternalDataSourceLiteralOrIdentifierOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ExternalDataSourceLiteralOrIdentifierOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ExternalDataSourceLiteralOrIdentifierOption left, ExternalDataSourceLiteralOrIdentifierOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ExternalDataSourceLiteralOrIdentifierOption left, ExternalDataSourceLiteralOrIdentifierOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ExternalDataSourceLiteralOrIdentifierOption left, ExternalDataSourceLiteralOrIdentifierOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ExternalDataSourceLiteralOrIdentifierOption left, ExternalDataSourceLiteralOrIdentifierOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ExternalDataSourceLiteralOrIdentifierOption FromMutable(ScriptDom.ExternalDataSourceLiteralOrIdentifierOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ExternalDataSourceLiteralOrIdentifierOption)) { throw new NotImplementedException("Unexpected subtype of ExternalDataSourceLiteralOrIdentifierOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ExternalDataSourceLiteralOrIdentifierOption(
                @value: ImmutableDom.IdentifierOrValueExpression.FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
