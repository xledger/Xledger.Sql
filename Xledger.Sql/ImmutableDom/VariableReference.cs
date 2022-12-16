using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class VariableReference : ValueExpression, IEquatable<VariableReference> {
        protected string name;
    
        public string Name => name;
    
        public VariableReference(string name = null, Identifier collation = null) {
            this.name = name;
            this.collation = collation;
        }
    
        public ScriptDom.VariableReference ToMutableConcrete() {
            var ret = new ScriptDom.VariableReference();
            ret.Name = name;
            ret.Collation = (ScriptDom.Identifier)collation?.ToMutable();
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
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as VariableReference);
        } 
        
        public bool Equals(VariableReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<string>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(VariableReference left, VariableReference right) {
            return EqualityComparer<VariableReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(VariableReference left, VariableReference right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (VariableReference)that;
            compare = CaseInsensitiveComparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (VariableReference left, VariableReference right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(VariableReference left, VariableReference right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (VariableReference left, VariableReference right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(VariableReference left, VariableReference right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
