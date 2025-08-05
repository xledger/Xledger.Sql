using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FileStreamDatabaseOption : DatabaseOption, IEquatable<FileStreamDatabaseOption> {
        protected ScriptDom.NonTransactedFileStreamAccess? nonTransactedAccess;
        protected Literal directoryName;
    
        public ScriptDom.NonTransactedFileStreamAccess? NonTransactedAccess => nonTransactedAccess;
        public Literal DirectoryName => directoryName;
    
        public FileStreamDatabaseOption(ScriptDom.NonTransactedFileStreamAccess? nonTransactedAccess = null, Literal directoryName = null, ScriptDom.DatabaseOptionKind optionKind = ScriptDom.DatabaseOptionKind.Online) {
            this.nonTransactedAccess = nonTransactedAccess;
            this.directoryName = directoryName;
            this.optionKind = optionKind;
        }
    
        public new ScriptDom.FileStreamDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.FileStreamDatabaseOption();
            ret.NonTransactedAccess = nonTransactedAccess;
            ret.DirectoryName = (ScriptDom.Literal)directoryName?.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + nonTransactedAccess.GetHashCode();
            if (!(directoryName is null)) {
                h = h * 23 + directoryName.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as FileStreamDatabaseOption);
        } 
        
        public bool Equals(FileStreamDatabaseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.NonTransactedFileStreamAccess?>.Default.Equals(other.NonTransactedAccess, nonTransactedAccess)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.DirectoryName, directoryName)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.DatabaseOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(FileStreamDatabaseOption left, FileStreamDatabaseOption right) {
            return EqualityComparer<FileStreamDatabaseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FileStreamDatabaseOption left, FileStreamDatabaseOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (FileStreamDatabaseOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.nonTransactedAccess, othr.nonTransactedAccess);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.directoryName, othr.directoryName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (FileStreamDatabaseOption left, FileStreamDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(FileStreamDatabaseOption left, FileStreamDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (FileStreamDatabaseOption left, FileStreamDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(FileStreamDatabaseOption left, FileStreamDatabaseOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static FileStreamDatabaseOption FromMutable(ScriptDom.FileStreamDatabaseOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.FileStreamDatabaseOption)) { throw new NotImplementedException("Unexpected subtype of FileStreamDatabaseOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FileStreamDatabaseOption(
                nonTransactedAccess: fragment.NonTransactedAccess,
                directoryName: ImmutableDom.Literal.FromMutable(fragment.DirectoryName),
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
