using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DbccStatement : TSqlStatement, IEquatable<DbccStatement> {
        protected string dllName;
        protected ScriptDom.DbccCommand command = ScriptDom.DbccCommand.None;
        protected bool parenthesisRequired = false;
        protected IReadOnlyList<DbccNamedLiteral> literals;
        protected IReadOnlyList<DbccOption> options;
        protected bool optionsUseJoin = false;
    
        public string DllName => dllName;
        public ScriptDom.DbccCommand Command => command;
        public bool ParenthesisRequired => parenthesisRequired;
        public IReadOnlyList<DbccNamedLiteral> Literals => literals;
        public IReadOnlyList<DbccOption> Options => options;
        public bool OptionsUseJoin => optionsUseJoin;
    
        public DbccStatement(string dllName = null, ScriptDom.DbccCommand command = ScriptDom.DbccCommand.None, bool parenthesisRequired = false, IReadOnlyList<DbccNamedLiteral> literals = null, IReadOnlyList<DbccOption> options = null, bool optionsUseJoin = false) {
            this.dllName = dllName;
            this.command = command;
            this.parenthesisRequired = parenthesisRequired;
            this.literals = ImmList<DbccNamedLiteral>.FromList(literals);
            this.options = ImmList<DbccOption>.FromList(options);
            this.optionsUseJoin = optionsUseJoin;
        }
    
        public ScriptDom.DbccStatement ToMutableConcrete() {
            var ret = new ScriptDom.DbccStatement();
            ret.DllName = dllName;
            ret.Command = command;
            ret.ParenthesisRequired = parenthesisRequired;
            ret.Literals.AddRange(literals.SelectList(c => (ScriptDom.DbccNamedLiteral)c?.ToMutable()));
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.DbccOption)c?.ToMutable()));
            ret.OptionsUseJoin = optionsUseJoin;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(dllName is null)) {
                h = h * 23 + dllName.GetHashCode();
            }
            h = h * 23 + command.GetHashCode();
            h = h * 23 + parenthesisRequired.GetHashCode();
            h = h * 23 + literals.GetHashCode();
            h = h * 23 + options.GetHashCode();
            h = h * 23 + optionsUseJoin.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DbccStatement);
        } 
        
        public bool Equals(DbccStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<string>.Default.Equals(other.DllName, dllName)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DbccCommand>.Default.Equals(other.Command, command)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.ParenthesisRequired, parenthesisRequired)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<DbccNamedLiteral>>.Default.Equals(other.Literals, literals)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<DbccOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.OptionsUseJoin, optionsUseJoin)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DbccStatement left, DbccStatement right) {
            return EqualityComparer<DbccStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DbccStatement left, DbccStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DbccStatement)that;
            compare = CaseInsensitiveComparer.DefaultInvariant.Compare(this.dllName, othr.dllName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.command, othr.command);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.parenthesisRequired, othr.parenthesisRequired);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.literals, othr.literals);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionsUseJoin, othr.optionsUseJoin);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (DbccStatement left, DbccStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DbccStatement left, DbccStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DbccStatement left, DbccStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DbccStatement left, DbccStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
