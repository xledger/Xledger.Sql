using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ColumnDefinitionBase : TSqlFragment, IEquatable<ColumnDefinitionBase> {
        protected Identifier columnIdentifier;
        protected DataTypeReference dataType;
        protected Identifier collation;
    
        public Identifier ColumnIdentifier => columnIdentifier;
        public DataTypeReference DataType => dataType;
        public Identifier Collation => collation;
    
        public ColumnDefinitionBase(Identifier columnIdentifier = null, DataTypeReference dataType = null, Identifier collation = null) {
            this.columnIdentifier = columnIdentifier;
            this.dataType = dataType;
            this.collation = collation;
        }
    
        public ScriptDom.ColumnDefinitionBase ToMutableConcrete() {
            var ret = new ScriptDom.ColumnDefinitionBase();
            ret.ColumnIdentifier = (ScriptDom.Identifier)columnIdentifier?.ToMutable();
            ret.DataType = (ScriptDom.DataTypeReference)dataType?.ToMutable();
            ret.Collation = (ScriptDom.Identifier)collation?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
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
            return Equals(obj as ColumnDefinitionBase);
        } 
        
        public bool Equals(ColumnDefinitionBase other) {
            if (other is null) { return false; }
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
        
        public static bool operator ==(ColumnDefinitionBase left, ColumnDefinitionBase right) {
            return EqualityComparer<ColumnDefinitionBase>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ColumnDefinitionBase left, ColumnDefinitionBase right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ColumnDefinitionBase)that;
            compare = Comparer.DefaultInvariant.Compare(this.columnIdentifier, othr.columnIdentifier);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.dataType, othr.dataType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ColumnDefinitionBase left, ColumnDefinitionBase right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ColumnDefinitionBase left, ColumnDefinitionBase right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ColumnDefinitionBase left, ColumnDefinitionBase right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ColumnDefinitionBase left, ColumnDefinitionBase right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ColumnDefinitionBase FromMutable(ScriptDom.ColumnDefinitionBase fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ColumnDefinitionBase)) { return TSqlFragment.FromMutable(fragment) as ColumnDefinitionBase; }
            return new ColumnDefinitionBase(
                columnIdentifier: ImmutableDom.Identifier.FromMutable(fragment.ColumnIdentifier),
                dataType: ImmutableDom.DataTypeReference.FromMutable(fragment.DataType),
                collation: ImmutableDom.Identifier.FromMutable(fragment.Collation)
            );
        }
    
    }

}
