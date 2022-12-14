using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExternalFileFormatUseDefaultTypeOption : ExternalFileFormatOption, IEquatable<ExternalFileFormatUseDefaultTypeOption> {
        protected ScriptDom.ExternalFileFormatUseDefaultType externalFileFormatUseDefaultType = ScriptDom.ExternalFileFormatUseDefaultType.False;
    
        public ScriptDom.ExternalFileFormatUseDefaultType ExternalFileFormatUseDefaultType => externalFileFormatUseDefaultType;
    
        public ExternalFileFormatUseDefaultTypeOption(ScriptDom.ExternalFileFormatUseDefaultType externalFileFormatUseDefaultType = ScriptDom.ExternalFileFormatUseDefaultType.False, ScriptDom.ExternalFileFormatOptionKind optionKind = ScriptDom.ExternalFileFormatOptionKind.SerDeMethod) {
            this.externalFileFormatUseDefaultType = externalFileFormatUseDefaultType;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.ExternalFileFormatUseDefaultTypeOption ToMutableConcrete() {
            var ret = new ScriptDom.ExternalFileFormatUseDefaultTypeOption();
            ret.ExternalFileFormatUseDefaultType = externalFileFormatUseDefaultType;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + externalFileFormatUseDefaultType.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExternalFileFormatUseDefaultTypeOption);
        } 
        
        public bool Equals(ExternalFileFormatUseDefaultTypeOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ExternalFileFormatUseDefaultType>.Default.Equals(other.ExternalFileFormatUseDefaultType, externalFileFormatUseDefaultType)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ExternalFileFormatOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExternalFileFormatUseDefaultTypeOption left, ExternalFileFormatUseDefaultTypeOption right) {
            return EqualityComparer<ExternalFileFormatUseDefaultTypeOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExternalFileFormatUseDefaultTypeOption left, ExternalFileFormatUseDefaultTypeOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ExternalFileFormatUseDefaultTypeOption)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.externalFileFormatUseDefaultType, othr.externalFileFormatUseDefaultType);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static ExternalFileFormatUseDefaultTypeOption FromMutable(ScriptDom.ExternalFileFormatUseDefaultTypeOption fragment) {
            return (ExternalFileFormatUseDefaultTypeOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
