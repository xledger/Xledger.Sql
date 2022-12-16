using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class VariableTableReference : TableReferenceWithAlias, IEquatable<VariableTableReference> {
        protected VariableReference variable;
    
        public VariableReference Variable => variable;
    
        public VariableTableReference(VariableReference variable = null, Identifier alias = null, bool forPath = false) {
            this.variable = variable;
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.VariableTableReference ToMutableConcrete() {
            var ret = new ScriptDom.VariableTableReference();
            ret.Variable = (ScriptDom.VariableReference)variable?.ToMutable();
            ret.Alias = (ScriptDom.Identifier)alias?.ToMutable();
            ret.ForPath = forPath;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(variable is null)) {
                h = h * 23 + variable.GetHashCode();
            }
            if (!(alias is null)) {
                h = h * 23 + alias.GetHashCode();
            }
            h = h * 23 + forPath.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as VariableTableReference);
        } 
        
        public bool Equals(VariableTableReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<VariableReference>.Default.Equals(other.Variable, variable)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Alias, alias)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.ForPath, forPath)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(VariableTableReference left, VariableTableReference right) {
            return EqualityComparer<VariableTableReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(VariableTableReference left, VariableTableReference right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (VariableTableReference)that;
            compare = Comparer.DefaultInvariant.Compare(this.variable, othr.variable);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.alias, othr.alias);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.forPath, othr.forPath);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (VariableTableReference left, VariableTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(VariableTableReference left, VariableTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (VariableTableReference left, VariableTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(VariableTableReference left, VariableTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
