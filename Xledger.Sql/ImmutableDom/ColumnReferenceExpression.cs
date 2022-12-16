using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ColumnReferenceExpression : PrimaryExpression, IEquatable<ColumnReferenceExpression> {
        protected ScriptDom.ColumnType columnType = ScriptDom.ColumnType.Regular;
        protected MultiPartIdentifier multiPartIdentifier;
    
        public ScriptDom.ColumnType ColumnType => columnType;
        public MultiPartIdentifier MultiPartIdentifier => multiPartIdentifier;
    
        public ColumnReferenceExpression(ScriptDom.ColumnType columnType = ScriptDom.ColumnType.Regular, MultiPartIdentifier multiPartIdentifier = null, Identifier collation = null) {
            this.columnType = columnType;
            this.multiPartIdentifier = multiPartIdentifier;
            this.collation = collation;
        }
    
        public ScriptDom.ColumnReferenceExpression ToMutableConcrete() {
            var ret = new ScriptDom.ColumnReferenceExpression();
            ret.ColumnType = columnType;
            ret.MultiPartIdentifier = (ScriptDom.MultiPartIdentifier)multiPartIdentifier?.ToMutable();
            ret.Collation = (ScriptDom.Identifier)collation?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + columnType.GetHashCode();
            if (!(multiPartIdentifier is null)) {
                h = h * 23 + multiPartIdentifier.GetHashCode();
            }
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ColumnReferenceExpression);
        } 
        
        public bool Equals(ColumnReferenceExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ColumnType>.Default.Equals(other.ColumnType, columnType)) {
                return false;
            }
            if (!EqualityComparer<MultiPartIdentifier>.Default.Equals(other.MultiPartIdentifier, multiPartIdentifier)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ColumnReferenceExpression left, ColumnReferenceExpression right) {
            return EqualityComparer<ColumnReferenceExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ColumnReferenceExpression left, ColumnReferenceExpression right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ColumnReferenceExpression)that;
            compare = Comparer.DefaultInvariant.Compare(this.columnType, othr.columnType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.multiPartIdentifier, othr.multiPartIdentifier);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ColumnReferenceExpression left, ColumnReferenceExpression right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ColumnReferenceExpression left, ColumnReferenceExpression right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ColumnReferenceExpression left, ColumnReferenceExpression right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ColumnReferenceExpression left, ColumnReferenceExpression right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
