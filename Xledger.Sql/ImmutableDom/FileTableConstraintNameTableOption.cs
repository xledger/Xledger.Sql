using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FileTableConstraintNameTableOption : TableOption, IEquatable<FileTableConstraintNameTableOption> {
        protected Identifier @value;
    
        public Identifier Value => @value;
    
        public FileTableConstraintNameTableOption(Identifier @value = null, ScriptDom.TableOptionKind optionKind = ScriptDom.TableOptionKind.LockEscalation) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.FileTableConstraintNameTableOption ToMutableConcrete() {
            var ret = new ScriptDom.FileTableConstraintNameTableOption();
            ret.Value = (ScriptDom.Identifier)@value.ToMutable();
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
            return Equals(obj as FileTableConstraintNameTableOption);
        } 
        
        public bool Equals(FileTableConstraintNameTableOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TableOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(FileTableConstraintNameTableOption left, FileTableConstraintNameTableOption right) {
            return EqualityComparer<FileTableConstraintNameTableOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FileTableConstraintNameTableOption left, FileTableConstraintNameTableOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (FileTableConstraintNameTableOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (FileTableConstraintNameTableOption left, FileTableConstraintNameTableOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(FileTableConstraintNameTableOption left, FileTableConstraintNameTableOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (FileTableConstraintNameTableOption left, FileTableConstraintNameTableOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(FileTableConstraintNameTableOption left, FileTableConstraintNameTableOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
