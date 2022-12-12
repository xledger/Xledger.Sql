using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SetIdentityInsertStatement : SetOnOffStatement, IEquatable<SetIdentityInsertStatement> {
        SchemaObjectName table;
    
        public SchemaObjectName Table => table;
    
        public SetIdentityInsertStatement(SchemaObjectName table = null, bool isOn = false) {
            this.table = table;
            this.isOn = isOn;
        }
    
        public ScriptDom.SetIdentityInsertStatement ToMutableConcrete() {
            var ret = new ScriptDom.SetIdentityInsertStatement();
            ret.Table = (ScriptDom.SchemaObjectName)table.ToMutable();
            ret.IsOn = isOn;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(table is null)) {
                h = h * 23 + table.GetHashCode();
            }
            h = h * 23 + isOn.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SetIdentityInsertStatement);
        } 
        
        public bool Equals(SetIdentityInsertStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Table, table)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsOn, isOn)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SetIdentityInsertStatement left, SetIdentityInsertStatement right) {
            return EqualityComparer<SetIdentityInsertStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SetIdentityInsertStatement left, SetIdentityInsertStatement right) {
            return !(left == right);
        }
    
    }

}
