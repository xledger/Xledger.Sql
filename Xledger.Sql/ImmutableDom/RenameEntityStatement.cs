using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class RenameEntityStatement : TSqlStatement, IEquatable<RenameEntityStatement> {
        protected ScriptDom.SecurityObjectKind renameEntityType = ScriptDom.SecurityObjectKind.NotSpecified;
        protected ScriptDom.SeparatorType? separatorType;
        protected SchemaObjectName oldName;
        protected Identifier newName;
    
        public ScriptDom.SecurityObjectKind RenameEntityType => renameEntityType;
        public ScriptDom.SeparatorType? SeparatorType => separatorType;
        public SchemaObjectName OldName => oldName;
        public Identifier NewName => newName;
    
        public RenameEntityStatement(ScriptDom.SecurityObjectKind renameEntityType = ScriptDom.SecurityObjectKind.NotSpecified, ScriptDom.SeparatorType? separatorType = null, SchemaObjectName oldName = null, Identifier newName = null) {
            this.renameEntityType = renameEntityType;
            this.separatorType = separatorType;
            this.oldName = oldName;
            this.newName = newName;
        }
    
        public ScriptDom.RenameEntityStatement ToMutableConcrete() {
            var ret = new ScriptDom.RenameEntityStatement();
            ret.RenameEntityType = renameEntityType;
            ret.SeparatorType = separatorType;
            ret.OldName = (ScriptDom.SchemaObjectName)oldName?.ToMutable();
            ret.NewName = (ScriptDom.Identifier)newName?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + renameEntityType.GetHashCode();
            h = h * 23 + separatorType.GetHashCode();
            if (!(oldName is null)) {
                h = h * 23 + oldName.GetHashCode();
            }
            if (!(newName is null)) {
                h = h * 23 + newName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as RenameEntityStatement);
        } 
        
        public bool Equals(RenameEntityStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.SecurityObjectKind>.Default.Equals(other.RenameEntityType, renameEntityType)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.SeparatorType?>.Default.Equals(other.SeparatorType, separatorType)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.OldName, oldName)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.NewName, newName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(RenameEntityStatement left, RenameEntityStatement right) {
            return EqualityComparer<RenameEntityStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(RenameEntityStatement left, RenameEntityStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (RenameEntityStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.renameEntityType, othr.renameEntityType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.separatorType, othr.separatorType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.oldName, othr.oldName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.newName, othr.newName);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (RenameEntityStatement left, RenameEntityStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(RenameEntityStatement left, RenameEntityStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (RenameEntityStatement left, RenameEntityStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(RenameEntityStatement left, RenameEntityStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static RenameEntityStatement FromMutable(ScriptDom.RenameEntityStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.RenameEntityStatement)) { throw new NotImplementedException("Unexpected subtype of RenameEntityStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new RenameEntityStatement(
                renameEntityType: fragment.RenameEntityType,
                separatorType: fragment.SeparatorType,
                oldName: ImmutableDom.SchemaObjectName.FromMutable(fragment.OldName),
                newName: ImmutableDom.Identifier.FromMutable(fragment.NewName)
            );
        }
    
    }

}
