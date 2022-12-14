using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterRemoteServiceBindingStatement : RemoteServiceBindingStatementBase, IEquatable<AlterRemoteServiceBindingStatement> {
        public AlterRemoteServiceBindingStatement(Identifier name = null, IReadOnlyList<RemoteServiceBindingOption> options = null) {
            this.name = name;
            this.options = ImmList<RemoteServiceBindingOption>.FromList(options);
        }
    
        public ScriptDom.AlterRemoteServiceBindingStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterRemoteServiceBindingStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.RemoteServiceBindingOption)c.ToMutable()));
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
            h = h * 23 + options.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterRemoteServiceBindingStatement);
        } 
        
        public bool Equals(AlterRemoteServiceBindingStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<RemoteServiceBindingOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterRemoteServiceBindingStatement left, AlterRemoteServiceBindingStatement right) {
            return EqualityComparer<AlterRemoteServiceBindingStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterRemoteServiceBindingStatement left, AlterRemoteServiceBindingStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterRemoteServiceBindingStatement)that;
            compare = StructuralComparisons.StructuralComparer.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = StructuralComparisons.StructuralComparer.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            return compare;
        } 
    
        public static AlterRemoteServiceBindingStatement FromMutable(ScriptDom.AlterRemoteServiceBindingStatement fragment) {
            return (AlterRemoteServiceBindingStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
