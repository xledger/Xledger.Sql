using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class UserDataTypeReference : ParameterizedDataTypeReference, IEquatable<UserDataTypeReference> {
        public UserDataTypeReference(IReadOnlyList<Literal> parameters = null, SchemaObjectName name = null) {
            this.parameters = ImmList<Literal>.FromList(parameters);
            this.name = name;
        }
    
        public ScriptDom.UserDataTypeReference ToMutableConcrete() {
            var ret = new ScriptDom.UserDataTypeReference();
            ret.Parameters.AddRange(parameters.SelectList(c => (ScriptDom.Literal)c.ToMutable()));
            ret.Name = (ScriptDom.SchemaObjectName)name.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + parameters.GetHashCode();
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as UserDataTypeReference);
        } 
        
        public bool Equals(UserDataTypeReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<Literal>>.Default.Equals(other.Parameters, parameters)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(UserDataTypeReference left, UserDataTypeReference right) {
            return EqualityComparer<UserDataTypeReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(UserDataTypeReference left, UserDataTypeReference right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (UserDataTypeReference)that;
            compare = Comparer.DefaultInvariant.Compare(this.parameters, othr.parameters);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (UserDataTypeReference left, UserDataTypeReference right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(UserDataTypeReference left, UserDataTypeReference right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (UserDataTypeReference left, UserDataTypeReference right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(UserDataTypeReference left, UserDataTypeReference right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
