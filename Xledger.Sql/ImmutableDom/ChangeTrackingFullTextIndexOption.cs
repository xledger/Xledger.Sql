using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ChangeTrackingFullTextIndexOption : FullTextIndexOption, IEquatable<ChangeTrackingFullTextIndexOption> {
        protected ScriptDom.ChangeTrackingOption @value = ScriptDom.ChangeTrackingOption.NotSpecified;
    
        public ScriptDom.ChangeTrackingOption Value => @value;
    
        public ChangeTrackingFullTextIndexOption(ScriptDom.ChangeTrackingOption @value = ScriptDom.ChangeTrackingOption.NotSpecified, ScriptDom.FullTextIndexOptionKind optionKind = ScriptDom.FullTextIndexOptionKind.ChangeTracking) {
            this.@value = @value;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.ChangeTrackingFullTextIndexOption ToMutableConcrete() {
            var ret = new ScriptDom.ChangeTrackingFullTextIndexOption();
            ret.Value = @value;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + @value.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ChangeTrackingFullTextIndexOption);
        } 
        
        public bool Equals(ChangeTrackingFullTextIndexOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ChangeTrackingOption>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.FullTextIndexOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ChangeTrackingFullTextIndexOption left, ChangeTrackingFullTextIndexOption right) {
            return EqualityComparer<ChangeTrackingFullTextIndexOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ChangeTrackingFullTextIndexOption left, ChangeTrackingFullTextIndexOption right) {
            return !(left == right);
        }
    
    }

}
