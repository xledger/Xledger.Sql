using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SelectiveXmlIndexPromotedPath : TSqlFragment, IEquatable<SelectiveXmlIndexPromotedPath> {
        protected Identifier name;
        protected Literal path;
        protected DataTypeReference sQLDataType;
        protected Literal xQueryDataType;
        protected IntegerLiteral maxLength;
        protected bool isSingleton = false;
    
        public Identifier Name => name;
        public Literal Path => path;
        public DataTypeReference SQLDataType => sQLDataType;
        public Literal XQueryDataType => xQueryDataType;
        public IntegerLiteral MaxLength => maxLength;
        public bool IsSingleton => isSingleton;
    
        public SelectiveXmlIndexPromotedPath(Identifier name = null, Literal path = null, DataTypeReference sQLDataType = null, Literal xQueryDataType = null, IntegerLiteral maxLength = null, bool isSingleton = false) {
            this.name = name;
            this.path = path;
            this.sQLDataType = sQLDataType;
            this.xQueryDataType = xQueryDataType;
            this.maxLength = maxLength;
            this.isSingleton = isSingleton;
        }
    
        public ScriptDom.SelectiveXmlIndexPromotedPath ToMutableConcrete() {
            var ret = new ScriptDom.SelectiveXmlIndexPromotedPath();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.Path = (ScriptDom.Literal)path?.ToMutable();
            ret.SQLDataType = (ScriptDom.DataTypeReference)sQLDataType?.ToMutable();
            ret.XQueryDataType = (ScriptDom.Literal)xQueryDataType?.ToMutable();
            ret.MaxLength = (ScriptDom.IntegerLiteral)maxLength?.ToMutable();
            ret.IsSingleton = isSingleton;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            if (!(path is null)) {
                h = h * 23 + path.GetHashCode();
            }
            if (!(sQLDataType is null)) {
                h = h * 23 + sQLDataType.GetHashCode();
            }
            if (!(xQueryDataType is null)) {
                h = h * 23 + xQueryDataType.GetHashCode();
            }
            if (!(maxLength is null)) {
                h = h * 23 + maxLength.GetHashCode();
            }
            h = h * 23 + isSingleton.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SelectiveXmlIndexPromotedPath);
        } 
        
        public bool Equals(SelectiveXmlIndexPromotedPath other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Path, path)) {
                return false;
            }
            if (!EqualityComparer<DataTypeReference>.Default.Equals(other.SQLDataType, sQLDataType)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.XQueryDataType, xQueryDataType)) {
                return false;
            }
            if (!EqualityComparer<IntegerLiteral>.Default.Equals(other.MaxLength, maxLength)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsSingleton, isSingleton)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SelectiveXmlIndexPromotedPath left, SelectiveXmlIndexPromotedPath right) {
            return EqualityComparer<SelectiveXmlIndexPromotedPath>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SelectiveXmlIndexPromotedPath left, SelectiveXmlIndexPromotedPath right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SelectiveXmlIndexPromotedPath)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.path, othr.path);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.sQLDataType, othr.sQLDataType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.xQueryDataType, othr.xQueryDataType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.maxLength, othr.maxLength);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isSingleton, othr.isSingleton);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (SelectiveXmlIndexPromotedPath left, SelectiveXmlIndexPromotedPath right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SelectiveXmlIndexPromotedPath left, SelectiveXmlIndexPromotedPath right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SelectiveXmlIndexPromotedPath left, SelectiveXmlIndexPromotedPath right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SelectiveXmlIndexPromotedPath left, SelectiveXmlIndexPromotedPath right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
