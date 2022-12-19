using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExternalResourcePoolStatement : TSqlStatement, IEquatable<ExternalResourcePoolStatement> {
        protected Identifier name;
        protected IReadOnlyList<ExternalResourcePoolParameter> externalResourcePoolParameters;
    
        public Identifier Name => name;
        public IReadOnlyList<ExternalResourcePoolParameter> ExternalResourcePoolParameters => externalResourcePoolParameters;
    
        public ExternalResourcePoolStatement(Identifier name = null, IReadOnlyList<ExternalResourcePoolParameter> externalResourcePoolParameters = null) {
            this.name = name;
            this.externalResourcePoolParameters = ImmList<ExternalResourcePoolParameter>.FromList(externalResourcePoolParameters);
        }
    
        public ScriptDom.ExternalResourcePoolStatement ToMutableConcrete() {
            var ret = new ScriptDom.ExternalResourcePoolStatement();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.ExternalResourcePoolParameters.AddRange(externalResourcePoolParameters.SelectList(c => (ScriptDom.ExternalResourcePoolParameter)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + externalResourcePoolParameters.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExternalResourcePoolStatement);
        } 
        
        public bool Equals(ExternalResourcePoolStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ExternalResourcePoolParameter>>.Default.Equals(other.ExternalResourcePoolParameters, externalResourcePoolParameters)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExternalResourcePoolStatement left, ExternalResourcePoolStatement right) {
            return EqualityComparer<ExternalResourcePoolStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExternalResourcePoolStatement left, ExternalResourcePoolStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ExternalResourcePoolStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.externalResourcePoolParameters, othr.externalResourcePoolParameters);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ExternalResourcePoolStatement left, ExternalResourcePoolStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ExternalResourcePoolStatement left, ExternalResourcePoolStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ExternalResourcePoolStatement left, ExternalResourcePoolStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ExternalResourcePoolStatement left, ExternalResourcePoolStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ExternalResourcePoolStatement FromMutable(ScriptDom.ExternalResourcePoolStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ExternalResourcePoolStatement)) { return TSqlFragment.FromMutable(fragment) as ExternalResourcePoolStatement; }
            return new ExternalResourcePoolStatement(
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                externalResourcePoolParameters: fragment.ExternalResourcePoolParameters.SelectList(ImmutableDom.ExternalResourcePoolParameter.FromMutable)
            );
        }
    
    }

}
