using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
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
            this.options = options.ToImmArray<AvailabilityGroupOption>();
            this.databases = databases.ToImmArray<Identifier>();
            this.replicas = replicas.ToImmArray<AvailabilityReplica>();
        }
    
        public ScriptDom.AlterAvailabilityGroupStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterAvailabilityGroupStatement();
            ret.AlterAvailabilityGroupStatementType = alterAvailabilityGroupStatementType;
            ret.Action = (ScriptDom.AlterAvailabilityGroupAction)action?.ToMutable();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.Options.AddRange(options.Select(c => (ScriptDom.AvailabilityGroupOption)c?.ToMutable()));
            ret.Databases.AddRange(databases.Select(c => (ScriptDom.Identifier)c?.ToMutable()));
            ret.Replicas.AddRange(replicas.Select(c => (ScriptDom.AvailabilityReplica)c?.ToMutable()));
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
            compare = Comparer.DefaultInvariant.Compare(this.alterAvailabilityGroupStatementType, othr.alterAvailabilityGroupStatementType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.action, othr.action);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.databases, othr.databases);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.replicas, othr.replicas);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterAvailabilityGroupStatement left, AlterAvailabilityGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterAvailabilityGroupStatement left, AlterAvailabilityGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterAvailabilityGroupStatement left, AlterAvailabilityGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterAvailabilityGroupStatement left, AlterAvailabilityGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterAvailabilityGroupStatement FromMutable(ScriptDom.AlterAvailabilityGroupStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterAvailabilityGroupStatement)) { throw new NotImplementedException("Unexpected subtype of AlterAvailabilityGroupStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterAvailabilityGroupStatement(
                alterAvailabilityGroupStatementType: fragment.AlterAvailabilityGroupStatementType,
                action: ImmutableDom.AlterAvailabilityGroupAction.FromMutable(fragment.Action),
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                options: fragment.Options.ToImmArray(ImmutableDom.AvailabilityGroupOption.FromMutable),
                databases: fragment.Databases.ToImmArray(ImmutableDom.Identifier.FromMutable),
                replicas: fragment.Replicas.ToImmArray(ImmutableDom.AvailabilityReplica.FromMutable)
            );
        }
    
    }

}
