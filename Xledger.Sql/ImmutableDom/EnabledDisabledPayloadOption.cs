using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class EnabledDisabledPayloadOption : PayloadOption, IEquatable<EnabledDisabledPayloadOption> {
        protected bool isEnabled = false;
    
        public bool IsEnabled => isEnabled;
    
        public EnabledDisabledPayloadOption(bool isEnabled = false, ScriptDom.PayloadOptionKinds kind = ScriptDom.PayloadOptionKinds.None) {
            this.isEnabled = isEnabled;
            this.kind = kind;
        }
    
        public ScriptDom.EnabledDisabledPayloadOption ToMutableConcrete() {
            var ret = new ScriptDom.EnabledDisabledPayloadOption();
            ret.IsEnabled = isEnabled;
            ret.Kind = kind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isEnabled.GetHashCode();
            h = h * 23 + kind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as EnabledDisabledPayloadOption);
        } 
        
        public bool Equals(EnabledDisabledPayloadOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsEnabled, isEnabled)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.PayloadOptionKinds>.Default.Equals(other.Kind, kind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(EnabledDisabledPayloadOption left, EnabledDisabledPayloadOption right) {
            return EqualityComparer<EnabledDisabledPayloadOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(EnabledDisabledPayloadOption left, EnabledDisabledPayloadOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (EnabledDisabledPayloadOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.isEnabled, othr.isEnabled);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.kind, othr.kind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (EnabledDisabledPayloadOption left, EnabledDisabledPayloadOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(EnabledDisabledPayloadOption left, EnabledDisabledPayloadOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (EnabledDisabledPayloadOption left, EnabledDisabledPayloadOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(EnabledDisabledPayloadOption left, EnabledDisabledPayloadOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
