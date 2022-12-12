using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class GlobalFunctionTableReference : TableReferenceWithAlias, IEquatable<GlobalFunctionTableReference> {
        Identifier name;
        IReadOnlyList<ScalarExpression> parameters;
    
        public Identifier Name => name;
        public IReadOnlyList<ScalarExpression> Parameters => parameters;
    
        public GlobalFunctionTableReference(Identifier name = null, IReadOnlyList<ScalarExpression> parameters = null, Identifier alias = null, bool forPath = false) {
            this.name = name;
            this.parameters = parameters is null ? ImmList<ScalarExpression>.Empty : ImmList<ScalarExpression>.FromList(parameters);
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.GlobalFunctionTableReference ToMutableConcrete() {
            var ret = new ScriptDom.GlobalFunctionTableReference();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.Parameters.AddRange(parameters.Select(c => (ScriptDom.ScalarExpression)c.ToMutable()));
            ret.Alias = (ScriptDom.Identifier)alias.ToMutable();
            ret.ForPath = forPath;
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
            h = h * 23 + parameters.GetHashCode();
            if (!(alias is null)) {
                h = h * 23 + alias.GetHashCode();
            }
            h = h * 23 + forPath.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as GlobalFunctionTableReference);
        } 
        
        public bool Equals(GlobalFunctionTableReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ScalarExpression>>.Default.Equals(other.Parameters, parameters)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Alias, alias)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.ForPath, forPath)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(GlobalFunctionTableReference left, GlobalFunctionTableReference right) {
            return EqualityComparer<GlobalFunctionTableReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(GlobalFunctionTableReference left, GlobalFunctionTableReference right) {
            return !(left == right);
        }
    
    }

}
