using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SchemaPayloadOption : PayloadOption, IEquatable<SchemaPayloadOption> {
        protected bool isStandard = false;
    
        public bool IsStandard => isStandard;
    
        public SchemaPayloadOption(bool isStandard = false, ScriptDom.PayloadOptionKinds kind = ScriptDom.PayloadOptionKinds.None) {
            this.isStandard = isStandard;
            this.kind = kind;
        }
    
        public ScriptDom.SchemaPayloadOption ToMutableConcrete() {
            var ret = new ScriptDom.SchemaPayloadOption();
            ret.IsStandard = isStandard;
            ret.Kind = kind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isStandard.GetHashCode();
            h = h * 23 + kind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SchemaPayloadOption);
        } 
        
        public bool Equals(SchemaPayloadOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsStandard, isStandard)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.PayloadOptionKinds>.Default.Equals(other.Kind, kind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SchemaPayloadOption left, SchemaPayloadOption right) {
            return EqualityComparer<SchemaPayloadOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SchemaPayloadOption left, SchemaPayloadOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SchemaPayloadOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.isStandard, othr.isStandard);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.kind, othr.kind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (SchemaPayloadOption left, SchemaPayloadOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SchemaPayloadOption left, SchemaPayloadOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SchemaPayloadOption left, SchemaPayloadOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SchemaPayloadOption left, SchemaPayloadOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SchemaPayloadOption FromMutable(ScriptDom.SchemaPayloadOption fragment) {
            return (SchemaPayloadOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
