using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AddSensitivityClassificationStatement : SensitivityClassificationStatement, IEquatable<AddSensitivityClassificationStatement> {
        protected IReadOnlyList<SensitivityClassificationOption> options;
    
        public IReadOnlyList<SensitivityClassificationOption> Options => options;
    
        public AddSensitivityClassificationStatement(IReadOnlyList<SensitivityClassificationOption> options = null, IReadOnlyList<ColumnReferenceExpression> columns = null) {
            this.options = ImmList<SensitivityClassificationOption>.FromList(options);
            this.columns = ImmList<ColumnReferenceExpression>.FromList(columns);
        }
    
        public ScriptDom.AddSensitivityClassificationStatement ToMutableConcrete() {
            var ret = new ScriptDom.AddSensitivityClassificationStatement();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.SensitivityClassificationOption)c?.ToMutable()));
            ret.Columns.AddRange(columns.SelectList(c => (ScriptDom.ColumnReferenceExpression)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + options.GetHashCode();
            h = h * 23 + columns.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AddSensitivityClassificationStatement);
        } 
        
        public bool Equals(AddSensitivityClassificationStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<SensitivityClassificationOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ColumnReferenceExpression>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AddSensitivityClassificationStatement left, AddSensitivityClassificationStatement right) {
            return EqualityComparer<AddSensitivityClassificationStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AddSensitivityClassificationStatement left, AddSensitivityClassificationStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AddSensitivityClassificationStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.columns, othr.columns);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AddSensitivityClassificationStatement left, AddSensitivityClassificationStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AddSensitivityClassificationStatement left, AddSensitivityClassificationStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AddSensitivityClassificationStatement left, AddSensitivityClassificationStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AddSensitivityClassificationStatement left, AddSensitivityClassificationStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
