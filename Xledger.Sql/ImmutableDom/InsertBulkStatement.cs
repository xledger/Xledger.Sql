using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class InsertBulkStatement : BulkInsertBase, IEquatable<InsertBulkStatement> {
        protected IReadOnlyList<InsertBulkColumnDefinition> columnDefinitions;
    
        public IReadOnlyList<InsertBulkColumnDefinition> ColumnDefinitions => columnDefinitions;
    
        public InsertBulkStatement(IReadOnlyList<InsertBulkColumnDefinition> columnDefinitions = null, SchemaObjectName to = null, IReadOnlyList<BulkInsertOption> options = null) {
            this.columnDefinitions = columnDefinitions is null ? ImmList<InsertBulkColumnDefinition>.Empty : ImmList<InsertBulkColumnDefinition>.FromList(columnDefinitions);
            this.to = to;
            this.options = options is null ? ImmList<BulkInsertOption>.Empty : ImmList<BulkInsertOption>.FromList(options);
        }
    
        public ScriptDom.InsertBulkStatement ToMutableConcrete() {
            var ret = new ScriptDom.InsertBulkStatement();
            ret.ColumnDefinitions.AddRange(columnDefinitions.SelectList(c => (ScriptDom.InsertBulkColumnDefinition)c.ToMutable()));
            ret.To = (ScriptDom.SchemaObjectName)to.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.BulkInsertOption)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + columnDefinitions.GetHashCode();
            if (!(to is null)) {
                h = h * 23 + to.GetHashCode();
            }
            h = h * 23 + options.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as InsertBulkStatement);
        } 
        
        public bool Equals(InsertBulkStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<InsertBulkColumnDefinition>>.Default.Equals(other.ColumnDefinitions, columnDefinitions)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.To, to)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<BulkInsertOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(InsertBulkStatement left, InsertBulkStatement right) {
            return EqualityComparer<InsertBulkStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(InsertBulkStatement left, InsertBulkStatement right) {
            return !(left == right);
        }
    
        public static InsertBulkStatement FromMutable(ScriptDom.InsertBulkStatement fragment) {
            return (InsertBulkStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
