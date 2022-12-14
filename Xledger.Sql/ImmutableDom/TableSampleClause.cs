using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class TableSampleClause : TSqlFragment, IEquatable<TableSampleClause> {
        protected bool system = false;
        protected ScalarExpression sampleNumber;
        protected ScriptDom.TableSampleClauseOption tableSampleClauseOption = ScriptDom.TableSampleClauseOption.NotSpecified;
        protected ScalarExpression repeatSeed;
    
        public bool System => system;
        public ScalarExpression SampleNumber => sampleNumber;
        public ScriptDom.TableSampleClauseOption TableSampleClauseOption => tableSampleClauseOption;
        public ScalarExpression RepeatSeed => repeatSeed;
    
        public TableSampleClause(bool system = false, ScalarExpression sampleNumber = null, ScriptDom.TableSampleClauseOption tableSampleClauseOption = ScriptDom.TableSampleClauseOption.NotSpecified, ScalarExpression repeatSeed = null) {
            this.system = system;
            this.sampleNumber = sampleNumber;
            this.tableSampleClauseOption = tableSampleClauseOption;
            this.repeatSeed = repeatSeed;
        }
    
        public ScriptDom.TableSampleClause ToMutableConcrete() {
            var ret = new ScriptDom.TableSampleClause();
            ret.System = system;
            ret.SampleNumber = (ScriptDom.ScalarExpression)sampleNumber.ToMutable();
            ret.TableSampleClauseOption = tableSampleClauseOption;
            ret.RepeatSeed = (ScriptDom.ScalarExpression)repeatSeed.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + system.GetHashCode();
            if (!(sampleNumber is null)) {
                h = h * 23 + sampleNumber.GetHashCode();
            }
            h = h * 23 + tableSampleClauseOption.GetHashCode();
            if (!(repeatSeed is null)) {
                h = h * 23 + repeatSeed.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as TableSampleClause);
        } 
        
        public bool Equals(TableSampleClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.System, system)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.SampleNumber, sampleNumber)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TableSampleClauseOption>.Default.Equals(other.TableSampleClauseOption, tableSampleClauseOption)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.RepeatSeed, repeatSeed)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(TableSampleClause left, TableSampleClause right) {
            return EqualityComparer<TableSampleClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(TableSampleClause left, TableSampleClause right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (TableSampleClause)that;
            compare = Comparer.DefaultInvariant.Compare(this.system, othr.system);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.sampleNumber, othr.sampleNumber);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.tableSampleClauseOption, othr.tableSampleClauseOption);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.repeatSeed, othr.repeatSeed);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (TableSampleClause left, TableSampleClause right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(TableSampleClause left, TableSampleClause right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (TableSampleClause left, TableSampleClause right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(TableSampleClause left, TableSampleClause right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static TableSampleClause FromMutable(ScriptDom.TableSampleClause fragment) {
            return (TableSampleClause)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
