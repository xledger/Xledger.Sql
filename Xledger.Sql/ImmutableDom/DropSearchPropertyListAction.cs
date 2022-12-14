using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropSearchPropertyListAction : SearchPropertyListAction, IEquatable<DropSearchPropertyListAction> {
        protected StringLiteral propertyName;
    
        public StringLiteral PropertyName => propertyName;
    
        public DropSearchPropertyListAction(StringLiteral propertyName = null) {
            this.propertyName = propertyName;
        }
    
        public ScriptDom.DropSearchPropertyListAction ToMutableConcrete() {
            var ret = new ScriptDom.DropSearchPropertyListAction();
            ret.PropertyName = (ScriptDom.StringLiteral)propertyName.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(propertyName is null)) {
                h = h * 23 + propertyName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropSearchPropertyListAction);
        } 
        
        public bool Equals(DropSearchPropertyListAction other) {
            if (other is null) { return false; }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.PropertyName, propertyName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropSearchPropertyListAction left, DropSearchPropertyListAction right) {
            return EqualityComparer<DropSearchPropertyListAction>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropSearchPropertyListAction left, DropSearchPropertyListAction right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DropSearchPropertyListAction)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.propertyName, othr.propertyName);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static DropSearchPropertyListAction FromMutable(ScriptDom.DropSearchPropertyListAction fragment) {
            return (DropSearchPropertyListAction)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
