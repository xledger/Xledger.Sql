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
            this.parameters = parameters is null ? ImmList<Literal>.Empty : ImmList<Literal>.FromList(parameters);
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
    
        public static SqlDataTypeReference FromMutable(ScriptDom.SqlDataTypeReference fragment) {
            return (SqlDataTypeReference)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
