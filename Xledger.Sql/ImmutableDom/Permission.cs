using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class Permission : TSqlFragment, IEquatable<Permission> {
        IReadOnlyList<Identifier> identifiers;
        IReadOnlyList<Identifier> columns;
    
        public IReadOnlyList<Identifier> Identifiers => identifiers;
        public IReadOnlyList<Identifier> Columns => columns;
    
        public Permission(IReadOnlyList<Identifier> identifiers = null, IReadOnlyList<Identifier> columns = null) {
            this.identifiers = identifiers is null ? ImmList<Identifier>.Empty : ImmList<Identifier>.FromList(identifiers);
            this.columns = columns is null ? ImmList<Identifier>.Empty : ImmList<Identifier>.FromList(columns);
        }
    
        public ScriptDom.Permission ToMutableConcrete() {
            var ret = new ScriptDom.Permission();
            ret.Identifiers.AddRange(identifiers.Select(c => (ScriptDom.Identifier)c.ToMutable()));
            ret.Columns.AddRange(columns.Select(c => (ScriptDom.Identifier)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + identifiers.GetHashCode();
            h = h * 23 + columns.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as Permission);
        } 
        
        public bool Equals(Permission other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.Identifiers, identifiers)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(Permission left, Permission right) {
            return EqualityComparer<Permission>.Default.Equals(left, right);
        }
        
        public static bool operator !=(Permission left, Permission right) {
            return !(left == right);
        }
    
    }

}
