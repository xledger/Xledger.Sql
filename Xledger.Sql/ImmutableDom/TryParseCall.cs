using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TryParseCall : PrimaryExpression, IEquatable<TryParseCall> {
        protected ScalarExpression stringValue;
        protected DataTypeReference dataType;
        protected ScalarExpression culture;
    
        public ScalarExpression StringValue => stringValue;
        public DataTypeReference DataType => dataType;
        public ScalarExpression Culture => culture;
    
        public TryParseCall(ScalarExpression stringValue = null, DataTypeReference dataType = null, ScalarExpression culture = null, Identifier collation = null) {
            this.stringValue = stringValue;
            this.dataType = dataType;
            this.culture = culture;
            this.collation = collation;
        }
    
        public ScriptDom.TryParseCall ToMutableConcrete() {
            var ret = new ScriptDom.TryParseCall();
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
            return Equals(obj as TryParseCall);
        } 
        
        public bool Equals(TryParseCall other) {
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
        
        public static bool operator ==(TryParseCall left, TryParseCall right) {
            return EqualityComparer<TryParseCall>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TryParseCall left, TryParseCall right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (TryParseCall)that;
            compare = Comparer.DefaultInvariant.Compare(this.stringValue, othr.stringValue);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.dataType, othr.dataType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.culture, othr.culture);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (TryParseCall left, TryParseCall right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(TryParseCall left, TryParseCall right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (TryParseCall left, TryParseCall right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(TryParseCall left, TryParseCall right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
