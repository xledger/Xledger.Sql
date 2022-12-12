using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class UpdateStatisticsStatement : TSqlStatement, IEquatable<UpdateStatisticsStatement> {
        SchemaObjectName schemaObjectName;
        IReadOnlyList<Identifier> subElements;
        IReadOnlyList<StatisticsOption> statisticsOptions;
    
        public SchemaObjectName SchemaObjectName => schemaObjectName;
        public IReadOnlyList<Identifier> SubElements => subElements;
        public IReadOnlyList<StatisticsOption> StatisticsOptions => statisticsOptions;
    
        public UpdateStatisticsStatement(SchemaObjectName schemaObjectName = null, IReadOnlyList<Identifier> subElements = null, IReadOnlyList<StatisticsOption> statisticsOptions = null) {
            this.schemaObjectName = schemaObjectName;
            this.subElements = subElements is null ? ImmList<Identifier>.Empty : ImmList<Identifier>.FromList(subElements);
            this.statisticsOptions = statisticsOptions is null ? ImmList<StatisticsOption>.Empty : ImmList<StatisticsOption>.FromList(statisticsOptions);
        }
    
        public ScriptDom.UpdateStatisticsStatement ToMutableConcrete() {
            var ret = new ScriptDom.UpdateStatisticsStatement();
            ret.SchemaObjectName = (ScriptDom.SchemaObjectName)schemaObjectName.ToMutable();
            ret.SubElements.AddRange(subElements.Select(c => (ScriptDom.Identifier)c.ToMutable()));
            ret.StatisticsOptions.AddRange(statisticsOptions.Select(c => (ScriptDom.StatisticsOption)c.ToMutable()));
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
            h = h * 23 + subElements.GetHashCode();
            h = h * 23 + statisticsOptions.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as UpdateStatisticsStatement);
        } 
        
        public bool Equals(UpdateStatisticsStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.SchemaObjectName, schemaObjectName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<Identifier>>.Default.Equals(other.SubElements, subElements)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<StatisticsOption>>.Default.Equals(other.StatisticsOptions, statisticsOptions)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(UpdateStatisticsStatement left, UpdateStatisticsStatement right) {
            return EqualityComparer<UpdateStatisticsStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(UpdateStatisticsStatement left, UpdateStatisticsStatement right) {
            return !(left == right);
        }
    
    }

}
