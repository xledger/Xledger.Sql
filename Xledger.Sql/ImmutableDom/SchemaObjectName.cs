using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SchemaObjectName : MultiPartIdentifier, IEquatable<SchemaObjectName> {
        public SchemaObjectName(IReadOnlyList<Identifier> identifiers = null) {
            this.identifiers = identifiers is null ? ImmList<Identifier>.Empty : ImmList<Identifier>.FromList(identifiers);
        }
    
        public ScriptDom.SchemaObjectName ToMutableConcrete() {
            var ret = new ScriptDom.SchemaObjectName();
            ret.Identifiers.AddRange(identifiers.SelectList(c => (ScriptDom.Identifier)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + identifiers.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SchemaObjectName);
        } 
        
        public bool Equals(SchemaObjectName other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.Identifiers, identifiers)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SchemaObjectName left, SchemaObjectName right) {
            return EqualityComparer<SchemaObjectName>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SchemaObjectName left, SchemaObjectName right) {
            return !(left == right);
        }
    
        public static SchemaObjectName FromMutable(ScriptDom.SchemaObjectName fragment) {
            return (SchemaObjectName)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
