using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class InsertBulkColumnDefinition : TSqlFragment, IEquatable<InsertBulkColumnDefinition> {
        protected ColumnDefinitionBase column;
        protected ScriptDom.NullNotNull nullNotNull = ScriptDom.NullNotNull.NotSpecified;
    
        public ColumnDefinitionBase Column => column;
        public ScriptDom.NullNotNull NullNotNull => nullNotNull;
    
        public InsertBulkColumnDefinition(ColumnDefinitionBase column = null, ScriptDom.NullNotNull nullNotNull = ScriptDom.NullNotNull.NotSpecified) {
            this.column = column;
            this.nullNotNull = nullNotNull;
        }
    
        public ScriptDom.InsertBulkColumnDefinition ToMutableConcrete() {
            var ret = new ScriptDom.InsertBulkColumnDefinition();
            ret.Column = (ScriptDom.ColumnDefinitionBase)column.ToMutable();
            ret.NullNotNull = nullNotNull;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(column is null)) {
                h = h * 23 + column.GetHashCode();
            }
            h = h * 23 + nullNotNull.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as InsertBulkColumnDefinition);
        } 
        
        public bool Equals(InsertBulkColumnDefinition other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ColumnDefinitionBase>.Default.Equals(other.Column, column)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.NullNotNull>.Default.Equals(other.NullNotNull, nullNotNull)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(InsertBulkColumnDefinition left, InsertBulkColumnDefinition right) {
            return EqualityComparer<InsertBulkColumnDefinition>.Default.Equals(left, right);
        }
        
        public static bool operator !=(InsertBulkColumnDefinition left, InsertBulkColumnDefinition right) {
            return !(left == right);
        }
    
        public static InsertBulkColumnDefinition FromMutable(ScriptDom.InsertBulkColumnDefinition fragment) {
            return (InsertBulkColumnDefinition)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
