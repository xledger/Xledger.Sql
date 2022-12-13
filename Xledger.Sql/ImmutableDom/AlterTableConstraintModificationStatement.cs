using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterTableConstraintModificationStatement : AlterTableStatement, IEquatable<AlterTableConstraintModificationStatement> {
        protected ScriptDom.ConstraintEnforcement existingRowsCheckEnforcement = ScriptDom.ConstraintEnforcement.NotSpecified;
        protected ScriptDom.ConstraintEnforcement constraintEnforcement = ScriptDom.ConstraintEnforcement.NotSpecified;
        protected bool all = false;
        protected IReadOnlyList<Identifier> constraintNames;
    
        public ScriptDom.ConstraintEnforcement ExistingRowsCheckEnforcement => existingRowsCheckEnforcement;
        public ScriptDom.ConstraintEnforcement ConstraintEnforcement => constraintEnforcement;
        public bool All => all;
        public IReadOnlyList<Identifier> ConstraintNames => constraintNames;
    
        public AlterTableConstraintModificationStatement(ScriptDom.ConstraintEnforcement existingRowsCheckEnforcement = ScriptDom.ConstraintEnforcement.NotSpecified, ScriptDom.ConstraintEnforcement constraintEnforcement = ScriptDom.ConstraintEnforcement.NotSpecified, bool all = false, IReadOnlyList<Identifier> constraintNames = null, SchemaObjectName schemaObjectName = null) {
            this.existingRowsCheckEnforcement = existingRowsCheckEnforcement;
            this.constraintEnforcement = constraintEnforcement;
            this.all = all;
            this.constraintNames = constraintNames is null ? ImmList<Identifier>.Empty : ImmList<Identifier>.FromList(constraintNames);
            this.schemaObjectName = schemaObjectName;
        }
    
        public ScriptDom.AlterTableConstraintModificationStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterTableConstraintModificationStatement();
            ret.ExistingRowsCheckEnforcement = existingRowsCheckEnforcement;
            ret.ConstraintEnforcement = constraintEnforcement;
            ret.All = all;
            ret.ConstraintNames.AddRange(constraintNames.SelectList(c => (ScriptDom.Identifier)c.ToMutable()));
            ret.SchemaObjectName = (ScriptDom.SchemaObjectName)schemaObjectName.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + existingRowsCheckEnforcement.GetHashCode();
            h = h * 23 + constraintEnforcement.GetHashCode();
            h = h * 23 + all.GetHashCode();
            h = h * 23 + constraintNames.GetHashCode();
            if (!(schemaObjectName is null)) {
                h = h * 23 + schemaObjectName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterTableConstraintModificationStatement);
        } 
        
        public bool Equals(AlterTableConstraintModificationStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ConstraintEnforcement>.Default.Equals(other.ExistingRowsCheckEnforcement, existingRowsCheckEnforcement)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ConstraintEnforcement>.Default.Equals(other.ConstraintEnforcement, constraintEnforcement)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.All, all)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.ConstraintNames, constraintNames)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.SchemaObjectName, schemaObjectName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterTableConstraintModificationStatement left, AlterTableConstraintModificationStatement right) {
            return EqualityComparer<AlterTableConstraintModificationStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterTableConstraintModificationStatement left, AlterTableConstraintModificationStatement right) {
            return !(left == right);
        }
    
        public static AlterTableConstraintModificationStatement FromMutable(ScriptDom.AlterTableConstraintModificationStatement fragment) {
            return (AlterTableConstraintModificationStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
