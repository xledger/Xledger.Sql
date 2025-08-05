using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class InsertSpecification : DataModificationSpecification, IEquatable<InsertSpecification> {
        protected ScriptDom.InsertOption insertOption = ScriptDom.InsertOption.None;
        protected InsertSource insertSource;
        protected IReadOnlyList<ColumnReferenceExpression> columns;
    
        public ScriptDom.InsertOption InsertOption => insertOption;
        public InsertSource InsertSource => insertSource;
        public IReadOnlyList<ColumnReferenceExpression> Columns => columns;
    
        public InsertSpecification(ScriptDom.InsertOption insertOption = ScriptDom.InsertOption.None, InsertSource insertSource = null, IReadOnlyList<ColumnReferenceExpression> columns = null, TableReference target = null, TopRowFilter topRowFilter = null, OutputIntoClause outputIntoClause = null, OutputClause outputClause = null) {
            this.insertOption = insertOption;
            this.insertSource = insertSource;
            this.columns = columns.ToImmArray<ColumnReferenceExpression>();
            this.target = target;
            this.topRowFilter = topRowFilter;
            this.outputIntoClause = outputIntoClause;
            this.outputClause = outputClause;
        }
    
        public ScriptDom.InsertSpecification ToMutableConcrete() {
            var ret = new ScriptDom.InsertSpecification();
            ret.InsertOption = insertOption;
            ret.InsertSource = (ScriptDom.InsertSource)insertSource?.ToMutable();
            ret.Columns.AddRange(columns.Select(c => (ScriptDom.ColumnReferenceExpression)c?.ToMutable()));
            ret.Target = (ScriptDom.TableReference)target?.ToMutable();
            ret.TopRowFilter = (ScriptDom.TopRowFilter)topRowFilter?.ToMutable();
            ret.OutputIntoClause = (ScriptDom.OutputIntoClause)outputIntoClause?.ToMutable();
            ret.OutputClause = (ScriptDom.OutputClause)outputClause?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + insertOption.GetHashCode();
            if (!(insertSource is null)) {
                h = h * 23 + insertSource.GetHashCode();
            }
            h = h * 23 + columns.GetHashCode();
            if (!(target is null)) {
                h = h * 23 + target.GetHashCode();
            }
            if (!(topRowFilter is null)) {
                h = h * 23 + topRowFilter.GetHashCode();
            }
            if (!(outputIntoClause is null)) {
                h = h * 23 + outputIntoClause.GetHashCode();
            }
            if (!(outputClause is null)) {
                h = h * 23 + outputClause.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as InsertSpecification);
        } 
        
        public bool Equals(InsertSpecification other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.InsertOption>.Default.Equals(other.InsertOption, insertOption)) {
                return false;
            }
            if (!EqualityComparer<InsertSource>.Default.Equals(other.InsertSource, insertSource)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ColumnReferenceExpression>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            if (!EqualityComparer<TableReference>.Default.Equals(other.Target, target)) {
                return false;
            }
            if (!EqualityComparer<TopRowFilter>.Default.Equals(other.TopRowFilter, topRowFilter)) {
                return false;
            }
            if (!EqualityComparer<OutputIntoClause>.Default.Equals(other.OutputIntoClause, outputIntoClause)) {
                return false;
            }
            if (!EqualityComparer<OutputClause>.Default.Equals(other.OutputClause, outputClause)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(InsertSpecification left, InsertSpecification right) {
            return EqualityComparer<InsertSpecification>.Default.Equals(left, right);
        }
        
        public static bool operator !=(InsertSpecification left, InsertSpecification right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (InsertSpecification)that;
            compare = Comparer.DefaultInvariant.Compare(this.insertOption, othr.insertOption);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.insertSource, othr.insertSource);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.columns, othr.columns);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.target, othr.target);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.topRowFilter, othr.topRowFilter);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.outputIntoClause, othr.outputIntoClause);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.outputClause, othr.outputClause);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (InsertSpecification left, InsertSpecification right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(InsertSpecification left, InsertSpecification right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (InsertSpecification left, InsertSpecification right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(InsertSpecification left, InsertSpecification right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static InsertSpecification FromMutable(ScriptDom.InsertSpecification fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.InsertSpecification)) { throw new NotImplementedException("Unexpected subtype of InsertSpecification not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new InsertSpecification(
                insertOption: fragment.InsertOption,
                insertSource: ImmutableDom.InsertSource.FromMutable(fragment.InsertSource),
                columns: fragment.Columns.ToImmArray(ImmutableDom.ColumnReferenceExpression.FromMutable),
                target: ImmutableDom.TableReference.FromMutable(fragment.Target),
                topRowFilter: ImmutableDom.TopRowFilter.FromMutable(fragment.TopRowFilter),
                outputIntoClause: ImmutableDom.OutputIntoClause.FromMutable(fragment.OutputIntoClause),
                outputClause: ImmutableDom.OutputClause.FromMutable(fragment.OutputClause)
            );
        }
    
    }

}
