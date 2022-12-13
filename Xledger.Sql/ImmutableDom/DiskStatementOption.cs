using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DiskStatementOption : TSqlFragment, IEquatable<DiskStatementOption> {
        protected ScriptDom.DiskStatementOptionKind optionKind = ScriptDom.DiskStatementOptionKind.Name;
        protected IdentifierOrValueExpression @value;
    
        public ScriptDom.DiskStatementOptionKind OptionKind => optionKind;
        public IdentifierOrValueExpression Value => @value;
    
        public DiskStatementOption(ScriptDom.DiskStatementOptionKind optionKind = ScriptDom.DiskStatementOptionKind.Name, IdentifierOrValueExpression @value = null) {
            this.optionKind = optionKind;
            this.@value = @value;
        }
    
        public ScriptDom.DiskStatementOption ToMutableConcrete() {
            var ret = new ScriptDom.DiskStatementOption();
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
            return Equals(obj as DiskStatementOption);
        } 
        
        public bool Equals(DiskStatementOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.DiskStatementOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.Value, @value)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DiskStatementOption left, DiskStatementOption right) {
            return EqualityComparer<DiskStatementOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DiskStatementOption left, DiskStatementOption right) {
            return !(left == right);
        }
    
        public static DiskStatementOption FromMutable(ScriptDom.DiskStatementOption fragment) {
            return (DiskStatementOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
