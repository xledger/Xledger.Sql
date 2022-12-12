using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ApplicationRoleOption : TSqlFragment, IEquatable<ApplicationRoleOption> {
        ScriptDom.ApplicationRoleOptionKind optionKind = ScriptDom.ApplicationRoleOptionKind.Name;
        IdentifierOrValueExpression @value;
    
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
    
    }

}
