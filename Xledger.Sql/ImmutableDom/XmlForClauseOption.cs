using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class XmlForClauseOption : ForClause, IEquatable<XmlForClauseOption> {
        protected ScriptDom.XmlForClauseOptions optionKind = ScriptDom.XmlForClauseOptions.None;
        protected Literal @value;
    
        public ScriptDom.XmlForClauseOptions OptionKind => optionKind;
        public Literal Value => @value;
    
        public XmlForClauseOption(ScriptDom.XmlForClauseOptions optionKind = ScriptDom.XmlForClauseOptions.None, Literal @value = null) {
            this.optionKind = optionKind;
            this.@value = @value;
        }
    
        public ScriptDom.XmlForClauseOption ToMutableConcrete() {
            var ret = new ScriptDom.XmlForClauseOption();
            ret.OptionKind = optionKind;
            ret.Value = (ScriptDom.Literal)@value.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionKind.GetHashCode();
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as XmlForClauseOption);
        } 
        
        public bool Equals(XmlForClauseOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.XmlForClauseOptions>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Value, @value)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(XmlForClauseOption left, XmlForClauseOption right) {
            return EqualityComparer<XmlForClauseOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(XmlForClauseOption left, XmlForClauseOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (XmlForClauseOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (XmlForClauseOption left, XmlForClauseOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(XmlForClauseOption left, XmlForClauseOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (XmlForClauseOption left, XmlForClauseOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(XmlForClauseOption left, XmlForClauseOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static XmlForClauseOption FromMutable(ScriptDom.XmlForClauseOption fragment) {
            return (XmlForClauseOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
