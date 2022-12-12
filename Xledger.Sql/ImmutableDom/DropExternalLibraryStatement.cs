using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropExternalLibraryStatement : TSqlStatement, IEquatable<DropExternalLibraryStatement> {
        protected Identifier name;
        protected Identifier owner;
    
        public Identifier Name => name;
        public Identifier Owner => owner;
    
        public DropExternalLibraryStatement(Identifier name = null, Identifier owner = null) {
            this.name = name;
            this.owner = owner;
        }
    
        public ScriptDom.DropExternalLibraryStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropExternalLibraryStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.Owner = (ScriptDom.Identifier)owner.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            if (!(owner is null)) {
                h = h * 23 + owner.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropExternalLibraryStatement);
        } 
        
        public bool Equals(DropExternalLibraryStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Owner, owner)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropExternalLibraryStatement left, DropExternalLibraryStatement right) {
            return EqualityComparer<DropExternalLibraryStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropExternalLibraryStatement left, DropExternalLibraryStatement right) {
            return !(left == right);
        }
    
    }

}
