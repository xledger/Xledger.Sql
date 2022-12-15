using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SqlDataTypeReference : ParameterizedDataTypeReference, IEquatable<SqlDataTypeReference> {
        protected ScriptDom.SqlDataTypeOption sqlDataTypeOption = ScriptDom.SqlDataTypeOption.None;
    
        public ScriptDom.SqlDataTypeOption SqlDataTypeOption => sqlDataTypeOption;
    
        public SqlDataTypeReference(ScriptDom.SqlDataTypeOption sqlDataTypeOption = ScriptDom.SqlDataTypeOption.None, IReadOnlyList<Literal> parameters = null, SchemaObjectName name = null) {
            this.sqlDataTypeOption = sqlDataTypeOption;
            this.parameters = ImmList<Literal>.FromList(parameters);
            this.name = name;
        }
    
        public ScriptDom.SqlDataTypeReference ToMutableConcrete() {
            var ret = new ScriptDom.SqlDataTypeReference();
            ret.SqlDataTypeOption = sqlDataTypeOption;
            ret.Parameters.AddRange(parameters.SelectList(c => (ScriptDom.Literal)c.ToMutable()));
            ret.Name = (ScriptDom.SchemaObjectName)name.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + sqlDataTypeOption.GetHashCode();
            h = h * 23 + parameters.GetHashCode();
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SqlDataTypeReference);
        } 
        
        public bool Equals(SqlDataTypeReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.SqlDataTypeOption>.Default.Equals(other.SqlDataTypeOption, sqlDataTypeOption)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Literal>>.Default.Equals(other.Parameters, parameters)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SqlDataTypeReference left, SqlDataTypeReference right) {
            return EqualityComparer<SqlDataTypeReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SqlDataTypeReference left, SqlDataTypeReference right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SqlDataTypeReference)that;
            compare = Comparer.DefaultInvariant.Compare(this.sqlDataTypeOption, othr.sqlDataTypeOption);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.parameters, othr.parameters);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (SqlDataTypeReference left, SqlDataTypeReference right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SqlDataTypeReference left, SqlDataTypeReference right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SqlDataTypeReference left, SqlDataTypeReference right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SqlDataTypeReference left, SqlDataTypeReference right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
