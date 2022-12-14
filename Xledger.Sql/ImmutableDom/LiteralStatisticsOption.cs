using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LiteralStatisticsOption : StatisticsOption, IEquatable<LiteralStatisticsOption> {
        protected Literal literal;
    
        public Literal Literal => literal;
    
        public LiteralStatisticsOption(Literal literal = null, ScriptDom.StatisticsOptionKind optionKind = ScriptDom.StatisticsOptionKind.FullScan) {
            this.literal = literal;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.LiteralStatisticsOption ToMutableConcrete() {
            var ret = new ScriptDom.LiteralStatisticsOption();
            ret.Literal = (ScriptDom.Literal)literal.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(literal is null)) {
                h = h * 23 + literal.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as LiteralStatisticsOption);
        } 
        
        public bool Equals(LiteralStatisticsOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Literal, literal)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.StatisticsOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LiteralStatisticsOption left, LiteralStatisticsOption right) {
            return EqualityComparer<LiteralStatisticsOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LiteralStatisticsOption left, LiteralStatisticsOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (LiteralStatisticsOption)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.literal, othr.literal);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static LiteralStatisticsOption FromMutable(ScriptDom.LiteralStatisticsOption fragment) {
            return (LiteralStatisticsOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
