using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class QueueDelayAuditOption : AuditOption, IEquatable<QueueDelayAuditOption> {
        Literal delay;
    
        public Literal Delay => delay;
    
        public QueueDelayAuditOption(Literal delay = null, ScriptDom.AuditOptionKind optionKind = ScriptDom.AuditOptionKind.QueueDelay) {
            this.delay = delay;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.QueueDelayAuditOption ToMutableConcrete() {
            var ret = new ScriptDom.QueueDelayAuditOption();
            ret.Delay = (ScriptDom.Literal)delay.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(delay is null)) {
                h = h * 23 + delay.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as QueueDelayAuditOption);
        } 
        
        public bool Equals(QueueDelayAuditOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Delay, delay)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AuditOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(QueueDelayAuditOption left, QueueDelayAuditOption right) {
            return EqualityComparer<QueueDelayAuditOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(QueueDelayAuditOption left, QueueDelayAuditOption right) {
            return !(left == right);
        }
    
    }

}