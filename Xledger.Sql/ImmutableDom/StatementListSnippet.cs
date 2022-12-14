using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class StatementListSnippet : StatementList, IEquatable<StatementListSnippet> {
        protected string script;
    
        public string Script => script;
    
        public StatementListSnippet(string script = null, IReadOnlyList<TSqlStatement> statements = null) {
            this.script = script;
            this.statements = ImmList<TSqlStatement>.FromList(statements);
        }
    
        public ScriptDom.StatementListSnippet ToMutableConcrete() {
            var ret = new ScriptDom.StatementListSnippet();
            ret.Script = script;
            ret.Statements.AddRange(statements.SelectList(c => (ScriptDom.TSqlStatement)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(script is null)) {
                h = h * 23 + script.GetHashCode();
            }
            h = h * 23 + statements.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as StatementListSnippet);
        } 
        
        public bool Equals(StatementListSnippet other) {
            if (other is null) { return false; }
            if (!EqualityComparer<string>.Default.Equals(other.Script, script)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<TSqlStatement>>.Default.Equals(other.Statements, statements)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(StatementListSnippet left, StatementListSnippet right) {
            return EqualityComparer<StatementListSnippet>.Default.Equals(left, right);
        }
        
        public static bool operator !=(StatementListSnippet left, StatementListSnippet right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (StatementListSnippet)that;
            compare = CaseInsensitiveComparer.DefaultInvariant.Compare(this.script, othr.script);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.statements, othr.statements);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (StatementListSnippet left, StatementListSnippet right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(StatementListSnippet left, StatementListSnippet right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (StatementListSnippet left, StatementListSnippet right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(StatementListSnippet left, StatementListSnippet right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static StatementListSnippet FromMutable(ScriptDom.StatementListSnippet fragment) {
            return (StatementListSnippet)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
