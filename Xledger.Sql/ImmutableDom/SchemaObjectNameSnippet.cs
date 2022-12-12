using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SchemaObjectNameSnippet : SchemaObjectName, IEquatable<SchemaObjectNameSnippet> {
        string script;
    
        public string Script => script;
    
        public SchemaObjectNameSnippet(string script = null, IReadOnlyList<Identifier> identifiers = null) {
            this.script = script;
            this.identifiers = identifiers is null ? ImmList<Identifier>.Empty : ImmList<Identifier>.FromList(identifiers);
        }
    
        public ScriptDom.SchemaObjectNameSnippet ToMutableConcrete() {
            var ret = new ScriptDom.SchemaObjectNameSnippet();
            ret.Script = script;
            ret.Identifiers.AddRange(identifiers.Select(c => (ScriptDom.Identifier)c.ToMutable()));
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
    
    }

}