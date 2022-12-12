using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ClassifierImportanceOption : WorkloadClassifierOption, IEquatable<ClassifierImportanceOption> {
        ScriptDom.ImportanceParameterType importance = ScriptDom.ImportanceParameterType.Unknown;
    
        public ScriptDom.ImportanceParameterType Importance => importance;
    
        public ClassifierImportanceOption(ScriptDom.ImportanceParameterType importance = ScriptDom.ImportanceParameterType.Unknown, ScriptDom.WorkloadClassifierOptionType optionType = ScriptDom.WorkloadClassifierOptionType.WorkloadGroup) {
            this.importance = importance;
            this.optionType = optionType;
        }
    
        public ScriptDom.ClassifierImportanceOption ToMutableConcrete() {
            var ret = new ScriptDom.ClassifierImportanceOption();
            ret.Importance = importance;
            ret.OptionType = optionType;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + importance.GetHashCode();
            h = h * 23 + optionType.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ClassifierImportanceOption);
        } 
        
        public bool Equals(ClassifierImportanceOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ImportanceParameterType>.Default.Equals(other.Importance, importance)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.WorkloadClassifierOptionType>.Default.Equals(other.OptionType, optionType)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ClassifierImportanceOption left, ClassifierImportanceOption right) {
            return EqualityComparer<ClassifierImportanceOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ClassifierImportanceOption left, ClassifierImportanceOption right) {
            return !(left == right);
        }
    
    }

}
