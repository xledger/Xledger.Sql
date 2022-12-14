using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterDatabaseModifyFileGroupStatement : AlterDatabaseStatement, IEquatable<AlterDatabaseModifyFileGroupStatement> {
        protected Identifier fileGroup;
        protected Identifier newFileGroupName;
        protected bool makeDefault = false;
        protected ScriptDom.ModifyFileGroupOption updatabilityOption = ScriptDom.ModifyFileGroupOption.None;
        protected AlterDatabaseTermination termination;
    
        public Identifier FileGroup => fileGroup;
        public Identifier NewFileGroupName => newFileGroupName;
        public bool MakeDefault => makeDefault;
        public ScriptDom.ModifyFileGroupOption UpdatabilityOption => updatabilityOption;
        public AlterDatabaseTermination Termination => termination;
    
        public AlterDatabaseModifyFileGroupStatement(Identifier fileGroup = null, Identifier newFileGroupName = null, bool makeDefault = false, ScriptDom.ModifyFileGroupOption updatabilityOption = ScriptDom.ModifyFileGroupOption.None, AlterDatabaseTermination termination = null, Identifier databaseName = null, bool useCurrent = false) {
            this.fileGroup = fileGroup;
            this.newFileGroupName = newFileGroupName;
            this.makeDefault = makeDefault;
            this.updatabilityOption = updatabilityOption;
            this.termination = termination;
            this.databaseName = databaseName;
            this.useCurrent = useCurrent;
        }
    
        public ScriptDom.AlterDatabaseModifyFileGroupStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterDatabaseModifyFileGroupStatement();
            ret.FileGroup = (ScriptDom.Identifier)fileGroup?.ToMutable();
            ret.NewFileGroupName = (ScriptDom.Identifier)newFileGroupName?.ToMutable();
            ret.MakeDefault = makeDefault;
            ret.UpdatabilityOption = updatabilityOption;
            ret.Termination = (ScriptDom.AlterDatabaseTermination)termination?.ToMutable();
            ret.DatabaseName = (ScriptDom.Identifier)databaseName?.ToMutable();
            ret.UseCurrent = useCurrent;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(fileGroup is null)) {
                h = h * 23 + fileGroup.GetHashCode();
            }
            if (!(newFileGroupName is null)) {
                h = h * 23 + newFileGroupName.GetHashCode();
            }
            h = h * 23 + makeDefault.GetHashCode();
            h = h * 23 + updatabilityOption.GetHashCode();
            if (!(termination is null)) {
                h = h * 23 + termination.GetHashCode();
            }
            if (!(databaseName is null)) {
                h = h * 23 + databaseName.GetHashCode();
            }
            h = h * 23 + useCurrent.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterDatabaseModifyFileGroupStatement);
        } 
        
        public bool Equals(AlterDatabaseModifyFileGroupStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.FileGroup, fileGroup)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.NewFileGroupName, newFileGroupName)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.MakeDefault, makeDefault)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ModifyFileGroupOption>.Default.Equals(other.UpdatabilityOption, updatabilityOption)) {
                return false;
            }
            if (!EqualityComparer<AlterDatabaseTermination>.Default.Equals(other.Termination, termination)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.DatabaseName, databaseName)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.UseCurrent, useCurrent)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterDatabaseModifyFileGroupStatement left, AlterDatabaseModifyFileGroupStatement right) {
            return EqualityComparer<AlterDatabaseModifyFileGroupStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterDatabaseModifyFileGroupStatement left, AlterDatabaseModifyFileGroupStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterDatabaseModifyFileGroupStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.fileGroup, othr.fileGroup);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.newFileGroupName, othr.newFileGroupName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.makeDefault, othr.makeDefault);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.updatabilityOption, othr.updatabilityOption);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.termination, othr.termination);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.databaseName, othr.databaseName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.useCurrent, othr.useCurrent);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterDatabaseModifyFileGroupStatement left, AlterDatabaseModifyFileGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterDatabaseModifyFileGroupStatement left, AlterDatabaseModifyFileGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterDatabaseModifyFileGroupStatement left, AlterDatabaseModifyFileGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterDatabaseModifyFileGroupStatement left, AlterDatabaseModifyFileGroupStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterDatabaseModifyFileGroupStatement FromMutable(ScriptDom.AlterDatabaseModifyFileGroupStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterDatabaseModifyFileGroupStatement)) { throw new NotImplementedException("Unexpected subtype of AlterDatabaseModifyFileGroupStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterDatabaseModifyFileGroupStatement(
                fileGroup: ImmutableDom.Identifier.FromMutable(fragment.FileGroup),
                newFileGroupName: ImmutableDom.Identifier.FromMutable(fragment.NewFileGroupName),
                makeDefault: fragment.MakeDefault,
                updatabilityOption: fragment.UpdatabilityOption,
                termination: ImmutableDom.AlterDatabaseTermination.FromMutable(fragment.Termination),
                databaseName: ImmutableDom.Identifier.FromMutable(fragment.DatabaseName),
                useCurrent: fragment.UseCurrent
            );
        }
    
    }

}
