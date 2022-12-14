using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ContractMessage : TSqlFragment, IEquatable<ContractMessage> {
        protected Identifier name;
        protected ScriptDom.MessageSender sentBy = ScriptDom.MessageSender.None;
    
        public Identifier Name => name;
        public ScriptDom.MessageSender SentBy => sentBy;
    
        public ContractMessage(Identifier name = null, ScriptDom.MessageSender sentBy = ScriptDom.MessageSender.None) {
            this.name = name;
            this.sentBy = sentBy;
        }
    
        public ScriptDom.ContractMessage ToMutableConcrete() {
            var ret = new ScriptDom.ContractMessage();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.SentBy = sentBy;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + sentBy.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ContractMessage);
        } 
        
        public bool Equals(ContractMessage other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.MessageSender>.Default.Equals(other.SentBy, sentBy)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ContractMessage left, ContractMessage right) {
            return EqualityComparer<ContractMessage>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ContractMessage left, ContractMessage right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ContractMessage)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.sentBy, othr.sentBy);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ContractMessage left, ContractMessage right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ContractMessage left, ContractMessage right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ContractMessage left, ContractMessage right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ContractMessage left, ContractMessage right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ContractMessage FromMutable(ScriptDom.ContractMessage fragment) {
            return (ContractMessage)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
