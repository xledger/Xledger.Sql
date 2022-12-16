using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DeviceInfo : TSqlFragment, IEquatable<DeviceInfo> {
        protected IdentifierOrValueExpression logicalDevice;
        protected ValueExpression physicalDevice;
        protected ScriptDom.DeviceType deviceType = ScriptDom.DeviceType.None;
    
        public IdentifierOrValueExpression LogicalDevice => logicalDevice;
        public ValueExpression PhysicalDevice => physicalDevice;
        public ScriptDom.DeviceType DeviceType => deviceType;
    
        public DeviceInfo(IdentifierOrValueExpression logicalDevice = null, ValueExpression physicalDevice = null, ScriptDom.DeviceType deviceType = ScriptDom.DeviceType.None) {
            this.logicalDevice = logicalDevice;
            this.physicalDevice = physicalDevice;
            this.deviceType = deviceType;
        }
    
        public ScriptDom.DeviceInfo ToMutableConcrete() {
            var ret = new ScriptDom.DeviceInfo();
            ret.LogicalDevice = (ScriptDom.IdentifierOrValueExpression)logicalDevice?.ToMutable();
            ret.PhysicalDevice = (ScriptDom.ValueExpression)physicalDevice?.ToMutable();
            ret.DeviceType = deviceType;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(logicalDevice is null)) {
                h = h * 23 + logicalDevice.GetHashCode();
            }
            if (!(physicalDevice is null)) {
                h = h * 23 + physicalDevice.GetHashCode();
            }
            h = h * 23 + deviceType.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DeviceInfo);
        } 
        
        public bool Equals(DeviceInfo other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.LogicalDevice, logicalDevice)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.PhysicalDevice, physicalDevice)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DeviceType>.Default.Equals(other.DeviceType, deviceType)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DeviceInfo left, DeviceInfo right) {
            return EqualityComparer<DeviceInfo>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DeviceInfo left, DeviceInfo right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DeviceInfo)that;
            compare = Comparer.DefaultInvariant.Compare(this.logicalDevice, othr.logicalDevice);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.physicalDevice, othr.physicalDevice);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.deviceType, othr.deviceType);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (DeviceInfo left, DeviceInfo right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DeviceInfo left, DeviceInfo right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DeviceInfo left, DeviceInfo right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DeviceInfo left, DeviceInfo right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
