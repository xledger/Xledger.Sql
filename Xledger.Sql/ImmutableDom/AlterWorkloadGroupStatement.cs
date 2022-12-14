using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterWorkloadGroupStatement : WorkloadGroupStatement, IEquatable<AlterWorkloadGroupStatement> {
        public AlterWorkloadGroupStatement(Identifier name = null, IReadOnlyList<WorkloadGroupParameter> workloadGroupParameters = null, Identifier poolName = null, Identifier externalPoolName = null) {
            this.name = name;
            this.workloadGroupParameters = ImmList<WorkloadGroupParameter>.FromList(workloadGroupParameters);
            this.poolName = poolName;
            this.externalPoolName = externalPoolName;
        }
    
        public ScriptDom.AlterWorkloadGroupStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterWorkloadGroupStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.WorkloadGroupParameters.AddRange(workloadGroupParameters.SelectList(c => (ScriptDom.WorkloadGroupParameter)c.ToMutable()));
            ret.PoolName = (ScriptDom.Identifier)poolName.ToMutable();
            ret.ExternalPoolName = (ScriptDom.Identifier)externalPoolName.ToMutable();
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
            return Equals(obj as AlterWorkloadGroupStatement);
        } 
        
        public bool Equals(AlterWorkloadGroupStatement other) {
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
        
        public static bool operator ==(AlterWorkloadGroupStatement left, AlterWorkloadGroupStatement right) {
            return EqualityComparer<AlterWorkloadGroupStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterWorkloadGroupStatement left, AlterWorkloadGroupStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterWorkloadGroupStatement)that;
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
        public static bool operator < (AlterWorkloadGroupStatement left, AlterWorkloadGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterWorkloadGroupStatement left, AlterWorkloadGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterWorkloadGroupStatement left, AlterWorkloadGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterWorkloadGroupStatement left, AlterWorkloadGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterWorkloadGroupStatement FromMutable(ScriptDom.AlterWorkloadGroupStatement fragment) {
            return (AlterWorkloadGroupStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
