using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterDatabaseSetStatement : AlterDatabaseStatement, IEquatable<AlterDatabaseSetStatement> {
        protected AlterDatabaseTermination termination;
        protected IReadOnlyList<DatabaseOption> options;
    
        public AlterDatabaseTermination Termination => termination;
        public IReadOnlyList<DatabaseOption> Options => options;
    
        public AlterDatabaseSetStatement(AlterDatabaseTermination termination = null, IReadOnlyList<DatabaseOption> options = null, Identifier databaseName = null, bool useCurrent = false) {
            this.termination = termination;
            this.options = options is null ? ImmList<DatabaseOption>.Empty : ImmList<DatabaseOption>.FromList(options);
            this.databaseName = databaseName;
            this.useCurrent = useCurrent;
        }
    
        public ScriptDom.AlterDatabaseSetStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterDatabaseSetStatement();
            ret.Termination = (ScriptDom.AlterDatabaseTermination)termination.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.DatabaseOption)c.ToMutable()));
            ret.DatabaseName = (ScriptDom.Identifier)databaseName.ToMutable();
            ret.UseCurrent = useCurrent;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(termination is null)) {
                h = h * 23 + termination.GetHashCode();
            }
            h = h * 23 + options.GetHashCode();
            if (!(databaseName is null)) {
                h = h * 23 + databaseName.GetHashCode();
            }
            h = h * 23 + useCurrent.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterDatabaseSetStatement);
        } 
        
        public bool Equals(AlterDatabaseSetStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<AlterDatabaseTermination>.Default.Equals(other.Termination, termination)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<DatabaseOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.DatabaseName, databaseName)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.UseCurrent, useCurrent)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterDatabaseSetStatement left, AlterDatabaseSetStatement right) {
            return EqualityComparer<AlterDatabaseSetStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterDatabaseSetStatement left, AlterDatabaseSetStatement right) {
            return !(left == right);
        }
    
        public static AlterDatabaseSetStatement FromMutable(ScriptDom.AlterDatabaseSetStatement fragment) {
            return (AlterDatabaseSetStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
