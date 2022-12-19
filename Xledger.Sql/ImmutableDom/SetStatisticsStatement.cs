using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SetStatisticsStatement : SetOnOffStatement, IEquatable<SetStatisticsStatement> {
        protected ScriptDom.SetStatisticsOptions options = ScriptDom.SetStatisticsOptions.None;
    
        public ScriptDom.SetStatisticsOptions Options => options;
    
        public SetStatisticsStatement(ScriptDom.SetStatisticsOptions options = ScriptDom.SetStatisticsOptions.None, bool isOn = false) {
            this.options = options;
            this.isOn = isOn;
        }
    
        public ScriptDom.SetStatisticsStatement ToMutableConcrete() {
            var ret = new ScriptDom.SetStatisticsStatement();
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
            return Equals(obj as SetStatisticsStatement);
        } 
        
        public bool Equals(SetStatisticsStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.SetStatisticsOptions>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsOn, isOn)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SetStatisticsStatement left, SetStatisticsStatement right) {
            return EqualityComparer<SetStatisticsStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SetStatisticsStatement left, SetStatisticsStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SetStatisticsStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isOn, othr.isOn);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (SetStatisticsStatement left, SetStatisticsStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SetStatisticsStatement left, SetStatisticsStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SetStatisticsStatement left, SetStatisticsStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SetStatisticsStatement left, SetStatisticsStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SetStatisticsStatement FromMutable(ScriptDom.SetStatisticsStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.SetStatisticsStatement)) { throw new NotImplementedException("Unexpected subtype of SetStatisticsStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SetStatisticsStatement(
                options: fragment.Options,
                isOn: fragment.IsOn
            );
        }
    
    }

}
