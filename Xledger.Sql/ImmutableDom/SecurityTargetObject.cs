using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SecurityTargetObject : TSqlFragment, IEquatable<SecurityTargetObject> {
        protected ScriptDom.SecurityObjectKind objectKind = ScriptDom.SecurityObjectKind.NotSpecified;
        protected SecurityTargetObjectName objectName;
        protected IReadOnlyList<Identifier> columns;
    
        public ScriptDom.SecurityObjectKind ObjectKind => objectKind;
        public SecurityTargetObjectName ObjectName => objectName;
        public IReadOnlyList<Identifier> Columns => columns;
    
        public SecurityTargetObject(ScriptDom.SecurityObjectKind objectKind = ScriptDom.SecurityObjectKind.NotSpecified, SecurityTargetObjectName objectName = null, IReadOnlyList<Identifier> columns = null) {
            this.objectKind = objectKind;
            this.objectName = objectName;
            this.columns = ImmList<Identifier>.FromList(columns);
        }
    
        public ScriptDom.SecurityTargetObject ToMutableConcrete() {
            var ret = new ScriptDom.SecurityTargetObject();
            ret.ObjectKind = objectKind;
            ret.ObjectName = (ScriptDom.SecurityTargetObjectName)objectName.ToMutable();
            ret.Columns.AddRange(columns.SelectList(c => (ScriptDom.Identifier)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + objectKind.GetHashCode();
            if (!(objectName is null)) {
                h = h * 23 + objectName.GetHashCode();
            }
            h = h * 23 + columns.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SecurityTargetObject);
        } 
        
        public bool Equals(SecurityTargetObject other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.SecurityObjectKind>.Default.Equals(other.ObjectKind, objectKind)) {
                return false;
            }
            if (!EqualityComparer<SecurityTargetObjectName>.Default.Equals(other.ObjectName, objectName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SecurityTargetObject left, SecurityTargetObject right) {
            return EqualityComparer<SecurityTargetObject>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SecurityTargetObject left, SecurityTargetObject right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SecurityTargetObject)that;
            compare = Comparer.DefaultInvariant.Compare(this.objectKind, othr.objectKind);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.objectName, othr.objectName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.columns, othr.columns);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (SecurityTargetObject left, SecurityTargetObject right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SecurityTargetObject left, SecurityTargetObject right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SecurityTargetObject left, SecurityTargetObject right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SecurityTargetObject left, SecurityTargetObject right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SecurityTargetObject FromMutable(ScriptDom.SecurityTargetObject fragment) {
            return (SecurityTargetObject)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
