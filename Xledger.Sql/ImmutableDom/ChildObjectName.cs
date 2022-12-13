using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ChildObjectName : SchemaObjectName, IEquatable<ChildObjectName> {
        public ChildObjectName(IReadOnlyList<Identifier> identifiers = null) {
            this.identifiers = identifiers is null ? ImmList<Identifier>.Empty : ImmList<Identifier>.FromList(identifiers);
        }
    
        public ScriptDom.ChildObjectName ToMutableConcrete() {
            var ret = new ScriptDom.ChildObjectName();
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
            return Equals(obj as ChildObjectName);
        } 
        
        public bool Equals(ChildObjectName other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.Identifiers, identifiers)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ChildObjectName left, ChildObjectName right) {
            return EqualityComparer<ChildObjectName>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ChildObjectName left, ChildObjectName right) {
            return !(left == right);
        }
    
        public static ChildObjectName FromMutable(ScriptDom.ChildObjectName fragment) {
            return (ChildObjectName)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
