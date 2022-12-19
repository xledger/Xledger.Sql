using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LabelStatement : TSqlStatement, IEquatable<LabelStatement> {
        protected string @value;
    
        public string Value => @value;
    
        public LabelStatement(string @value = null) {
            this.@value = @value;
        }
    
        public ScriptDom.LabelStatement ToMutableConcrete() {
            var ret = new ScriptDom.LabelStatement();
            ret.Value = @value;
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
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as LabelStatement);
        } 
        
        public bool Equals(LabelStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<string>.Default.Equals(other.Value, @value)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LabelStatement left, LabelStatement right) {
            return EqualityComparer<LabelStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LabelStatement left, LabelStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (LabelStatement)that;
            compare = CaseInsensitiveComparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (LabelStatement left, LabelStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(LabelStatement left, LabelStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (LabelStatement left, LabelStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(LabelStatement left, LabelStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static LabelStatement FromMutable(ScriptDom.LabelStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.LabelStatement)) { throw new NotImplementedException("Unexpected subtype of LabelStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new LabelStatement(
                @value: fragment.Value
            );
        }
    
    }

}
