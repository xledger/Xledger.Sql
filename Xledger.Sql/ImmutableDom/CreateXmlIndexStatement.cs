using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateXmlIndexStatement : IndexStatement, IEquatable<CreateXmlIndexStatement> {
        bool primary = false;
        Identifier xmlColumn;
        Identifier secondaryXmlIndexName;
        ScriptDom.SecondaryXmlIndexType secondaryXmlIndexType = ScriptDom.SecondaryXmlIndexType.NotSpecified;
        FileGroupOrPartitionScheme onFileGroupOrPartitionScheme;
    
        public bool Primary => primary;
        public Identifier XmlColumn => xmlColumn;
        public Identifier SecondaryXmlIndexName => secondaryXmlIndexName;
        public ScriptDom.SecondaryXmlIndexType SecondaryXmlIndexType => secondaryXmlIndexType;
        public FileGroupOrPartitionScheme OnFileGroupOrPartitionScheme => onFileGroupOrPartitionScheme;
    
        public CreateXmlIndexStatement(bool primary = false, Identifier xmlColumn = null, Identifier secondaryXmlIndexName = null, ScriptDom.SecondaryXmlIndexType secondaryXmlIndexType = ScriptDom.SecondaryXmlIndexType.NotSpecified, FileGroupOrPartitionScheme onFileGroupOrPartitionScheme = null, Identifier name = null, SchemaObjectName onName = null, IReadOnlyList<IndexOption> indexOptions = null) {
            this.primary = primary;
            this.xmlColumn = xmlColumn;
            this.secondaryXmlIndexName = secondaryXmlIndexName;
            this.secondaryXmlIndexType = secondaryXmlIndexType;
            this.onFileGroupOrPartitionScheme = onFileGroupOrPartitionScheme;
            this.name = name;
            this.onName = onName;
            this.indexOptions = indexOptions is null ? ImmList<IndexOption>.Empty : ImmList<IndexOption>.FromList(indexOptions);
        }
    
        public ScriptDom.CreateXmlIndexStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateXmlIndexStatement();
            ret.Primary = primary;
            ret.XmlColumn = (ScriptDom.Identifier)xmlColumn.ToMutable();
            ret.SecondaryXmlIndexName = (ScriptDom.Identifier)secondaryXmlIndexName.ToMutable();
            ret.SecondaryXmlIndexType = secondaryXmlIndexType;
            ret.OnFileGroupOrPartitionScheme = (ScriptDom.FileGroupOrPartitionScheme)onFileGroupOrPartitionScheme.ToMutable();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.OnName = (ScriptDom.SchemaObjectName)onName.ToMutable();
            ret.IndexOptions.AddRange(indexOptions.Select(c => (ScriptDom.IndexOption)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + primary.GetHashCode();
            if (!(xmlColumn is null)) {
                h = h * 23 + xmlColumn.GetHashCode();
            }
            if (!(secondaryXmlIndexName is null)) {
                h = h * 23 + secondaryXmlIndexName.GetHashCode();
            }
            h = h * 23 + secondaryXmlIndexType.GetHashCode();
            if (!(onFileGroupOrPartitionScheme is null)) {
                h = h * 23 + onFileGroupOrPartitionScheme.GetHashCode();
            }
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            if (!(onName is null)) {
                h = h * 23 + onName.GetHashCode();
            }
            h = h * 23 + indexOptions.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateXmlIndexStatement);
        } 
        
        public bool Equals(CreateXmlIndexStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.Primary, primary)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.XmlColumn, xmlColumn)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.SecondaryXmlIndexName, secondaryXmlIndexName)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.SecondaryXmlIndexType>.Default.Equals(other.SecondaryXmlIndexType, secondaryXmlIndexType)) {
                return false;
            }
            if (!EqualityComparer<FileGroupOrPartitionScheme>.Default.Equals(other.OnFileGroupOrPartitionScheme, onFileGroupOrPartitionScheme)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.OnName, onName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<IndexOption>>.Default.Equals(other.IndexOptions, indexOptions)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateXmlIndexStatement left, CreateXmlIndexStatement right) {
            return EqualityComparer<CreateXmlIndexStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateXmlIndexStatement left, CreateXmlIndexStatement right) {
            return !(left == right);
        }
    
    }

}
