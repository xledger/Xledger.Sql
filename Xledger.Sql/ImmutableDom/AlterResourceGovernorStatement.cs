using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterResourceGovernorStatement : TSqlStatement, IEquatable<AlterResourceGovernorStatement> {
        protected ScriptDom.AlterResourceGovernorCommandType command = ScriptDom.AlterResourceGovernorCommandType.Unknown;
        protected SchemaObjectName classifierFunction;
    
        public ScriptDom.AlterResourceGovernorCommandType Command => command;
        public SchemaObjectName ClassifierFunction => classifierFunction;
    
        public AlterResourceGovernorStatement(ScriptDom.AlterResourceGovernorCommandType command = ScriptDom.AlterResourceGovernorCommandType.Unknown, SchemaObjectName classifierFunction = null) {
            this.command = command;
            this.classifierFunction = classifierFunction;
        }
    
        public ScriptDom.AlterResourceGovernorStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterResourceGovernorStatement();
            ret.Command = command;
            ret.ClassifierFunction = (ScriptDom.SchemaObjectName)classifierFunction.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + command.GetHashCode();
            if (!(classifierFunction is null)) {
                h = h * 23 + classifierFunction.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterResourceGovernorStatement);
        } 
        
        public bool Equals(AlterResourceGovernorStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.AlterResourceGovernorCommandType>.Default.Equals(other.Command, command)) {
                return false;
            }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.ClassifierFunction, classifierFunction)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterResourceGovernorStatement left, AlterResourceGovernorStatement right) {
            return EqualityComparer<AlterResourceGovernorStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterResourceGovernorStatement left, AlterResourceGovernorStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AlterResourceGovernorStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.command, othr.command);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.classifierFunction, othr.classifierFunction);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AlterResourceGovernorStatement left, AlterResourceGovernorStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AlterResourceGovernorStatement left, AlterResourceGovernorStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AlterResourceGovernorStatement left, AlterResourceGovernorStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AlterResourceGovernorStatement left, AlterResourceGovernorStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
