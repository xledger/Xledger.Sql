using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class RegexpLikePredicate : BooleanExpression, IEquatable<RegexpLikePredicate> {
        protected ScalarExpression text;
        protected ScalarExpression pattern;
        protected ScalarExpression flags;
    
        public ScalarExpression Text => text;
        public ScalarExpression Pattern => pattern;
        public ScalarExpression Flags => flags;
    
        public RegexpLikePredicate(ScalarExpression text = null, ScalarExpression pattern = null, ScalarExpression flags = null) {
            this.text = text;
            this.pattern = pattern;
            this.flags = flags;
        }
    
        public ScriptDom.RegexpLikePredicate ToMutableConcrete() {
            var ret = new ScriptDom.RegexpLikePredicate();
            ret.Text = (ScriptDom.ScalarExpression)text?.ToMutable();
            ret.Pattern = (ScriptDom.ScalarExpression)pattern?.ToMutable();
            ret.Flags = (ScriptDom.ScalarExpression)flags?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(text is null)) {
                h = h * 23 + text.GetHashCode();
            }
            if (!(pattern is null)) {
                h = h * 23 + pattern.GetHashCode();
            }
            if (!(flags is null)) {
                h = h * 23 + flags.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as RegexpLikePredicate);
        } 
        
        public bool Equals(RegexpLikePredicate other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Text, text)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Pattern, pattern)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Flags, flags)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(RegexpLikePredicate left, RegexpLikePredicate right) {
            return EqualityComparer<RegexpLikePredicate>.Default.Equals(left, right);
        }
        
        public static bool operator !=(RegexpLikePredicate left, RegexpLikePredicate right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (RegexpLikePredicate)that;
            compare = Comparer.DefaultInvariant.Compare(this.text, othr.text);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.pattern, othr.pattern);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.flags, othr.flags);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (RegexpLikePredicate left, RegexpLikePredicate right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(RegexpLikePredicate left, RegexpLikePredicate right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (RegexpLikePredicate left, RegexpLikePredicate right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(RegexpLikePredicate left, RegexpLikePredicate right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static RegexpLikePredicate FromMutable(ScriptDom.RegexpLikePredicate fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.RegexpLikePredicate)) { throw new NotImplementedException("Unexpected subtype of RegexpLikePredicate not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RegexpLikePredicate(
                text: ImmutableDom.ScalarExpression.FromMutable(fragment.Text),
                pattern: ImmutableDom.ScalarExpression.FromMutable(fragment.Pattern),
                flags: ImmutableDom.ScalarExpression.FromMutable(fragment.Flags)
            );
        }
    
    }

}
