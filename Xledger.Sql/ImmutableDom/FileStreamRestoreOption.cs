using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FileStreamRestoreOption : RestoreOption, IEquatable<FileStreamRestoreOption> {
        FileStreamDatabaseOption fileStreamOption;
    
        public FileStreamDatabaseOption FileStreamOption => fileStreamOption;
    
        public FileStreamRestoreOption(FileStreamDatabaseOption fileStreamOption = null, ScriptDom.RestoreOptionKind optionKind = 0) {
            this.fileStreamOption = fileStreamOption;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.FileStreamRestoreOption ToMutableConcrete() {
            var ret = new ScriptDom.FileStreamRestoreOption();
            ret.FileStreamOption = (ScriptDom.FileStreamDatabaseOption)fileStreamOption.ToMutable();
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
    
    }

}
