using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SetOffsetsStatement : SetOnOffStatement, IEquatable<SetOffsetsStatement> {
        protected ScriptDom.SetOffsets options = ScriptDom.SetOffsets.None;
    
        public ScriptDom.SetOffsets Options => options;
    
        public SetOffsetsStatement(ScriptDom.SetOffsets options = ScriptDom.SetOffsets.None, bool isOn = false) {
            this.options = options;
            this.isOn = isOn;
        }
    
        public ScriptDom.SetOffsetsStatement ToMutableConcrete() {
            var ret = new ScriptDom.SetOffsetsStatement();
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
            return Equals(obj as SetOffsetsStatement);
        } 
        
        public bool Equals(SetOffsetsStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.SetOffsets>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsOn, isOn)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SetOffsetsStatement left, SetOffsetsStatement right) {
            return EqualityComparer<SetOffsetsStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SetOffsetsStatement left, SetOffsetsStatement right) {
            return !(left == right);
        }
    
        public static SetOffsetsStatement FromMutable(ScriptDom.SetOffsetsStatement fragment) {
            return (SetOffsetsStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
