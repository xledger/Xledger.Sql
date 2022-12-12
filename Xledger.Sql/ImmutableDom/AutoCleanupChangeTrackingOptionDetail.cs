using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AutoCleanupChangeTrackingOptionDetail : ChangeTrackingOptionDetail, IEquatable<AutoCleanupChangeTrackingOptionDetail> {
        protected bool isOn = false;
    
        public bool IsOn => isOn;
    
        public AutoCleanupChangeTrackingOptionDetail(bool isOn = false) {
            this.isOn = isOn;
        }
    
        public ScriptDom.AutoCleanupChangeTrackingOptionDetail ToMutableConcrete() {
            var ret = new ScriptDom.AutoCleanupChangeTrackingOptionDetail();
            ret.IsOn = isOn;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isOn.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AutoCleanupChangeTrackingOptionDetail);
        } 
        
        public bool Equals(AutoCleanupChangeTrackingOptionDetail other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsOn, isOn)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AutoCleanupChangeTrackingOptionDetail left, AutoCleanupChangeTrackingOptionDetail right) {
            return EqualityComparer<AutoCleanupChangeTrackingOptionDetail>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AutoCleanupChangeTrackingOptionDetail left, AutoCleanupChangeTrackingOptionDetail right) {
            return !(left == right);
        }
    
    }

}
