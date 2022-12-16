using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ReceiveStatement : WaitForSupportedStatement, IEquatable<ReceiveStatement> {
        protected ScalarExpression top;
        protected IReadOnlyList<SelectElement> selectElements;
        protected SchemaObjectName queue;
        protected VariableTableReference into;
        protected ValueExpression where;
        protected bool isConversationGroupIdWhere = false;
    
        public ScalarExpression Top => top;
        public IReadOnlyList<SelectElement> SelectElements => selectElements;
        public SchemaObjectName Queue => queue;
        public VariableTableReference Into => into;
        public ValueExpression Where => where;
        public bool IsConversationGroupIdWhere => isConversationGroupIdWhere;
    
        public ReceiveStatement(ScalarExpression top = null, IReadOnlyList<SelectElement> selectElements = null, SchemaObjectName queue = null, VariableTableReference into = null, ValueExpression where = null, bool isConversationGroupIdWhere = false) {
            this.top = top;
            this.selectElements = ImmList<SelectElement>.FromList(selectElements);
            this.queue = queue;
            this.into = into;
            this.where = where;
            this.isConversationGroupIdWhere = isConversationGroupIdWhere;
        }
    
        public ScriptDom.ReceiveStatement ToMutableConcrete() {
            var ret = new ScriptDom.ReceiveStatement();
            ret.Top = (ScriptDom.ScalarExpression)top?.ToMutable();
            ret.SelectElements.AddRange(selectElements.SelectList(c => (ScriptDom.SelectElement)c?.ToMutable()));
            ret.Queue = (ScriptDom.SchemaObjectName)queue?.ToMutable();
            ret.Into = (ScriptDom.VariableTableReference)into?.ToMutable();
            ret.Where = (ScriptDom.ValueExpression)where?.ToMutable();
            ret.IsConversationGroupIdWhere = isConversationGroupIdWhere;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(top is null)) {
                h = h * 23 + top.GetHashCode();
            }
            h = h * 23 + selectElements.GetHashCode();
            if (!(queue is null)) {
                h = h * 23 + queue.GetHashCode();
            }
            if (!(into is null)) {
                h = h * 23 + into.GetHashCode();
            }
            if (!(where is null)) {
                h = h * 23 + where.GetHashCode();
            }
            h = h * 23 + isConversationGroupIdWhere.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ReceiveStatement);
        } 
        
        public bool Equals(ReceiveStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.Top, top)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<SelectElement>>.Default.Equals(other.SelectElements, selectElements)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Queue, queue)) {
                return false;
            }
            if (!EqualityComparer<VariableTableReference>.Default.Equals(other.Into, into)) {
                return false;
            }
            if (!EqualityComparer<ValueExpression>.Default.Equals(other.Where, where)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsConversationGroupIdWhere, isConversationGroupIdWhere)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ReceiveStatement left, ReceiveStatement right) {
            return EqualityComparer<ReceiveStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ReceiveStatement left, ReceiveStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (!object.ReferenceEquals(this.GetType(), that.GetType())) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ReceiveStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.top, othr.top);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.selectElements, othr.selectElements);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.queue, othr.queue);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.into, othr.into);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.where, othr.where);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isConversationGroupIdWhere, othr.isConversationGroupIdWhere);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ReceiveStatement left, ReceiveStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ReceiveStatement left, ReceiveStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ReceiveStatement left, ReceiveStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ReceiveStatement left, ReceiveStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
