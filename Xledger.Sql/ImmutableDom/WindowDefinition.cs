using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class WindowDefinition : TSqlFragment, IEquatable<WindowDefinition> {
        Identifier windowName;
        Identifier refWindowName;
        IReadOnlyList<ScalarExpression> partitions;
        OrderByClause orderByClause;
        WindowFrameClause windowFrameClause;
    
        public Identifier WindowName => windowName;
        public Identifier RefWindowName => refWindowName;
        public IReadOnlyList<ScalarExpression> Partitions => partitions;
        public OrderByClause OrderByClause => orderByClause;
        public WindowFrameClause WindowFrameClause => windowFrameClause;
    
        public WindowDefinition(Identifier windowName = null, Identifier refWindowName = null, IReadOnlyList<ScalarExpression> partitions = null, OrderByClause orderByClause = null, WindowFrameClause windowFrameClause = null) {
            this.windowName = windowName;
            this.refWindowName = refWindowName;
            this.partitions = partitions is null ? ImmList<ScalarExpression>.Empty : ImmList<ScalarExpression>.FromList(partitions);
            this.orderByClause = orderByClause;
            this.windowFrameClause = windowFrameClause;
        }
    
        public ScriptDom.WindowDefinition ToMutableConcrete() {
            var ret = new ScriptDom.WindowDefinition();
            ret.WindowName = (ScriptDom.Identifier)windowName.ToMutable();
            ret.RefWindowName = (ScriptDom.Identifier)refWindowName.ToMutable();
            ret.Partitions.AddRange(partitions.Select(c => (ScriptDom.ScalarExpression)c.ToMutable()));
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
            if (!(refWindowName is null)) {
                h = h * 23 + refWindowName.GetHashCode();
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
            return Equals(obj as WindowDefinition);
        } 
        
        public bool Equals(WindowDefinition other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.WindowName, windowName)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.RefWindowName, refWindowName)) {
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
        
        public static bool operator ==(WindowDefinition left, WindowDefinition right) {
            return EqualityComparer<WindowDefinition>.Default.Equals(left, right);
        }
        
        public static bool operator !=(WindowDefinition left, WindowDefinition right) {
            return !(left == right);
        }
    
    }

}
