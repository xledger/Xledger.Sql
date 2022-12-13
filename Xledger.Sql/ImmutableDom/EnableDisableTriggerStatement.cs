using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class EnableDisableTriggerStatement : TSqlStatement, IEquatable<EnableDisableTriggerStatement> {
        protected ScriptDom.TriggerEnforcement triggerEnforcement = ScriptDom.TriggerEnforcement.Disable;
        protected bool all = false;
        protected IReadOnlyList<SchemaObjectName> triggerNames;
        protected TriggerObject triggerObject;
    
        public ScriptDom.TriggerEnforcement TriggerEnforcement => triggerEnforcement;
        public bool All => all;
        public IReadOnlyList<SchemaObjectName> TriggerNames => triggerNames;
        public TriggerObject TriggerObject => triggerObject;
    
        public EnableDisableTriggerStatement(ScriptDom.TriggerEnforcement triggerEnforcement = ScriptDom.TriggerEnforcement.Disable, bool all = false, IReadOnlyList<SchemaObjectName> triggerNames = null, TriggerObject triggerObject = null) {
            this.triggerEnforcement = triggerEnforcement;
            this.all = all;
            this.triggerNames = triggerNames is null ? ImmList<SchemaObjectName>.Empty : ImmList<SchemaObjectName>.FromList(triggerNames);
            this.triggerObject = triggerObject;
        }
    
        public ScriptDom.EnableDisableTriggerStatement ToMutableConcrete() {
            var ret = new ScriptDom.EnableDisableTriggerStatement();
            ret.TriggerEnforcement = triggerEnforcement;
            ret.All = all;
            ret.TriggerNames.AddRange(triggerNames.SelectList(c => (ScriptDom.SchemaObjectName)c.ToMutable()));
            ret.TriggerObject = (ScriptDom.TriggerObject)triggerObject.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + triggerEnforcement.GetHashCode();
            h = h * 23 + all.GetHashCode();
            h = h * 23 + triggerNames.GetHashCode();
            if (!(triggerObject is null)) {
                h = h * 23 + triggerObject.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as EnableDisableTriggerStatement);
        } 
        
        public bool Equals(EnableDisableTriggerStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.TriggerEnforcement>.Default.Equals(other.TriggerEnforcement, triggerEnforcement)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.All, all)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<SchemaObjectName>>.Default.Equals(other.TriggerNames, triggerNames)) {
                return false;
            }
            if (!EqualityComparer<TriggerObject>.Default.Equals(other.TriggerObject, triggerObject)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(EnableDisableTriggerStatement left, EnableDisableTriggerStatement right) {
            return EqualityComparer<EnableDisableTriggerStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(EnableDisableTriggerStatement left, EnableDisableTriggerStatement right) {
            return !(left == right);
        }
    
        public static EnableDisableTriggerStatement FromMutable(ScriptDom.EnableDisableTriggerStatement fragment) {
            return (EnableDisableTriggerStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
