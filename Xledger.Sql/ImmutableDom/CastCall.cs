using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CastCall : PrimaryExpression, IEquatable<CastCall> {
        protected DataTypeReference dataType;
        protected ScalarExpression parameter;
    
        public DataTypeReference DataType => dataType;
        public ScalarExpression Parameter => parameter;
    
        public CastCall(DataTypeReference dataType = null, ScalarExpression parameter = null, Identifier collation = null) {
            this.dataType = dataType;
            this.parameter = parameter;
            this.collation = collation;
        }
    
        public ScriptDom.CastCall ToMutableConcrete() {
            var ret = new ScriptDom.CastCall();
            ret.DataType = (ScriptDom.DataTypeReference)dataType.ToMutable();
            ret.Parameter = (ScriptDom.ScalarExpression)parameter.ToMutable();
            ret.Collation = (ScriptDom.Identifier)collation.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(dataType is null)) {
                h = h * 23 + dataType.GetHashCode();
            }
            if (!(parameter is null)) {
                h = h * 23 + parameter.GetHashCode();
            }
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CastCall);
        } 
        
        public bool Equals(CastCall other) {
            if (other is null) { return false; }
            if (!EqualityComparer<DataTypeReference>.Default.Equals(other.DataType, dataType)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Parameter, parameter)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CastCall left, CastCall right) {
            return EqualityComparer<CastCall>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CastCall left, CastCall right) {
            return !(left == right);
        }
    
    }

}
