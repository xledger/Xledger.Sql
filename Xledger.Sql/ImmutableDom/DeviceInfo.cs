using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DeviceInfo : TSqlFragment, IEquatable<DeviceInfo> {
        IdentifierOrValueExpression logicalDevice;
        ValueExpression physicalDevice;
        ScriptDom.DeviceType deviceType = ScriptDom.DeviceType.None;
    
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
            ret.LogicalDevice = (ScriptDom.IdentifierOrValueExpression)logicalDevice.ToMutable();
            ret.PhysicalDevice = (ScriptDom.ValueExpression)physicalDevice.ToMutable();
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
    
    }

}
