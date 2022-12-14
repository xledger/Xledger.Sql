using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateQueueStatement : QueueStatement, IEquatable<CreateQueueStatement> {
        protected IdentifierOrValueExpression onFileGroup;
    
        public IdentifierOrValueExpression OnFileGroup => onFileGroup;
    
        public CreateQueueStatement(IdentifierOrValueExpression onFileGroup = null, SchemaObjectName name = null, IReadOnlyList<QueueOption> queueOptions = null) {
            this.onFileGroup = onFileGroup;
            this.name = name;
            this.queueOptions = ImmList<QueueOption>.FromList(queueOptions);
        }
    
        public ScriptDom.CreateQueueStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateQueueStatement();
            ret.OnFileGroup = (ScriptDom.IdentifierOrValueExpression)onFileGroup?.ToMutable();
            ret.Name = (ScriptDom.SchemaObjectName)name?.ToMutable();
            ret.QueueOptions.AddRange(queueOptions.SelectList(c => (ScriptDom.QueueOption)c?.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(onFileGroup is null)) {
                h = h * 23 + onFileGroup.GetHashCode();
            }
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + queueOptions.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateQueueStatement);
        } 
        
        public bool Equals(CreateQueueStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IdentifierOrValueExpression>.Default.Equals(other.OnFileGroup, onFileGroup)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<QueueOption>>.Default.Equals(other.QueueOptions, queueOptions)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateQueueStatement left, CreateQueueStatement right) {
            return EqualityComparer<CreateQueueStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateQueueStatement left, CreateQueueStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateQueueStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.onFileGroup, othr.onFileGroup);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.queueOptions, othr.queueOptions);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CreateQueueStatement left, CreateQueueStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateQueueStatement left, CreateQueueStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateQueueStatement left, CreateQueueStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateQueueStatement left, CreateQueueStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateQueueStatement FromMutable(ScriptDom.CreateQueueStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreateQueueStatement)) { throw new NotImplementedException("Unexpected subtype of CreateQueueStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateQueueStatement(
                onFileGroup: ImmutableDom.IdentifierOrValueExpression.FromMutable(fragment.OnFileGroup),
                name: ImmutableDom.SchemaObjectName.FromMutable(fragment.Name),
                queueOptions: fragment.QueueOptions.SelectList(ImmutableDom.QueueOption.FromMutable)
            );
        }
    
    }

}
