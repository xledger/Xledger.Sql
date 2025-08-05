using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CharacterSetPayloadOption : PayloadOption, IEquatable<CharacterSetPayloadOption> {
        protected bool isSql = false;
    
        public bool IsSql => isSql;
    
        public CharacterSetPayloadOption(bool isSql = false, ScriptDom.PayloadOptionKinds kind = ScriptDom.PayloadOptionKinds.None) {
            this.isSql = isSql;
            this.kind = kind;
        }
    
        public ScriptDom.CharacterSetPayloadOption ToMutableConcrete() {
            var ret = new ScriptDom.CharacterSetPayloadOption();
            ret.IsSql = isSql;
            ret.Kind = kind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isSql.GetHashCode();
            h = h * 23 + kind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CharacterSetPayloadOption);
        } 
        
        public bool Equals(CharacterSetPayloadOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsSql, isSql)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.PayloadOptionKinds>.Default.Equals(other.Kind, kind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CharacterSetPayloadOption left, CharacterSetPayloadOption right) {
            return EqualityComparer<CharacterSetPayloadOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CharacterSetPayloadOption left, CharacterSetPayloadOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CharacterSetPayloadOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.isSql, othr.isSql);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.kind, othr.kind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CharacterSetPayloadOption left, CharacterSetPayloadOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CharacterSetPayloadOption left, CharacterSetPayloadOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CharacterSetPayloadOption left, CharacterSetPayloadOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CharacterSetPayloadOption left, CharacterSetPayloadOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CharacterSetPayloadOption FromMutable(ScriptDom.CharacterSetPayloadOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CharacterSetPayloadOption)) { throw new NotImplementedException("Unexpected subtype of CharacterSetPayloadOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CharacterSetPayloadOption(
                isSql: fragment.IsSql,
                kind: fragment.Kind
            );
        }
    
    }

}
