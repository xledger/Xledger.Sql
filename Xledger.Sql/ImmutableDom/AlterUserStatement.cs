using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterUserStatement : UserStatement, IEquatable<AlterUserStatement> {
        public AlterUserStatement(Identifier name = null, IReadOnlyList<PrincipalOption> userOptions = null) {
            this.name = name;
            this.userOptions = ImmList<PrincipalOption>.FromList(userOptions);
        }
    
        public ScriptDom.AlterUserStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterUserStatement();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.UserOptions.AddRange(userOptions.SelectList(c => (ScriptDom.PrincipalOption)c?.ToMutable()));
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
            h = h * 23 + userOptions.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterUserStatement);
        } 
        
        public bool Equals(AlterUserStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<PrincipalOption>>.Default.Equals(other.UserOptions, userOptions)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterUserStatement left, AlterUserStatement right) {
            return EqualityComparer<AlterUserStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterUserStatement left, AlterUserStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterUserStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.userOptions, othr.userOptions);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AlterUserStatement left, AlterUserStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterUserStatement left, AlterUserStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterUserStatement left, AlterUserStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterUserStatement left, AlterUserStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
