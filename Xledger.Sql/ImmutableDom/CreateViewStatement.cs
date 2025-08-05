using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateViewStatement : ViewStatementBody, IEquatable<CreateViewStatement> {
        public CreateViewStatement(SchemaObjectName schemaObjectName = null, IReadOnlyList<Identifier> columns = null, IReadOnlyList<ViewOption> viewOptions = null, SelectStatement selectStatement = null, bool withCheckOption = false, bool isMaterialized = false) {
            this.schemaObjectName = schemaObjectName;
            this.columns = columns.ToImmArray<Identifier>();
            this.viewOptions = viewOptions.ToImmArray<ViewOption>();
            this.selectStatement = selectStatement;
            this.withCheckOption = withCheckOption;
            this.isMaterialized = isMaterialized;
        }
    
        public ScriptDom.CreateViewStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateViewStatement();
            ret.SchemaObjectName = (ScriptDom.SchemaObjectName)schemaObjectName?.ToMutable();
            ret.Columns.AddRange(columns.Select(c => (ScriptDom.Identifier)c?.ToMutable()));
            ret.ViewOptions.AddRange(viewOptions.Select(c => (ScriptDom.ViewOption)c?.ToMutable()));
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
            return Equals(obj as CreateViewStatement);
        } 
        
        public bool Equals(CreateViewStatement other) {
            if (other is null) { return false; }
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
        
        public static bool operator ==(CreateViewStatement left, CreateViewStatement right) {
            return EqualityComparer<CreateViewStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateViewStatement left, CreateViewStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateViewStatement)that;
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
        
        public static bool operator < (CreateViewStatement left, CreateViewStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateViewStatement left, CreateViewStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateViewStatement left, CreateViewStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateViewStatement left, CreateViewStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateViewStatement FromMutable(ScriptDom.CreateViewStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreateViewStatement)) { throw new NotImplementedException("Unexpected subtype of CreateViewStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateViewStatement(
                schemaObjectName: ImmutableDom.SchemaObjectName.FromMutable(fragment.SchemaObjectName),
                columns: fragment.Columns.ToImmArray(ImmutableDom.Identifier.FromMutable),
                viewOptions: fragment.ViewOptions.ToImmArray(ImmutableDom.ViewOption.FromMutable),
                selectStatement: ImmutableDom.SelectStatement.FromMutable(fragment.SelectStatement),
                withCheckOption: fragment.WithCheckOption,
                isMaterialized: fragment.IsMaterialized
            );
        }
    
    }

}
