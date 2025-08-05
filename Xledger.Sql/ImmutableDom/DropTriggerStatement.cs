using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropTriggerStatement : DropObjectsStatement, IEquatable<DropTriggerStatement> {
        protected ScriptDom.TriggerScope triggerScope = ScriptDom.TriggerScope.Normal;
    
        public ScriptDom.TriggerScope TriggerScope => triggerScope;
    
        public DropTriggerStatement(ScriptDom.TriggerScope triggerScope = ScriptDom.TriggerScope.Normal, IReadOnlyList<SchemaObjectName> objects = null, bool isIfExists = false) {
            this.triggerScope = triggerScope;
            this.objects = objects.ToImmArray<SchemaObjectName>();
            this.isIfExists = isIfExists;
        }
    
        public ScriptDom.DropTriggerStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropTriggerStatement();
            ret.TriggerScope = triggerScope;
            ret.Objects.AddRange(objects.Select(c => (ScriptDom.SchemaObjectName)c?.ToMutable()));
            ret.IsIfExists = isIfExists;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + triggerScope.GetHashCode();
            h = h * 23 + objects.GetHashCode();
            h = h * 23 + isIfExists.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropTriggerStatement);
        } 
        
        public bool Equals(DropTriggerStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.TriggerScope>.Default.Equals(other.TriggerScope, triggerScope)) {
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
        
        public static bool operator ==(DropTriggerStatement left, DropTriggerStatement right) {
            return EqualityComparer<DropTriggerStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropTriggerStatement left, DropTriggerStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (DropTriggerStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.triggerScope, othr.triggerScope);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.objects, othr.objects);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isIfExists, othr.isIfExists);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (DropTriggerStatement left, DropTriggerStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(DropTriggerStatement left, DropTriggerStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (DropTriggerStatement left, DropTriggerStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(DropTriggerStatement left, DropTriggerStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static DropTriggerStatement FromMutable(ScriptDom.DropTriggerStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.DropTriggerStatement)) { throw new NotImplementedException("Unexpected subtype of DropTriggerStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new DropTriggerStatement(
                triggerScope: fragment.TriggerScope,
                objects: fragment.Objects.ToImmArray(ImmutableDom.SchemaObjectName.FromMutable),
                isIfExists: fragment.IsIfExists
            );
        }
    
    }

}
