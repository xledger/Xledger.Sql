using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ColumnDefinitionBase : TSqlFragment, IEquatable<ColumnDefinitionBase> {
        Identifier columnIdentifier;
        DataTypeReference dataType;
        Identifier collation;
    
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
    
    }

}
