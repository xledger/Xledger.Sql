using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ContainmentDatabaseOption : DatabaseOption, IEquatable<ContainmentDatabaseOption> {
        protected ScriptDom.ContainmentOptionKind @value = ScriptDom.ContainmentOptionKind.None;
    
        public ScriptDom.ContainmentOptionKind Value => @value;
    
        public ContainmentDatabaseOption(ScriptDom.ContainmentOptionKind @value = ScriptDom.ContainmentOptionKind.None, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.ContainmentDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.ContainmentDatabaseOption();
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
            return Equals(obj as ContainmentDatabaseOption);
        } 
        
        public bool Equals(ContainmentDatabaseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ContainmentOptionKind>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ContainmentDatabaseOption left, ContainmentDatabaseOption right) {
            return EqualityComparer<ContainmentDatabaseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ContainmentDatabaseOption left, ContainmentDatabaseOption right) {
            return !(left == right);
        }
    
    }

}
