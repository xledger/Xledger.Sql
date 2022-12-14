using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterTableChangeTrackingModificationStatement : AlterTableStatement, IEquatable<AlterTableChangeTrackingModificationStatement> {
        protected bool isEnable = false;
        protected ScriptDom.OptionState trackColumnsUpdated = ScriptDom.OptionState.NotSet;
    
        public bool IsEnable => isEnable;
        public ScriptDom.OptionState TrackColumnsUpdated => trackColumnsUpdated;
    
        public AlterTableChangeTrackingModificationStatement(bool isEnable = false, ScriptDom.OptionState trackColumnsUpdated = ScriptDom.OptionState.NotSet, SchemaObjectName schemaObjectName = null) {
            this.isEnable = isEnable;
            this.trackColumnsUpdated = trackColumnsUpdated;
            this.schemaObjectName = schemaObjectName;
        }
    
        public ScriptDom.AlterTableChangeTrackingModificationStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterTableChangeTrackingModificationStatement();
            ret.IsEnable = isEnable;
            ret.TrackColumnsUpdated = trackColumnsUpdated;
            ret.SchemaObjectName = (ScriptDom.SchemaObjectName)schemaObjectName.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isEnable.GetHashCode();
            h = h * 23 + trackColumnsUpdated.GetHashCode();
            if (!(schemaObjectName is null)) {
                h = h * 23 + schemaObjectName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterTableChangeTrackingModificationStatement);
        } 
        
        public bool Equals(AlterTableChangeTrackingModificationStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsEnable, isEnable)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.TrackColumnsUpdated, trackColumnsUpdated)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.SchemaObjectName, schemaObjectName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterTableChangeTrackingModificationStatement left, AlterTableChangeTrackingModificationStatement right) {
            return EqualityComparer<AlterTableChangeTrackingModificationStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterTableChangeTrackingModificationStatement left, AlterTableChangeTrackingModificationStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterTableChangeTrackingModificationStatement)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.isEnable, othr.isEnable);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.trackColumnsUpdated, othr.trackColumnsUpdated);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.schemaObjectName, othr.schemaObjectName);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static AlterTableChangeTrackingModificationStatement FromMutable(ScriptDom.AlterTableChangeTrackingModificationStatement fragment) {
            return (AlterTableChangeTrackingModificationStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
