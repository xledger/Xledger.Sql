using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterTableTriggerModificationStatement : AlterTableStatement, IEquatable<AlterTableTriggerModificationStatement> {
        protected ScriptDom.TriggerEnforcement triggerEnforcement = ScriptDom.TriggerEnforcement.Disable;
        protected bool all = false;
        protected IReadOnlyList<Identifier> triggerNames;
    
        public ScriptDom.TriggerEnforcement TriggerEnforcement => triggerEnforcement;
        public bool All => all;
        public IReadOnlyList<Identifier> TriggerNames => triggerNames;
    
        public AlterTableTriggerModificationStatement(ScriptDom.TriggerEnforcement triggerEnforcement = ScriptDom.TriggerEnforcement.Disable, bool all = false, IReadOnlyList<Identifier> triggerNames = null, SchemaObjectName schemaObjectName = null) {
            this.triggerEnforcement = triggerEnforcement;
            this.all = all;
            this.triggerNames = ImmList<Identifier>.FromList(triggerNames);
            this.schemaObjectName = schemaObjectName;
        }
    
        public ScriptDom.AlterTableTriggerModificationStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterTableTriggerModificationStatement();
            ret.TriggerEnforcement = triggerEnforcement;
            ret.All = all;
            ret.TriggerNames.AddRange(triggerNames.SelectList(c => (ScriptDom.Identifier)c.ToMutable()));
            ret.SchemaObjectName = (ScriptDom.SchemaObjectName)schemaObjectName.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + triggerEnforcement.GetHashCode();
            h = h * 23 + all.GetHashCode();
            h = h * 23 + triggerNames.GetHashCode();
            if (!(schemaObjectName is null)) {
                h = h * 23 + schemaObjectName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterTableTriggerModificationStatement);
        } 
        
        public bool Equals(AlterTableTriggerModificationStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.TriggerEnforcement>.Default.Equals(other.TriggerEnforcement, triggerEnforcement)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.All, all)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.TriggerNames, triggerNames)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.SchemaObjectName, schemaObjectName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterTableTriggerModificationStatement left, AlterTableTriggerModificationStatement right) {
            return EqualityComparer<AlterTableTriggerModificationStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterTableTriggerModificationStatement left, AlterTableTriggerModificationStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterTableTriggerModificationStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.triggerEnforcement, othr.triggerEnforcement);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.all, othr.all);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.triggerNames, othr.triggerNames);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.schemaObjectName, othr.schemaObjectName);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AlterTableTriggerModificationStatement left, AlterTableTriggerModificationStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterTableTriggerModificationStatement left, AlterTableTriggerModificationStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterTableTriggerModificationStatement left, AlterTableTriggerModificationStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterTableTriggerModificationStatement left, AlterTableTriggerModificationStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterTableTriggerModificationStatement FromMutable(ScriptDom.AlterTableTriggerModificationStatement fragment) {
            return (AlterTableTriggerModificationStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
