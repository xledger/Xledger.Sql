using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExecuteStatement : TSqlStatement, IEquatable<ExecuteStatement> {
        ExecuteSpecification executeSpecification;
        IReadOnlyList<ExecuteOption> options;
    
        public ExecuteSpecification ExecuteSpecification => executeSpecification;
        public IReadOnlyList<ExecuteOption> Options => options;
    
        public ExecuteStatement(ExecuteSpecification executeSpecification = null, IReadOnlyList<ExecuteOption> options = null) {
            this.executeSpecification = executeSpecification;
            this.options = options is null ? ImmList<ExecuteOption>.Empty : ImmList<ExecuteOption>.FromList(options);
        }
    
        public ScriptDom.ExecuteStatement ToMutableConcrete() {
            var ret = new ScriptDom.ExecuteStatement();
            ret.ExecuteSpecification = (ScriptDom.ExecuteSpecification)executeSpecification.ToMutable();
            ret.Options.AddRange(options.Select(c => (ScriptDom.ExecuteOption)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(executeSpecification is null)) {
                h = h * 23 + executeSpecification.GetHashCode();
            }
            h = h * 23 + options.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ExecuteStatement);
        } 
        
        public bool Equals(ExecuteStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ExecuteSpecification>.Default.Equals(other.ExecuteSpecification, executeSpecification)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ExecuteOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExecuteStatement left, ExecuteStatement right) {
            return EqualityComparer<ExecuteStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExecuteStatement left, ExecuteStatement right) {
            return !(left == right);
        }
    
    }

}
