using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class KeySourceKeyOption : KeyOption, IEquatable<KeySourceKeyOption> {
        protected Literal passPhrase;
    
        public Literal PassPhrase => passPhrase;
    
        public KeySourceKeyOption(Literal passPhrase = null, ScriptDom.KeyOptionKind optionKind = ScriptDom.KeyOptionKind.KeySource) {
            this.passPhrase = passPhrase;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.KeySourceKeyOption ToMutableConcrete() {
            var ret = new ScriptDom.KeySourceKeyOption();
            ret.PassPhrase = (ScriptDom.Literal)passPhrase.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(passPhrase is null)) {
                h = h * 23 + passPhrase.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as KeySourceKeyOption);
        } 
        
        public bool Equals(KeySourceKeyOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.PassPhrase, passPhrase)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.KeyOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(KeySourceKeyOption left, KeySourceKeyOption right) {
            return EqualityComparer<KeySourceKeyOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(KeySourceKeyOption left, KeySourceKeyOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (KeySourceKeyOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.passPhrase, othr.passPhrase);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (KeySourceKeyOption left, KeySourceKeyOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(KeySourceKeyOption left, KeySourceKeyOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (KeySourceKeyOption left, KeySourceKeyOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(KeySourceKeyOption left, KeySourceKeyOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static KeySourceKeyOption FromMutable(ScriptDom.KeySourceKeyOption fragment) {
            return (KeySourceKeyOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
