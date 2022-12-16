using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SelectStatement : StatementWithCtesAndXmlNamespaces, IEquatable<SelectStatement> {
        protected QueryExpression queryExpression;
        protected SchemaObjectName into;
        protected Identifier on;
        protected IReadOnlyList<ComputeClause> computeClauses;
    
        public QueryExpression QueryExpression => queryExpression;
        public SchemaObjectName Into => into;
        public Identifier On => on;
        public IReadOnlyList<ComputeClause> ComputeClauses => computeClauses;
    
        public SelectStatement(QueryExpression queryExpression = null, SchemaObjectName into = null, Identifier on = null, IReadOnlyList<ComputeClause> computeClauses = null, WithCtesAndXmlNamespaces withCtesAndXmlNamespaces = null, IReadOnlyList<OptimizerHint> optimizerHints = null) {
            this.queryExpression = queryExpression;
            this.into = into;
            this.on = on;
            this.computeClauses = ImmList<ComputeClause>.FromList(computeClauses);
            this.withCtesAndXmlNamespaces = withCtesAndXmlNamespaces;
            this.optimizerHints = ImmList<OptimizerHint>.FromList(optimizerHints);
        }
    
        public ScriptDom.SelectStatement ToMutableConcrete() {
            var ret = new ScriptDom.SelectStatement();
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
            return Equals(obj as SelectStatement);
        } 
        
        public bool Equals(SelectStatement other) {
            if (other is null) { return false; }
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
        
        public static bool operator ==(SelectStatement left, SelectStatement right) {
            return EqualityComparer<SelectStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SelectStatement left, SelectStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SelectStatement)that;
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
        public static bool operator < (SelectStatement left, SelectStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SelectStatement left, SelectStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SelectStatement left, SelectStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SelectStatement left, SelectStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
