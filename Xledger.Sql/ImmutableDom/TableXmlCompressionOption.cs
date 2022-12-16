using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TableXmlCompressionOption : TableOption, IEquatable<TableXmlCompressionOption> {
        protected XmlCompressionOption xmlCompressionOption;
    
        public XmlCompressionOption XmlCompressionOption => xmlCompressionOption;
    
        public TableXmlCompressionOption(XmlCompressionOption xmlCompressionOption = null, ScriptDom.TableOptionKind optionKind = ScriptDom.TableOptionKind.LockEscalation) {
            this.xmlCompressionOption = xmlCompressionOption;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.TableXmlCompressionOption ToMutableConcrete() {
            var ret = new ScriptDom.TableXmlCompressionOption();
            ret.XmlCompressionOption = (ScriptDom.XmlCompressionOption)xmlCompressionOption?.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(xmlCompressionOption is null)) {
                h = h * 23 + xmlCompressionOption.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TableXmlCompressionOption);
        } 
        
        public bool Equals(TableXmlCompressionOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<XmlCompressionOption>.Default.Equals(other.XmlCompressionOption, xmlCompressionOption)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TableOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TableXmlCompressionOption left, TableXmlCompressionOption right) {
            return EqualityComparer<TableXmlCompressionOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TableXmlCompressionOption left, TableXmlCompressionOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (TableXmlCompressionOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.xmlCompressionOption, othr.xmlCompressionOption);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (TableXmlCompressionOption left, TableXmlCompressionOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(TableXmlCompressionOption left, TableXmlCompressionOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (TableXmlCompressionOption left, TableXmlCompressionOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(TableXmlCompressionOption left, TableXmlCompressionOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
