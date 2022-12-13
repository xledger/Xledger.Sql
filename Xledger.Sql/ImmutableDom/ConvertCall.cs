using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ConvertCall : PrimaryExpression, IEquatable<ConvertCall> {
        protected DataTypeReference dataType;
        protected ScalarExpression parameter;
        protected ScalarExpression style;
    
        public DataTypeReference DataType => dataType;
        public ScalarExpression Parameter => parameter;
        public ScalarExpression Style => style;
    
        public ConvertCall(DataTypeReference dataType = null, ScalarExpression parameter = null, ScalarExpression style = null, Identifier collation = null) {
            this.dataType = dataType;
            this.parameter = parameter;
            this.style = style;
            this.collation = collation;
        }
    
        public ScriptDom.ConvertCall ToMutableConcrete() {
            var ret = new ScriptDom.ConvertCall();
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
            return Equals(obj as ConvertCall);
        } 
        
        public bool Equals(ConvertCall other) {
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
        
        public static bool operator ==(ConvertCall left, ConvertCall right) {
            return EqualityComparer<ConvertCall>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ConvertCall left, ConvertCall right) {
            return !(left == right);
        }
    
        public static ConvertCall FromMutable(ScriptDom.ConvertCall fragment) {
            return (ConvertCall)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
