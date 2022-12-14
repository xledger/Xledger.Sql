using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class GoToStatement : TSqlStatement, IEquatable<GoToStatement> {
        protected Identifier labelName;
    
        public Identifier LabelName => labelName;
    
        public GoToStatement(Identifier labelName = null) {
            this.labelName = labelName;
        }
    
        public ScriptDom.GoToStatement ToMutableConcrete() {
            var ret = new ScriptDom.GoToStatement();
            ret.LabelName = (ScriptDom.Identifier)labelName.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(labelName is null)) {
                h = h * 23 + labelName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as GoToStatement);
        } 
        
        public bool Equals(GoToStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.LabelName, labelName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(GoToStatement left, GoToStatement right) {
            return EqualityComparer<GoToStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(GoToStatement left, GoToStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (GoToStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.labelName, othr.labelName);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (GoToStatement left, GoToStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(GoToStatement left, GoToStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (GoToStatement left, GoToStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(GoToStatement left, GoToStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static GoToStatement FromMutable(ScriptDom.GoToStatement fragment) {
            return (GoToStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
