using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class UserDefinedTypeCallTarget : CallTarget, IEquatable<UserDefinedTypeCallTarget> {
        protected SchemaObjectName schemaObjectName;
    
        public SchemaObjectName SchemaObjectName => schemaObjectName;
    
        public UserDefinedTypeCallTarget(SchemaObjectName schemaObjectName = null) {
            this.schemaObjectName = schemaObjectName;
        }
    
        public ScriptDom.UserDefinedTypeCallTarget ToMutableConcrete() {
            var ret = new ScriptDom.UserDefinedTypeCallTarget();
            ret.SchemaObjectName = (ScriptDom.SchemaObjectName)schemaObjectName.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(schemaObjectName is null)) {
                h = h * 23 + schemaObjectName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as UserDefinedTypeCallTarget);
        } 
        
        public bool Equals(UserDefinedTypeCallTarget other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.SchemaObjectName, schemaObjectName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(UserDefinedTypeCallTarget left, UserDefinedTypeCallTarget right) {
            return EqualityComparer<UserDefinedTypeCallTarget>.Default.Equals(left, right);
        }
        
        public static bool operator !=(UserDefinedTypeCallTarget left, UserDefinedTypeCallTarget right) {
            return !(left == right);
        }
    
    }

}
