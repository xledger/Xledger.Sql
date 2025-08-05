using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class FullTextPredicate : BooleanExpression, IEquatable<FullTextPredicate> {
        protected ScriptDom.FullTextFunctionType fullTextFunctionType = ScriptDom.FullTextFunctionType.None;
        protected IReadOnlyList<ColumnReferenceExpression> columns;
        protected ValueExpression @value;
        protected ValueExpression languageTerm;
        protected StringLiteral propertyName;
    
        public ScriptDom.FullTextFunctionType FullTextFunctionType => fullTextFunctionType;
        public IReadOnlyList<ColumnReferenceExpression> Columns => columns;
        public ValueExpression Value => @value;
        public ValueExpression LanguageTerm => languageTerm;
        public StringLiteral PropertyName => propertyName;
    
        public FullTextPredicate(ScriptDom.FullTextFunctionType fullTextFunctionType = ScriptDom.FullTextFunctionType.None, IReadOnlyList<ColumnReferenceExpression> columns = null, ValueExpression @value = null, ValueExpression languageTerm = null, StringLiteral propertyName = null) {
            this.fullTextFunctionType = fullTextFunctionType;
            this.columns = columns.ToImmArray<ColumnReferenceExpression>();
            this.@value = @value;
            this.languageTerm = languageTerm;
            this.propertyName = propertyName;
        }
    
        public ScriptDom.FullTextPredicate ToMutableConcrete() {
            var ret = new ScriptDom.FullTextPredicate();
            ret.FullTextFunctionType = fullTextFunctionType;
            ret.Columns.AddRange(columns.Select(c => (ScriptDom.ColumnReferenceExpression)c?.ToMutable()));
            ret.Value = (ScriptDom.ValueExpression)@value?.ToMutable();
            ret.LanguageTerm = (ScriptDom.ValueExpression)languageTerm?.ToMutable();
            ret.PropertyName = (ScriptDom.StringLiteral)propertyName?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + fullTextFunctionType.GetHashCode();
            h = h * 23 + columns.GetHashCode();
            if (!(@value is null)) {
                h = h * 23 + @value.GetHashCode();
            }
            if (!(languageTerm is null)) {
                h = h * 23 + languageTerm.GetHashCode();
            }
            if (!(propertyName is null)) {
                h = h * 23 + propertyName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as FullTextPredicate);
        } 
        
        public bool Equals(FullTextPredicate other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.FullTextFunctionType>.Default.Equals(other.FullTextFunctionType, fullTextFunctionType)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ColumnReferenceExpression>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.Value, @value)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.LanguageTerm, languageTerm)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.PropertyName, propertyName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(FullTextPredicate left, FullTextPredicate right) {
            return EqualityComparer<FullTextPredicate>.Default.Equals(left, right);
        }
        
        public static bool operator !=(FullTextPredicate left, FullTextPredicate right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (FullTextPredicate)that;
            compare = Comparer.DefaultInvariant.Compare(this.fullTextFunctionType, othr.fullTextFunctionType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.columns, othr.columns);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.@value, othr.@value);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.languageTerm, othr.languageTerm);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.propertyName, othr.propertyName);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (FullTextPredicate left, FullTextPredicate right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(FullTextPredicate left, FullTextPredicate right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (FullTextPredicate left, FullTextPredicate right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(FullTextPredicate left, FullTextPredicate right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static FullTextPredicate FromMutable(ScriptDom.FullTextPredicate fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.FullTextPredicate)) { throw new NotImplementedException("Unexpected subtype of FullTextPredicate not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new FullTextPredicate(
                fullTextFunctionType: fragment.FullTextFunctionType,
                columns: fragment.Columns.ToImmArray(ImmutableDom.ColumnReferenceExpression.FromMutable),
                @value: ImmutableDom.ValueExpression.FromMutable(fragment.Value),
                languageTerm: ImmutableDom.ValueExpression.FromMutable(fragment.LanguageTerm),
                propertyName: ImmutableDom.StringLiteral.FromMutable(fragment.PropertyName)
            );
        }
    
    }

}
