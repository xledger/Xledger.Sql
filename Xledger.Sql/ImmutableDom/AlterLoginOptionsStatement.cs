using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterLoginOptionsStatement : AlterLoginStatement, IEquatable<AlterLoginOptionsStatement> {
        protected IReadOnlyList<PrincipalOption> options;
    
        public IReadOnlyList<PrincipalOption> Options => options;
    
        public AlterLoginOptionsStatement(IReadOnlyList<PrincipalOption> options = null, Identifier name = null) {
            this.options = options.ToImmArray<PrincipalOption>();
            this.name = name;
        }
    
        public ScriptDom.AlterLoginOptionsStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterLoginOptionsStatement();
            ret.Options.AddRange(options.Select(c => (ScriptDom.PrincipalOption)c?.ToMutable()));
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + options.GetHashCode();
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterLoginOptionsStatement);
        } 
        
        public bool Equals(AlterLoginOptionsStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<PrincipalOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterLoginOptionsStatement left, AlterLoginOptionsStatement right) {
            return EqualityComparer<AlterLoginOptionsStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterLoginOptionsStatement left, AlterLoginOptionsStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterLoginOptionsStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterLoginOptionsStatement left, AlterLoginOptionsStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterLoginOptionsStatement left, AlterLoginOptionsStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterLoginOptionsStatement left, AlterLoginOptionsStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterLoginOptionsStatement left, AlterLoginOptionsStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterLoginOptionsStatement FromMutable(ScriptDom.AlterLoginOptionsStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterLoginOptionsStatement)) { throw new NotImplementedException("Unexpected subtype of AlterLoginOptionsStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterLoginOptionsStatement(
                options: fragment.Options.ToImmArray(ImmutableDom.PrincipalOption.FromMutable),
                name: ImmutableDom.Identifier.FromMutable(fragment.Name)
            );
        }
    
    }

}
