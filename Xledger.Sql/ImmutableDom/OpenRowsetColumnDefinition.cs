using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class OpenRowsetColumnDefinition : ColumnDefinitionBase, IEquatable<OpenRowsetColumnDefinition> {
        protected IntegerLiteral columnOrdinal;
        protected StringLiteral jsonPath;
    
        public IntegerLiteral ColumnOrdinal => columnOrdinal;
        public StringLiteral JsonPath => jsonPath;
    
        public OpenRowsetColumnDefinition(IntegerLiteral columnOrdinal = null, StringLiteral jsonPath = null, Identifier columnIdentifier = null, DataTypeReference dataType = null, Identifier collation = null) {
            this.columnOrdinal = columnOrdinal;
            this.jsonPath = jsonPath;
            this.columnIdentifier = columnIdentifier;
            this.dataType = dataType;
            this.collation = collation;
        }
    
        public ScriptDom.OpenRowsetColumnDefinition ToMutableConcrete() {
            var ret = new ScriptDom.OpenRowsetColumnDefinition();
            ret.ColumnOrdinal = (ScriptDom.IntegerLiteral)columnOrdinal.ToMutable();
            ret.JsonPath = (ScriptDom.StringLiteral)jsonPath.ToMutable();
            ret.ColumnIdentifier = (ScriptDom.Identifier)columnIdentifier.ToMutable();
            ret.DataType = (ScriptDom.DataTypeReference)dataType.ToMutable();
            ret.Collation = (ScriptDom.Identifier)collation.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(columnOrdinal is null)) {
                h = h * 23 + columnOrdinal.GetHashCode();
            }
            if (!(jsonPath is null)) {
                h = h * 23 + jsonPath.GetHashCode();
            }
            if (!(columnIdentifier is null)) {
                h = h * 23 + columnIdentifier.GetHashCode();
            }
            if (!(dataType is null)) {
                h = h * 23 + dataType.GetHashCode();
            }
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as OpenRowsetColumnDefinition);
        } 
        
        public bool Equals(OpenRowsetColumnDefinition other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IntegerLiteral>.Default.Equals(other.ColumnOrdinal, columnOrdinal)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.JsonPath, jsonPath)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.ColumnIdentifier, columnIdentifier)) {
                return false;
            }
            if (!EqualityComparer<DataTypeReference>.Default.Equals(other.DataType, dataType)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(OpenRowsetColumnDefinition left, OpenRowsetColumnDefinition right) {
            return EqualityComparer<OpenRowsetColumnDefinition>.Default.Equals(left, right);
        }
        
        public static bool operator !=(OpenRowsetColumnDefinition left, OpenRowsetColumnDefinition right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (OpenRowsetColumnDefinition)that;
            compare = Comparer.DefaultInvariant.Compare(this.columnOrdinal, othr.columnOrdinal);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.jsonPath, othr.jsonPath);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.columnIdentifier, othr.columnIdentifier);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.dataType, othr.dataType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (OpenRowsetColumnDefinition left, OpenRowsetColumnDefinition right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(OpenRowsetColumnDefinition left, OpenRowsetColumnDefinition right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (OpenRowsetColumnDefinition left, OpenRowsetColumnDefinition right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(OpenRowsetColumnDefinition left, OpenRowsetColumnDefinition right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
