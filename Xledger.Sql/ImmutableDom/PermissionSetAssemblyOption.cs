using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class PermissionSetAssemblyOption : AssemblyOption, IEquatable<PermissionSetAssemblyOption> {
        protected ScriptDom.PermissionSetOption permissionSetOption = ScriptDom.PermissionSetOption.None;
    
        public ScriptDom.PermissionSetOption PermissionSetOption => permissionSetOption;
    
        public PermissionSetAssemblyOption(ScriptDom.PermissionSetOption permissionSetOption = ScriptDom.PermissionSetOption.None, ScriptDom.AssemblyOptionKind optionKind = ScriptDom.AssemblyOptionKind.PermissionSet) {
            this.permissionSetOption = permissionSetOption;
            this.optionKind = optionKind;
        }
    
        public new ScriptDom.PermissionSetAssemblyOption ToMutableConcrete() {
            var ret = new ScriptDom.PermissionSetAssemblyOption();
            ret.PermissionSetOption = permissionSetOption;
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + permissionSetOption.GetHashCode();
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as PermissionSetAssemblyOption);
        } 
        
        public bool Equals(PermissionSetAssemblyOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.PermissionSetOption>.Default.Equals(other.PermissionSetOption, permissionSetOption)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AssemblyOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(PermissionSetAssemblyOption left, PermissionSetAssemblyOption right) {
            return EqualityComparer<PermissionSetAssemblyOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(PermissionSetAssemblyOption left, PermissionSetAssemblyOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (PermissionSetAssemblyOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.permissionSetOption, othr.permissionSetOption);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (PermissionSetAssemblyOption left, PermissionSetAssemblyOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(PermissionSetAssemblyOption left, PermissionSetAssemblyOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (PermissionSetAssemblyOption left, PermissionSetAssemblyOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(PermissionSetAssemblyOption left, PermissionSetAssemblyOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static PermissionSetAssemblyOption FromMutable(ScriptDom.PermissionSetAssemblyOption fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.PermissionSetAssemblyOption)) { throw new NotImplementedException("Unexpected subtype of PermissionSetAssemblyOption not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new PermissionSetAssemblyOption(
                permissionSetOption: fragment.PermissionSetOption,
                optionKind: fragment.OptionKind
            );
        }
    
    }

}
