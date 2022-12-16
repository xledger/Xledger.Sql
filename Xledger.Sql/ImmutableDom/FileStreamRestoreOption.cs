using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FileStreamRestoreOption : RestoreOption, IEquatable<FileStreamRestoreOption> {
        protected FileStreamDatabaseOption fileStreamOption;
    
        public FileStreamDatabaseOption FileStreamOption => fileStreamOption;
    
        public FileStreamRestoreOption(FileStreamDatabaseOption fileStreamOption = null, ScriptDom.RestoreOptionKind optionKind = 0) {
            this.fileStreamOption = fileStreamOption;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.FileStreamRestoreOption ToMutableConcrete() {
            var ret = new ScriptDom.FileStreamRestoreOption();
            ret.FileStreamOption = (ScriptDom.FileStreamDatabaseOption)fileStreamOption?.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(fileStreamOption is null)) {
                h = h * 23 + fileStreamOption.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as FileStreamRestoreOption);
        } 
        
        public bool Equals(FileStreamRestoreOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<FileStreamDatabaseOption>.Default.Equals(other.FileStreamOption, fileStreamOption)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.RestoreOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(FileStreamRestoreOption left, FileStreamRestoreOption right) {
            return EqualityComparer<FileStreamRestoreOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FileStreamRestoreOption left, FileStreamRestoreOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (FileStreamRestoreOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.fileStreamOption, othr.fileStreamOption);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (FileStreamRestoreOption left, FileStreamRestoreOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(FileStreamRestoreOption left, FileStreamRestoreOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (FileStreamRestoreOption left, FileStreamRestoreOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(FileStreamRestoreOption left, FileStreamRestoreOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
