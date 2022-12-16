using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class RemoteDataArchiveDbCredentialSetting : RemoteDataArchiveDatabaseSetting, IEquatable<RemoteDataArchiveDbCredentialSetting> {
        protected Identifier credential;
    
        public Identifier Credential => credential;
    
        public RemoteDataArchiveDbCredentialSetting(Identifier credential = null, ScriptDom.RemoteDataArchiveDatabaseSettingKind settingKind = ScriptDom.RemoteDataArchiveDatabaseSettingKind.Server) {
            this.credential = credential;
            this.settingKind = settingKind;
        }
    
        public ScriptDom.RemoteDataArchiveDbCredentialSetting ToMutableConcrete() {
            var ret = new ScriptDom.RemoteDataArchiveDbCredentialSetting();
            ret.Credential = (ScriptDom.Identifier)credential?.ToMutable();
            ret.SettingKind = settingKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(credential is null)) {
                h = h * 23 + credential.GetHashCode();
            }
            h = h * 23 + settingKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as RemoteDataArchiveDbCredentialSetting);
        } 
        
        public bool Equals(RemoteDataArchiveDbCredentialSetting other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Credential, credential)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.RemoteDataArchiveDatabaseSettingKind>.Default.Equals(other.SettingKind, settingKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(RemoteDataArchiveDbCredentialSetting left, RemoteDataArchiveDbCredentialSetting right) {
            return EqualityComparer<RemoteDataArchiveDbCredentialSetting>.Default.Equals(left, right);
        }
        
        public static bool operator !=(RemoteDataArchiveDbCredentialSetting left, RemoteDataArchiveDbCredentialSetting right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (RemoteDataArchiveDbCredentialSetting)that;
            compare = Comparer.DefaultInvariant.Compare(this.credential, othr.credential);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.settingKind, othr.settingKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (RemoteDataArchiveDbCredentialSetting left, RemoteDataArchiveDbCredentialSetting right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(RemoteDataArchiveDbCredentialSetting left, RemoteDataArchiveDbCredentialSetting right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (RemoteDataArchiveDbCredentialSetting left, RemoteDataArchiveDbCredentialSetting right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(RemoteDataArchiveDbCredentialSetting left, RemoteDataArchiveDbCredentialSetting right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
