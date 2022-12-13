using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BackupDatabaseStatement : BackupStatement, IEquatable<BackupDatabaseStatement> {
        protected IReadOnlyList<BackupRestoreFileInfo> files;
    
        public IReadOnlyList<BackupRestoreFileInfo> Files => files;
    
        public BackupDatabaseStatement(IReadOnlyList<BackupRestoreFileInfo> files = null, IdentifierOrValueExpression databaseName = null, IReadOnlyList<BackupOption> options = null, IReadOnlyList<MirrorToClause> mirrorToClauses = null, IReadOnlyList<DeviceInfo> devices = null) {
            this.files = files is null ? ImmList<BackupRestoreFileInfo>.Empty : ImmList<BackupRestoreFileInfo>.FromList(files);
            this.databaseName = databaseName;
            this.options = options is null ? ImmList<BackupOption>.Empty : ImmList<BackupOption>.FromList(options);
            this.mirrorToClauses = mirrorToClauses is null ? ImmList<MirrorToClause>.Empty : ImmList<MirrorToClause>.FromList(mirrorToClauses);
            this.devices = devices is null ? ImmList<DeviceInfo>.Empty : ImmList<DeviceInfo>.FromList(devices);
        }
    
        public ScriptDom.BackupDatabaseStatement ToMutableConcrete() {
            var ret = new ScriptDom.BackupDatabaseStatement();
            ret.Files.AddRange(files.SelectList(c => (ScriptDom.BackupRestoreFileInfo)c.ToMutable()));
            ret.DatabaseName = (ScriptDom.IdentifierOrValueExpression)databaseName.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.BackupOption)c.ToMutable()));
            ret.MirrorToClauses.AddRange(mirrorToClauses.SelectList(c => (ScriptDom.MirrorToClause)c.ToMutable()));
            ret.Devices.AddRange(devices.SelectList(c => (ScriptDom.DeviceInfo)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + files.GetHashCode();
            if (!(databaseName is null)) {
                h = h * 23 + databaseName.GetHashCode();
            }
            h = h * 23 + options.GetHashCode();
            h = h * 23 + mirrorToClauses.GetHashCode();
            h = h * 23 + devices.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as BackupDatabaseStatement);
        } 
        
        public bool Equals(BackupDatabaseStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<BackupRestoreFileInfo>>.Default.Equals(other.Files, files)) {
                return false;
            }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.DatabaseName, databaseName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<BackupOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<MirrorToClause>>.Default.Equals(other.MirrorToClauses, mirrorToClauses)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<DeviceInfo>>.Default.Equals(other.Devices, devices)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(BackupDatabaseStatement left, BackupDatabaseStatement right) {
            return EqualityComparer<BackupDatabaseStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BackupDatabaseStatement left, BackupDatabaseStatement right) {
            return !(left == right);
        }
    
        public static BackupDatabaseStatement FromMutable(ScriptDom.BackupDatabaseStatement fragment) {
            return (BackupDatabaseStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
