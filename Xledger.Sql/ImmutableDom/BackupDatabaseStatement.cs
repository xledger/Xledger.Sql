using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BackupDatabaseStatement : BackupStatement, IEquatable<BackupDatabaseStatement> {
        protected IReadOnlyList<BackupRestoreFileInfo> files;
    
        public IReadOnlyList<BackupRestoreFileInfo> Files => files;
    
        public BackupDatabaseStatement(IReadOnlyList<BackupRestoreFileInfo> files = null, IdentifierOrValueExpression databaseName = null, IReadOnlyList<BackupOption> options = null, IReadOnlyList<MirrorToClause> mirrorToClauses = null, IReadOnlyList<DeviceInfo> devices = null) {
            this.files = files.ToImmArray<BackupRestoreFileInfo>();
            this.databaseName = databaseName;
            this.options = options.ToImmArray<BackupOption>();
            this.mirrorToClauses = mirrorToClauses.ToImmArray<MirrorToClause>();
            this.devices = devices.ToImmArray<DeviceInfo>();
        }
    
        public ScriptDom.BackupDatabaseStatement ToMutableConcrete() {
            var ret = new ScriptDom.BackupDatabaseStatement();
            ret.Files.AddRange(files.Select(c => (ScriptDom.BackupRestoreFileInfo)c?.ToMutable()));
            ret.DatabaseName = (ScriptDom.IdentifierOrValueExpression)databaseName?.ToMutable();
            ret.Options.AddRange(options.Select(c => (ScriptDom.BackupOption)c?.ToMutable()));
            ret.MirrorToClauses.AddRange(mirrorToClauses.Select(c => (ScriptDom.MirrorToClause)c?.ToMutable()));
            ret.Devices.AddRange(devices.Select(c => (ScriptDom.DeviceInfo)c?.ToMutable()));
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (BackupDatabaseStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.files, othr.files);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.databaseName, othr.databaseName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.mirrorToClauses, othr.mirrorToClauses);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.devices, othr.devices);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (BackupDatabaseStatement left, BackupDatabaseStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(BackupDatabaseStatement left, BackupDatabaseStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (BackupDatabaseStatement left, BackupDatabaseStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(BackupDatabaseStatement left, BackupDatabaseStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static BackupDatabaseStatement FromMutable(ScriptDom.BackupDatabaseStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.BackupDatabaseStatement)) { throw new NotImplementedException("Unexpected subtype of BackupDatabaseStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BackupDatabaseStatement(
                files: fragment.Files.ToImmArray(ImmutableDom.BackupRestoreFileInfo.FromMutable),
                databaseName: ImmutableDom.IdentifierOrValueExpression.FromMutable(fragment.DatabaseName),
                options: fragment.Options.ToImmArray(ImmutableDom.BackupOption.FromMutable),
                mirrorToClauses: fragment.MirrorToClauses.ToImmArray(ImmutableDom.MirrorToClause.FromMutable),
                devices: fragment.Devices.ToImmArray(ImmutableDom.DeviceInfo.FromMutable)
            );
        }
    
    }

}
