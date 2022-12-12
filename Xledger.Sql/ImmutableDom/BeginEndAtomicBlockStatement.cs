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
            this.options = options is null ? ImmList<AtomicBlockOption>.Empty : ImmList<AtomicBlockOption>.FromList(options);
            this.statementList = statementList;
        }
    
        public ScriptDom.BeginEndAtomicBlockStatement ToMutableConcrete() {
            var ret = new ScriptDom.BeginEndAtomicBlockStatement();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.AtomicBlockOption)c.ToMutable()));
            ret.StatementList = (ScriptDom.StatementList)statementList.ToMutable();
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
    
    }

}
