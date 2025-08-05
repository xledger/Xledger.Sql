using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropAssemblyStatement : DropObjectsStatement, IEquatable<DropAssemblyStatement> {
        protected bool withNoDependents = false;
    
        public bool WithNoDependents => withNoDependents;
    
        public DropAssemblyStatement(bool withNoDependents = false, IReadOnlyList<SchemaObjectName> objects = null, bool isIfExists = false) {
            this.withNoDependents = withNoDependents;
            this.objects = objects.ToImmArray<SchemaObjectName>();
            this.isIfExists = isIfExists;
        }
    
        public ScriptDom.DropAssemblyStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropAssemblyStatement();
            ret.WithNoDependents = withNoDependents;
            ret.Objects.AddRange(objects.Select(c => (ScriptDom.SchemaObjectName)c?.ToMutable()));
            ret.IsIfExists = isIfExists;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + withNoDependents.GetHashCode();
            h = h * 23 + objects.GetHashCode();
            h = h * 23 + isIfExists.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropAssemblyStatement);
        } 
        
        public bool Equals(DropAssemblyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.WithNoDependents, withNoDependents)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<SchemaObjectName>>.Default.Equals(other.Objects, objects)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsIfExists, isIfExists)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropAssemblyStatement left, DropAssemblyStatement right) {
            return EqualityComparer<DropAssemblyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropAssemblyStatement left, DropAssemblyStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DropAssemblyStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.withNoDependents, othr.withNoDependents);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.objects, othr.objects);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isIfExists, othr.isIfExists);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (DropAssemblyStatement left, DropAssemblyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DropAssemblyStatement left, DropAssemblyStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DropAssemblyStatement left, DropAssemblyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DropAssemblyStatement left, DropAssemblyStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static DropAssemblyStatement FromMutable(ScriptDom.DropAssemblyStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.DropAssemblyStatement)) { throw new NotImplementedException("Unexpected subtype of DropAssemblyStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropAssemblyStatement(
                withNoDependents: fragment.WithNoDependents,
                objects: fragment.Objects.ToImmArray(ImmutableDom.SchemaObjectName.FromMutable),
                isIfExists: fragment.IsIfExists
            );
        }
    
    }

}
