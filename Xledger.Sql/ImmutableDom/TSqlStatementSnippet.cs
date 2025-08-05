using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TSqlStatementSnippet : TSqlStatement, IEquatable<TSqlStatementSnippet> {
        protected string script;
    
        public string Script => script;
    
        public TSqlStatementSnippet(string script = null) {
            this.script = script;
        }
    
        public ScriptDom.TSqlStatementSnippet ToMutableConcrete() {
            var ret = new ScriptDom.TSqlStatementSnippet();
            ret.Script = script;
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
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TSqlStatementSnippet);
        } 
        
        public bool Equals(TSqlStatementSnippet other) {
            if (other is null) { return false; }
            if (!EqualityComparer<string>.Default.Equals(other.Script, script)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TSqlStatementSnippet left, TSqlStatementSnippet right) {
            return EqualityComparer<TSqlStatementSnippet>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TSqlStatementSnippet left, TSqlStatementSnippet right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (TSqlStatementSnippet)that;
            compare = CaseInsensitiveComparer.DefaultInvariant.Compare(this.script, othr.script);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (TSqlStatementSnippet left, TSqlStatementSnippet right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(TSqlStatementSnippet left, TSqlStatementSnippet right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (TSqlStatementSnippet left, TSqlStatementSnippet right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(TSqlStatementSnippet left, TSqlStatementSnippet right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static TSqlStatementSnippet FromMutable(ScriptDom.TSqlStatementSnippet fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.TSqlStatementSnippet)) { throw new NotImplementedException("Unexpected subtype of TSqlStatementSnippet not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new TSqlStatementSnippet(
                script: fragment.Script
            );
        }
    
    }

}
