using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterViewStatement : ViewStatementBody, IEquatable<AlterViewStatement> {
        protected bool isRebuild = false;
        protected bool isDisable = false;
    
        public bool IsRebuild => isRebuild;
        public bool IsDisable => isDisable;
    
        public AlterViewStatement(bool isRebuild = false, bool isDisable = false, SchemaObjectName schemaObjectName = null, IReadOnlyList<Identifier> columns = null, IReadOnlyList<ViewOption> viewOptions = null, SelectStatement selectStatement = null, bool withCheckOption = false, bool isMaterialized = false) {
            this.isRebuild = isRebuild;
            this.isDisable = isDisable;
            this.schemaObjectName = schemaObjectName;
            this.columns = ImmList<Identifier>.FromList(columns);
            this.viewOptions = ImmList<ViewOption>.FromList(viewOptions);
            this.selectStatement = selectStatement;
            this.withCheckOption = withCheckOption;
            this.isMaterialized = isMaterialized;
        }
    
        public ScriptDom.AlterViewStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterViewStatement();
            ret.IsRebuild = isRebuild;
            ret.IsDisable = isDisable;
            ret.SchemaObjectName = (ScriptDom.SchemaObjectName)schemaObjectName?.ToMutable();
            ret.Columns.AddRange(columns.SelectList(c => (ScriptDom.Identifier)c?.ToMutable()));
            ret.ViewOptions.AddRange(viewOptions.SelectList(c => (ScriptDom.ViewOption)c?.ToMutable()));
            ret.SelectStatement = (ScriptDom.SelectStatement)selectStatement?.ToMutable();
            ret.WithCheckOption = withCheckOption;
            ret.IsMaterialized = isMaterialized;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isRebuild.GetHashCode();
            h = h * 23 + isDisable.GetHashCode();
            if (!(schemaObjectName is null)) {
                h = h * 23 + schemaObjectName.GetHashCode();
            }
            h = h * 23 + columns.GetHashCode();
            h = h * 23 + viewOptions.GetHashCode();
            if (!(selectStatement is null)) {
                h = h * 23 + selectStatement.GetHashCode();
            }
            h = h * 23 + withCheckOption.GetHashCode();
            h = h * 23 + isMaterialized.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterViewStatement);
        } 
        
        public bool Equals(AlterViewStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsRebuild, isRebuild)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsDisable, isDisable)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.SchemaObjectName, schemaObjectName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ViewOption>>.Default.Equals(other.ViewOptions, viewOptions)) {
                return false;
            }
            if (!EqualityComparer<SelectStatement>.Default.Equals(other.SelectStatement, selectStatement)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.WithCheckOption, withCheckOption)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsMaterialized, isMaterialized)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterViewStatement left, AlterViewStatement right) {
            return EqualityComparer<AlterViewStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterViewStatement left, AlterViewStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterViewStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.isRebuild, othr.isRebuild);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isDisable, othr.isDisable);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.schemaObjectName, othr.schemaObjectName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.columns, othr.columns);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.viewOptions, othr.viewOptions);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.selectStatement, othr.selectStatement);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.withCheckOption, othr.withCheckOption);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isMaterialized, othr.isMaterialized);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (AlterViewStatement left, AlterViewStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterViewStatement left, AlterViewStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterViewStatement left, AlterViewStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterViewStatement left, AlterViewStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AlterViewStatement FromMutable(ScriptDom.AlterViewStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.AlterViewStatement)) { throw new NotImplementedException("Unexpected subtype of AlterViewStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new AlterViewStatement(
                isRebuild: fragment.IsRebuild,
                isDisable: fragment.IsDisable,
                schemaObjectName: ImmutableDom.SchemaObjectName.FromMutable(fragment.SchemaObjectName),
                columns: fragment.Columns.SelectList(ImmutableDom.Identifier.FromMutable),
                viewOptions: fragment.ViewOptions.SelectList(ImmutableDom.ViewOption.FromMutable),
                selectStatement: ImmutableDom.SelectStatement.FromMutable(fragment.SelectStatement),
                withCheckOption: fragment.WithCheckOption,
                isMaterialized: fragment.IsMaterialized
            );
        }
    
    }

}
