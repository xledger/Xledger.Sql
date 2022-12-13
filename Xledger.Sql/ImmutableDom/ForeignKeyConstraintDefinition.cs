using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ForeignKeyConstraintDefinition : ConstraintDefinition, IEquatable<ForeignKeyConstraintDefinition> {
        protected IReadOnlyList<Identifier> columns;
        protected SchemaObjectName referenceTableName;
        protected IReadOnlyList<Identifier> referencedTableColumns;
        protected ScriptDom.DeleteUpdateAction deleteAction = ScriptDom.DeleteUpdateAction.NotSpecified;
        protected ScriptDom.DeleteUpdateAction updateAction = ScriptDom.DeleteUpdateAction.NotSpecified;
        protected bool notForReplication = false;
    
        public IReadOnlyList<Identifier> Columns => columns;
        public SchemaObjectName ReferenceTableName => referenceTableName;
        public IReadOnlyList<Identifier> ReferencedTableColumns => referencedTableColumns;
        public ScriptDom.DeleteUpdateAction DeleteAction => deleteAction;
        public ScriptDom.DeleteUpdateAction UpdateAction => updateAction;
        public bool NotForReplication => notForReplication;
    
        public ForeignKeyConstraintDefinition(IReadOnlyList<Identifier> columns = null, SchemaObjectName referenceTableName = null, IReadOnlyList<Identifier> referencedTableColumns = null, ScriptDom.DeleteUpdateAction deleteAction = ScriptDom.DeleteUpdateAction.NotSpecified, ScriptDom.DeleteUpdateAction updateAction = ScriptDom.DeleteUpdateAction.NotSpecified, bool notForReplication = false, Identifier constraintIdentifier = null) {
            this.columns = columns is null ? ImmList<Identifier>.Empty : ImmList<Identifier>.FromList(columns);
            this.referenceTableName = referenceTableName;
            this.referencedTableColumns = referencedTableColumns is null ? ImmList<Identifier>.Empty : ImmList<Identifier>.FromList(referencedTableColumns);
            this.deleteAction = deleteAction;
            this.updateAction = updateAction;
            this.notForReplication = notForReplication;
            this.constraintIdentifier = constraintIdentifier;
        }
    
        public ScriptDom.ForeignKeyConstraintDefinition ToMutableConcrete() {
            var ret = new ScriptDom.ForeignKeyConstraintDefinition();
            ret.Columns.AddRange(columns.SelectList(c => (ScriptDom.Identifier)c.ToMutable()));
            ret.ReferenceTableName = (ScriptDom.SchemaObjectName)referenceTableName.ToMutable();
            ret.ReferencedTableColumns.AddRange(referencedTableColumns.SelectList(c => (ScriptDom.Identifier)c.ToMutable()));
            ret.DeleteAction = deleteAction;
            ret.UpdateAction = updateAction;
            ret.NotForReplication = notForReplication;
            ret.ConstraintIdentifier = (ScriptDom.Identifier)constraintIdentifier.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + columns.GetHashCode();
            if (!(referenceTableName is null)) {
                h = h * 23 + referenceTableName.GetHashCode();
            }
            h = h * 23 + referencedTableColumns.GetHashCode();
            h = h * 23 + deleteAction.GetHashCode();
            h = h * 23 + updateAction.GetHashCode();
            h = h * 23 + notForReplication.GetHashCode();
            if (!(constraintIdentifier is null)) {
                h = h * 23 + constraintIdentifier.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ForeignKeyConstraintDefinition);
        } 
        
        public bool Equals(ForeignKeyConstraintDefinition other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.ReferenceTableName, referenceTableName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.ReferencedTableColumns, referencedTableColumns)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DeleteUpdateAction>.Default.Equals(other.DeleteAction, deleteAction)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DeleteUpdateAction>.Default.Equals(other.UpdateAction, updateAction)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.NotForReplication, notForReplication)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.ConstraintIdentifier, constraintIdentifier)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ForeignKeyConstraintDefinition left, ForeignKeyConstraintDefinition right) {
            return EqualityComparer<ForeignKeyConstraintDefinition>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ForeignKeyConstraintDefinition left, ForeignKeyConstraintDefinition right) {
            return !(left == right);
        }
    
        public static ForeignKeyConstraintDefinition FromMutable(ScriptDom.ForeignKeyConstraintDefinition fragment) {
            return (ForeignKeyConstraintDefinition)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
