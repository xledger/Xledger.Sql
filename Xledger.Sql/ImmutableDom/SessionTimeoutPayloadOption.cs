using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SessionTimeoutPayloadOption : PayloadOption, IEquatable<SessionTimeoutPayloadOption> {
        bool isNever = false;
        Literal timeout;
    
        public bool IsNever => isNever;
        public Literal Timeout => timeout;
    
        public SessionTimeoutPayloadOption(bool isNever = false, Literal timeout = null, ScriptDom.PayloadOptionKinds kind = ScriptDom.PayloadOptionKinds.None) {
            this.isNever = isNever;
            this.timeout = timeout;
            this.kind = kind;
        }
    
        public ScriptDom.SessionTimeoutPayloadOption ToMutableConcrete() {
            var ret = new ScriptDom.SessionTimeoutPayloadOption();
            ret.IsNever = isNever;
            ret.Timeout = (ScriptDom.Literal)timeout.ToMutable();
            ret.Kind = kind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isNever.GetHashCode();
            if (!(timeout is null)) {
                h = h * 23 + timeout.GetHashCode();
            }
            h = h * 23 + kind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SessionTimeoutPayloadOption);
        } 
        
        public bool Equals(SessionTimeoutPayloadOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsNever, isNever)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Timeout, timeout)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.PayloadOptionKinds>.Default.Equals(other.Kind, kind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SessionTimeoutPayloadOption left, SessionTimeoutPayloadOption right) {
            return EqualityComparer<SessionTimeoutPayloadOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SessionTimeoutPayloadOption left, SessionTimeoutPayloadOption right) {
            return !(left == right);
        }
    
    }

}