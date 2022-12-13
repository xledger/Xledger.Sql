using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropLoginStatement : DropUnownedObjectStatement, IEquatable<DropLoginStatement> {
        public DropLoginStatement(Identifier name = null, bool isIfExists = false) {
            this.name = name;
            this.isIfExists = isIfExists;
        }
    
        public ScriptDom.DropLoginStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropLoginStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.IsIfExists = isIfExists;
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
            h = h * 23 + isIfExists.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropLoginStatement);
        } 
        
        public bool Equals(DropLoginStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsIfExists, isIfExists)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropLoginStatement left, DropLoginStatement right) {
            return EqualityComparer<DropLoginStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropLoginStatement left, DropLoginStatement right) {
            return !(left == right);
        }
    
        public static DropLoginStatement FromMutable(ScriptDom.DropLoginStatement fragment) {
            return (DropLoginStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
