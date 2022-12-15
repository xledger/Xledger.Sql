using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropWorkloadClassifierStatement : DropUnownedObjectStatement, IEquatable<DropWorkloadClassifierStatement> {
        public DropWorkloadClassifierStatement(Identifier name = null, bool isIfExists = false) {
            this.name = name;
            this.isIfExists = isIfExists;
        }
    
        public ScriptDom.DropWorkloadClassifierStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropWorkloadClassifierStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.IsIfExists = isIfExists;
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
            h = h * 23 + isIfExists.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropWorkloadClassifierStatement);
        } 
        
        public bool Equals(DropWorkloadClassifierStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsIfExists, isIfExists)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropWorkloadClassifierStatement left, DropWorkloadClassifierStatement right) {
            return EqualityComparer<DropWorkloadClassifierStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropWorkloadClassifierStatement left, DropWorkloadClassifierStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DropWorkloadClassifierStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isIfExists, othr.isIfExists);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (DropWorkloadClassifierStatement left, DropWorkloadClassifierStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DropWorkloadClassifierStatement left, DropWorkloadClassifierStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DropWorkloadClassifierStatement left, DropWorkloadClassifierStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DropWorkloadClassifierStatement left, DropWorkloadClassifierStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
