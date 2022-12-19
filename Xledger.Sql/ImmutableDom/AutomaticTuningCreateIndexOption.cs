using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AutomaticTuningCreateIndexOption : AutomaticTuningOption, IEquatable<AutomaticTuningCreateIndexOption> {
        public AutomaticTuningCreateIndexOption(ScriptDom.AutomaticTuningOptionKind optionKind = ScriptDom.AutomaticTuningOptionKind.Force_Last_Good_Plan, ScriptDom.AutomaticTuningOptionState @value = ScriptDom.AutomaticTuningOptionState.Off) {
            this.optionKind = optionKind;
            this.@value = @value;
        }
    
        public new ScriptDom.AutomaticTuningCreateIndexOption ToMutableConcrete() {
            var ret = new ScriptDom.AutomaticTuningCreateIndexOption();
            ret.OptionKind = optionKind;
            ret.Value = @value;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + optionKind.GetHashCode();
            h = h * 23 + @value.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AutomaticTuningCreateIndexOption);
        } 
        
        public bool Equals(AutomaticTuningCreateIndexOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.AutomaticTuningOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AutomaticTuningOptionState>.Default.Equals(other.Value, @value)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AutomaticTuningCreateIndexOption left, AutomaticTuningCreateIndexOption right) {
            return EqualityComparer<AutomaticTuningCreateIndexOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AutomaticTuningCreateIndexOption left, AutomaticTuningCreateIndexOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AutomaticTuningCreateIndexOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AutomaticTuningCreateIndexOption left, AutomaticTuningCreateIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AutomaticTuningCreateIndexOption left, AutomaticTuningCreateIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AutomaticTuningCreateIndexOption left, AutomaticTuningCreateIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AutomaticTuningCreateIndexOption left, AutomaticTuningCreateIndexOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AutomaticTuningCreateIndexOption FromMutable(ScriptDom.AutomaticTuningCreateIndexOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AutomaticTuningCreateIndexOption)) { throw new NotImplementedException("Unexpected subtype of AutomaticTuningCreateIndexOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AutomaticTuningCreateIndexOption(
                optionKind: fragment.OptionKind,
                @value: fragment.Value
            );
        }
    
    }

}
