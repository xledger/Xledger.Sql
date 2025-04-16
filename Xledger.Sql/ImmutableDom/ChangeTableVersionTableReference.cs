using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ChangeTableVersionTableReference : TableReferenceWithAliasAndColumns, IEquatable<ChangeTableVersionTableReference> {
        protected SchemaObjectName target;
        protected IReadOnlyList<Identifier> primaryKeyColumns;
        protected IReadOnlyList<ScalarExpression> primaryKeyValues;
        protected bool forceSeek = false;
    
        public SchemaObjectName Target => target;
        public IReadOnlyList<Identifier> PrimaryKeyColumns => primaryKeyColumns;
        public IReadOnlyList<ScalarExpression> PrimaryKeyValues => primaryKeyValues;
        public bool ForceSeek => forceSeek;
    
        public ChangeTableVersionTableReference(SchemaObjectName target = null, IReadOnlyList<Identifier> primaryKeyColumns = null, IReadOnlyList<ScalarExpression> primaryKeyValues = null, bool forceSeek = false, IReadOnlyList<Identifier> columns = null, Identifier alias = null, bool forPath = false) {
            this.target = target;
            this.primaryKeyColumns = ImmList<Identifier>.FromList(primaryKeyColumns);
            this.primaryKeyValues = ImmList<ScalarExpression>.FromList(primaryKeyValues);
            this.forceSeek = forceSeek;
            this.columns = ImmList<Identifier>.FromList(columns);
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.ChangeTableVersionTableReference ToMutableConcrete() {
            var ret = new ScriptDom.ChangeTableVersionTableReference();
            ret.Target = (ScriptDom.SchemaObjectName)target?.ToMutable();
            ret.PrimaryKeyColumns.AddRange(primaryKeyColumns.SelectList(c => (ScriptDom.Identifier)c?.ToMutable()));
            ret.PrimaryKeyValues.AddRange(primaryKeyValues.SelectList(c => (ScriptDom.ScalarExpression)c?.ToMutable()));
            ret.ForceSeek = forceSeek;
            ret.Columns.AddRange(columns.SelectList(c => (ScriptDom.Identifier)c?.ToMutable()));
            ret.Alias = (ScriptDom.Identifier)alias?.ToMutable();
            ret.ForPath = forPath;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(target is null)) {
                h = h * 23 + target.GetHashCode();
            }
            h = h * 23 + primaryKeyColumns.GetHashCode();
            h = h * 23 + primaryKeyValues.GetHashCode();
            h = h * 23 + forceSeek.GetHashCode();
            h = h * 23 + columns.GetHashCode();
            if (!(alias is null)) {
                h = h * 23 + alias.GetHashCode();
            }
            h = h * 23 + forPath.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ChangeTableVersionTableReference);
        } 
        
        public bool Equals(ChangeTableVersionTableReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Target, target)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.PrimaryKeyColumns, primaryKeyColumns)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ScalarExpression>>.Default.Equals(other.PrimaryKeyValues, primaryKeyValues)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.ForceSeek, forceSeek)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Alias, alias)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.ForPath, forPath)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ChangeTableVersionTableReference left, ChangeTableVersionTableReference right) {
            return EqualityComparer<ChangeTableVersionTableReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ChangeTableVersionTableReference left, ChangeTableVersionTableReference right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ChangeTableVersionTableReference)that;
            compare = Comparer.DefaultInvariant.Compare(this.target, othr.target);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.primaryKeyColumns, othr.primaryKeyColumns);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.primaryKeyValues, othr.primaryKeyValues);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.forceSeek, othr.forceSeek);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.columns, othr.columns);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.alias, othr.alias);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.forPath, othr.forPath);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (ChangeTableVersionTableReference left, ChangeTableVersionTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ChangeTableVersionTableReference left, ChangeTableVersionTableReference right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ChangeTableVersionTableReference left, ChangeTableVersionTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ChangeTableVersionTableReference left, ChangeTableVersionTableReference right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ChangeTableVersionTableReference FromMutable(ScriptDom.ChangeTableVersionTableReference fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.ChangeTableVersionTableReference)) { throw new NotImplementedException("Unexpected subtype of ChangeTableVersionTableReference not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new ChangeTableVersionTableReference(
                target: ImmutableDom.SchemaObjectName.FromMutable(fragment.Target),
                primaryKeyColumns: fragment.PrimaryKeyColumns.SelectList(ImmutableDom.Identifier.FromMutable),
                primaryKeyValues: fragment.PrimaryKeyValues.SelectList(ImmutableDom.ScalarExpression.FromMutable),
                forceSeek: fragment.ForceSeek,
                columns: fragment.Columns.SelectList(ImmutableDom.Identifier.FromMutable),
                alias: ImmutableDom.Identifier.FromMutable(fragment.Alias),
                forPath: fragment.ForPath
            );
        }
    
    }

}
