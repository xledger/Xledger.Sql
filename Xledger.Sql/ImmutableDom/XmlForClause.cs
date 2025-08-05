using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class XmlForClause : ForClause, IEquatable<XmlForClause> {
        protected IReadOnlyList<XmlForClauseOption> options;
    
        public IReadOnlyList<XmlForClauseOption> Options => options;
    
        public XmlForClause(IReadOnlyList<XmlForClauseOption> options = null) {
            this.options = options.ToImmArray<XmlForClauseOption>();
        }
    
        public ScriptDom.XmlForClause ToMutableConcrete() {
            var ret = new ScriptDom.XmlForClause();
            ret.Options.AddRange(options.Select(c => (ScriptDom.XmlForClauseOption)c?.ToMutable()));
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
            return Equals(obj as XmlForClause);
        } 
        
        public bool Equals(XmlForClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<XmlForClauseOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(XmlForClause left, XmlForClause right) {
            return EqualityComparer<XmlForClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(XmlForClause left, XmlForClause right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (XmlForClause)that;
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (XmlForClause left, XmlForClause right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(XmlForClause left, XmlForClause right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (XmlForClause left, XmlForClause right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(XmlForClause left, XmlForClause right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static XmlForClause FromMutable(ScriptDom.XmlForClause fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.XmlForClause)) { throw new NotImplementedException("Unexpected subtype of XmlForClause not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new XmlForClause(
                options: fragment.Options.ToImmArray(ImmutableDom.XmlForClauseOption.FromMutable)
            );
        }
    
    }

}
