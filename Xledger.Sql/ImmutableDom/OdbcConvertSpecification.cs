using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OdbcConvertSpecification : ScalarExpression, IEquatable<OdbcConvertSpecification> {
        protected Identifier identifier;
    
        public Identifier Identifier => identifier;
    
        public OdbcConvertSpecification(Identifier identifier = null) {
            this.identifier = identifier;
        }
    
        public ScriptDom.OdbcConvertSpecification ToMutableConcrete() {
            var ret = new ScriptDom.OdbcConvertSpecification();
            ret.Identifier = (ScriptDom.Identifier)identifier.ToMutable();
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
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OdbcConvertSpecification);
        } 
        
        public bool Equals(OdbcConvertSpecification other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Identifier, identifier)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OdbcConvertSpecification left, OdbcConvertSpecification right) {
            return EqualityComparer<OdbcConvertSpecification>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OdbcConvertSpecification left, OdbcConvertSpecification right) {
            return !(left == right);
        }
    
    }

}
