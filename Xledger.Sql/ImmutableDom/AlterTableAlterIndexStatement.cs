using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterTableAlterIndexStatement : AlterTableStatement, IEquatable<AlterTableAlterIndexStatement> {
        protected Identifier indexIdentifier;
        protected ScriptDom.AlterIndexType alterIndexType = ScriptDom.AlterIndexType.Rebuild;
        protected IReadOnlyList<IndexOption> indexOptions;
    
        public Identifier IndexIdentifier => indexIdentifier;
        public ScriptDom.AlterIndexType AlterIndexType => alterIndexType;
        public IReadOnlyList<IndexOption> IndexOptions => indexOptions;
    
        public AlterTableAlterIndexStatement(Identifier indexIdentifier = null, ScriptDom.AlterIndexType alterIndexType = ScriptDom.AlterIndexType.Rebuild, IReadOnlyList<IndexOption> indexOptions = null, SchemaObjectName schemaObjectName = null) {
            this.indexIdentifier = indexIdentifier;
            this.alterIndexType = alterIndexType;
            this.indexOptions = indexOptions is null ? ImmList<IndexOption>.Empty : ImmList<IndexOption>.FromList(indexOptions);
            this.schemaObjectName = schemaObjectName;
        }
    
        public ScriptDom.AlterTableAlterIndexStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterTableAlterIndexStatement();
            ret.IndexIdentifier = (ScriptDom.Identifier)indexIdentifier.ToMutable();
            ret.AlterIndexType = alterIndexType;
            ret.IndexOptions.AddRange(indexOptions.SelectList(c => (ScriptDom.IndexOption)c.ToMutable()));
            ret.SchemaObjectName = (ScriptDom.SchemaObjectName)schemaObjectName.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(indexIdentifier is null)) {
                h = h * 23 + indexIdentifier.GetHashCode();
            }
            h = h * 23 + alterIndexType.GetHashCode();
            h = h * 23 + indexOptions.GetHashCode();
            if (!(schemaObjectName is null)) {
                h = h * 23 + schemaObjectName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterTableAlterIndexStatement);
        } 
        
        public bool Equals(AlterTableAlterIndexStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.IndexIdentifier, indexIdentifier)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.AlterIndexType>.Default.Equals(other.AlterIndexType, alterIndexType)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<IndexOption>>.Default.Equals(other.IndexOptions, indexOptions)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.SchemaObjectName, schemaObjectName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterTableAlterIndexStatement left, AlterTableAlterIndexStatement right) {
            return EqualityComparer<AlterTableAlterIndexStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterTableAlterIndexStatement left, AlterTableAlterIndexStatement right) {
            return !(left == right);
        }
    
    }

}
