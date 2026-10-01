using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ClusterByTableOption : TableOption, IEquatable<ClusterByTableOption> {
        protected IReadOnlyList<ColumnReferenceExpression> columns;
    
        public IReadOnlyList<ColumnReferenceExpression> Columns => columns;
    
        public ClusterByTableOption(IReadOnlyList<ColumnReferenceExpression> columns = null, ScriptDom.TableOptionKind optionKind = ScriptDom.TableOptionKind.LockEscalation) {
            this.columns = columns.ToImmArray<ColumnReferenceExpression>();
            this.optionKind = optionKind;
        }
    
        public ScriptDom.ClusterByTableOption ToMutableConcrete() {
            var ret = new ScriptDom.ClusterByTableOption();
            ret.Columns.AddRange(columns.Select(c => (ScriptDom.ColumnReferenceExpression)c?.ToMutable()));
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + columns.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ClusterByTableOption);
        } 
        
        public bool Equals(ClusterByTableOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<ColumnReferenceExpression>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TableOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ClusterByTableOption left, ClusterByTableOption right) {
            return EqualityComparer<ClusterByTableOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ClusterByTableOption left, ClusterByTableOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ClusterByTableOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.columns, othr.columns);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ClusterByTableOption left, ClusterByTableOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ClusterByTableOption left, ClusterByTableOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ClusterByTableOption left, ClusterByTableOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ClusterByTableOption left, ClusterByTableOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ClusterByTableOption FromMutable(ScriptDom.ClusterByTableOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ClusterByTableOption)) { throw new NotImplementedException("Unexpected subtype of ClusterByTableOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ClusterByTableOption(
                columns: fragment.Columns.ToImmArray(ImmutableDom.ColumnReferenceExpression.FromMutable),
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
