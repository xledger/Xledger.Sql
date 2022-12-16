using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class UpdateStatisticsStatement : TSqlStatement, IEquatable<UpdateStatisticsStatement> {
        protected SchemaObjectName schemaObjectName;
        protected IReadOnlyList<Identifier> subElements;
        protected IReadOnlyList<StatisticsOption> statisticsOptions;
    
        public SchemaObjectName SchemaObjectName => schemaObjectName;
        public IReadOnlyList<Identifier> SubElements => subElements;
        public IReadOnlyList<StatisticsOption> StatisticsOptions => statisticsOptions;
    
        public UpdateStatisticsStatement(SchemaObjectName schemaObjectName = null, IReadOnlyList<Identifier> subElements = null, IReadOnlyList<StatisticsOption> statisticsOptions = null) {
            this.schemaObjectName = schemaObjectName;
            this.subElements = ImmList<Identifier>.FromList(subElements);
            this.statisticsOptions = ImmList<StatisticsOption>.FromList(statisticsOptions);
        }
    
        public ScriptDom.UpdateStatisticsStatement ToMutableConcrete() {
            var ret = new ScriptDom.UpdateStatisticsStatement();
            ret.SchemaObjectName = (ScriptDom.SchemaObjectName)schemaObjectName?.ToMutable();
            ret.SubElements.AddRange(subElements.SelectList(c => (ScriptDom.Identifier)c?.ToMutable()));
            ret.StatisticsOptions.AddRange(statisticsOptions.SelectList(c => (ScriptDom.StatisticsOption)c?.ToMutable()));
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (UpdateStatisticsStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.schemaObjectName, othr.schemaObjectName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.subElements, othr.subElements);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.statisticsOptions, othr.statisticsOptions);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (UpdateStatisticsStatement left, UpdateStatisticsStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(UpdateStatisticsStatement left, UpdateStatisticsStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (UpdateStatisticsStatement left, UpdateStatisticsStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(UpdateStatisticsStatement left, UpdateStatisticsStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
