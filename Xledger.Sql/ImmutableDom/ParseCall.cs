using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ParseCall : PrimaryExpression, IEquatable<ParseCall> {
        ScalarExpression stringValue;
        DataTypeReference dataType;
        ScalarExpression culture;
    
        public ScalarExpression StringValue => stringValue;
        public DataTypeReference DataType => dataType;
        public ScalarExpression Culture => culture;
    
        public ParseCall(ScalarExpression stringValue = null, DataTypeReference dataType = null, ScalarExpression culture = null, Identifier collation = null) {
            this.stringValue = stringValue;
            this.dataType = dataType;
            this.culture = culture;
            this.collation = collation;
        }
    
        public ScriptDom.ParseCall ToMutableConcrete() {
            var ret = new ScriptDom.ParseCall();
            ret.StringValue = (ScriptDom.ScalarExpression)stringValue.ToMutable();
            ret.DataType = (ScriptDom.DataTypeReference)dataType.ToMutable();
            ret.Culture = (ScriptDom.ScalarExpression)culture.ToMutable();
            ret.Collation = (ScriptDom.Identifier)collation.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(stringValue is null)) {
                h = h * 23 + stringValue.GetHashCode();
            }
            if (!(dataType is null)) {
                h = h * 23 + dataType.GetHashCode();
            }
            if (!(culture is null)) {
                h = h * 23 + culture.GetHashCode();
            }
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ParseCall);
        } 
        
        public bool Equals(ParseCall other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.StringValue, stringValue)) {
                return false;
            }
            if (!EqualityComparer<DataTypeReference>.Default.Equals(other.DataType, dataType)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Culture, culture)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ParseCall left, ParseCall right) {
            return EqualityComparer<ParseCall>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ParseCall left, ParseCall right) {
            return !(left == right);
        }
    
    }

}
