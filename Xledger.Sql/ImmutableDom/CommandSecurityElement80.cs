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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CommandSecurityElement80)that;
            compare = Comparer.DefaultInvariant.Compare(this.all, othr.all);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.commandOptions, othr.commandOptions);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CommandSecurityElement80 left, CommandSecurityElement80 right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CommandSecurityElement80 left, CommandSecurityElement80 right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CommandSecurityElement80 left, CommandSecurityElement80 right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CommandSecurityElement80 left, CommandSecurityElement80 right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CommandSecurityElement80 FromMutable(ScriptDom.CommandSecurityElement80 fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CommandSecurityElement80)) { throw new NotImplementedException("Unexpected subtype of CommandSecurityElement80 not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CommandSecurityElement80(
                all: fragment.All,
                commandOptions: fragment.CommandOptions
            );
        }
    
    }

}
