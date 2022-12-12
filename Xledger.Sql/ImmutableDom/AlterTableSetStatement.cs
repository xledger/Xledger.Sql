using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterTableSetStatement : AlterTableStatement, IEquatable<AlterTableSetStatement> {
        protected IReadOnlyList<TableOption> options;
    
        public IReadOnlyList<TableOption> Options => options;
    
        public AlterTableSetStatement(IReadOnlyList<TableOption> options = null, SchemaObjectName schemaObjectName = null) {
            this.options = options is null ? ImmList<TableOption>.Empty : ImmList<TableOption>.FromList(options);
            this.schemaObjectName = schemaObjectName;
        }
    
        public ScriptDom.AlterTableSetStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterTableSetStatement();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.TableOption)c.ToMutable()));
            ret.SchemaObjectName = (ScriptDom.SchemaObjectName)schemaObjectName.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + options.GetHashCode();
            if (!(schemaObjectName is null)) {
                h = h * 23 + schemaObjectName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterTableSetStatement);
        } 
        
        public bool Equals(AlterTableSetStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<TableOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.SchemaObjectName, schemaObjectName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterTableSetStatement left, AlterTableSetStatement right) {
            return EqualityComparer<AlterTableSetStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterTableSetStatement left, AlterTableSetStatement right) {
            return !(left == right);
        }
    
    }

}
