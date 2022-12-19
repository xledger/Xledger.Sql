using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropQueueStatement : TSqlStatement, IEquatable<DropQueueStatement> {
        protected SchemaObjectName name;
    
        public SchemaObjectName Name => name;
    
        public DropQueueStatement(SchemaObjectName name = null) {
            this.name = name;
        }
    
        public ScriptDom.DropQueueStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropQueueStatement();
            ret.Name = (ScriptDom.SchemaObjectName)name?.ToMutable();
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
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropQueueStatement);
        } 
        
        public bool Equals(DropQueueStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropQueueStatement left, DropQueueStatement right) {
            return EqualityComparer<DropQueueStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropQueueStatement left, DropQueueStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DropQueueStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (DropQueueStatement left, DropQueueStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DropQueueStatement left, DropQueueStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DropQueueStatement left, DropQueueStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DropQueueStatement left, DropQueueStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static DropQueueStatement FromMutable(ScriptDom.DropQueueStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.DropQueueStatement)) { throw new NotImplementedException("Unexpected subtype of DropQueueStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropQueueStatement(
                name: ImmutableDom.SchemaObjectName.FromMutable(fragment.Name)
            );
        }
    
    }

}
