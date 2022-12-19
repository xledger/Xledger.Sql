using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class WindowClause : TSqlFragment, IEquatable<WindowClause> {
        protected IReadOnlyList<WindowDefinition> windowDefinition;
    
        public IReadOnlyList<WindowDefinition> WindowDefinition => windowDefinition;
    
        public WindowClause(IReadOnlyList<WindowDefinition> windowDefinition = null) {
            this.windowDefinition = ImmList<WindowDefinition>.FromList(windowDefinition);
        }
    
        public ScriptDom.WindowClause ToMutableConcrete() {
            var ret = new ScriptDom.WindowClause();
            ret.WindowDefinition.AddRange(windowDefinition.SelectList(c => (ScriptDom.WindowDefinition)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + windowDefinition.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as WindowClause);
        } 
        
        public bool Equals(WindowClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<WindowDefinition>>.Default.Equals(other.WindowDefinition, windowDefinition)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(WindowClause left, WindowClause right) {
            return EqualityComparer<WindowClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(WindowClause left, WindowClause right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (WindowClause)that;
            compare = Comparer.DefaultInvariant.Compare(this.windowDefinition, othr.windowDefinition);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (WindowClause left, WindowClause right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(WindowClause left, WindowClause right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (WindowClause left, WindowClause right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(WindowClause left, WindowClause right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static WindowClause FromMutable(ScriptDom.WindowClause fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.WindowClause)) { throw new NotImplementedException("Unexpected subtype of WindowClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new WindowClause(
                windowDefinition: fragment.WindowDefinition.SelectList(ImmutableDom.WindowDefinition.FromMutable)
            );
        }
    
    }

}
