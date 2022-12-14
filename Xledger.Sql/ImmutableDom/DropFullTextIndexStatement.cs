using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropFullTextIndexStatement : TSqlStatement, IEquatable<DropFullTextIndexStatement> {
        protected SchemaObjectName tableName;
    
        public SchemaObjectName TableName => tableName;
    
        public DropFullTextIndexStatement(SchemaObjectName tableName = null) {
            this.tableName = tableName;
        }
    
        public ScriptDom.DropFullTextIndexStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropFullTextIndexStatement();
            ret.TableName = (ScriptDom.SchemaObjectName)tableName?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(tableName is null)) {
                h = h * 23 + tableName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropFullTextIndexStatement);
        } 
        
        public bool Equals(DropFullTextIndexStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.TableName, tableName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropFullTextIndexStatement left, DropFullTextIndexStatement right) {
            return EqualityComparer<DropFullTextIndexStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropFullTextIndexStatement left, DropFullTextIndexStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DropFullTextIndexStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.tableName, othr.tableName);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (DropFullTextIndexStatement left, DropFullTextIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DropFullTextIndexStatement left, DropFullTextIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DropFullTextIndexStatement left, DropFullTextIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DropFullTextIndexStatement left, DropFullTextIndexStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static DropFullTextIndexStatement FromMutable(ScriptDom.DropFullTextIndexStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.DropFullTextIndexStatement)) { throw new NotImplementedException("Unexpected subtype of DropFullTextIndexStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropFullTextIndexStatement(
                tableName: ImmutableDom.SchemaObjectName.FromMutable(fragment.TableName)
            );
        }
    
    }

}
