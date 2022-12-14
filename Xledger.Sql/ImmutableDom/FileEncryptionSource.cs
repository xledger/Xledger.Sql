using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FileEncryptionSource : EncryptionSource, IEquatable<FileEncryptionSource> {
        protected bool isExecutable = false;
        protected Literal file;
    
        public bool IsExecutable => isExecutable;
        public Literal File => file;
    
        public FileEncryptionSource(bool isExecutable = false, Literal file = null) {
            this.isExecutable = isExecutable;
            this.file = file;
        }
    
        public ScriptDom.FileEncryptionSource ToMutableConcrete() {
            var ret = new ScriptDom.FileEncryptionSource();
            ret.IsExecutable = isExecutable;
            ret.File = (ScriptDom.Literal)file.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isExecutable.GetHashCode();
            if (!(file is null)) {
                h = h * 23 + file.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as FileEncryptionSource);
        } 
        
        public bool Equals(FileEncryptionSource other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsExecutable, isExecutable)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.File, file)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(FileEncryptionSource left, FileEncryptionSource right) {
            return EqualityComparer<FileEncryptionSource>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FileEncryptionSource left, FileEncryptionSource right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (FileEncryptionSource)that;
            compare = Comparer.DefaultInvariant.Compare(this.isExecutable, othr.isExecutable);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.file, othr.file);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (FileEncryptionSource left, FileEncryptionSource right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(FileEncryptionSource left, FileEncryptionSource right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (FileEncryptionSource left, FileEncryptionSource right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(FileEncryptionSource left, FileEncryptionSource right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static FileEncryptionSource FromMutable(ScriptDom.FileEncryptionSource fragment) {
            return (FileEncryptionSource)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
