using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterTableAddTableElementStatement : AlterTableStatement, IEquatable<AlterTableAddTableElementStatement> {
        protected ScriptDom.ConstraintEnforcement existingRowsCheckEnforcement = ScriptDom.ConstraintEnforcement.NotSpecified;
        protected TableDefinition definition;
    
        public ScriptDom.ConstraintEnforcement ExistingRowsCheckEnforcement => existingRowsCheckEnforcement;
        public TableDefinition Definition => definition;
    
        public AlterTableAddTableElementStatement(ScriptDom.ConstraintEnforcement existingRowsCheckEnforcement = ScriptDom.ConstraintEnforcement.NotSpecified, TableDefinition definition = null, SchemaObjectName schemaObjectName = null) {
            this.existingRowsCheckEnforcement = existingRowsCheckEnforcement;
            this.definition = definition;
            this.schemaObjectName = schemaObjectName;
        }
    
        public ScriptDom.AlterTableAddTableElementStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterTableAddTableElementStatement();
            ret.ExistingRowsCheckEnforcement = existingRowsCheckEnforcement;
            ret.Definition = (ScriptDom.TableDefinition)definition.ToMutable();
            ret.SchemaObjectName = (ScriptDom.SchemaObjectName)schemaObjectName.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + existingRowsCheckEnforcement.GetHashCode();
            if (!(definition is null)) {
                h = h * 23 + definition.GetHashCode();
            }
            if (!(schemaObjectName is null)) {
                h = h * 23 + schemaObjectName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterTableAddTableElementStatement);
        } 
        
        public bool Equals(AlterTableAddTableElementStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ConstraintEnforcement>.Default.Equals(other.ExistingRowsCheckEnforcement, existingRowsCheckEnforcement)) {
                return false;
            }
            if (!EqualityComparer<TableDefinition>.Default.Equals(other.Definition, definition)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.SchemaObjectName, schemaObjectName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterTableAddTableElementStatement left, AlterTableAddTableElementStatement right) {
            return EqualityComparer<AlterTableAddTableElementStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterTableAddTableElementStatement left, AlterTableAddTableElementStatement right) {
            return !(left == right);
        }
    
    }

}
