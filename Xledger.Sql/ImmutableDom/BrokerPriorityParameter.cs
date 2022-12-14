using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BrokerPriorityParameter : TSqlFragment, IEquatable<BrokerPriorityParameter> {
        protected ScriptDom.BrokerPriorityParameterSpecialType isDefaultOrAny = ScriptDom.BrokerPriorityParameterSpecialType.None;
        protected ScriptDom.BrokerPriorityParameterType parameterType = ScriptDom.BrokerPriorityParameterType.Unknown;
        protected IdentifierOrValueExpression parameterValue;
    
        public ScriptDom.BrokerPriorityParameterSpecialType IsDefaultOrAny => isDefaultOrAny;
        public ScriptDom.BrokerPriorityParameterType ParameterType => parameterType;
        public IdentifierOrValueExpression ParameterValue => parameterValue;
    
        public BrokerPriorityParameter(ScriptDom.BrokerPriorityParameterSpecialType isDefaultOrAny = ScriptDom.BrokerPriorityParameterSpecialType.None, ScriptDom.BrokerPriorityParameterType parameterType = ScriptDom.BrokerPriorityParameterType.Unknown, IdentifierOrValueExpression parameterValue = null) {
            this.isDefaultOrAny = isDefaultOrAny;
            this.parameterType = parameterType;
            this.parameterValue = parameterValue;
        }
    
        public ScriptDom.BrokerPriorityParameter ToMutableConcrete() {
            var ret = new ScriptDom.BrokerPriorityParameter();
            ret.IsDefaultOrAny = isDefaultOrAny;
            ret.ParameterType = parameterType;
            ret.ParameterValue = (ScriptDom.IdentifierOrValueExpression)parameterValue.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isDefaultOrAny.GetHashCode();
            h = h * 23 + parameterType.GetHashCode();
            if (!(parameterValue is null)) {
                h = h * 23 + parameterValue.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as BrokerPriorityParameter);
        } 
        
        public bool Equals(BrokerPriorityParameter other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.BrokerPriorityParameterSpecialType>.Default.Equals(other.IsDefaultOrAny, isDefaultOrAny)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.BrokerPriorityParameterType>.Default.Equals(other.ParameterType, parameterType)) {
                return false;
            }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.ParameterValue, parameterValue)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(BrokerPriorityParameter left, BrokerPriorityParameter right) {
            return EqualityComparer<BrokerPriorityParameter>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BrokerPriorityParameter left, BrokerPriorityParameter right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (BrokerPriorityParameter)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.isDefaultOrAny, othr.isDefaultOrAny);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.parameterType, othr.parameterType);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.parameterValue, othr.parameterValue);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static BrokerPriorityParameter FromMutable(ScriptDom.BrokerPriorityParameter fragment) {
            return (BrokerPriorityParameter)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
