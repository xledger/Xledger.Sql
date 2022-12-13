using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DatabaseOption : TSqlFragment, IEquatable<DatabaseOption> {
        protected ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online;
    
        public ScriptDom.DatabaseOptionKind OptionKind => optionKind;
    
        public DatabaseOption(ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.optionKind = optionKind;
        }
    
        public ScriptDom.DatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.DatabaseOption();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DatabaseOption);
        } 
        
        public bool Equals(DatabaseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DatabaseOption left, DatabaseOption right) {
            return EqualityComparer<DatabaseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DatabaseOption left, DatabaseOption right) {
            return !(left == right);
        }
    
        public static DatabaseOption FromMutable(ScriptDom.DatabaseOption fragment) {
            return (DatabaseOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
