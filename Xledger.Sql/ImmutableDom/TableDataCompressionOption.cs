using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TableDataCompressionOption : TableOption, IEquatable<TableDataCompressionOption> {
        protected DataCompressionOption dataCompressionOption;
    
        public DataCompressionOption DataCompressionOption => dataCompressionOption;
    
        public TableDataCompressionOption(DataCompressionOption dataCompressionOption = null, ScriptDom.TableOptionKind optionKind = ScriptDom.TableOptionKind.LockEscalation) {
            this.dataCompressionOption = dataCompressionOption;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.TableDataCompressionOption ToMutableConcrete() {
            var ret = new ScriptDom.TableDataCompressionOption();
            ret.DataCompressionOption = (ScriptDom.DataCompressionOption)dataCompressionOption?.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(dataCompressionOption is null)) {
                h = h * 23 + dataCompressionOption.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TableDataCompressionOption);
        } 
        
        public bool Equals(TableDataCompressionOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<DataCompressionOption>.Default.Equals(other.DataCompressionOption, dataCompressionOption)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TableOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TableDataCompressionOption left, TableDataCompressionOption right) {
            return EqualityComparer<TableDataCompressionOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TableDataCompressionOption left, TableDataCompressionOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (TableDataCompressionOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.dataCompressionOption, othr.dataCompressionOption);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (TableDataCompressionOption left, TableDataCompressionOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(TableDataCompressionOption left, TableDataCompressionOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (TableDataCompressionOption left, TableDataCompressionOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(TableDataCompressionOption left, TableDataCompressionOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
