using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OdbcLiteral : Literal, IEquatable<OdbcLiteral> {
        protected ScriptDom.OdbcLiteralType odbcLiteralType = ScriptDom.OdbcLiteralType.Time;
        protected bool isNational = false;
    
        public ScriptDom.OdbcLiteralType OdbcLiteralType => odbcLiteralType;
        public bool IsNational => isNational;
    
        public OdbcLiteral(ScriptDom.OdbcLiteralType odbcLiteralType = ScriptDom.OdbcLiteralType.Time, bool isNational = false, string @value = null, Identifier collation = null) {
            this.odbcLiteralType = odbcLiteralType;
            this.isNational = isNational;
            this.@value = @value;
            this.collation = collation;
        }
    
        public ScriptDom.OdbcLiteral ToMutableConcrete() {
            var ret = new ScriptDom.OdbcLiteral();
            ret.OdbcLiteralType = odbcLiteralType;
            ret.IsNational = isNational;
            ret.Value = @value;
            ret.Collation = (ScriptDom.Identifier)collation.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + odbcLiteralType.GetHashCode();
            h = h * 23 + isNational.GetHashCode();
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OdbcLiteral);
        } 
        
        public bool Equals(OdbcLiteral other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OdbcLiteralType>.Default.Equals(other.OdbcLiteralType, odbcLiteralType)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsNational, isNational)) {
                return false;
            }
            if (!EqualityComparer<string>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OdbcLiteral left, OdbcLiteral right) {
            return EqualityComparer<OdbcLiteral>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OdbcLiteral left, OdbcLiteral right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OdbcLiteral)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.odbcLiteralType, othr.odbcLiteralType);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.isNational, othr.isNational);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static OdbcLiteral FromMutable(ScriptDom.OdbcLiteral fragment) {
            return (OdbcLiteral)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
