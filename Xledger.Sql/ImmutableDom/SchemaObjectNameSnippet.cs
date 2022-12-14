using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SchemaObjectNameSnippet : SchemaObjectName, IEquatable<SchemaObjectNameSnippet> {
        protected string script;
    
        public string Script => script;
    
        public SchemaObjectNameSnippet(string script = null, IReadOnlyList<Identifier> identifiers = null) {
            this.script = script;
            this.identifiers = ImmList<Identifier>.FromList(identifiers);
        }
    
        public new ScriptDom.SchemaObjectNameSnippet ToMutableConcrete() {
            var ret = new ScriptDom.SchemaObjectNameSnippet();
            ret.Script = script;
            ret.Identifiers.AddRange(identifiers.SelectList(c => (ScriptDom.Identifier)c?.ToMutable()));
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
            h = h * 23 + identifiers.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SchemaObjectNameSnippet);
        } 
        
        public bool Equals(SchemaObjectNameSnippet other) {
            if (other is null) { return false; }
            if (!EqualityComparer<string>.Default.Equals(other.Script, script)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.Identifiers, identifiers)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SchemaObjectNameSnippet left, SchemaObjectNameSnippet right) {
            return EqualityComparer<SchemaObjectNameSnippet>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SchemaObjectNameSnippet left, SchemaObjectNameSnippet right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SchemaObjectNameSnippet)that;
            compare = CaseInsensitiveComparer.DefaultInvariant.Compare(this.script, othr.script);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.identifiers, othr.identifiers);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (SchemaObjectNameSnippet left, SchemaObjectNameSnippet right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SchemaObjectNameSnippet left, SchemaObjectNameSnippet right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SchemaObjectNameSnippet left, SchemaObjectNameSnippet right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SchemaObjectNameSnippet left, SchemaObjectNameSnippet right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SchemaObjectNameSnippet FromMutable(ScriptDom.SchemaObjectNameSnippet fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.SchemaObjectNameSnippet)) { throw new NotImplementedException("Unexpected subtype of SchemaObjectNameSnippet not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SchemaObjectNameSnippet(
                script: fragment.Script,
                identifiers: fragment.Identifiers.SelectList(ImmutableDom.Identifier.FromMutable)
            );
        }
    
    }

}
