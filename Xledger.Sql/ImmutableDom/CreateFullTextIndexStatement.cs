using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateFullTextIndexStatement : TSqlStatement, IEquatable<CreateFullTextIndexStatement> {
        protected SchemaObjectName onName;
        protected IReadOnlyList<FullTextIndexColumn> fullTextIndexColumns;
        protected Identifier keyIndexName;
        protected FullTextCatalogAndFileGroup catalogAndFileGroup;
        protected IReadOnlyList<FullTextIndexOption> options;
    
        public SchemaObjectName OnName => onName;
        public IReadOnlyList<FullTextIndexColumn> FullTextIndexColumns => fullTextIndexColumns;
        public Identifier KeyIndexName => keyIndexName;
        public FullTextCatalogAndFileGroup CatalogAndFileGroup => catalogAndFileGroup;
        public IReadOnlyList<FullTextIndexOption> Options => options;
    
        public CreateFullTextIndexStatement(SchemaObjectName onName = null, IReadOnlyList<FullTextIndexColumn> fullTextIndexColumns = null, Identifier keyIndexName = null, FullTextCatalogAndFileGroup catalogAndFileGroup = null, IReadOnlyList<FullTextIndexOption> options = null) {
            this.onName = onName;
            this.fullTextIndexColumns = fullTextIndexColumns is null ? ImmList<FullTextIndexColumn>.Empty : ImmList<FullTextIndexColumn>.FromList(fullTextIndexColumns);
            this.keyIndexName = keyIndexName;
            this.catalogAndFileGroup = catalogAndFileGroup;
            this.options = options is null ? ImmList<FullTextIndexOption>.Empty : ImmList<FullTextIndexOption>.FromList(options);
        }
    
        public ScriptDom.CreateFullTextIndexStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateFullTextIndexStatement();
            ret.OnName = (ScriptDom.SchemaObjectName)onName.ToMutable();
            ret.FullTextIndexColumns.AddRange(fullTextIndexColumns.SelectList(c => (ScriptDom.FullTextIndexColumn)c.ToMutable()));
            ret.KeyIndexName = (ScriptDom.Identifier)keyIndexName.ToMutable();
            ret.CatalogAndFileGroup = (ScriptDom.FullTextCatalogAndFileGroup)catalogAndFileGroup.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.FullTextIndexOption)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(onName is null)) {
                h = h * 23 + onName.GetHashCode();
            }
            h = h * 23 + fullTextIndexColumns.GetHashCode();
            if (!(keyIndexName is null)) {
                h = h * 23 + keyIndexName.GetHashCode();
            }
            if (!(catalogAndFileGroup is null)) {
                h = h * 23 + catalogAndFileGroup.GetHashCode();
            }
            h = h * 23 + options.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateFullTextIndexStatement);
        } 
        
        public bool Equals(CreateFullTextIndexStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.OnName, onName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<FullTextIndexColumn>>.Default.Equals(other.FullTextIndexColumns, fullTextIndexColumns)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.KeyIndexName, keyIndexName)) {
                return false;
            }
            if (!EqualityComparer<FullTextCatalogAndFileGroup>.Default.Equals(other.CatalogAndFileGroup, catalogAndFileGroup)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<FullTextIndexOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateFullTextIndexStatement left, CreateFullTextIndexStatement right) {
            return EqualityComparer<CreateFullTextIndexStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateFullTextIndexStatement left, CreateFullTextIndexStatement right) {
            return !(left == right);
        }
    
    }

}
