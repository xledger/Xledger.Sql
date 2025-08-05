using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class WindowFrameClause : TSqlFragment, IEquatable<WindowFrameClause> {
        protected WindowDelimiter top;
        protected WindowDelimiter bottom;
        protected ScriptDom.WindowFrameType windowFrameType = ScriptDom.WindowFrameType.Rows;
    
        public WindowDelimiter Top => top;
        public WindowDelimiter Bottom => bottom;
        public ScriptDom.WindowFrameType WindowFrameType => windowFrameType;
    
        public WindowFrameClause(WindowDelimiter top = null, WindowDelimiter bottom = null, ScriptDom.WindowFrameType windowFrameType = ScriptDom.WindowFrameType.Rows) {
            this.top = top;
            this.bottom = bottom;
            this.windowFrameType = windowFrameType;
        }
    
        public ScriptDom.WindowFrameClause ToMutableConcrete() {
            var ret = new ScriptDom.WindowFrameClause();
            ret.Top = (ScriptDom.WindowDelimiter)top?.ToMutable();
            ret.Bottom = (ScriptDom.WindowDelimiter)bottom?.ToMutable();
            ret.WindowFrameType = windowFrameType;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(top is null)) {
                h = h * 23 + top.GetHashCode();
            }
            if (!(bottom is null)) {
                h = h * 23 + bottom.GetHashCode();
            }
            h = h * 23 + windowFrameType.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as WindowFrameClause);
        } 
        
        public bool Equals(WindowFrameClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<WindowDelimiter>.Default.Equals(other.Top, top)) {
                return false;
            }
            if (!EqualityComparer<WindowDelimiter>.Default.Equals(other.Bottom, bottom)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.WindowFrameType>.Default.Equals(other.WindowFrameType, windowFrameType)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(WindowFrameClause left, WindowFrameClause right) {
            return EqualityComparer<WindowFrameClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(WindowFrameClause left, WindowFrameClause right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (WindowFrameClause)that;
            compare = Comparer.DefaultInvariant.Compare(this.top, othr.top);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.bottom, othr.bottom);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.windowFrameType, othr.windowFrameType);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (WindowFrameClause left, WindowFrameClause right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(WindowFrameClause left, WindowFrameClause right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (WindowFrameClause left, WindowFrameClause right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(WindowFrameClause left, WindowFrameClause right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static WindowFrameClause FromMutable(ScriptDom.WindowFrameClause fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.WindowFrameClause)) { throw new NotImplementedException("Unexpected subtype of WindowFrameClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new WindowFrameClause(
                top: ImmutableDom.WindowDelimiter.FromMutable(fragment.Top),
                bottom: ImmutableDom.WindowDelimiter.FromMutable(fragment.Bottom),
                windowFrameType: fragment.WindowFrameType
            );
        }
    
    }

}
