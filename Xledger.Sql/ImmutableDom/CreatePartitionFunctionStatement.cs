using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreatePartitionFunctionStatement : TSqlStatement, IEquatable<CreatePartitionFunctionStatement> {
        protected Identifier name;
        protected PartitionParameterType parameterType;
        protected ScriptDom.PartitionFunctionRange range = ScriptDom.PartitionFunctionRange.NotSpecified;
        protected IReadOnlyList<ScalarExpression> boundaryValues;
    
        public Identifier Name => name;
        public PartitionParameterType ParameterType => parameterType;
        public ScriptDom.PartitionFunctionRange Range => range;
        public IReadOnlyList<ScalarExpression> BoundaryValues => boundaryValues;
    
        public CreatePartitionFunctionStatement(Identifier name = null, PartitionParameterType parameterType = null, ScriptDom.PartitionFunctionRange range = ScriptDom.PartitionFunctionRange.NotSpecified, IReadOnlyList<ScalarExpression> boundaryValues = null) {
            this.name = name;
            this.parameterType = parameterType;
            this.range = range;
            this.boundaryValues = ImmList<ScalarExpression>.FromList(boundaryValues);
        }
    
        public ScriptDom.CreatePartitionFunctionStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreatePartitionFunctionStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.ParameterType = (ScriptDom.PartitionParameterType)parameterType.ToMutable();
            ret.Range = range;
            ret.BoundaryValues.AddRange(boundaryValues.SelectList(c => (ScriptDom.ScalarExpression)c.ToMutable()));
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
            if (!(parameterType is null)) {
                h = h * 23 + parameterType.GetHashCode();
            }
            h = h * 23 + range.GetHashCode();
            h = h * 23 + boundaryValues.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreatePartitionFunctionStatement);
        } 
        
        public bool Equals(CreatePartitionFunctionStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<PartitionParameterType>.Default.Equals(other.ParameterType, parameterType)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.PartitionFunctionRange>.Default.Equals(other.Range, range)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ScalarExpression>>.Default.Equals(other.BoundaryValues, boundaryValues)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreatePartitionFunctionStatement left, CreatePartitionFunctionStatement right) {
            return EqualityComparer<CreatePartitionFunctionStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreatePartitionFunctionStatement left, CreatePartitionFunctionStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreatePartitionFunctionStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.parameterType, othr.parameterType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.range, othr.range);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.boundaryValues, othr.boundaryValues);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (CreatePartitionFunctionStatement left, CreatePartitionFunctionStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreatePartitionFunctionStatement left, CreatePartitionFunctionStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreatePartitionFunctionStatement left, CreatePartitionFunctionStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreatePartitionFunctionStatement left, CreatePartitionFunctionStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreatePartitionFunctionStatement FromMutable(ScriptDom.CreatePartitionFunctionStatement fragment) {
            return (CreatePartitionFunctionStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
