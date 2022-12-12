using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CommandSecurityElement80 : SecurityElement80, IEquatable<CommandSecurityElement80> {
        protected bool all = false;
        protected ScriptDom.CommandOptions commandOptions = ScriptDom.CommandOptions.None;
    
        public bool All => all;
        public ScriptDom.CommandOptions CommandOptions => commandOptions;
    
        public CommandSecurityElement80(bool all = false, ScriptDom.CommandOptions commandOptions = ScriptDom.CommandOptions.None) {
            this.all = all;
            this.commandOptions = commandOptions;
        }
    
        public ScriptDom.CommandSecurityElement80 ToMutableConcrete() {
            var ret = new ScriptDom.CommandSecurityElement80();
            ret.All = all;
            ret.CommandOptions = commandOptions;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + all.GetHashCode();
            h = h * 23 + commandOptions.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CommandSecurityElement80);
        } 
        
        public bool Equals(CommandSecurityElement80 other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.All, all)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.CommandOptions>.Default.Equals(other.CommandOptions, commandOptions)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CommandSecurityElement80 left, CommandSecurityElement80 right) {
            return EqualityComparer<CommandSecurityElement80>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CommandSecurityElement80 left, CommandSecurityElement80 right) {
            return !(left == right);
        }
    
    }

}
