using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class MirrorToClause : TSqlFragment, IEquatable<MirrorToClause> {
        protected IReadOnlyList<DeviceInfo> devices;
    
        public IReadOnlyList<DeviceInfo> Devices => devices;
    
        public MirrorToClause(IReadOnlyList<DeviceInfo> devices = null) {
            this.devices = devices.ToImmArray<DeviceInfo>();
        }
    
        public ScriptDom.MirrorToClause ToMutableConcrete() {
            var ret = new ScriptDom.MirrorToClause();
            ret.Devices.AddRange(devices.Select(c => (ScriptDom.DeviceInfo)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + devices.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as MirrorToClause);
        } 
        
        public bool Equals(MirrorToClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<DeviceInfo>>.Default.Equals(other.Devices, devices)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(MirrorToClause left, MirrorToClause right) {
            return EqualityComparer<MirrorToClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(MirrorToClause left, MirrorToClause right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (MirrorToClause)that;
            compare = Comparer.DefaultInvariant.Compare(this.devices, othr.devices);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (MirrorToClause left, MirrorToClause right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(MirrorToClause left, MirrorToClause right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (MirrorToClause left, MirrorToClause right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(MirrorToClause left, MirrorToClause right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static MirrorToClause FromMutable(ScriptDom.MirrorToClause fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.MirrorToClause)) { throw new NotImplementedException("Unexpected subtype of MirrorToClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new MirrorToClause(
                devices: fragment.Devices.ToImmArray(ImmutableDom.DeviceInfo.FromMutable)
            );
        }
    
    }

}
