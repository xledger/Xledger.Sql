using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FileGrowthFileDeclarationOption : FileDeclarationOption, IEquatable<FileGrowthFileDeclarationOption> {
        protected Literal growthIncrement;
        protected ScriptDom.MemoryUnit units = ScriptDom.MemoryUnit.Unspecified;
    
        public Literal GrowthIncrement => growthIncrement;
        public ScriptDom.MemoryUnit Units => units;
    
        public FileGrowthFileDeclarationOption(Literal growthIncrement = null, ScriptDom.MemoryUnit units = ScriptDom.MemoryUnit.Unspecified, ScriptDom.FileDeclarationOptionKind optionKind = ScriptDom.FileDeclarationOptionKind.Name) {
            this.growthIncrement = growthIncrement;
            this.units = units;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.FileGrowthFileDeclarationOption ToMutableConcrete() {
            var ret = new ScriptDom.FileGrowthFileDeclarationOption();
            ret.GrowthIncrement = (ScriptDom.Literal)growthIncrement?.ToMutable();
            ret.Units = units;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(growthIncrement is null)) {
                h = h * 23 + growthIncrement.GetHashCode();
            }
            h = h * 23 + units.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as FileGrowthFileDeclarationOption);
        } 
        
        public bool Equals(FileGrowthFileDeclarationOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.GrowthIncrement, growthIncrement)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.MemoryUnit>.Default.Equals(other.Units, units)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.FileDeclarationOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(FileGrowthFileDeclarationOption left, FileGrowthFileDeclarationOption right) {
            return EqualityComparer<FileGrowthFileDeclarationOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FileGrowthFileDeclarationOption left, FileGrowthFileDeclarationOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (FileGrowthFileDeclarationOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.growthIncrement, othr.growthIncrement);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.units, othr.units);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (FileGrowthFileDeclarationOption left, FileGrowthFileDeclarationOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(FileGrowthFileDeclarationOption left, FileGrowthFileDeclarationOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (FileGrowthFileDeclarationOption left, FileGrowthFileDeclarationOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(FileGrowthFileDeclarationOption left, FileGrowthFileDeclarationOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
