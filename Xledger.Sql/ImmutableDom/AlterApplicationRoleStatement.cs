using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterApplicationRoleStatement : ApplicationRoleStatement, IEquatable<AlterApplicationRoleStatement> {
        public AlterApplicationRoleStatement(Identifier name = null, IReadOnlyList<ApplicationRoleOption> applicationRoleOptions = null) {
            this.name = name;
            this.applicationRoleOptions = ImmList<ApplicationRoleOption>.FromList(applicationRoleOptions);
        }
    
        public ScriptDom.AlterApplicationRoleStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterApplicationRoleStatement();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.ApplicationRoleOptions.AddRange(applicationRoleOptions.SelectList(c => (ScriptDom.ApplicationRoleOption)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + applicationRoleOptions.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterApplicationRoleStatement);
        } 
        
        public bool Equals(AlterApplicationRoleStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ApplicationRoleOption>>.Default.Equals(other.ApplicationRoleOptions, applicationRoleOptions)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterApplicationRoleStatement left, AlterApplicationRoleStatement right) {
            return EqualityComparer<AlterApplicationRoleStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterApplicationRoleStatement left, AlterApplicationRoleStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterApplicationRoleStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.applicationRoleOptions, othr.applicationRoleOptions);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterApplicationRoleStatement left, AlterApplicationRoleStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterApplicationRoleStatement left, AlterApplicationRoleStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterApplicationRoleStatement left, AlterApplicationRoleStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterApplicationRoleStatement left, AlterApplicationRoleStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterApplicationRoleStatement FromMutable(ScriptDom.AlterApplicationRoleStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterApplicationRoleStatement)) { throw new NotImplementedException("Unexpected subtype of AlterApplicationRoleStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterApplicationRoleStatement(
                name: ImmutableDom.Identifier.FromMutable(fragment.Name),
                applicationRoleOptions: fragment.ApplicationRoleOptions.SelectList(ImmutableDom.ApplicationRoleOption.FromMutable)
            );
        }
    
    }

}
