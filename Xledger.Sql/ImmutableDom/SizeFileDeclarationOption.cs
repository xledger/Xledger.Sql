using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SizeFileDeclarationOption : FileDeclarationOption, IEquatable<SizeFileDeclarationOption> {
        protected Literal size;
        protected ScriptDom.MemoryUnit units = ScriptDom.MemoryUnit.Unspecified;
    
        public Literal Size => size;
        public ScriptDom.MemoryUnit Units => units;
    
        public SizeFileDeclarationOption(Literal size = null, ScriptDom.MemoryUnit units = ScriptDom.MemoryUnit.Unspecified, ScriptDom.FileDeclarationOptionKind optionKind = ScriptDom.FileDeclarationOptionKind.Name) {
            this.size = size;
            this.units = units;
            this.optionKind = optionKind;
        }
    
        public new ScriptDom.SizeFileDeclarationOption ToMutableConcrete() {
            var ret = new ScriptDom.SizeFileDeclarationOption();
            ret.Size = (ScriptDom.Literal)size?.ToMutable();
            ret.Units = units;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(size is null)) {
                h = h * 23 + size.GetHashCode();
            }
            h = h * 23 + units.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SizeFileDeclarationOption);
        } 
        
        public bool Equals(SizeFileDeclarationOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Size, size)) {
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
        
        public static bool operator ==(SizeFileDeclarationOption left, SizeFileDeclarationOption right) {
            return EqualityComparer<SizeFileDeclarationOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SizeFileDeclarationOption left, SizeFileDeclarationOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SizeFileDeclarationOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.size, othr.size);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.units, othr.units);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (SizeFileDeclarationOption left, SizeFileDeclarationOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SizeFileDeclarationOption left, SizeFileDeclarationOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SizeFileDeclarationOption left, SizeFileDeclarationOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SizeFileDeclarationOption left, SizeFileDeclarationOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SizeFileDeclarationOption FromMutable(ScriptDom.SizeFileDeclarationOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.SizeFileDeclarationOption)) { throw new NotImplementedException("Unexpected subtype of SizeFileDeclarationOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SizeFileDeclarationOption(
                size: ImmutableDom.Literal.FromMutable(fragment.Size),
                units: fragment.Units,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
