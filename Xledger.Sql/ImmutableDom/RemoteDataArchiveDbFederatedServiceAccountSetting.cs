using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class RemoteDataArchiveDbFederatedServiceAccountSetting : RemoteDataArchiveDatabaseSetting, IEquatable<RemoteDataArchiveDbFederatedServiceAccountSetting> {
        protected bool isOn = false;
    
        public bool IsOn => isOn;
    
        public RemoteDataArchiveDbFederatedServiceAccountSetting(bool isOn = false, ScriptDom.RemoteDataArchiveDatabaseSettingKind settingKind = ScriptDom.RemoteDataArchiveDatabaseSettingKind.Server) {
            this.isOn = isOn;
            this.settingKind = settingKind;
        }
    
        public ScriptDom.RemoteDataArchiveDbFederatedServiceAccountSetting ToMutableConcrete() {
            var ret = new ScriptDom.RemoteDataArchiveDbFederatedServiceAccountSetting();
            ret.IsOn = isOn;
            ret.SettingKind = settingKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isOn.GetHashCode();
            h = h * 23 + settingKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as RemoteDataArchiveDbFederatedServiceAccountSetting);
        } 
        
        public bool Equals(RemoteDataArchiveDbFederatedServiceAccountSetting other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsOn, isOn)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.RemoteDataArchiveDatabaseSettingKind>.Default.Equals(other.SettingKind, settingKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(RemoteDataArchiveDbFederatedServiceAccountSetting left, RemoteDataArchiveDbFederatedServiceAccountSetting right) {
            return EqualityComparer<RemoteDataArchiveDbFederatedServiceAccountSetting>.Default.Equals(left, right);
        }
        
        public static bool operator !=(RemoteDataArchiveDbFederatedServiceAccountSetting left, RemoteDataArchiveDbFederatedServiceAccountSetting right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (RemoteDataArchiveDbFederatedServiceAccountSetting)that;
            compare = Comparer.DefaultInvariant.Compare(this.isOn, othr.isOn);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.settingKind, othr.settingKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (RemoteDataArchiveDbFederatedServiceAccountSetting left, RemoteDataArchiveDbFederatedServiceAccountSetting right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(RemoteDataArchiveDbFederatedServiceAccountSetting left, RemoteDataArchiveDbFederatedServiceAccountSetting right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (RemoteDataArchiveDbFederatedServiceAccountSetting left, RemoteDataArchiveDbFederatedServiceAccountSetting right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(RemoteDataArchiveDbFederatedServiceAccountSetting left, RemoteDataArchiveDbFederatedServiceAccountSetting right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static RemoteDataArchiveDbFederatedServiceAccountSetting FromMutable(ScriptDom.RemoteDataArchiveDbFederatedServiceAccountSetting fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.RemoteDataArchiveDbFederatedServiceAccountSetting)) { throw new NotImplementedException("Unexpected subtype of RemoteDataArchiveDbFederatedServiceAccountSetting not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RemoteDataArchiveDbFederatedServiceAccountSetting(
                isOn: fragment.IsOn,
                settingKind: fragment.SettingKind
            );
        }
    
    }

}
