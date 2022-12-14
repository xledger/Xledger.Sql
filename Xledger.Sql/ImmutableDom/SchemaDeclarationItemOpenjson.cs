using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SchemaDeclarationItemOpenjson : SchemaDeclarationItem, IEquatable<SchemaDeclarationItemOpenjson> {
        protected bool asJson = false;
    
        public bool AsJson => asJson;
    
        public SchemaDeclarationItemOpenjson(bool asJson = false, ColumnDefinitionBase columnDefinition = null, ValueExpression mapping = null) {
            this.asJson = asJson;
            this.columnDefinition = columnDefinition;
            this.mapping = mapping;
        }
    
        public ScriptDom.SchemaDeclarationItemOpenjson ToMutableConcrete() {
            var ret = new ScriptDom.SchemaDeclarationItemOpenjson();
            ret.AsJson = asJson;
            ret.ColumnDefinition = (ScriptDom.ColumnDefinitionBase)columnDefinition.ToMutable();
            ret.Mapping = (ScriptDom.ValueExpression)mapping.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + asJson.GetHashCode();
            if (!(columnDefinition is null)) {
                h = h * 23 + columnDefinition.GetHashCode();
            }
            if (!(mapping is null)) {
                h = h * 23 + mapping.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SchemaDeclarationItemOpenjson);
        } 
        
        public bool Equals(SchemaDeclarationItemOpenjson other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.AsJson, asJson)) {
                return false;
            }
            if (!EqualityComparer<ColumnDefinitionBase>.Default.Equals(other.ColumnDefinition, columnDefinition)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.Mapping, mapping)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SchemaDeclarationItemOpenjson left, SchemaDeclarationItemOpenjson right) {
            return EqualityComparer<SchemaDeclarationItemOpenjson>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SchemaDeclarationItemOpenjson left, SchemaDeclarationItemOpenjson right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SchemaDeclarationItemOpenjson)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.asJson, othr.asJson);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.columnDefinition, othr.columnDefinition);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.mapping, othr.mapping);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static SchemaDeclarationItemOpenjson FromMutable(ScriptDom.SchemaDeclarationItemOpenjson fragment) {
            return (SchemaDeclarationItemOpenjson)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
