using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateWorkloadClassifierStatement : WorkloadClassifierStatement, IEquatable<CreateWorkloadClassifierStatement> {
        public CreateWorkloadClassifierStatement(Identifier classifierName = null, IReadOnlyList<WorkloadClassifierOption> options = null) {
            this.classifierName = classifierName;
            this.options = options is null ? ImmList<WorkloadClassifierOption>.Empty : ImmList<WorkloadClassifierOption>.FromList(options);
        }
    
        public ScriptDom.CreateWorkloadClassifierStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateWorkloadClassifierStatement();
            ret.ClassifierName = (ScriptDom.Identifier)classifierName.ToMutable();
            ret.Options.AddRange(options.Select(c => (ScriptDom.WorkloadClassifierOption)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(classifierName is null)) {
                h = h * 23 + classifierName.GetHashCode();
            }
            h = h * 23 + options.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateWorkloadClassifierStatement);
        } 
        
        public bool Equals(CreateWorkloadClassifierStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.ClassifierName, classifierName)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<WorkloadClassifierOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateWorkloadClassifierStatement left, CreateWorkloadClassifierStatement right) {
            return EqualityComparer<CreateWorkloadClassifierStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateWorkloadClassifierStatement left, CreateWorkloadClassifierStatement right) {
            return !(left == right);
        }
    
    }

}
