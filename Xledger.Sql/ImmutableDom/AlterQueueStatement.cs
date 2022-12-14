using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterQueueStatement : QueueStatement, IEquatable<AlterQueueStatement> {
        public AlterQueueStatement(SchemaObjectName name = null, IReadOnlyList<QueueOption> queueOptions = null) {
            this.name = name;
            this.queueOptions = ImmList<QueueOption>.FromList(queueOptions);
        }
    
        public ScriptDom.AlterQueueStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterQueueStatement();
            ret.Name = (ScriptDom.SchemaObjectName)name.ToMutable();
            ret.QueueOptions.AddRange(queueOptions.SelectList(c => (ScriptDom.QueueOption)c.ToMutable()));
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
            h = h * 23 + queueOptions.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterQueueStatement);
        } 
        
        public bool Equals(AlterQueueStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<QueueOption>>.Default.Equals(other.QueueOptions, queueOptions)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterQueueStatement left, AlterQueueStatement right) {
            return EqualityComparer<AlterQueueStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterQueueStatement left, AlterQueueStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterQueueStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.queueOptions, othr.queueOptions);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AlterQueueStatement left, AlterQueueStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterQueueStatement left, AlterQueueStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterQueueStatement left, AlterQueueStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterQueueStatement left, AlterQueueStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterQueueStatement FromMutable(ScriptDom.AlterQueueStatement fragment) {
            return (AlterQueueStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
