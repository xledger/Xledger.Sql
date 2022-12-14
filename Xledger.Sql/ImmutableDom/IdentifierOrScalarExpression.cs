using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class IdentifierOrScalarExpression : TSqlFragment, IEquatable<IdentifierOrScalarExpression> {
        protected Identifier identifier;
        protected ScalarExpression scalarExpression;
    
        public Identifier Identifier => identifier;
        public ScalarExpression ScalarExpression => scalarExpression;
    
        public IdentifierOrScalarExpression(Identifier identifier = null, ScalarExpression scalarExpression = null) {
            this.identifier = identifier;
            this.scalarExpression = scalarExpression;
        }
    
        public ScriptDom.IdentifierOrScalarExpression ToMutableConcrete() {
            var ret = new ScriptDom.IdentifierOrScalarExpression();
            ret.Identifier = (ScriptDom.Identifier)identifier.ToMutable();
            ret.ScalarExpression = (ScriptDom.ScalarExpression)scalarExpression.ToMutable();
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
            if (!(scalarExpression is null)) {
                h = h * 23 + scalarExpression.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as IdentifierOrScalarExpression);
        } 
        
        public bool Equals(IdentifierOrScalarExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Identifier, identifier)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.ScalarExpression, scalarExpression)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(IdentifierOrScalarExpression left, IdentifierOrScalarExpression right) {
            return EqualityComparer<IdentifierOrScalarExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(IdentifierOrScalarExpression left, IdentifierOrScalarExpression right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (IdentifierOrScalarExpression)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.identifier, othr.identifier);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.scalarExpression, othr.scalarExpression);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static IdentifierOrScalarExpression FromMutable(ScriptDom.IdentifierOrScalarExpression fragment) {
            return (IdentifierOrScalarExpression)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
