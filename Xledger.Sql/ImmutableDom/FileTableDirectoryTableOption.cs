using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FileTableDirectoryTableOption : TableOption, IEquatable<FileTableDirectoryTableOption> {
        protected Literal @value;
    
        public Literal Value => @value;
    
        public FileTableDirectoryTableOption(Literal @value = null, ScriptDom.TableOptionKind optionKind = ScriptDom.TableOptionKind.LockEscalation) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.FileTableDirectoryTableOption ToMutableConcrete() {
            var ret = new ScriptDom.FileTableDirectoryTableOption();
            ret.Value = (ScriptDom.Literal)@value.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as FileTableDirectoryTableOption);
        } 
        
        public bool Equals(FileTableDirectoryTableOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TableOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(FileTableDirectoryTableOption left, FileTableDirectoryTableOption right) {
            return EqualityComparer<FileTableDirectoryTableOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FileTableDirectoryTableOption left, FileTableDirectoryTableOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (FileTableDirectoryTableOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (FileTableDirectoryTableOption left, FileTableDirectoryTableOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(FileTableDirectoryTableOption left, FileTableDirectoryTableOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (FileTableDirectoryTableOption left, FileTableDirectoryTableOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(FileTableDirectoryTableOption left, FileTableDirectoryTableOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static FileTableDirectoryTableOption FromMutable(ScriptDom.FileTableDirectoryTableOption fragment) {
            return (FileTableDirectoryTableOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
