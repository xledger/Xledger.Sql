using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateSequenceStatement : SequenceStatement, IEquatable<CreateSequenceStatement> {
        public CreateSequenceStatement(SchemaObjectName name = null, IReadOnlyList<SequenceOption> sequenceOptions = null) {
            this.name = name;
            this.sequenceOptions = ImmList<SequenceOption>.FromList(sequenceOptions);
        }
    
        public ScriptDom.CreateSequenceStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateSequenceStatement();
            ret.Name = (ScriptDom.SchemaObjectName)name?.ToMutable();
            ret.SequenceOptions.AddRange(sequenceOptions.SelectList(c => (ScriptDom.SequenceOption)c?.ToMutable()));
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
            h = h * 23 + sequenceOptions.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateSequenceStatement);
        } 
        
        public bool Equals(CreateSequenceStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<SequenceOption>>.Default.Equals(other.SequenceOptions, sequenceOptions)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateSequenceStatement left, CreateSequenceStatement right) {
            return EqualityComparer<CreateSequenceStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateSequenceStatement left, CreateSequenceStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateSequenceStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.sequenceOptions, othr.sequenceOptions);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CreateSequenceStatement left, CreateSequenceStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateSequenceStatement left, CreateSequenceStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateSequenceStatement left, CreateSequenceStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateSequenceStatement left, CreateSequenceStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateSequenceStatement FromMutable(ScriptDom.CreateSequenceStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreateSequenceStatement)) { throw new NotImplementedException("Unexpected subtype of CreateSequenceStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateSequenceStatement(
                name: ImmutableDom.SchemaObjectName.FromMutable(fragment.Name),
                sequenceOptions: fragment.SequenceOptions.SelectList(ImmutableDom.SequenceOption.FromMutable)
            );
        }
    
    }

}
