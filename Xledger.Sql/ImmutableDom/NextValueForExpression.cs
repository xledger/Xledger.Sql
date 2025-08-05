using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class NextValueForExpression : PrimaryExpression, IEquatable<NextValueForExpression> {
        protected SchemaObjectName sequenceName;
        protected OverClause overClause;
    
        public SchemaObjectName SequenceName => sequenceName;
        public OverClause OverClause => overClause;
    
        public NextValueForExpression(SchemaObjectName sequenceName = null, OverClause overClause = null, Identifier collation = null) {
            this.sequenceName = sequenceName;
            this.overClause = overClause;
            this.collation = collation;
        }
    
        public ScriptDom.NextValueForExpression ToMutableConcrete() {
            var ret = new ScriptDom.NextValueForExpression();
            ret.SequenceName = (ScriptDom.SchemaObjectName)sequenceName?.ToMutable();
            ret.OverClause = (ScriptDom.OverClause)overClause?.ToMutable();
            ret.Collation = (ScriptDom.Identifier)collation?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(sequenceName is null)) {
                h = h * 23 + sequenceName.GetHashCode();
            }
            if (!(overClause is null)) {
                h = h * 23 + overClause.GetHashCode();
            }
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as NextValueForExpression);
        } 
        
        public bool Equals(NextValueForExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.SequenceName, sequenceName)) {
                return false;
            }
            if (!EqualityComparer<OverClause>.Default.Equals(other.OverClause, overClause)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(NextValueForExpression left, NextValueForExpression right) {
            return EqualityComparer<NextValueForExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(NextValueForExpression left, NextValueForExpression right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (NextValueForExpression)that;
            compare = Comparer.DefaultInvariant.Compare(this.sequenceName, othr.sequenceName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.overClause, othr.overClause);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (NextValueForExpression left, NextValueForExpression right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(NextValueForExpression left, NextValueForExpression right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (NextValueForExpression left, NextValueForExpression right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(NextValueForExpression left, NextValueForExpression right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static NextValueForExpression FromMutable(ScriptDom.NextValueForExpression fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.NextValueForExpression)) { throw new NotImplementedException("Unexpected subtype of NextValueForExpression not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new NextValueForExpression(
                sequenceName: ImmutableDom.SchemaObjectName.FromMutable(fragment.SequenceName),
                overClause: ImmutableDom.OverClause.FromMutable(fragment.OverClause),
                collation: ImmutableDom.Identifier.FromMutable(fragment.Collation)
            );
        }
    
    }

}
