using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropSchemaStatement : TSqlStatement, IEquatable<DropSchemaStatement> {
        SchemaObjectName schema;
        ScriptDom.DropSchemaBehavior dropBehavior = ScriptDom.DropSchemaBehavior.None;
        bool isIfExists = false;
    
        public SchemaObjectName Schema => schema;
        public ScriptDom.DropSchemaBehavior DropBehavior => dropBehavior;
        public bool IsIfExists => isIfExists;
    
        public DropSchemaStatement(SchemaObjectName schema = null, ScriptDom.DropSchemaBehavior dropBehavior = ScriptDom.DropSchemaBehavior.None, bool isIfExists = false) {
            this.schema = schema;
            this.dropBehavior = dropBehavior;
            this.isIfExists = isIfExists;
        }
    
        public ScriptDom.DropSchemaStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropSchemaStatement();
            ret.Schema = (ScriptDom.SchemaObjectName)schema.ToMutable();
            ret.DropBehavior = dropBehavior;
            ret.IsIfExists = isIfExists;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(schema is null)) {
                h = h * 23 + schema.GetHashCode();
            }
            h = h * 23 + dropBehavior.GetHashCode();
            h = h * 23 + isIfExists.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropSchemaStatement);
        } 
        
        public bool Equals(DropSchemaStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Schema, schema)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DropSchemaBehavior>.Default.Equals(other.DropBehavior, dropBehavior)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsIfExists, isIfExists)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropSchemaStatement left, DropSchemaStatement right) {
            return EqualityComparer<DropSchemaStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropSchemaStatement left, DropSchemaStatement right) {
            return !(left == right);
        }
    
    }

}