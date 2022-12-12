using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CursorDefaultDatabaseOption : DatabaseOption, IEquatable<CursorDefaultDatabaseOption> {
        bool isLocal = false;
    
        public bool IsLocal => isLocal;
    
        public CursorDefaultDatabaseOption(bool isLocal = false, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.isLocal = isLocal;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.CursorDefaultDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.CursorDefaultDatabaseOption();
            ret.IsLocal = isLocal;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isLocal.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CursorDefaultDatabaseOption);
        } 
        
        public bool Equals(CursorDefaultDatabaseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsLocal, isLocal)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CursorDefaultDatabaseOption left, CursorDefaultDatabaseOption right) {
            return EqualityComparer<CursorDefaultDatabaseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CursorDefaultDatabaseOption left, CursorDefaultDatabaseOption right) {
            return !(left == right);
        }
    
    }

}
