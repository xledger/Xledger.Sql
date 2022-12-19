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
            this.columnDefinitions = ImmList<InsertBulkColumnDefinition>.FromList(columnDefinitions);
            this.to = to;
            this.options = ImmList<BulkInsertOption>.FromList(options);
        }
    
        public ScriptDom.InsertBulkStatement ToMutableConcrete() {
            var ret = new ScriptDom.InsertBulkStatement();
            ret.ColumnDefinitions.AddRange(columnDefinitions.SelectList(c => (ScriptDom.InsertBulkColumnDefinition)c?.ToMutable()));
            ret.To = (ScriptDom.SchemaObjectName)to?.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.BulkInsertOption)c?.ToMutable()));
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (InsertBulkStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.columnDefinitions, othr.columnDefinitions);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.to, othr.to);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (InsertBulkStatement left, InsertBulkStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(InsertBulkStatement left, InsertBulkStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (InsertBulkStatement left, InsertBulkStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(InsertBulkStatement left, InsertBulkStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static InsertBulkStatement FromMutable(ScriptDom.InsertBulkStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.InsertBulkStatement)) { throw new NotImplementedException("Unexpected subtype of InsertBulkStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new InsertBulkStatement(
                columnDefinitions: fragment.ColumnDefinitions.SelectList(ImmutableDom.InsertBulkColumnDefinition.FromMutable),
                to: ImmutableDom.SchemaObjectName.FromMutable(fragment.To),
                options: fragment.Options.SelectList(ImmutableDom.BulkInsertOption.FromMutable)
            );
        }
    
    }

}
