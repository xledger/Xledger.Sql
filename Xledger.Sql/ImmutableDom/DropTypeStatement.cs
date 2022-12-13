using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropTypeStatement : TSqlStatement, IEquatable<DropTypeStatement> {
        protected SchemaObjectName name;
        protected bool isIfExists = false;
    
        public SchemaObjectName Name => name;
        public bool IsIfExists => isIfExists;
    
        public DropTypeStatement(SchemaObjectName name = null, bool isIfExists = false) {
            this.name = name;
            this.isIfExists = isIfExists;
        }
    
        public ScriptDom.DropTypeStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropTypeStatement();
            ret.Name = (ScriptDom.SchemaObjectName)name.ToMutable();
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
            return Equals(obj as DropTypeStatement);
        } 
        
        public bool Equals(DropTypeStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsIfExists, isIfExists)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropTypeStatement left, DropTypeStatement right) {
            return EqualityComparer<DropTypeStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropTypeStatement left, DropTypeStatement right) {
            return !(left == right);
        }
    
        public static DropTypeStatement FromMutable(ScriptDom.DropTypeStatement fragment) {
            return (DropTypeStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
