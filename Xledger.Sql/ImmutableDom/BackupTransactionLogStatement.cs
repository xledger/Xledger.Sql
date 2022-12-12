using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BackupTransactionLogStatement : BackupStatement, IEquatable<BackupTransactionLogStatement> {
        public BackupTransactionLogStatement(IdentifierOrValueExpression databaseName = null, IReadOnlyList<BackupOption> options = null, IReadOnlyList<MirrorToClause> mirrorToClauses = null, IReadOnlyList<DeviceInfo> devices = null) {
            this.databaseName = databaseName;
            this.options = options is null ? ImmList<BackupOption>.Empty : ImmList<BackupOption>.FromList(options);
            this.mirrorToClauses = mirrorToClauses is null ? ImmList<MirrorToClause>.Empty : ImmList<MirrorToClause>.FromList(mirrorToClauses);
            this.devices = devices is null ? ImmList<DeviceInfo>.Empty : ImmList<DeviceInfo>.FromList(devices);
        }
    
        public ScriptDom.BackupTransactionLogStatement ToMutableConcrete() {
            var ret = new ScriptDom.BackupTransactionLogStatement();
            ret.DatabaseName = (ScriptDom.IdentifierOrValueExpression)databaseName.ToMutable();
            ret.Options.AddRange(options.Select(c => (ScriptDom.BackupOption)c.ToMutable()));
            ret.MirrorToClauses.AddRange(mirrorToClauses.Select(c => (ScriptDom.MirrorToClause)c.ToMutable()));
            ret.Devices.AddRange(devices.Select(c => (ScriptDom.DeviceInfo)c.ToMutable()));
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
            h = h * 23 + options.GetHashCode();
            h = h * 23 + mirrorToClauses.GetHashCode();
            h = h * 23 + devices.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as BackupTransactionLogStatement);
        } 
        
        public bool Equals(BackupTransactionLogStatement other) {
            if (other is null) { return false; }
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
        
        public static bool operator ==(BackupTransactionLogStatement left, BackupTransactionLogStatement right) {
            return EqualityComparer<BackupTransactionLogStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BackupTransactionLogStatement left, BackupTransactionLogStatement right) {
            return !(left == right);
        }
    
    }

}
