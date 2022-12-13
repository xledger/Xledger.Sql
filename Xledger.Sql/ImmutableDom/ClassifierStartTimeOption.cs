using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ClassifierStartTimeOption : WorkloadClassifierOption, IEquatable<ClassifierStartTimeOption> {
        protected WlmTimeLiteral time;
    
        public WlmTimeLiteral Time => time;
    
        public ClassifierStartTimeOption(WlmTimeLiteral time = null, ScriptDom.WorkloadClassifierOptionType optionType = ScriptDom.WorkloadClassifierOptionType.WorkloadGroup) {
            this.time = time;
            this.optionType = optionType;
        }
    
        public ScriptDom.ClassifierStartTimeOption ToMutableConcrete() {
            var ret = new ScriptDom.ClassifierStartTimeOption();
            ret.Time = (ScriptDom.WlmTimeLiteral)time.ToMutable();
            ret.OptionType = optionType;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(time is null)) {
                h = h * 23 + time.GetHashCode();
            }
            h = h * 23 + optionType.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ClassifierStartTimeOption);
        } 
        
        public bool Equals(ClassifierStartTimeOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<WlmTimeLiteral>.Default.Equals(other.Time, time)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.WorkloadClassifierOptionType>.Default.Equals(other.OptionType, optionType)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ClassifierStartTimeOption left, ClassifierStartTimeOption right) {
            return EqualityComparer<ClassifierStartTimeOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ClassifierStartTimeOption left, ClassifierStartTimeOption right) {
            return !(left == right);
        }
    
        public static ClassifierStartTimeOption FromMutable(ScriptDom.ClassifierStartTimeOption fragment) {
            return (ClassifierStartTimeOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
