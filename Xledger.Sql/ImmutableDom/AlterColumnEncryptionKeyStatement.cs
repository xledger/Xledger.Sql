using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterColumnEncryptionKeyStatement : ColumnEncryptionKeyStatement, IEquatable<AlterColumnEncryptionKeyStatement> {
        protected ScriptDom.ColumnEncryptionKeyAlterType alterType = ScriptDom.ColumnEncryptionKeyAlterType.Add;
    
        public ScriptDom.ColumnEncryptionKeyAlterType AlterType => alterType;
    
        public AlterColumnEncryptionKeyStatement(ScriptDom.ColumnEncryptionKeyAlterType alterType = ScriptDom.ColumnEncryptionKeyAlterType.Add, Identifier name = null, IReadOnlyList<ColumnEncryptionKeyValue> columnEncryptionKeyValues = null) {
            this.alterType = alterType;
            this.name = name;
            this.columnEncryptionKeyValues = columnEncryptionKeyValues is null ? ImmList<ColumnEncryptionKeyValue>.Empty : ImmList<ColumnEncryptionKeyValue>.FromList(columnEncryptionKeyValues);
        }
    
        public ScriptDom.AlterColumnEncryptionKeyStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterColumnEncryptionKeyStatement();
            ret.AlterType = alterType;
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.ColumnEncryptionKeyValues.AddRange(columnEncryptionKeyValues.SelectList(c => (ScriptDom.ColumnEncryptionKeyValue)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + alterType.GetHashCode();
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + columnEncryptionKeyValues.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterColumnEncryptionKeyStatement);
        } 
        
        public bool Equals(AlterColumnEncryptionKeyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.ColumnEncryptionKeyAlterType>.Default.Equals(other.AlterType, alterType)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ColumnEncryptionKeyValue>>.Default.Equals(other.ColumnEncryptionKeyValues, columnEncryptionKeyValues)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterColumnEncryptionKeyStatement left, AlterColumnEncryptionKeyStatement right) {
            return EqualityComparer<AlterColumnEncryptionKeyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterColumnEncryptionKeyStatement left, AlterColumnEncryptionKeyStatement right) {
            return !(left == right);
        }
    
    }

}
