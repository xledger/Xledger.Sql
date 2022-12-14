using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LiteralBulkInsertOption : BulkInsertOption, IEquatable<LiteralBulkInsertOption> {
        protected Literal @value;
    
        public Literal Value => @value;
    
        public LiteralBulkInsertOption(Literal @value = null, ScriptDom.BulkInsertOptionKind optionKind = ScriptDom.BulkInsertOptionKind.None) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.LiteralBulkInsertOption ToMutableConcrete() {
            var ret = new ScriptDom.LiteralBulkInsertOption();
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
            return Equals(obj as LiteralBulkInsertOption);
        } 
        
        public bool Equals(LiteralBulkInsertOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.BulkInsertOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LiteralBulkInsertOption left, LiteralBulkInsertOption right) {
            return EqualityComparer<LiteralBulkInsertOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LiteralBulkInsertOption left, LiteralBulkInsertOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (LiteralBulkInsertOption)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static LiteralBulkInsertOption FromMutable(ScriptDom.LiteralBulkInsertOption fragment) {
            return (LiteralBulkInsertOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
