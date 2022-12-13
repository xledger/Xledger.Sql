using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AtTimeZoneCall : PrimaryExpression, IEquatable<AtTimeZoneCall> {
        protected ScalarExpression dateValue;
        protected ScalarExpression timeZone;
    
        public ScalarExpression DateValue => dateValue;
        public ScalarExpression TimeZone => timeZone;
    
        public AtTimeZoneCall(ScalarExpression dateValue = null, ScalarExpression timeZone = null, Identifier collation = null) {
            this.dateValue = dateValue;
            this.timeZone = timeZone;
            this.collation = collation;
        }
    
        public ScriptDom.AtTimeZoneCall ToMutableConcrete() {
            var ret = new ScriptDom.AtTimeZoneCall();
            ret.DateValue = (ScriptDom.ScalarExpression)dateValue.ToMutable();
            ret.TimeZone = (ScriptDom.ScalarExpression)timeZone.ToMutable();
            ret.Collation = (ScriptDom.Identifier)collation.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(dateValue is null)) {
                h = h * 23 + dateValue.GetHashCode();
            }
            if (!(timeZone is null)) {
                h = h * 23 + timeZone.GetHashCode();
            }
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AtTimeZoneCall);
        } 
        
        public bool Equals(AtTimeZoneCall other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.DateValue, dateValue)) {
                return false;
            }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.TimeZone, timeZone)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AtTimeZoneCall left, AtTimeZoneCall right) {
            return EqualityComparer<AtTimeZoneCall>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AtTimeZoneCall left, AtTimeZoneCall right) {
            return !(left == right);
        }
    
        public static AtTimeZoneCall FromMutable(ScriptDom.AtTimeZoneCall fragment) {
            return (AtTimeZoneCall)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
