using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
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
            ret.PropertyName = (ScriptDom.StringLiteral)propertyName?.ToMutable();
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
            compare = Comparer.DefaultInvariant.Compare(this.propertyName, othr.propertyName);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (DropSearchPropertyListAction left, DropSearchPropertyListAction right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DropSearchPropertyListAction left, DropSearchPropertyListAction right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DropSearchPropertyListAction left, DropSearchPropertyListAction right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DropSearchPropertyListAction left, DropSearchPropertyListAction right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static DropSearchPropertyListAction FromMutable(ScriptDom.DropSearchPropertyListAction fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.DropSearchPropertyListAction)) { throw new NotImplementedException("Unexpected subtype of DropSearchPropertyListAction not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropSearchPropertyListAction(
                propertyName: ImmutableDom.StringLiteral.FromMutable(fragment.PropertyName)
            );
        }
    
    }

}
