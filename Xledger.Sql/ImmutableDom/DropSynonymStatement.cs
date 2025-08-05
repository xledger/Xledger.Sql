using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropSynonymStatement : DropObjectsStatement, IEquatable<DropSynonymStatement> {
        public DropSynonymStatement(IReadOnlyList<SchemaObjectName> objects = null, bool isIfExists = false) {
            this.objects = objects.ToImmArray<SchemaObjectName>();
            this.isIfExists = isIfExists;
        }
    
        public ScriptDom.DropSynonymStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropSynonymStatement();
            ret.Objects.AddRange(objects.Select(c => (ScriptDom.SchemaObjectName)c?.ToMutable()));
            ret.IsIfExists = isIfExists;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + objects.GetHashCode();
            h = h * 23 + isIfExists.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropSynonymStatement);
        } 
        
        public bool Equals(DropSynonymStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<SchemaObjectName>>.Default.Equals(other.Objects, objects)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsIfExists, isIfExists)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropSynonymStatement left, DropSynonymStatement right) {
            return EqualityComparer<DropSynonymStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropSynonymStatement left, DropSynonymStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DropSynonymStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.objects, othr.objects);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isIfExists, othr.isIfExists);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (DropSynonymStatement left, DropSynonymStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DropSynonymStatement left, DropSynonymStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DropSynonymStatement left, DropSynonymStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DropSynonymStatement left, DropSynonymStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static DropSynonymStatement FromMutable(ScriptDom.DropSynonymStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.DropSynonymStatement)) { throw new NotImplementedException("Unexpected subtype of DropSynonymStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropSynonymStatement(
                objects: fragment.Objects.ToImmArray(ImmutableDom.SchemaObjectName.FromMutable),
                isIfExists: fragment.IsIfExists
            );
        }
    
    }

}
