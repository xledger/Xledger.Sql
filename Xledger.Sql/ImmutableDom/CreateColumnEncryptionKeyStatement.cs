using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateColumnEncryptionKeyStatement : ColumnEncryptionKeyStatement, IEquatable<CreateColumnEncryptionKeyStatement> {
        public CreateColumnEncryptionKeyStatement(Identifier name = null, IReadOnlyList<ColumnEncryptionKeyValue> columnEncryptionKeyValues = null) {
            this.name = name;
            this.columnEncryptionKeyValues = columnEncryptionKeyValues is null ? ImmList<ColumnEncryptionKeyValue>.Empty : ImmList<ColumnEncryptionKeyValue>.FromList(columnEncryptionKeyValues);
        }
    
        public ScriptDom.CreateColumnEncryptionKeyStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateColumnEncryptionKeyStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.ColumnEncryptionKeyValues.AddRange(columnEncryptionKeyValues.SelectList(c => (ScriptDom.ColumnEncryptionKeyValue)c.ToMutable()));
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
            h = h * 23 + columnEncryptionKeyValues.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateColumnEncryptionKeyStatement);
        } 
        
        public bool Equals(CreateColumnEncryptionKeyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ColumnEncryptionKeyValue>>.Default.Equals(other.ColumnEncryptionKeyValues, columnEncryptionKeyValues)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateColumnEncryptionKeyStatement left, CreateColumnEncryptionKeyStatement right) {
            return EqualityComparer<CreateColumnEncryptionKeyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateColumnEncryptionKeyStatement left, CreateColumnEncryptionKeyStatement right) {
            return !(left == right);
        }
    
    }

}
