using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SchemaDeclarationItem : TSqlFragment, IEquatable<SchemaDeclarationItem> {
        protected ColumnDefinitionBase columnDefinition;
        protected ValueExpression mapping;
    
        public ColumnDefinitionBase ColumnDefinition => columnDefinition;
        public ValueExpression Mapping => mapping;
    
        public SchemaDeclarationItem(ColumnDefinitionBase columnDefinition = null, ValueExpression mapping = null) {
            this.columnDefinition = columnDefinition;
            this.mapping = mapping;
        }
    
        public ScriptDom.SchemaDeclarationItem ToMutableConcrete() {
            var ret = new ScriptDom.SchemaDeclarationItem();
            ret.ColumnDefinition = (ScriptDom.ColumnDefinitionBase)columnDefinition?.ToMutable();
            ret.Mapping = (ScriptDom.ValueExpression)mapping?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(columnDefinition is null)) {
                h = h * 23 + columnDefinition.GetHashCode();
            }
            if (!(mapping is null)) {
                h = h * 23 + mapping.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SchemaDeclarationItem);
        } 
        
        public bool Equals(SchemaDeclarationItem other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ColumnDefinitionBase>.Default.Equals(other.ColumnDefinition, columnDefinition)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.Mapping, mapping)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SchemaDeclarationItem left, SchemaDeclarationItem right) {
            return EqualityComparer<SchemaDeclarationItem>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SchemaDeclarationItem left, SchemaDeclarationItem right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SchemaDeclarationItem)that;
            compare = Comparer.DefaultInvariant.Compare(this.columnDefinition, othr.columnDefinition);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.mapping, othr.mapping);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (SchemaDeclarationItem left, SchemaDeclarationItem right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SchemaDeclarationItem left, SchemaDeclarationItem right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SchemaDeclarationItem left, SchemaDeclarationItem right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SchemaDeclarationItem left, SchemaDeclarationItem right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
