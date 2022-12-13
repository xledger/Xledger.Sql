using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class MirrorToClause : TSqlFragment, IEquatable<MirrorToClause> {
        protected IReadOnlyList<DeviceInfo> devices;
    
        public IReadOnlyList<DeviceInfo> Devices => devices;
    
        public MirrorToClause(IReadOnlyList<DeviceInfo> devices = null) {
            this.devices = devices is null ? ImmList<DeviceInfo>.Empty : ImmList<DeviceInfo>.FromList(devices);
        }
    
        public ScriptDom.MirrorToClause ToMutableConcrete() {
            var ret = new ScriptDom.MirrorToClause();
            ret.Devices.AddRange(devices.SelectList(c => (ScriptDom.DeviceInfo)c.ToMutable()));
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
    
        public static MirrorToClause FromMutable(ScriptDom.MirrorToClause fragment) {
            return (MirrorToClause)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
