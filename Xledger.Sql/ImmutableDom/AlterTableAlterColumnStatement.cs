using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterTableAlterColumnStatement : AlterTableStatement, IEquatable<AlterTableAlterColumnStatement> {
        protected Identifier columnIdentifier;
        protected DataTypeReference dataType;
        protected ScriptDom.AlterTableAlterColumnOption alterTableAlterColumnOption = ScriptDom.AlterTableAlterColumnOption.NoOptionDefined;
        protected ColumnStorageOptions storageOptions;
        protected IReadOnlyList<IndexOption> options;
        protected ScriptDom.GeneratedAlwaysType? generatedAlways;
        protected bool isHidden = false;
        protected ColumnEncryptionDefinition encryption;
        protected Identifier collation;
        protected bool isMasked = false;
        protected StringLiteral maskingFunction;
    
        public Identifier ColumnIdentifier => columnIdentifier;
        public DataTypeReference DataType => dataType;
        public ScriptDom.AlterTableAlterColumnOption AlterTableAlterColumnOption => alterTableAlterColumnOption;
        public ColumnStorageOptions StorageOptions => storageOptions;
        public IReadOnlyList<IndexOption> Options => options;
        public ScriptDom.GeneratedAlwaysType? GeneratedAlways => generatedAlways;
        public bool IsHidden => isHidden;
        public ColumnEncryptionDefinition Encryption => encryption;
        public Identifier Collation => collation;
        public bool IsMasked => isMasked;
        public StringLiteral MaskingFunction => maskingFunction;
    
        public AlterTableAlterColumnStatement(Identifier columnIdentifier = null, DataTypeReference dataType = null, ScriptDom.AlterTableAlterColumnOption alterTableAlterColumnOption = ScriptDom.AlterTableAlterColumnOption.NoOptionDefined, ColumnStorageOptions storageOptions = null, IReadOnlyList<IndexOption> options = null, ScriptDom.GeneratedAlwaysType? generatedAlways = null, bool isHidden = false, ColumnEncryptionDefinition encryption = null, Identifier collation = null, bool isMasked = false, StringLiteral maskingFunction = null, SchemaObjectName schemaObjectName = null) {
            this.columnIdentifier = columnIdentifier;
            this.dataType = dataType;
            this.alterTableAlterColumnOption = alterTableAlterColumnOption;
            this.storageOptions = storageOptions;
            this.options = ImmList<IndexOption>.FromList(options);
            this.generatedAlways = generatedAlways;
            this.isHidden = isHidden;
            this.encryption = encryption;
            this.collation = collation;
            this.isMasked = isMasked;
            this.maskingFunction = maskingFunction;
            this.schemaObjectName = schemaObjectName;
        }
    
        public ScriptDom.AlterTableAlterColumnStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterTableAlterColumnStatement();
            ret.ColumnIdentifier = (ScriptDom.Identifier)columnIdentifier.ToMutable();
            ret.DataType = (ScriptDom.DataTypeReference)dataType.ToMutable();
            ret.AlterTableAlterColumnOption = alterTableAlterColumnOption;
            ret.StorageOptions = (ScriptDom.ColumnStorageOptions)storageOptions.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.IndexOption)c.ToMutable()));
            ret.GeneratedAlways = generatedAlways;
            ret.IsHidden = isHidden;
            ret.Encryption = (ScriptDom.ColumnEncryptionDefinition)encryption.ToMutable();
            ret.Collation = (ScriptDom.Identifier)collation.ToMutable();
            ret.IsMasked = isMasked;
            ret.MaskingFunction = (ScriptDom.StringLiteral)maskingFunction.ToMutable();
            ret.SchemaObjectName = (ScriptDom.SchemaObjectName)schemaObjectName.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(columnIdentifier is null)) {
                h = h * 23 + columnIdentifier.GetHashCode();
            }
            if (!(dataType is null)) {
                h = h * 23 + dataType.GetHashCode();
            }
            h = h * 23 + alterTableAlterColumnOption.GetHashCode();
            if (!(storageOptions is null)) {
                h = h * 23 + storageOptions.GetHashCode();
            }
            h = h * 23 + options.GetHashCode();
            h = h * 23 + generatedAlways.GetHashCode();
            h = h * 23 + isHidden.GetHashCode();
            if (!(encryption is null)) {
                h = h * 23 + encryption.GetHashCode();
            }
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            h = h * 23 + isMasked.GetHashCode();
            if (!(maskingFunction is null)) {
                h = h * 23 + maskingFunction.GetHashCode();
            }
            if (!(schemaObjectName is null)) {
                h = h * 23 + schemaObjectName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterTableAlterColumnStatement);
        } 
        
        public bool Equals(AlterTableAlterColumnStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.ColumnIdentifier, columnIdentifier)) {
                return false;
            }
            if (!EqualityComparer<DataTypeReference>.Default.Equals(other.DataType, dataType)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AlterTableAlterColumnOption>.Default.Equals(other.AlterTableAlterColumnOption, alterTableAlterColumnOption)) {
                return false;
            }
            if (!EqualityComparer<ColumnStorageOptions>.Default.Equals(other.StorageOptions, storageOptions)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<IndexOption>>.Default.Equals(other.Options, options)) {
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
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsMasked, isMasked)) {
                return false;
            }
            if (!EqualityComparer<StringLiteral>.Default.Equals(other.MaskingFunction, maskingFunction)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.SchemaObjectName, schemaObjectName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterTableAlterColumnStatement left, AlterTableAlterColumnStatement right) {
            return EqualityComparer<AlterTableAlterColumnStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterTableAlterColumnStatement left, AlterTableAlterColumnStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterTableAlterColumnStatement)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.columnIdentifier, othr.columnIdentifier);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.dataType, othr.dataType);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.alterTableAlterColumnOption, othr.alterTableAlterColumnOption);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.storageOptions, othr.storageOptions);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.generatedAlways, othr.generatedAlways);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.isHidden, othr.isHidden);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.encryption, othr.encryption);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.collation, othr.collation);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.isMasked, othr.isMasked);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.maskingFunction, othr.maskingFunction);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.schemaObjectName, othr.schemaObjectName);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static AlterTableAlterColumnStatement FromMutable(ScriptDom.AlterTableAlterColumnStatement fragment) {
            return (AlterTableAlterColumnStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
