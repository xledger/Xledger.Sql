using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public abstract class RemoteDataArchiveDatabaseSetting : TSqlFragment {
        protected ScriptDom.RemoteDataArchiveDatabaseSettingKind settingKind;
    
        public ScriptDom.RemoteDataArchiveDatabaseSettingKind SettingKind => settingKind;
    
        public static RemoteDataArchiveDatabaseSetting FromMutable(ScriptDom.RemoteDataArchiveDatabaseSetting fragment) => (RemoteDataArchiveDatabaseSetting)TSqlFragment.FromMutable(fragment);
    
    }

}
