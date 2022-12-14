using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ListTypeCopyOption : CopyStatementOptionBase, IEquatable<ListTypeCopyOption> {
        protected IReadOnlyList<CopyStatementOptionBase> options;
    
        public IReadOnlyList<CopyStatementOptionBase> Options => options;
    
        public ListTypeCopyOption(IReadOnlyList<CopyStatementOptionBase> options = null) {
            this.options = ImmList<CopyStatementOptionBase>.FromList(options);
        }
    
        public ScriptDom.ListTypeCopyOption ToMutableConcrete() {
            var ret = new ScriptDom.ListTypeCopyOption();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.CopyStatementOptionBase)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + options.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ListTypeCopyOption);
        } 
        
        public bool Equals(ListTypeCopyOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<CopyStatementOptionBase>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ListTypeCopyOption left, ListTypeCopyOption right) {
            return EqualityComparer<ListTypeCopyOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ListTypeCopyOption left, ListTypeCopyOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ListTypeCopyOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ListTypeCopyOption left, ListTypeCopyOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ListTypeCopyOption left, ListTypeCopyOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ListTypeCopyOption left, ListTypeCopyOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ListTypeCopyOption left, ListTypeCopyOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ListTypeCopyOption FromMutable(ScriptDom.ListTypeCopyOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ListTypeCopyOption)) { throw new NotImplementedException("Unexpected subtype of ListTypeCopyOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ListTypeCopyOption(
                options: fragment.Options.SelectList(ImmutableDom.CopyStatementOptionBase.FromMutable)
            );
        }
    
    }

}
