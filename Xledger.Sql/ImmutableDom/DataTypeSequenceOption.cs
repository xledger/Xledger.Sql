using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DataTypeSequenceOption : SequenceOption, IEquatable<DataTypeSequenceOption> {
        protected DataTypeReference dataType;
    
        public DataTypeReference DataType => dataType;
    
        public DataTypeSequenceOption(DataTypeReference dataType = null, ScriptDom.SequenceOptionKind optionKind = ScriptDom.SequenceOptionKind.As, bool noValue = false) {
            this.dataType = dataType;
            this.optionKind = optionKind;
            this.noValue = noValue;
        }
    
        public ScriptDom.DataTypeSequenceOption ToMutableConcrete() {
            var ret = new ScriptDom.DataTypeSequenceOption();
            ret.DataType = (ScriptDom.DataTypeReference)dataType.ToMutable();
            ret.OptionKind = optionKind;
            ret.NoValue = noValue;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(dataType is null)) {
                h = h * 23 + dataType.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            h = h * 23 + noValue.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DataTypeSequenceOption);
        } 
        
        public bool Equals(DataTypeSequenceOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<DataTypeReference>.Default.Equals(other.DataType, dataType)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.SequenceOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.NoValue, noValue)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DataTypeSequenceOption left, DataTypeSequenceOption right) {
            return EqualityComparer<DataTypeSequenceOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DataTypeSequenceOption left, DataTypeSequenceOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DataTypeSequenceOption)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.dataType, othr.dataType);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.noValue, othr.noValue);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static DataTypeSequenceOption FromMutable(ScriptDom.DataTypeSequenceOption fragment) {
            return (DataTypeSequenceOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
