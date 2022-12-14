using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FileTableCollateFileNameTableOption : TableOption, IEquatable<FileTableCollateFileNameTableOption> {
        protected Identifier @value;
    
        public Identifier Value => @value;
    
        public FileTableCollateFileNameTableOption(Identifier @value = null, ScriptDom.TableOptionKind optionKind = ScriptDom.TableOptionKind.LockEscalation) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.FileTableCollateFileNameTableOption ToMutableConcrete() {
            var ret = new ScriptDom.FileTableCollateFileNameTableOption();
            ret.Value = (ScriptDom.Identifier)@value?.ToMutable();
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
            return Equals(obj as FileTableCollateFileNameTableOption);
        } 
        
        public bool Equals(FileTableCollateFileNameTableOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TableOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(FileTableCollateFileNameTableOption left, FileTableCollateFileNameTableOption right) {
            return EqualityComparer<FileTableCollateFileNameTableOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FileTableCollateFileNameTableOption left, FileTableCollateFileNameTableOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (FileTableCollateFileNameTableOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (FileTableCollateFileNameTableOption left, FileTableCollateFileNameTableOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(FileTableCollateFileNameTableOption left, FileTableCollateFileNameTableOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (FileTableCollateFileNameTableOption left, FileTableCollateFileNameTableOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(FileTableCollateFileNameTableOption left, FileTableCollateFileNameTableOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static FileTableCollateFileNameTableOption FromMutable(ScriptDom.FileTableCollateFileNameTableOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.FileTableCollateFileNameTableOption)) { throw new NotImplementedException("Unexpected subtype of FileTableCollateFileNameTableOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FileTableCollateFileNameTableOption(
                @value: ImmutableDom.Identifier.FromMutable(fragment.Value),
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
