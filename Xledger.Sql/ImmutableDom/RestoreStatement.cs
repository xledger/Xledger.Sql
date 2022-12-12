using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class RestoreStatement : TSqlStatement, IEquatable<RestoreStatement> {
        IdentifierOrValueExpression databaseName;
        IReadOnlyList<DeviceInfo> devices;
        IReadOnlyList<BackupRestoreFileInfo> files;
        IReadOnlyList<RestoreOption> options;
        ScriptDom.RestoreStatementKind kind = ScriptDom.RestoreStatementKind.None;
    
        public IdentifierOrValueExpression DatabaseName => databaseName;
        public IReadOnlyList<DeviceInfo> Devices => devices;
        public IReadOnlyList<BackupRestoreFileInfo> Files => files;
        public IReadOnlyList<RestoreOption> Options => options;
        public ScriptDom.RestoreStatementKind Kind => kind;
    
        public RestoreStatement(IdentifierOrValueExpression databaseName = null, IReadOnlyList<DeviceInfo> devices = null, IReadOnlyList<BackupRestoreFileInfo> files = null, IReadOnlyList<RestoreOption> options = null, ScriptDom.RestoreStatementKind kind = ScriptDom.RestoreStatementKind.None) {
            this.databaseName = databaseName;
            this.devices = devices is null ? ImmList<DeviceInfo>.Empty : ImmList<DeviceInfo>.FromList(devices);
            this.files = files is null ? ImmList<BackupRestoreFileInfo>.Empty : ImmList<BackupRestoreFileInfo>.FromList(files);
            this.options = options is null ? ImmList<RestoreOption>.Empty : ImmList<RestoreOption>.FromList(options);
            this.kind = kind;
        }
    
        public ScriptDom.RestoreStatement ToMutableConcrete() {
            var ret = new ScriptDom.RestoreStatement();
            ret.DatabaseName = (ScriptDom.IdentifierOrValueExpression)databaseName.ToMutable();
            ret.Devices.AddRange(devices.Select(c => (ScriptDom.DeviceInfo)c.ToMutable()));
            ret.Files.AddRange(files.Select(c => (ScriptDom.BackupRestoreFileInfo)c.ToMutable()));
            ret.Options.AddRange(options.Select(c => (ScriptDom.RestoreOption)c.ToMutable()));
            ret.Kind = kind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(databaseName is null)) {
                h = h * 23 + databaseName.GetHashCode();
            }
            h = h * 23 + devices.GetHashCode();
            h = h * 23 + files.GetHashCode();
            h = h * 23 + options.GetHashCode();
            h = h * 23 + kind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as RestoreStatement);
        } 
        
        public bool Equals(RestoreStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.DatabaseName, databaseName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<DeviceInfo>>.Default.Equals(other.Devices, devices)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<BackupRestoreFileInfo>>.Default.Equals(other.Files, files)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<RestoreOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.RestoreStatementKind>.Default.Equals(other.Kind, kind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(RestoreStatement left, RestoreStatement right) {
            return EqualityComparer<RestoreStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(RestoreStatement left, RestoreStatement right) {
            return !(left == right);
        }
    
    }

}
