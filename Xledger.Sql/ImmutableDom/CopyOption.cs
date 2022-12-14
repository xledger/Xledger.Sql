using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CopyOption : TSqlFragment, IEquatable<CopyOption> {
        protected ScriptDom.CopyOptionKind kind = 0;
        protected CopyStatementOptionBase @value;
    
        public ScriptDom.CopyOptionKind Kind => kind;
        public CopyStatementOptionBase Value => @value;
    
        public CopyOption(ScriptDom.CopyOptionKind kind = 0, CopyStatementOptionBase @value = null) {
            this.kind = kind;
            this.@value = @value;
        }
    
        public ScriptDom.CopyOption ToMutableConcrete() {
            var ret = new ScriptDom.CopyOption();
            ret.Kind = kind;
            ret.Value = (ScriptDom.CopyStatementOptionBase)@value?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + kind.GetHashCode();
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CopyOption);
        } 
        
        public bool Equals(CopyOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.CopyOptionKind>.Default.Equals(other.Kind, kind)) {
                return false;
            }
            if (!EqualityComparer<CopyStatementOptionBase>.Default.Equals(other.Value, @value)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CopyOption left, CopyOption right) {
            return EqualityComparer<CopyOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CopyOption left, CopyOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CopyOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.kind, othr.kind);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CopyOption left, CopyOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CopyOption left, CopyOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CopyOption left, CopyOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CopyOption left, CopyOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CopyOption FromMutable(ScriptDom.CopyOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CopyOption)) { throw new NotImplementedException("Unexpected subtype of CopyOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CopyOption(
                kind: fragment.Kind,
                @value: ImmutableDom.CopyStatementOptionBase.FromMutable(fragment.Value)
            );
        }
    
    }

}
