using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterExternalResourcePoolStatement : ExternalResourcePoolStatement, IEquatable<AlterExternalResourcePoolStatement> {
        public AlterExternalResourcePoolStatement(Identifier name = null, IReadOnlyList<ExternalResourcePoolParameter> externalResourcePoolParameters = null) {
            this.name = name;
            this.externalResourcePoolParameters = ImmList<ExternalResourcePoolParameter>.FromList(externalResourcePoolParameters);
        }
    
        public ScriptDom.AlterExternalResourcePoolStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterExternalResourcePoolStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.ExternalResourcePoolParameters.AddRange(externalResourcePoolParameters.SelectList(c => (ScriptDom.ExternalResourcePoolParameter)c.ToMutable()));
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
            return Equals(obj as AlterExternalResourcePoolStatement);
        } 
        
        public bool Equals(AlterExternalResourcePoolStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ExternalResourcePoolParameter>>.Default.Equals(other.ExternalResourcePoolParameters, externalResourcePoolParameters)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterExternalResourcePoolStatement left, AlterExternalResourcePoolStatement right) {
            return EqualityComparer<AlterExternalResourcePoolStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterExternalResourcePoolStatement left, AlterExternalResourcePoolStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterExternalResourcePoolStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.externalResourcePoolParameters, othr.externalResourcePoolParameters);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AlterExternalResourcePoolStatement left, AlterExternalResourcePoolStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterExternalResourcePoolStatement left, AlterExternalResourcePoolStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterExternalResourcePoolStatement left, AlterExternalResourcePoolStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterExternalResourcePoolStatement left, AlterExternalResourcePoolStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
