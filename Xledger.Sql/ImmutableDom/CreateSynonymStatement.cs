using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateSynonymStatement : TSqlStatement, IEquatable<CreateSynonymStatement> {
        protected SchemaObjectName name;
        protected SchemaObjectName forName;
    
        public SchemaObjectName Name => name;
        public SchemaObjectName ForName => forName;
    
        public CreateSynonymStatement(SchemaObjectName name = null, SchemaObjectName forName = null) {
            this.name = name;
            this.forName = forName;
        }
    
        public ScriptDom.CreateSynonymStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateSynonymStatement();
            ret.Name = (ScriptDom.SchemaObjectName)name.ToMutable();
            ret.ForName = (ScriptDom.SchemaObjectName)forName.ToMutable();
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
            if (!(forName is null)) {
                h = h * 23 + forName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateSynonymStatement);
        } 
        
        public bool Equals(CreateSynonymStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.ForName, forName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateSynonymStatement left, CreateSynonymStatement right) {
            return EqualityComparer<CreateSynonymStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateSynonymStatement left, CreateSynonymStatement right) {
            return !(left == right);
        }
    
    }

}
