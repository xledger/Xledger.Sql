using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ChangeRetentionChangeTrackingOptionDetail : ChangeTrackingOptionDetail, IEquatable<ChangeRetentionChangeTrackingOptionDetail> {
        protected Literal retentionPeriod;
        protected ScriptDom.TimeUnit unit = ScriptDom.TimeUnit.Seconds;
    
        public Literal RetentionPeriod => retentionPeriod;
        public ScriptDom.TimeUnit Unit => unit;
    
        public ChangeRetentionChangeTrackingOptionDetail(Literal retentionPeriod = null, ScriptDom.TimeUnit unit = ScriptDom.TimeUnit.Seconds) {
            this.retentionPeriod = retentionPeriod;
            this.unit = unit;
        }
    
        public ScriptDom.ChangeRetentionChangeTrackingOptionDetail ToMutableConcrete() {
            var ret = new ScriptDom.ChangeRetentionChangeTrackingOptionDetail();
            ret.RetentionPeriod = (ScriptDom.Literal)retentionPeriod.ToMutable();
            ret.Unit = unit;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(retentionPeriod is null)) {
                h = h * 23 + retentionPeriod.GetHashCode();
            }
            h = h * 23 + unit.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ChangeRetentionChangeTrackingOptionDetail);
        } 
        
        public bool Equals(ChangeRetentionChangeTrackingOptionDetail other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.RetentionPeriod, retentionPeriod)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TimeUnit>.Default.Equals(other.Unit, unit)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ChangeRetentionChangeTrackingOptionDetail left, ChangeRetentionChangeTrackingOptionDetail right) {
            return EqualityComparer<ChangeRetentionChangeTrackingOptionDetail>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ChangeRetentionChangeTrackingOptionDetail left, ChangeRetentionChangeTrackingOptionDetail right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ChangeRetentionChangeTrackingOptionDetail)that;
            compare = Comparer.DefaultInvariant.Compare(this.retentionPeriod, othr.retentionPeriod);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.unit, othr.unit);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ChangeRetentionChangeTrackingOptionDetail left, ChangeRetentionChangeTrackingOptionDetail right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ChangeRetentionChangeTrackingOptionDetail left, ChangeRetentionChangeTrackingOptionDetail right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ChangeRetentionChangeTrackingOptionDetail left, ChangeRetentionChangeTrackingOptionDetail right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ChangeRetentionChangeTrackingOptionDetail left, ChangeRetentionChangeTrackingOptionDetail right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
