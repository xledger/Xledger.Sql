using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
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
    
        public ScriptDom.FileStreamDatabaseOption ToMutableConcrete() {
            var ret = new ScriptDom.FileStreamDatabaseOption();
            ret.NonTransactedAccess = nonTransactedAccess;
            ret.DirectoryName = (ScriptDom.Literal)directoryName.ToMutable();
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
    
    }

}
