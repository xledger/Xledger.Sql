using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ColumnStorageOptions : TSqlFragment, IEquatable<ColumnStorageOptions> {
        protected bool isFileStream = false;
        protected ScriptDom.SparseColumnOption sparseOption = ScriptDom.SparseColumnOption.None;
    
        public bool IsFileStream => isFileStream;
        public ScriptDom.SparseColumnOption SparseOption => sparseOption;
    
        public ColumnStorageOptions(bool isFileStream = false, ScriptDom.SparseColumnOption sparseOption = ScriptDom.SparseColumnOption.None) {
            this.isFileStream = isFileStream;
            this.sparseOption = sparseOption;
        }
    
        public ScriptDom.ColumnStorageOptions ToMutableConcrete() {
            var ret = new ScriptDom.ColumnStorageOptions();
            ret.IsFileStream = isFileStream;
            ret.SparseOption = sparseOption;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isFileStream.GetHashCode();
            h = h * 23 + sparseOption.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ColumnStorageOptions);
        } 
        
        public bool Equals(ColumnStorageOptions other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsFileStream, isFileStream)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.SparseColumnOption>.Default.Equals(other.SparseOption, sparseOption)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ColumnStorageOptions left, ColumnStorageOptions right) {
            return EqualityComparer<ColumnStorageOptions>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ColumnStorageOptions left, ColumnStorageOptions right) {
            return !(left == right);
        }
    
        public static ColumnStorageOptions FromMutable(ScriptDom.ColumnStorageOptions fragment) {
            return (ColumnStorageOptions)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
