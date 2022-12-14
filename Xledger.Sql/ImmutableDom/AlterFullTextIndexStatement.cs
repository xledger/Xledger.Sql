using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterFullTextIndexStatement : TSqlStatement, IEquatable<AlterFullTextIndexStatement> {
        protected SchemaObjectName onName;
        protected AlterFullTextIndexAction action;
    
        public SchemaObjectName OnName => onName;
        public AlterFullTextIndexAction Action => action;
    
        public AlterFullTextIndexStatement(SchemaObjectName onName = null, AlterFullTextIndexAction action = null) {
            this.onName = onName;
            this.action = action;
        }
    
        public ScriptDom.AlterFullTextIndexStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterFullTextIndexStatement();
            ret.OnName = (ScriptDom.SchemaObjectName)onName.ToMutable();
            ret.Action = (ScriptDom.AlterFullTextIndexAction)action.ToMutable();
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
            if (!(action is null)) {
                h = h * 23 + action.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterFullTextIndexStatement);
        } 
        
        public bool Equals(AlterFullTextIndexStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.OnName, onName)) {
                return false;
            }
            if (!EqualityComparer<AlterFullTextIndexAction>.Default.Equals(other.Action, action)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterFullTextIndexStatement left, AlterFullTextIndexStatement right) {
            return EqualityComparer<AlterFullTextIndexStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterFullTextIndexStatement left, AlterFullTextIndexStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterFullTextIndexStatement)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.onName, othr.onName);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.action, othr.action);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static AlterFullTextIndexStatement FromMutable(ScriptDom.AlterFullTextIndexStatement fragment) {
            return (AlterFullTextIndexStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
