using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DatabaseConfigurationSetOption : TSqlFragment, IEquatable<DatabaseConfigurationSetOption> {
        ScriptDom.DatabaseConfigSetOptionKind optionKind = ScriptDom.DatabaseConfigSetOptionKind.MaxDop;
        Identifier genericOptionKind;
    
        public ScriptDom.DatabaseConfigSetOptionKind OptionKind => optionKind;
        public Identifier GenericOptionKind => genericOptionKind;
    
        public DatabaseConfigurationSetOption(ScriptDom.DatabaseConfigSetOptionKind optionKind = ScriptDom.DatabaseConfigSetOptionKind.MaxDop, Identifier genericOptionKind = null) {
            this.optionKind = optionKind;
            this.genericOptionKind = genericOptionKind;
        }
    
        public ScriptDom.DatabaseConfigurationSetOption ToMutableConcrete() {
            var ret = new ScriptDom.DatabaseConfigurationSetOption();
            ret.OptionKind = optionKind;
            ret.GenericOptionKind = (ScriptDom.Identifier)genericOptionKind.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionKind.GetHashCode();
            if (!(genericOptionKind is null)) {
                h = h * 23 + genericOptionKind.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DatabaseConfigurationSetOption);
        } 
        
        public bool Equals(DatabaseConfigurationSetOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.DatabaseConfigSetOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.GenericOptionKind, genericOptionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DatabaseConfigurationSetOption left, DatabaseConfigurationSetOption right) {
            return EqualityComparer<DatabaseConfigurationSetOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DatabaseConfigurationSetOption left, DatabaseConfigurationSetOption right) {
            return !(left == right);
        }
    
    }

}
