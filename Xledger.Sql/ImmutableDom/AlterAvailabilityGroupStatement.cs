using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterAvailabilityGroupStatement : AvailabilityGroupStatement, IEquatable<AlterAvailabilityGroupStatement> {
        protected ScriptDom.AlterAvailabilityGroupStatementType alterAvailabilityGroupStatementType = ScriptDom.AlterAvailabilityGroupStatementType.AddDatabase;
        protected AlterAvailabilityGroupAction action;
    
        public ScriptDom.AlterAvailabilityGroupStatementType AlterAvailabilityGroupStatementType => alterAvailabilityGroupStatementType;
        public AlterAvailabilityGroupAction Action => action;
    
        public AlterAvailabilityGroupStatement(ScriptDom.AlterAvailabilityGroupStatementType alterAvailabilityGroupStatementType = ScriptDom.AlterAvailabilityGroupStatementType.AddDatabase, AlterAvailabilityGroupAction action = null, Identifier name = null, IReadOnlyList<AvailabilityGroupOption> options = null, IReadOnlyList<Identifier> databases = null, IReadOnlyList<AvailabilityReplica> replicas = null) {
            this.alterAvailabilityGroupStatementType = alterAvailabilityGroupStatementType;
            this.action = action;
            this.name = name;
            this.options = ImmList<AvailabilityGroupOption>.FromList(options);
            this.databases = ImmList<Identifier>.FromList(databases);
            this.replicas = ImmList<AvailabilityReplica>.FromList(replicas);
        }
    
        public ScriptDom.AlterAvailabilityGroupStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterAvailabilityGroupStatement();
            ret.AlterAvailabilityGroupStatementType = alterAvailabilityGroupStatementType;
            ret.Action = (ScriptDom.AlterAvailabilityGroupAction)action.ToMutable();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.AvailabilityGroupOption)c.ToMutable()));
            ret.Databases.AddRange(databases.SelectList(c => (ScriptDom.Identifier)c.ToMutable()));
            ret.Replicas.AddRange(replicas.SelectList(c => (ScriptDom.AvailabilityReplica)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + alterAvailabilityGroupStatementType.GetHashCode();
            if (!(action is null)) {
                h = h * 23 + action.GetHashCode();
            }
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + options.GetHashCode();
            h = h * 23 + databases.GetHashCode();
            h = h * 23 + replicas.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterAvailabilityGroupStatement);
        } 
        
        public bool Equals(AlterAvailabilityGroupStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.AlterAvailabilityGroupStatementType>.Default.Equals(other.AlterAvailabilityGroupStatementType, alterAvailabilityGroupStatementType)) {
                return false;
            }
            if (!EqualityComparer<AlterAvailabilityGroupAction>.Default.Equals(other.Action, action)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<AvailabilityGroupOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.Databases, databases)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<AvailabilityReplica>>.Default.Equals(other.Replicas, replicas)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterAvailabilityGroupStatement left, AlterAvailabilityGroupStatement right) {
            return EqualityComparer<AlterAvailabilityGroupStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterAvailabilityGroupStatement left, AlterAvailabilityGroupStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterAvailabilityGroupStatement)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.alterAvailabilityGroupStatementType, othr.alterAvailabilityGroupStatementType);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.action, othr.action);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.databases, othr.databases);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.replicas, othr.replicas);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static AlterAvailabilityGroupStatement FromMutable(ScriptDom.AlterAvailabilityGroupStatement fragment) {
            return (AlterAvailabilityGroupStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
