using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class WindowsCreateLoginSource : CreateLoginSource, IEquatable<WindowsCreateLoginSource> {
        protected IReadOnlyList<PrincipalOption> options;
    
        public IReadOnlyList<PrincipalOption> Options => options;
    
        public WindowsCreateLoginSource(IReadOnlyList<PrincipalOption> options = null) {
            this.options = ImmList<PrincipalOption>.FromList(options);
        }
    
        public ScriptDom.WindowsCreateLoginSource ToMutableConcrete() {
            var ret = new ScriptDom.WindowsCreateLoginSource();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.PrincipalOption)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + options.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as WindowsCreateLoginSource);
        } 
        
        public bool Equals(WindowsCreateLoginSource other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<PrincipalOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(WindowsCreateLoginSource left, WindowsCreateLoginSource right) {
            return EqualityComparer<WindowsCreateLoginSource>.Default.Equals(left, right);
        }
        
        public static bool operator !=(WindowsCreateLoginSource left, WindowsCreateLoginSource right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (WindowsCreateLoginSource)that;
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (WindowsCreateLoginSource left, WindowsCreateLoginSource right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(WindowsCreateLoginSource left, WindowsCreateLoginSource right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (WindowsCreateLoginSource left, WindowsCreateLoginSource right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(WindowsCreateLoginSource left, WindowsCreateLoginSource right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
