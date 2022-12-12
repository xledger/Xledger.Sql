using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExternalDataSourceLiteralOrIdentifierOption : ExternalDataSourceOption, IEquatable<ExternalDataSourceLiteralOrIdentifierOption> {
        IdentifierOrValueExpression @value;
    
        public IdentifierOrValueExpression Value => @value;
    
        public ExternalDataSourceLiteralOrIdentifierOption(IdentifierOrValueExpression @value = null, ScriptDom.ExternalDataSourceOptionKind optionKind = ScriptDom.ExternalDataSourceOptionKind.ResourceManagerLocation) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.ExternalDataSourceLiteralOrIdentifierOption ToMutableConcrete() {
            var ret = new ScriptDom.ExternalDataSourceLiteralOrIdentifierOption();
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
    
    }

}