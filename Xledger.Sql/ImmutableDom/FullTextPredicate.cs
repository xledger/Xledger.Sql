using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
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
            this.columns = columns is null ? ImmList<ColumnReferenceExpression>.Empty : ImmList<ColumnReferenceExpression>.FromList(columns);
            this.@value = @value;
            this.languageTerm = languageTerm;
            this.propertyName = propertyName;
        }
    
        public ScriptDom.FullTextPredicate ToMutableConcrete() {
            var ret = new ScriptDom.FullTextPredicate();
            ret.FullTextFunctionType = fullTextFunctionType;
            ret.Columns.AddRange(columns.SelectList(c => (ScriptDom.ColumnReferenceExpression)c.ToMutable()));
            ret.Value = (ScriptDom.ValueExpression)@value.ToMutable();
            ret.LanguageTerm = (ScriptDom.ValueExpression)languageTerm.ToMutable();
            ret.PropertyName = (ScriptDom.StringLiteral)propertyName.ToMutable();
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
    
    }

}
