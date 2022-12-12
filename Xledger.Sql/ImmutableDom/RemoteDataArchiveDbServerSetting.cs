using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class RemoteDataArchiveDbServerSetting : RemoteDataArchiveDatabaseSetting, IEquatable<RemoteDataArchiveDbServerSetting> {
        StringLiteral server;
    
        public StringLiteral Server => server;
    
        public RemoteDataArchiveDbServerSetting(StringLiteral server = null, ScriptDom.RemoteDataArchiveDatabaseSettingKind settingKind = ScriptDom.RemoteDataArchiveDatabaseSettingKind.Server) {
            this.server = server;
            this.settingKind = settingKind;
        }
    
        public ScriptDom.RemoteDataArchiveDbServerSetting ToMutableConcrete() {
            var ret = new ScriptDom.RemoteDataArchiveDbServerSetting();
            ret.Server = (ScriptDom.StringLiteral)server.ToMutable();
            ret.SettingKind = settingKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(server is null)) {
                h = h * 23 + server.GetHashCode();
            }
            h = h * 23 + settingKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as RemoteDataArchiveDbServerSetting);
        } 
        
        public bool Equals(RemoteDataArchiveDbServerSetting other) {
            if (other is null) { return false; }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.Server, server)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.RemoteDataArchiveDatabaseSettingKind>.Default.Equals(other.SettingKind, settingKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(RemoteDataArchiveDbServerSetting left, RemoteDataArchiveDbServerSetting right) {
            return EqualityComparer<RemoteDataArchiveDbServerSetting>.Default.Equals(left, right);
        }
        
        public static bool operator !=(RemoteDataArchiveDbServerSetting left, RemoteDataArchiveDbServerSetting right) {
            return !(left == right);
        }
    
    }

}
