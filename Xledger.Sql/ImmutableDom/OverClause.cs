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
            this.partitions = partitions is null ? ImmList<ScalarExpression>.Empty : ImmList<ScalarExpression>.FromList(partitions);
            this.orderByClause = orderByClause;
            this.windowFrameClause = windowFrameClause;
        }
    
        public ScriptDom.OverClause ToMutableConcrete() {
            var ret = new ScriptDom.OverClause();
            ret.WindowName = (ScriptDom.Identifier)windowName.ToMutable();
            ret.Partitions.AddRange(partitions.SelectList(c => (ScriptDom.ScalarExpression)c.ToMutable()));
            ret.OrderByClause = (ScriptDom.OrderByClause)orderByClause.ToMutable();
            ret.WindowFrameClause = (ScriptDom.WindowFrameClause)windowFrameClause.ToMutable();
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
    
        public static OverClause FromMutable(ScriptDom.OverClause fragment) {
            return (OverClause)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
