using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropProcedureStatement : DropObjectsStatement, IEquatable<DropProcedureStatement> {
        public DropProcedureStatement(IReadOnlyList<SchemaObjectName> objects = null, bool isIfExists = false) {
            this.objects = ImmList<SchemaObjectName>.FromList(objects);
            this.isIfExists = isIfExists;
        }
    
        public ScriptDom.DropProcedureStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropProcedureStatement();
            ret.Objects.AddRange(objects.SelectList(c => (ScriptDom.SchemaObjectName)c?.ToMutable()));
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
            return Equals(obj as DropProcedureStatement);
        } 
        
        public bool Equals(DropProcedureStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<SchemaObjectName>>.Default.Equals(other.Objects, objects)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsIfExists, isIfExists)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropProcedureStatement left, DropProcedureStatement right) {
            return EqualityComparer<DropProcedureStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropProcedureStatement left, DropProcedureStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DropProcedureStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.objects, othr.objects);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isIfExists, othr.isIfExists);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (DropProcedureStatement left, DropProcedureStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DropProcedureStatement left, DropProcedureStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DropProcedureStatement left, DropProcedureStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DropProcedureStatement left, DropProcedureStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static DropProcedureStatement FromMutable(ScriptDom.DropProcedureStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.DropProcedureStatement)) { throw new NotImplementedException("Unexpected subtype of DropProcedureStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropProcedureStatement(
                objects: fragment.Objects.SelectList(ImmutableDom.SchemaObjectName.FromMutable),
                isIfExists: fragment.IsIfExists
            );
        }
    
    }

}
