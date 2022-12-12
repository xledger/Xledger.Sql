using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class IdentifierOrScalarExpression : TSqlFragment, IEquatable<IdentifierOrScalarExpression> {
        Identifier identifier;
        ScalarExpression scalarExpression;
    
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
    
    }

}