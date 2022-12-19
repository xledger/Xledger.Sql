using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class QueueProcedureOption : QueueOption, IEquatable<QueueProcedureOption> {
        protected SchemaObjectName optionValue;
    
        public SchemaObjectName OptionValue => optionValue;
    
        public QueueProcedureOption(SchemaObjectName optionValue = null, ScriptDom.QueueOptionKind optionKind = ScriptDom.QueueOptionKind.Status) {
            this.optionValue = optionValue;
            this.optionKind = optionKind;
        }
    
        public new ScriptDom.QueueProcedureOption ToMutableConcrete() {
            var ret = new ScriptDom.QueueProcedureOption();
            ret.OptionValue = (ScriptDom.SchemaObjectName)optionValue?.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(optionValue is null)) {
                h = h * 23 + optionValue.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as QueueProcedureOption);
        } 
        
        public bool Equals(QueueProcedureOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.OptionValue, optionValue)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.QueueOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(QueueProcedureOption left, QueueProcedureOption right) {
            return EqualityComparer<QueueProcedureOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(QueueProcedureOption left, QueueProcedureOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (QueueProcedureOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.optionValue, othr.optionValue);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (QueueProcedureOption left, QueueProcedureOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(QueueProcedureOption left, QueueProcedureOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (QueueProcedureOption left, QueueProcedureOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(QueueProcedureOption left, QueueProcedureOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static QueueProcedureOption FromMutable(ScriptDom.QueueProcedureOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.QueueProcedureOption)) { throw new NotImplementedException("Unexpected subtype of QueueProcedureOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new QueueProcedureOption(
                optionValue: ImmutableDom.SchemaObjectName.FromMutable(fragment.OptionValue),
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
