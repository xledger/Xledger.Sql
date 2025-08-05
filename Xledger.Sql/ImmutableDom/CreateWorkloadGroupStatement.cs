using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateWorkloadGroupStatement : WorkloadGroupStatement, IEquatable<CreateWorkloadGroupStatement> {
        public CreateWorkloadGroupStatement(Identifier name = null, IReadOnlyList<WorkloadGroupParameter> workloadGroupParameters = null, Identifier poolName = null, Identifier externalPoolName = null) {
            this.name = name;
            this.workloadGroupParameters = workloadGroupParameters.ToImmArray<WorkloadGroupParameter>();
            this.poolName = poolName;
            this.externalPoolName = externalPoolName;
        }
    
        public ScriptDom.CreateWorkloadGroupStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateWorkloadGroupStatement();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.WorkloadGroupParameters.AddRange(workloadGroupParameters.Select(c => (ScriptDom.WorkloadGroupParameter)c?.ToMutable()));
            ret.PoolName = (ScriptDom.Identifier)poolName?.ToMutable();
            ret.ExternalPoolName = (ScriptDom.Identifier)externalPoolName?.ToMutable();
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
            h = h * 23 + workloadGroupParameters.GetHashCode();
            if (!(poolName is null)) {
                h = h * 23 + poolName.GetHashCode();
            }
            if (!(externalPoolName is null)) {
                h = h * 23 + externalPoolName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateWorkloadGroupStatement);
        } 
        
        public bool Equals(CreateWorkloadGroupStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<WorkloadGroupParameter>>.Default.Equals(other.WorkloadGroupParameters, workloadGroupParameters)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.PoolName, poolName)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.ExternalPoolName, externalPoolName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateWorkloadGroupStatement left, CreateWorkloadGroupStatement right) {
            return EqualityComparer<CreateWorkloadGroupStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateWorkloadGroupStatement left, CreateWorkloadGroupStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateWorkloadGroupStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.workloadGroupParameters, othr.workloadGroupParameters);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.poolName, othr.poolName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.externalPoolName, othr.externalPoolName);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CreateWorkloadGroupStatement left, CreateWorkloadGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateWorkloadGroupStatement left, CreateWorkloadGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateWorkloadGroupStatement left, CreateWorkloadGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateWorkloadGroupStatement left, CreateWorkloadGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateWorkloadGroupStatement FromMutable(ScriptDom.CreateWorkloadGroupStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreateWorkloadGroupStatement)) { throw new NotImplementedException("Unexpected subtype of CreateWorkloadGroupStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateWorkloadGroupStatement(
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                workloadGroupParameters: fragment.WorkloadGroupParameters.ToImmArray(ImmutableDom.WorkloadGroupParameter.FromMutable),
                poolName: ImmutableDom.Identifier.FromMutable(fragment.PoolName),
                externalPoolName: ImmutableDom.Identifier.FromMutable(fragment.ExternalPoolName)
            );
        }
    
    }

}
