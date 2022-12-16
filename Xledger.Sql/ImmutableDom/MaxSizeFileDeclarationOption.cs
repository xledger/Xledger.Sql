using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class MaxSizeFileDeclarationOption : FileDeclarationOption, IEquatable<MaxSizeFileDeclarationOption> {
        protected Literal maxSize;
        protected ScriptDom.MemoryUnit units = ScriptDom.MemoryUnit.Unspecified;
        protected bool unlimited = false;
    
        public Literal MaxSize => maxSize;
        public ScriptDom.MemoryUnit Units => units;
        public bool Unlimited => unlimited;
    
        public MaxSizeFileDeclarationOption(Literal maxSize = null, ScriptDom.MemoryUnit units = ScriptDom.MemoryUnit.Unspecified, bool unlimited = false, ScriptDom.FileDeclarationOptionKind optionKind = ScriptDom.FileDeclarationOptionKind.Name) {
            this.maxSize = maxSize;
            this.units = units;
            this.unlimited = unlimited;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.MaxSizeFileDeclarationOption ToMutableConcrete() {
            var ret = new ScriptDom.MaxSizeFileDeclarationOption();
            ret.MaxSize = (ScriptDom.Literal)maxSize?.ToMutable();
            ret.Units = units;
            ret.Unlimited = unlimited;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(maxSize is null)) {
                h = h * 23 + maxSize.GetHashCode();
            }
            h = h * 23 + units.GetHashCode();
            h = h * 23 + unlimited.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as MaxSizeFileDeclarationOption);
        } 
        
        public bool Equals(MaxSizeFileDeclarationOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.MaxSize, maxSize)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.MemoryUnit>.Default.Equals(other.Units, units)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.Unlimited, unlimited)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.FileDeclarationOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(MaxSizeFileDeclarationOption left, MaxSizeFileDeclarationOption right) {
            return EqualityComparer<MaxSizeFileDeclarationOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(MaxSizeFileDeclarationOption left, MaxSizeFileDeclarationOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (MaxSizeFileDeclarationOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.maxSize, othr.maxSize);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.units, othr.units);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.unlimited, othr.unlimited);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (MaxSizeFileDeclarationOption left, MaxSizeFileDeclarationOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(MaxSizeFileDeclarationOption left, MaxSizeFileDeclarationOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (MaxSizeFileDeclarationOption left, MaxSizeFileDeclarationOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(MaxSizeFileDeclarationOption left, MaxSizeFileDeclarationOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
