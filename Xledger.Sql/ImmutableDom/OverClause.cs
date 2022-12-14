using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OverClause : TSqlFragment, IEquatable<OverClause> {
        protected Identifier windowName;
        protected IReadOnlyList<ScalarExpression> partitions;
        protected OrderByClause orderByClause;
        protected WindowFrameClause windowFrameClause;
    
        public Identifier WindowName => windowName;
        public IReadOnlyList<ScalarExpression> Partitions => partitions;
        public OrderByClause OrderByClause => orderByClause;
        public WindowFrameClause WindowFrameClause => windowFrameClause;
    
        public OverClause(Identifier windowName = null, IReadOnlyList<ScalarExpression> partitions = null, OrderByClause orderByClause = null, WindowFrameClause windowFrameClause = null) {
            this.windowName = windowName;
            this.partitions = ImmList<ScalarExpression>.FromList(partitions);
            this.orderByClause = orderByClause;
            this.windowFrameClause = windowFrameClause;
        }
    
        public ScriptDom.OverClause ToMutableConcrete() {
            var ret = new ScriptDom.OverClause();
            ret.WindowName = (ScriptDom.Identifier)windowName?.ToMutable();
            ret.Partitions.AddRange(partitions.SelectList(c => (ScriptDom.ScalarExpression)c?.ToMutable()));
            ret.OrderByClause = (ScriptDom.OrderByClause)orderByClause?.ToMutable();
            ret.WindowFrameClause = (ScriptDom.WindowFrameClause)windowFrameClause?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(windowName is null)) {
                h = h * 23 + windowName.GetHashCode();
            }
            h = h * 23 + partitions.GetHashCode();
            if (!(orderByClause is null)) {
                h = h * 23 + orderByClause.GetHashCode();
            }
            if (!(windowFrameClause is null)) {
                h = h * 23 + windowFrameClause.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OverClause);
        } 
        
        public bool Equals(OverClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.WindowName, windowName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ScalarExpression>>.Default.Equals(other.Partitions, partitions)) {
                return false;
            }
            if (!EqualityComparer<OrderByClause>.Default.Equals(other.OrderByClause, orderByClause)) {
                return false;
            }
            if (!EqualityComparer<WindowFrameClause>.Default.Equals(other.WindowFrameClause, windowFrameClause)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OverClause left, OverClause right) {
            return EqualityComparer<OverClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OverClause left, OverClause right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OverClause)that;
            compare = Comparer.DefaultInvariant.Compare(this.windowName, othr.windowName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.partitions, othr.partitions);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.orderByClause, othr.orderByClause);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.windowFrameClause, othr.windowFrameClause);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (OverClause left, OverClause right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(OverClause left, OverClause right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (OverClause left, OverClause right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(OverClause left, OverClause right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static OverClause FromMutable(ScriptDom.OverClause fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.OverClause)) { throw new NotImplementedException("Unexpected subtype of OverClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new OverClause(
                windowName: ImmutableDom.Identifier.FromMutable(fragment.WindowName),
                partitions: fragment.Partitions.SelectList(ImmutableDom.ScalarExpression.FromMutable),
                orderByClause: ImmutableDom.OrderByClause.FromMutable(fragment.OrderByClause),
                windowFrameClause: ImmutableDom.WindowFrameClause.FromMutable(fragment.WindowFrameClause)
            );
        }
    
    }

}
