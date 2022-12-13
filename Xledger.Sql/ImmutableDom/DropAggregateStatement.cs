using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropAggregateStatement : DropObjectsStatement, IEquatable<DropAggregateStatement> {
        public DropAggregateStatement(IReadOnlyList<SchemaObjectName> objects = null, bool isIfExists = false) {
            this.objects = objects is null ? ImmList<SchemaObjectName>.Empty : ImmList<SchemaObjectName>.FromList(objects);
            this.isIfExists = isIfExists;
        }
    
        public ScriptDom.DropAggregateStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropAggregateStatement();
            ret.Objects.AddRange(objects.SelectList(c => (ScriptDom.SchemaObjectName)c.ToMutable()));
            ret.IsIfExists = isIfExists;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + objects.GetHashCode();
            h = h * 23 + isIfExists.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropAggregateStatement);
        } 
        
        public bool Equals(DropAggregateStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<SchemaObjectName>>.Default.Equals(other.Objects, objects)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsIfExists, isIfExists)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropAggregateStatement left, DropAggregateStatement right) {
            return EqualityComparer<DropAggregateStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropAggregateStatement left, DropAggregateStatement right) {
            return !(left == right);
        }
    
        public static DropAggregateStatement FromMutable(ScriptDom.DropAggregateStatement fragment) {
            return (DropAggregateStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
