using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class PredicateSetStatement : SetOnOffStatement, IEquatable<PredicateSetStatement> {
        ScriptDom.SetOptions options = ScriptDom.SetOptions.None;
    
        public ScriptDom.SetOptions Options => options;
    
        public PredicateSetStatement(ScriptDom.SetOptions options = ScriptDom.SetOptions.None, bool isOn = false) {
            this.options = options;
            this.isOn = isOn;
        }
    
        public ScriptDom.PredicateSetStatement ToMutableConcrete() {
            var ret = new ScriptDom.PredicateSetStatement();
            ret.Options = options;
            ret.IsOn = isOn;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + options.GetHashCode();
            h = h * 23 + isOn.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as PredicateSetStatement);
        } 
        
        public bool Equals(PredicateSetStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.SetOptions>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsOn, isOn)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(PredicateSetStatement left, PredicateSetStatement right) {
            return EqualityComparer<PredicateSetStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(PredicateSetStatement left, PredicateSetStatement right) {
            return !(left == right);
        }
    
    }

}
