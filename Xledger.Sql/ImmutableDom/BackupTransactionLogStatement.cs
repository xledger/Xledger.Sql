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
            this.options = ImmList<BackupOption>.FromList(options);
            this.mirrorToClauses = ImmList<MirrorToClause>.FromList(mirrorToClauses);
            this.devices = ImmList<DeviceInfo>.FromList(devices);
        }
    
        public ScriptDom.BackupTransactionLogStatement ToMutableConcrete() {
            var ret = new ScriptDom.BackupTransactionLogStatement();
            ret.DatabaseName = (ScriptDom.IdentifierOrValueExpression)databaseName?.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.BackupOption)c?.ToMutable()));
            ret.MirrorToClauses.AddRange(mirrorToClauses.SelectList(c => (ScriptDom.MirrorToClause)c?.ToMutable()));
            ret.Devices.AddRange(devices.SelectList(c => (ScriptDom.DeviceInfo)c?.ToMutable()));
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (BackupTransactionLogStatement)that;
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
        
        public static bool operator < (BackupTransactionLogStatement left, BackupTransactionLogStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(BackupTransactionLogStatement left, BackupTransactionLogStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (BackupTransactionLogStatement left, BackupTransactionLogStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(BackupTransactionLogStatement left, BackupTransactionLogStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static BackupTransactionLogStatement FromMutable(ScriptDom.BackupTransactionLogStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.BackupTransactionLogStatement)) { throw new NotImplementedException("Unexpected subtype of BackupTransactionLogStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BackupTransactionLogStatement(
                databaseName: ImmutableDom.IdentifierOrValueExpression.FromMutable(fragment.DatabaseName),
                options: fragment.Options.SelectList(ImmutableDom.BackupOption.FromMutable),
                mirrorToClauses: fragment.MirrorToClauses.SelectList(ImmutableDom.MirrorToClause.FromMutable),
                devices: fragment.Devices.SelectList(ImmutableDom.DeviceInfo.FromMutable)
            );
        }
    
    }

}
