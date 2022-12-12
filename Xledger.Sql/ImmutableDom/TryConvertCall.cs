using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TryConvertCall : PrimaryExpression, IEquatable<TryConvertCall> {
        DataTypeReference dataType;
        ScalarExpression parameter;
        ScalarExpression style;
    
        public DataTypeReference DataType => dataType;
        public ScalarExpression Parameter => parameter;
        public ScalarExpression Style => style;
    
        public TryConvertCall(DataTypeReference dataType = null, ScalarExpression parameter = null, ScalarExpression style = null, Identifier collation = null) {
            this.dataType = dataType;
            this.parameter = parameter;
            this.style = style;
            this.collation = collation;
        }
    
        public ScriptDom.TryConvertCall ToMutableConcrete() {
            var ret = new ScriptDom.TryConvertCall();
            ret.DataType = (ScriptDom.DataTypeReference)dataType.ToMutable();
            ret.Parameter = (ScriptDom.ScalarExpression)parameter.ToMutable();
            ret.Style = (ScriptDom.ScalarExpression)style.ToMutable();
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
            if (!(style is null)) {
                h = h * 23 + style.GetHashCode();
            }
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TryConvertCall);
        } 
        
        public bool Equals(TryConvertCall other) {
            if (other is null) { return false; }
            if (!EqualityComparer<DataTypeReference>.Default.Equals(other.DataType, dataType)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Parameter, parameter)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Style, style)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TryConvertCall left, TryConvertCall right) {
            return EqualityComparer<TryConvertCall>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TryConvertCall left, TryConvertCall right) {
            return !(left == right);
        }
    
    }

}