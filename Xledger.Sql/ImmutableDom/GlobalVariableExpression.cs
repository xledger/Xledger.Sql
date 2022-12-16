using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class GlobalVariableExpression : ValueExpression, IEquatable<GlobalVariableExpression> {
        protected string name;
    
        public string Name => name;
    
        public GlobalVariableExpression(string name = null, Identifier collation = null) {
            this.name = name;
            this.collation = collation;
        }
    
        public ScriptDom.GlobalVariableExpression ToMutableConcrete() {
            var ret = new ScriptDom.GlobalVariableExpression();
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
            return Equals(obj as GlobalVariableExpression);
        } 
        
        public bool Equals(GlobalVariableExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<string>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(GlobalVariableExpression left, GlobalVariableExpression right) {
            return EqualityComparer<GlobalVariableExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(GlobalVariableExpression left, GlobalVariableExpression right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (GlobalVariableExpression)that;
            compare = CaseInsensitiveComparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (GlobalVariableExpression left, GlobalVariableExpression right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(GlobalVariableExpression left, GlobalVariableExpression right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (GlobalVariableExpression left, GlobalVariableExpression right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(GlobalVariableExpression left, GlobalVariableExpression right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
