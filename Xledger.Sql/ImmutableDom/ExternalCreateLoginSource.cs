using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExternalCreateLoginSource : CreateLoginSource, IEquatable<ExternalCreateLoginSource> {
        protected IReadOnlyList<PrincipalOption> options;
    
        public IReadOnlyList<PrincipalOption> Options => options;
    
        public ExternalCreateLoginSource(IReadOnlyList<PrincipalOption> options = null) {
            this.options = ImmList<PrincipalOption>.FromList(options);
        }
    
        public ScriptDom.ExternalCreateLoginSource ToMutableConcrete() {
            var ret = new ScriptDom.ExternalCreateLoginSource();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.PrincipalOption)c.ToMutable()));
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
            return Equals(obj as ExternalCreateLoginSource);
        } 
        
        public bool Equals(ExternalCreateLoginSource other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<PrincipalOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExternalCreateLoginSource left, ExternalCreateLoginSource right) {
            return EqualityComparer<ExternalCreateLoginSource>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExternalCreateLoginSource left, ExternalCreateLoginSource right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ExternalCreateLoginSource)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static ExternalCreateLoginSource FromMutable(ScriptDom.ExternalCreateLoginSource fragment) {
            return (ExternalCreateLoginSource)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
