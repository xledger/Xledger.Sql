using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateStatisticsStatement : TSqlStatement, IEquatable<CreateStatisticsStatement> {
        protected Identifier name;
        protected SchemaObjectName onName;
        protected IReadOnlyList<ColumnReferenceExpression> columns;
        protected IReadOnlyList<StatisticsOption> statisticsOptions;
        protected BooleanExpression filterPredicate;
    
        public Identifier Name => name;
        public SchemaObjectName OnName => onName;
        public IReadOnlyList<ColumnReferenceExpression> Columns => columns;
        public IReadOnlyList<StatisticsOption> StatisticsOptions => statisticsOptions;
        public BooleanExpression FilterPredicate => filterPredicate;
    
        public CreateStatisticsStatement(Identifier name = null, SchemaObjectName onName = null, IReadOnlyList<ColumnReferenceExpression> columns = null, IReadOnlyList<StatisticsOption> statisticsOptions = null, BooleanExpression filterPredicate = null) {
            this.name = name;
            this.onName = onName;
            this.columns = columns is null ? ImmList<ColumnReferenceExpression>.Empty : ImmList<ColumnReferenceExpression>.FromList(columns);
            this.statisticsOptions = statisticsOptions is null ? ImmList<StatisticsOption>.Empty : ImmList<StatisticsOption>.FromList(statisticsOptions);
            this.filterPredicate = filterPredicate;
        }
    
        public ScriptDom.CreateStatisticsStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateStatisticsStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.OnName = (ScriptDom.SchemaObjectName)onName.ToMutable();
            ret.Columns.AddRange(columns.SelectList(c => (ScriptDom.ColumnReferenceExpression)c.ToMutable()));
            ret.StatisticsOptions.AddRange(statisticsOptions.SelectList(c => (ScriptDom.StatisticsOption)c.ToMutable()));
            ret.FilterPredicate = (ScriptDom.BooleanExpression)filterPredicate.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            if (!(onName is null)) {
                h = h * 23 + onName.GetHashCode();
            }
            h = h * 23 + columns.GetHashCode();
            h = h * 23 + statisticsOptions.GetHashCode();
            if (!(filterPredicate is null)) {
                h = h * 23 + filterPredicate.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateStatisticsStatement);
        } 
        
        public bool Equals(CreateStatisticsStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.OnName, onName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ColumnReferenceExpression>>.Default.Equals(other.Columns, columns)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<StatisticsOption>>.Default.Equals(other.StatisticsOptions, statisticsOptions)) {
                return false;
            }
            if (!EqualityComparer<BooleanExpression>.Default.Equals(other.FilterPredicate, filterPredicate)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateStatisticsStatement left, CreateStatisticsStatement right) {
            return EqualityComparer<CreateStatisticsStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateStatisticsStatement left, CreateStatisticsStatement right) {
            return !(left == right);
        }
    
    }

}
