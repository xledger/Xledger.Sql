using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateExternalResourcePoolStatement : ExternalResourcePoolStatement, IEquatable<CreateExternalResourcePoolStatement> {
        public CreateExternalResourcePoolStatement(Identifier name = null, IReadOnlyList<ExternalResourcePoolParameter> externalResourcePoolParameters = null) {
            this.name = name;
            this.externalResourcePoolParameters = ImmList<ExternalResourcePoolParameter>.FromList(externalResourcePoolParameters);
        }
    
        public ScriptDom.CreateExternalResourcePoolStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateExternalResourcePoolStatement();
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
            return Equals(obj as CreateExternalResourcePoolStatement);
        } 
        
        public bool Equals(CreateExternalResourcePoolStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ExternalResourcePoolParameter>>.Default.Equals(other.ExternalResourcePoolParameters, externalResourcePoolParameters)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateExternalResourcePoolStatement left, CreateExternalResourcePoolStatement right) {
            return EqualityComparer<CreateExternalResourcePoolStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateExternalResourcePoolStatement left, CreateExternalResourcePoolStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateExternalResourcePoolStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.externalResourcePoolParameters, othr.externalResourcePoolParameters);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (CreateExternalResourcePoolStatement left, CreateExternalResourcePoolStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateExternalResourcePoolStatement left, CreateExternalResourcePoolStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateExternalResourcePoolStatement left, CreateExternalResourcePoolStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateExternalResourcePoolStatement left, CreateExternalResourcePoolStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateExternalResourcePoolStatement FromMutable(ScriptDom.CreateExternalResourcePoolStatement fragment) {
            return (CreateExternalResourcePoolStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
