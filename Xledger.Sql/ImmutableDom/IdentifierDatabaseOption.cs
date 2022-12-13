using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class IdentifierDatabaseOption : DatabaseOption, IEquatable<IdentifierDatabaseOption> {
        protected Identifier @value;
    
        public Identifier Value => @value;
    
        public IdentifierDatabaseOption(Identifier @value = null, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.IdentifierDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.IdentifierDatabaseOption();
            ret.Value = (ScriptDom.Identifier)@value.ToMutable();
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
            return Equals(obj as IdentifierDatabaseOption);
        } 
        
        public bool Equals(IdentifierDatabaseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(IdentifierDatabaseOption left, IdentifierDatabaseOption right) {
            return EqualityComparer<IdentifierDatabaseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(IdentifierDatabaseOption left, IdentifierDatabaseOption right) {
            return !(left == right);
        }
    
        public static IdentifierDatabaseOption FromMutable(ScriptDom.IdentifierDatabaseOption fragment) {
            return (IdentifierDatabaseOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
