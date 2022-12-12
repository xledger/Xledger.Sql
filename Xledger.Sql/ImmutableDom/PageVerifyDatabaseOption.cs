using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class PageVerifyDatabaseOption : DatabaseOption, IEquatable<PageVerifyDatabaseOption> {
        protected ScriptDom.PageVerifyDatabaseOptionKind @value = ScriptDom.PageVerifyDatabaseOptionKind.None;
    
        public ScriptDom.PageVerifyDatabaseOptionKind Value => @value;
    
        public PageVerifyDatabaseOption(ScriptDom.PageVerifyDatabaseOptionKind @value = ScriptDom.PageVerifyDatabaseOptionKind.None, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.PageVerifyDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.PageVerifyDatabaseOption();
            ret.Value = @value;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + @value.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as PageVerifyDatabaseOption);
        } 
        
        public bool Equals(PageVerifyDatabaseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.PageVerifyDatabaseOptionKind>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(PageVerifyDatabaseOption left, PageVerifyDatabaseOption right) {
            return EqualityComparer<PageVerifyDatabaseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(PageVerifyDatabaseOption left, PageVerifyDatabaseOption right) {
            return !(left == right);
        }
    
    }

}
