using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BackupRestoreFileInfo : TSqlFragment, IEquatable<BackupRestoreFileInfo> {
        protected IReadOnlyList<ValueExpression> items;
        protected ScriptDom.BackupRestoreItemKind itemKind = ScriptDom.BackupRestoreItemKind.None;
    
        public IReadOnlyList<ValueExpression> Items => items;
        public ScriptDom.BackupRestoreItemKind ItemKind => itemKind;
    
        public BackupRestoreFileInfo(IReadOnlyList<ValueExpression> items = null, ScriptDom.BackupRestoreItemKind itemKind = ScriptDom.BackupRestoreItemKind.None) {
            this.items = ImmList<ValueExpression>.FromList(items);
            this.itemKind = itemKind;
        }
    
        public ScriptDom.BackupRestoreFileInfo ToMutableConcrete() {
            var ret = new ScriptDom.BackupRestoreFileInfo();
            ret.Items.AddRange(items.SelectList(c => (ScriptDom.ValueExpression)c?.ToMutable()));
            ret.ItemKind = itemKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + items.GetHashCode();
            h = h * 23 + itemKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as BackupRestoreFileInfo);
        } 
        
        public bool Equals(BackupRestoreFileInfo other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<ValueExpression>>.Default.Equals(other.Items, items)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.BackupRestoreItemKind>.Default.Equals(other.ItemKind, itemKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(BackupRestoreFileInfo left, BackupRestoreFileInfo right) {
            return EqualityComparer<BackupRestoreFileInfo>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BackupRestoreFileInfo left, BackupRestoreFileInfo right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (BackupRestoreFileInfo)that;
            compare = Comparer.DefaultInvariant.Compare(this.items, othr.items);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.itemKind, othr.itemKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (BackupRestoreFileInfo left, BackupRestoreFileInfo right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(BackupRestoreFileInfo left, BackupRestoreFileInfo right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (BackupRestoreFileInfo left, BackupRestoreFileInfo right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(BackupRestoreFileInfo left, BackupRestoreFileInfo right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static BackupRestoreFileInfo FromMutable(ScriptDom.BackupRestoreFileInfo fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.BackupRestoreFileInfo)) { throw new NotImplementedException("Unexpected subtype of BackupRestoreFileInfo not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BackupRestoreFileInfo(
                items: fragment.Items.SelectList(ImmutableDom.ValueExpression.FromMutable),
                itemKind: fragment.ItemKind
            );
        }
    
    }

}
