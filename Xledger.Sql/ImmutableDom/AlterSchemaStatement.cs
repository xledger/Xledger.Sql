using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterSchemaStatement : TSqlStatement, IEquatable<AlterSchemaStatement> {
        Identifier name;
        SchemaObjectName objectName;
        ScriptDom.SecurityObjectKind objectKind = ScriptDom.SecurityObjectKind.NotSpecified;
    
        public Identifier Name => name;
        public SchemaObjectName ObjectName => objectName;
        public ScriptDom.SecurityObjectKind ObjectKind => objectKind;
    
        public AlterSchemaStatement(Identifier name = null, SchemaObjectName objectName = null, ScriptDom.SecurityObjectKind objectKind = ScriptDom.SecurityObjectKind.NotSpecified) {
            this.name = name;
            this.objectName = objectName;
            this.objectKind = objectKind;
        }
    
        public ScriptDom.AlterSchemaStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterSchemaStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.ObjectName = (ScriptDom.SchemaObjectName)objectName.ToMutable();
            ret.ObjectKind = objectKind;
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
            if (!(objectName is null)) {
                h = h * 23 + objectName.GetHashCode();
            }
            h = h * 23 + objectKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterSchemaStatement);
        } 
        
        public bool Equals(AlterSchemaStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.ObjectName, objectName)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.SecurityObjectKind>.Default.Equals(other.ObjectKind, objectKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterSchemaStatement left, AlterSchemaStatement right) {
            return EqualityComparer<AlterSchemaStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterSchemaStatement left, AlterSchemaStatement right) {
            return !(left == right);
        }
    
    }

}