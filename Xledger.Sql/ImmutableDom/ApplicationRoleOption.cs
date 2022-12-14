using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ApplicationRoleOption : TSqlFragment, IEquatable<ApplicationRoleOption> {
        protected ScriptDom.ApplicationRoleOptionKind optionKind = ScriptDom.ApplicationRoleOptionKind.Name;
        protected IdentifierOrValueExpression @value;
    
        public ScriptDom.ApplicationRoleOptionKind OptionKind => optionKind;
        public IdentifierOrValueExpression Value => @value;
    
        public ApplicationRoleOption(ScriptDom.ApplicationRoleOptionKind optionKind = ScriptDom.ApplicationRoleOptionKind.Name, IdentifierOrValueExpression @value = null) {
            this.optionKind = optionKind;
            this.@value = @value;
        }
    
        public ScriptDom.ApplicationRoleOption ToMutableConcrete() {
            var ret = new ScriptDom.ApplicationRoleOption();
            ret.OptionKind = optionKind;
            ret.Value = (ScriptDom.IdentifierOrValueExpression)@value.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionKind.GetHashCode();
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ApplicationRoleOption);
        } 
        
        public bool Equals(ApplicationRoleOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ApplicationRoleOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.Value, @value)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ApplicationRoleOption left, ApplicationRoleOption right) {
            return EqualityComparer<ApplicationRoleOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ApplicationRoleOption left, ApplicationRoleOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ApplicationRoleOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ApplicationRoleOption left, ApplicationRoleOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ApplicationRoleOption left, ApplicationRoleOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ApplicationRoleOption left, ApplicationRoleOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ApplicationRoleOption left, ApplicationRoleOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ApplicationRoleOption FromMutable(ScriptDom.ApplicationRoleOption fragment) {
            return (ApplicationRoleOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
