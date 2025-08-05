using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class IdentityOptions : TSqlFragment, IEquatable<IdentityOptions> {
        protected ScalarExpression identitySeed;
        protected ScalarExpression identityIncrement;
        protected bool isIdentityNotForReplication = false;
    
        public ScalarExpression IdentitySeed => identitySeed;
        public ScalarExpression IdentityIncrement => identityIncrement;
        public bool IsIdentityNotForReplication => isIdentityNotForReplication;
    
        public IdentityOptions(ScalarExpression identitySeed = null, ScalarExpression identityIncrement = null, bool isIdentityNotForReplication = false) {
            this.identitySeed = identitySeed;
            this.identityIncrement = identityIncrement;
            this.isIdentityNotForReplication = isIdentityNotForReplication;
        }
    
        public ScriptDom.IdentityOptions ToMutableConcrete() {
            var ret = new ScriptDom.IdentityOptions();
            ret.IdentitySeed = (ScriptDom.ScalarExpression)identitySeed?.ToMutable();
            ret.IdentityIncrement = (ScriptDom.ScalarExpression)identityIncrement?.ToMutable();
            ret.IsIdentityNotForReplication = isIdentityNotForReplication;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(identitySeed is null)) {
                h = h * 23 + identitySeed.GetHashCode();
            }
            if (!(identityIncrement is null)) {
                h = h * 23 + identityIncrement.GetHashCode();
            }
            h = h * 23 + isIdentityNotForReplication.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as IdentityOptions);
        } 
        
        public bool Equals(IdentityOptions other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.IdentitySeed, identitySeed)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.IdentityIncrement, identityIncrement)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsIdentityNotForReplication, isIdentityNotForReplication)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(IdentityOptions left, IdentityOptions right) {
            return EqualityComparer<IdentityOptions>.Default.Equals(left, right);
        }
        
        public static bool operator !=(IdentityOptions left, IdentityOptions right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (IdentityOptions)that;
            compare = Comparer.DefaultInvariant.Compare(this.identitySeed, othr.identitySeed);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.identityIncrement, othr.identityIncrement);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isIdentityNotForReplication, othr.isIdentityNotForReplication);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (IdentityOptions left, IdentityOptions right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(IdentityOptions left, IdentityOptions right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (IdentityOptions left, IdentityOptions right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(IdentityOptions left, IdentityOptions right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static IdentityOptions FromMutable(ScriptDom.IdentityOptions fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.IdentityOptions)) { throw new NotImplementedException("Unexpected subtype of IdentityOptions not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new IdentityOptions(
                identitySeed: ImmutableDom.ScalarExpression.FromMutable(fragment.IdentitySeed),
                identityIncrement: ImmutableDom.ScalarExpression.FromMutable(fragment.IdentityIncrement),
                isIdentityNotForReplication: fragment.IsIdentityNotForReplication
            );
        }
    
    }

}
