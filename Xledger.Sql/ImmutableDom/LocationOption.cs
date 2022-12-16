using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class LocationOption : TableOption, IEquatable<LocationOption> {
        protected Identifier locationValue;
    
        public Identifier LocationValue => locationValue;
    
        public LocationOption(Identifier locationValue = null, ScriptDom.TableOptionKind optionKind = ScriptDom.TableOptionKind.LockEscalation) {
            this.locationValue = locationValue;
            this.optionKind = optionKind;
        }
    
        public ScriptDom.LocationOption ToMutableConcrete() {
            var ret = new ScriptDom.LocationOption();
            ret.LocationValue = (ScriptDom.Identifier)locationValue?.ToMutable();
            ret.OptionKind = optionKind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(locationValue is null)) {
                h = h * 23 + locationValue.GetHashCode();
            }
            h = h * 23 + optionKind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as LocationOption);
        } 
        
        public bool Equals(LocationOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.LocationValue, locationValue)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TableOptionKind>.Default.Equals(other.OptionKind, optionKind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(LocationOption left, LocationOption right) {
            return EqualityComparer<LocationOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(LocationOption left, LocationOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (LocationOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.locationValue, othr.locationValue);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.optionKind, othr.optionKind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (LocationOption left, LocationOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(LocationOption left, LocationOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (LocationOption left, LocationOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(LocationOption left, LocationOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
