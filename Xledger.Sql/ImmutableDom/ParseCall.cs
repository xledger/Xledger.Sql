using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ParseCall : PrimaryExpression, IEquatable<ParseCall> {
        protected ScalarExpression stringValue;
        protected DataTypeReference dataType;
        protected ScalarExpression culture;
    
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
            ret.StringValue = (ScriptDom.ScalarExpression)stringValue?.ToMutable();
            ret.DataType = (ScriptDom.DataTypeReference)dataType?.ToMutable();
            ret.Culture = (ScriptDom.ScalarExpression)culture?.ToMutable();
            ret.Collation = (ScriptDom.Identifier)collation?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ParseCall)that;
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
        
        public static bool operator < (ParseCall left, ParseCall right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ParseCall left, ParseCall right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ParseCall left, ParseCall right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ParseCall left, ParseCall right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ParseCall FromMutable(ScriptDom.ParseCall fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ParseCall)) { throw new NotImplementedException("Unexpected subtype of ParseCall not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ParseCall(
                stringValue: ImmutableDom.ScalarExpression.FromMutable(fragment.StringValue),
                dataType: ImmutableDom.DataTypeReference.FromMutable(fragment.DataType),
                culture: ImmutableDom.ScalarExpression.FromMutable(fragment.Culture),
                collation: ImmutableDom.Identifier.FromMutable(fragment.Collation)
            );
        }
    
    }

}
