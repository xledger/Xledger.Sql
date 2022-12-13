using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
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
    
        public static CharacterSetPayloadOption FromMutable(ScriptDom.CharacterSetPayloadOption fragment) {
            return (CharacterSetPayloadOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
