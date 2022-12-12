using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropXmlSchemaCollectionStatement : TSqlStatement, IEquatable<DropXmlSchemaCollectionStatement> {
        SchemaObjectName name;
    
        public SchemaObjectName Name => name;
    
        public DropXmlSchemaCollectionStatement(SchemaObjectName name = null) {
            this.name = name;
        }
    
        public ScriptDom.DropXmlSchemaCollectionStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropXmlSchemaCollectionStatement();
            ret.Name = (ScriptDom.SchemaObjectName)name.ToMutable();
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
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropXmlSchemaCollectionStatement);
        } 
        
        public bool Equals(DropXmlSchemaCollectionStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropXmlSchemaCollectionStatement left, DropXmlSchemaCollectionStatement right) {
            return EqualityComparer<DropXmlSchemaCollectionStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropXmlSchemaCollectionStatement left, DropXmlSchemaCollectionStatement right) {
            return !(left == right);
        }
    
    }

}
