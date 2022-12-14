using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BeginEndAtomicBlockStatement : BeginEndBlockStatement, IEquatable<BeginEndAtomicBlockStatement> {
        protected IReadOnlyList<AtomicBlockOption> options;
    
        public IReadOnlyList<AtomicBlockOption> Options => options;
    
        public BeginEndAtomicBlockStatement(IReadOnlyList<AtomicBlockOption> options = null, StatementList statementList = null) {
            this.options = ImmList<AtomicBlockOption>.FromList(options);
            this.statementList = statementList;
        }
    
        public new ScriptDom.BeginEndAtomicBlockStatement ToMutableConcrete() {
            var ret = new ScriptDom.BeginEndAtomicBlockStatement();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.AtomicBlockOption)c?.ToMutable()));
            ret.StatementList = (ScriptDom.StatementList)statementList?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + options.GetHashCode();
            if (!(statementList is null)) {
                h = h * 23 + statementList.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as BeginEndAtomicBlockStatement);
        } 
        
        public bool Equals(BeginEndAtomicBlockStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<AtomicBlockOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<StatementList>.Default.Equals(other.StatementList, statementList)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(BeginEndAtomicBlockStatement left, BeginEndAtomicBlockStatement right) {
            return EqualityComparer<BeginEndAtomicBlockStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BeginEndAtomicBlockStatement left, BeginEndAtomicBlockStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (BeginEndAtomicBlockStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.statementList, othr.statementList);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (BeginEndAtomicBlockStatement left, BeginEndAtomicBlockStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(BeginEndAtomicBlockStatement left, BeginEndAtomicBlockStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (BeginEndAtomicBlockStatement left, BeginEndAtomicBlockStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(BeginEndAtomicBlockStatement left, BeginEndAtomicBlockStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static BeginEndAtomicBlockStatement FromMutable(ScriptDom.BeginEndAtomicBlockStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.BeginEndAtomicBlockStatement)) { throw new NotImplementedException("Unexpected subtype of BeginEndAtomicBlockStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new BeginEndAtomicBlockStatement(
                options: fragment.Options.SelectList(ImmutableDom.AtomicBlockOption.FromMutable),
                statementList: ImmutableDom.StatementList.FromMutable(fragment.StatementList)
            );
        }
    
    }

}
