using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class IdentifierOrValueExpression : TSqlFragment, IEquatable<IdentifierOrValueExpression> {
        protected Identifier identifier;
        protected ValueExpression valueExpression;
    
        public Identifier Identifier => identifier;
        public ValueExpression ValueExpression => valueExpression;
    
        public IdentifierOrValueExpression(Identifier identifier = null, ValueExpression valueExpression = null) {
            this.identifier = identifier;
            this.valueExpression = valueExpression;
        }
    
        public ScriptDom.IdentifierOrValueExpression ToMutableConcrete() {
            var ret = new ScriptDom.IdentifierOrValueExpression();
            ret.Identifier = (ScriptDom.Identifier)identifier.ToMutable();
            ret.ValueExpression = (ScriptDom.ValueExpression)valueExpression.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(identifier is null)) {
                h = h * 23 + identifier.GetHashCode();
            }
            if (!(valueExpression is null)) {
                h = h * 23 + valueExpression.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as IdentifierOrValueExpression);
        } 
        
        public bool Equals(IdentifierOrValueExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Identifier, identifier)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.ValueExpression, valueExpression)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(IdentifierOrValueExpression left, IdentifierOrValueExpression right) {
            return EqualityComparer<IdentifierOrValueExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(IdentifierOrValueExpression left, IdentifierOrValueExpression right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (IdentifierOrValueExpression)that;
            compare = Comparer.DefaultInvariant.Compare(this.identifier, othr.identifier);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.valueExpression, othr.valueExpression);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (IdentifierOrValueExpression left, IdentifierOrValueExpression right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(IdentifierOrValueExpression left, IdentifierOrValueExpression right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (IdentifierOrValueExpression left, IdentifierOrValueExpression right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(IdentifierOrValueExpression left, IdentifierOrValueExpression right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static IdentifierOrValueExpression FromMutable(ScriptDom.IdentifierOrValueExpression fragment) {
            return (IdentifierOrValueExpression)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
