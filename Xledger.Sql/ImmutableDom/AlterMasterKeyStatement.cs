using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterMasterKeyStatement : MasterKeyStatement, IEquatable<AlterMasterKeyStatement> {
        protected ScriptDom.AlterMasterKeyOption option = ScriptDom.AlterMasterKeyOption.None;
    
        public ScriptDom.AlterMasterKeyOption Option => option;
    
        public AlterMasterKeyStatement(ScriptDom.AlterMasterKeyOption option = ScriptDom.AlterMasterKeyOption.None, Literal password = null) {
            this.option = option;
            this.password = password;
        }
    
        public ScriptDom.AlterMasterKeyStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterMasterKeyStatement();
            ret.Option = option;
            ret.Password = (ScriptDom.Literal)password.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + option.GetHashCode();
            if (!(password is null)) {
                h = h * 23 + password.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterMasterKeyStatement);
        } 
        
        public bool Equals(AlterMasterKeyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.AlterMasterKeyOption>.Default.Equals(other.Option, option)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Password, password)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterMasterKeyStatement left, AlterMasterKeyStatement right) {
            return EqualityComparer<AlterMasterKeyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterMasterKeyStatement left, AlterMasterKeyStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterMasterKeyStatement)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.option, othr.option);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.password, othr.password);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static AlterMasterKeyStatement FromMutable(ScriptDom.AlterMasterKeyStatement fragment) {
            return (AlterMasterKeyStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
