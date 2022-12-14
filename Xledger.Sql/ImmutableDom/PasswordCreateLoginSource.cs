using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class PasswordCreateLoginSource : CreateLoginSource, IEquatable<PasswordCreateLoginSource> {
        protected Literal password;
        protected bool hashed = false;
        protected bool mustChange = false;
        protected IReadOnlyList<PrincipalOption> options;
    
        public Literal Password => password;
        public bool Hashed => hashed;
        public bool MustChange => mustChange;
        public IReadOnlyList<PrincipalOption> Options => options;
    
        public PasswordCreateLoginSource(Literal password = null, bool hashed = false, bool mustChange = false, IReadOnlyList<PrincipalOption> options = null) {
            this.password = password;
            this.hashed = hashed;
            this.mustChange = mustChange;
            this.options = ImmList<PrincipalOption>.FromList(options);
        }
    
        public ScriptDom.PasswordCreateLoginSource ToMutableConcrete() {
            var ret = new ScriptDom.PasswordCreateLoginSource();
            ret.Password = (ScriptDom.Literal)password.ToMutable();
            ret.Hashed = hashed;
            ret.MustChange = mustChange;
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.PrincipalOption)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(password is null)) {
                h = h * 23 + password.GetHashCode();
            }
            h = h * 23 + hashed.GetHashCode();
            h = h * 23 + mustChange.GetHashCode();
            h = h * 23 + options.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as PasswordCreateLoginSource);
        } 
        
        public bool Equals(PasswordCreateLoginSource other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Password, password)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.Hashed, hashed)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.MustChange, mustChange)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<PrincipalOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(PasswordCreateLoginSource left, PasswordCreateLoginSource right) {
            return EqualityComparer<PasswordCreateLoginSource>.Default.Equals(left, right);
        }
        
        public static bool operator !=(PasswordCreateLoginSource left, PasswordCreateLoginSource right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (PasswordCreateLoginSource)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.password, othr.password);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.hashed, othr.hashed);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.mustChange, othr.mustChange);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static PasswordCreateLoginSource FromMutable(ScriptDom.PasswordCreateLoginSource fragment) {
            return (PasswordCreateLoginSource)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
