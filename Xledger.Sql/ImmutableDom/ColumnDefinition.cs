using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ColumnDefinition : ColumnDefinitionBase, IEquatable<ColumnDefinition> {
        protected ScalarExpression computedColumnExpression;
        protected bool isPersisted = false;
        protected DefaultConstraintDefinition defaultConstraint;
        protected IdentityOptions identityOptions;
        protected bool isRowGuidCol = false;
        protected IReadOnlyList<ConstraintDefinition> constraints;
        protected ColumnStorageOptions storageOptions;
        protected IndexDefinition index;
        protected ScriptDom.GeneratedAlwaysType? generatedAlways;
        protected bool isHidden = false;
        protected ColumnEncryptionDefinition encryption;
        protected bool isMasked = false;
        protected StringLiteral maskingFunction;
    
        public ScalarExpression ComputedColumnExpression => computedColumnExpression;
        public bool IsPersisted => isPersisted;
        public DefaultConstraintDefinition DefaultConstraint => defaultConstraint;
        public IdentityOptions IdentityOptions => identityOptions;
        public bool IsRowGuidCol => isRowGuidCol;
        public IReadOnlyList<ConstraintDefinition> Constraints => constraints;
        public ColumnStorageOptions StorageOptions => storageOptions;
        public IndexDefinition Index => index;
        public ScriptDom.GeneratedAlwaysType? GeneratedAlways => generatedAlways;
        public bool IsHidden => isHidden;
        public ColumnEncryptionDefinition Encryption => encryption;
        public bool IsMasked => isMasked;
        public StringLiteral MaskingFunction => maskingFunction;
    
        public ColumnDefinition(ScalarExpression computedColumnExpression = null, bool isPersisted = false, DefaultConstraintDefinition defaultConstraint = null, IdentityOptions identityOptions = null, bool isRowGuidCol = false, IReadOnlyList<ConstraintDefinition> constraints = null, ColumnStorageOptions storageOptions = null, IndexDefinition index = null, ScriptDom.GeneratedAlwaysType? generatedAlways = null, bool isHidden = false, ColumnEncryptionDefinition encryption = null, bool isMasked = false, StringLiteral maskingFunction = null, Identifier columnIdentifier = null, DataTypeReference dataType = null, Identifier collation = null) {
            this.computedColumnExpression = computedColumnExpression;
            this.isPersisted = isPersisted;
            this.defaultConstraint = defaultConstraint;
            this.identityOptions = identityOptions;
            this.isRowGuidCol = isRowGuidCol;
            this.constraints = ImmList<ConstraintDefinition>.FromList(constraints);
            this.storageOptions = storageOptions;
            this.index = index;
            this.generatedAlways = generatedAlways;
            this.isHidden = isHidden;
            this.encryption = encryption;
            this.isMasked = isMasked;
            this.maskingFunction = maskingFunction;
            this.columnIdentifier = columnIdentifier;
            this.dataType = dataType;
            this.collation = collation;
        }
    
        public ScriptDom.ColumnDefinition ToMutableConcrete() {
            var ret = new ScriptDom.ColumnDefinition();
            ret.ComputedColumnExpression = (ScriptDom.ScalarExpression)computedColumnExpression?.ToMutable();
            ret.IsPersisted = isPersisted;
            ret.DefaultConstraint = (ScriptDom.DefaultConstraintDefinition)defaultConstraint?.ToMutable();
            ret.IdentityOptions = (ScriptDom.IdentityOptions)identityOptions?.ToMutable();
            ret.IsRowGuidCol = isRowGuidCol;
            ret.Constraints.AddRange(constraints.SelectList(c => (ScriptDom.ConstraintDefinition)c?.ToMutable()));
            ret.StorageOptions = (ScriptDom.ColumnStorageOptions)storageOptions?.ToMutable();
            ret.Index = (ScriptDom.IndexDefinition)index?.ToMutable();
            ret.GeneratedAlways = generatedAlways;
            ret.IsHidden = isHidden;
            ret.Encryption = (ScriptDom.ColumnEncryptionDefinition)encryption?.ToMutable();
            ret.IsMasked = isMasked;
            ret.MaskingFunction = (ScriptDom.StringLiteral)maskingFunction?.ToMutable();
            ret.ColumnIdentifier = (ScriptDom.Identifier)columnIdentifier?.ToMutable();
            ret.DataType = (ScriptDom.DataTypeReference)dataType?.ToMutable();
            ret.Collation = (ScriptDom.Identifier)collation?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(computedColumnExpression is null)) {
                h = h * 23 + computedColumnExpression.GetHashCode();
            }
            h = h * 23 + isPersisted.GetHashCode();
            if (!(defaultConstraint is null)) {
                h = h * 23 + defaultConstraint.GetHashCode();
            }
            if (!(identityOptions is null)) {
                h = h * 23 + identityOptions.GetHashCode();
            }
            h = h * 23 + isRowGuidCol.GetHashCode();
            h = h * 23 + constraints.GetHashCode();
            if (!(storageOptions is null)) {
                h = h * 23 + storageOptions.GetHashCode();
            }
            if (!(index is null)) {
                h = h * 23 + index.GetHashCode();
            }
            h = h * 23 + generatedAlways.GetHashCode();
            h = h * 23 + isHidden.GetHashCode();
            if (!(encryption is null)) {
                h = h * 23 + encryption.GetHashCode();
            }
            h = h * 23 + isMasked.GetHashCode();
            if (!(maskingFunction is null)) {
                h = h * 23 + maskingFunction.GetHashCode();
            }
            if (!(columnIdentifier is null)) {
                h = h * 23 + columnIdentifier.GetHashCode();
            }
            if (!(dataType is null)) {
                h = h * 23 + dataType.GetHashCode();
            }
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ColumnDefinition);
        } 
        
        public bool Equals(ColumnDefinition other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.ComputedColumnExpression, computedColumnExpression)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsPersisted, isPersisted)) {
                return false;
            }
            if (!EqualityComparer<DefaultConstraintDefinition>.Default.Equals(other.DefaultConstraint, defaultConstraint)) {
                return false;
            }
            if (!EqualityComparer<IdentityOptions>.Default.Equals(other.IdentityOptions, identityOptions)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsRowGuidCol, isRowGuidCol)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ConstraintDefinition>>.Default.Equals(other.Constraints, constraints)) {
                return false;
            }
            if (!EqualityComparer<ColumnStorageOptions>.Default.Equals(other.StorageOptions, storageOptions)) {
                return false;
            }
            if (!EqualityComparer<IndexDefinition>.Default.Equals(other.Index, index)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.GeneratedAlwaysType?>.Default.Equals(other.GeneratedAlways, generatedAlways)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsHidden, isHidden)) {
                return false;
            }
            if (!EqualityComparer<ColumnEncryptionDefinition>.Default.Equals(other.Encryption, encryption)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsMasked, isMasked)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.MaskingFunction, maskingFunction)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.ColumnIdentifier, columnIdentifier)) {
                return false;
            }
            if (!EqualityComparer<DataTypeReference>.Default.Equals(other.DataType, dataType)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ColumnDefinition left, ColumnDefinition right) {
            return EqualityComparer<ColumnDefinition>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ColumnDefinition left, ColumnDefinition right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ColumnDefinition)that;
            compare = Comparer.DefaultInvariant.Compare(this.computedColumnExpression, othr.computedColumnExpression);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isPersisted, othr.isPersisted);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.defaultConstraint, othr.defaultConstraint);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.identityOptions, othr.identityOptions);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isRowGuidCol, othr.isRowGuidCol);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.constraints, othr.constraints);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.storageOptions, othr.storageOptions);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.index, othr.index);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.generatedAlways, othr.generatedAlways);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isHidden, othr.isHidden);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.encryption, othr.encryption);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isMasked, othr.isMasked);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.maskingFunction, othr.maskingFunction);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.columnIdentifier, othr.columnIdentifier);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.dataType, othr.dataType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ColumnDefinition left, ColumnDefinition right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ColumnDefinition left, ColumnDefinition right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ColumnDefinition left, ColumnDefinition right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ColumnDefinition left, ColumnDefinition right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
