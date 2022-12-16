using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SelectStatementSnippet : SelectStatement, IEquatable<SelectStatementSnippet> {
        protected string script;
    
        public string Script => script;
    
        public SelectStatementSnippet(string script = null, QueryExpression queryExpression = null, SchemaObjectName into = null, Identifier on = null, IReadOnlyList<ComputeClause> computeClauses = null, WithCtesAndXmlNamespaces withCtesAndXmlNamespaces = null, IReadOnlyList<OptimizerHint> optimizerHints = null) {
            this.script = script;
            this.queryExpression = queryExpression;
            this.into = into;
            this.on = on;
            this.computeClauses = ImmList<ComputeClause>.FromList(computeClauses);
            this.withCtesAndXmlNamespaces = withCtesAndXmlNamespaces;
            this.optimizerHints = ImmList<OptimizerHint>.FromList(optimizerHints);
        }
    
        public ScriptDom.SelectStatementSnippet ToMutableConcrete() {
            var ret = new ScriptDom.SelectStatementSnippet();
            ret.Script = script;
            ret.QueryExpression = (ScriptDom.QueryExpression)queryExpression?.ToMutable();
            ret.Into = (ScriptDom.SchemaObjectName)into?.ToMutable();
            ret.On = (ScriptDom.Identifier)on?.ToMutable();
            ret.ComputeClauses.AddRange(computeClauses.SelectList(c => (ScriptDom.ComputeClause)c?.ToMutable()));
            ret.WithCtesAndXmlNamespaces = (ScriptDom.WithCtesAndXmlNamespaces)withCtesAndXmlNamespaces?.ToMutable();
            ret.OptimizerHints.AddRange(optimizerHints.SelectList(c => (ScriptDom.OptimizerHint)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(script is null)) {
                h = h * 23 + script.GetHashCode();
            }
            if (!(queryExpression is null)) {
                h = h * 23 + queryExpression.GetHashCode();
            }
            if (!(into is null)) {
                h = h * 23 + into.GetHashCode();
            }
            if (!(on is null)) {
                h = h * 23 + on.GetHashCode();
            }
            h = h * 23 + computeClauses.GetHashCode();
            if (!(withCtesAndXmlNamespaces is null)) {
                h = h * 23 + withCtesAndXmlNamespaces.GetHashCode();
            }
            h = h * 23 + optimizerHints.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SelectStatementSnippet);
        } 
        
        public bool Equals(SelectStatementSnippet other) {
            if (other is null) { return false; }
            if (!EqualityComparer<string>.Default.Equals(other.Script, script)) {
                return false;
            }
            if (!EqualityComparer<QueryExpression>.Default.Equals(other.QueryExpression, queryExpression)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Into, into)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.On, on)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ComputeClause>>.Default.Equals(other.ComputeClauses, computeClauses)) {
                return false;
            }
            if (!EqualityComparer<WithCtesAndXmlNamespaces>.Default.Equals(other.WithCtesAndXmlNamespaces, withCtesAndXmlNamespaces)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<OptimizerHint>>.Default.Equals(other.OptimizerHints, optimizerHints)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SelectStatementSnippet left, SelectStatementSnippet right) {
            return EqualityComparer<SelectStatementSnippet>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SelectStatementSnippet left, SelectStatementSnippet right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SelectStatementSnippet)that;
            compare = CaseInsensitiveComparer.DefaultInvariant.Compare(this.script, othr.script);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.queryExpression, othr.queryExpression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.into, othr.into);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.on, othr.on);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.computeClauses, othr.computeClauses);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.withCtesAndXmlNamespaces, othr.withCtesAndXmlNamespaces);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optimizerHints, othr.optimizerHints);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (SelectStatementSnippet left, SelectStatementSnippet right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SelectStatementSnippet left, SelectStatementSnippet right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SelectStatementSnippet left, SelectStatementSnippet right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SelectStatementSnippet left, SelectStatementSnippet right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
