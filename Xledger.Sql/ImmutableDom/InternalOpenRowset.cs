using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class InternalOpenRowset : TableReferenceWithAlias, IEquatable<InternalOpenRowset> {
        protected Identifier identifier;
        protected IReadOnlyList<ScalarExpression> varArgs;
    
        public Identifier Identifier => identifier;
        public IReadOnlyList<ScalarExpression> VarArgs => varArgs;
    
        public InternalOpenRowset(Identifier identifier = null, IReadOnlyList<ScalarExpression> varArgs = null, Identifier alias = null, bool forPath = false) {
            this.identifier = identifier;
            this.varArgs = varArgs is null ? ImmList<ScalarExpression>.Empty : ImmList<ScalarExpression>.FromList(varArgs);
            this.alias = alias;
            this.forPath = forPath;
        }
    
        public ScriptDom.InternalOpenRowset ToMutableConcrete() {
            var ret = new ScriptDom.InternalOpenRowset();
            ret.Identifier = (ScriptDom.Identifier)identifier.ToMutable();
            ret.VarArgs.AddRange(varArgs.SelectList(c => (ScriptDom.ScalarExpression)c.ToMutable()));
            ret.Alias = (ScriptDom.Identifier)alias.ToMutable();
            ret.ForPath = forPath;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(identifier is null)) {
                h = h * 23 + identifier.GetHashCode();
            }
            h = h * 23 + varArgs.GetHashCode();
            if (!(alias is null)) {
                h = h * 23 + alias.GetHashCode();
            }
            h = h * 23 + forPath.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as InternalOpenRowset);
        } 
        
        public bool Equals(InternalOpenRowset other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Identifier, identifier)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ScalarExpression>>.Default.Equals(other.VarArgs, varArgs)) {
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
        
        public static bool operator ==(InternalOpenRowset left, InternalOpenRowset right) {
            return EqualityComparer<InternalOpenRowset>.Default.Equals(left, right);
        }
        
        public static bool operator !=(InternalOpenRowset left, InternalOpenRowset right) {
            return !(left == right);
        }
    
        public static InternalOpenRowset FromMutable(ScriptDom.InternalOpenRowset fragment) {
            return (InternalOpenRowset)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
