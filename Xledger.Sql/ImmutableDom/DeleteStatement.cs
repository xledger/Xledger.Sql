using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DeleteStatement : DataModificationStatement, IEquatable<DeleteStatement> {
        protected DeleteSpecification deleteSpecification;
    
        public DeleteSpecification DeleteSpecification => deleteSpecification;
    
        public DeleteStatement(DeleteSpecification deleteSpecification = null, WithCtesAndXmlNamespaces withCtesAndXmlNamespaces = null, IReadOnlyList<OptimizerHint> optimizerHints = null) {
            this.deleteSpecification = deleteSpecification;
            this.withCtesAndXmlNamespaces = withCtesAndXmlNamespaces;
            this.optimizerHints = optimizerHints is null ? ImmList<OptimizerHint>.Empty : ImmList<OptimizerHint>.FromList(optimizerHints);
        }
    
        public ScriptDom.DeleteStatement ToMutableConcrete() {
            var ret = new ScriptDom.DeleteStatement();
            ret.DeleteSpecification = (ScriptDom.DeleteSpecification)deleteSpecification.ToMutable();
            ret.WithCtesAndXmlNamespaces = (ScriptDom.WithCtesAndXmlNamespaces)withCtesAndXmlNamespaces.ToMutable();
            ret.OptimizerHints.AddRange(optimizerHints.SelectList(c => (ScriptDom.OptimizerHint)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(deleteSpecification is null)) {
                h = h * 23 + deleteSpecification.GetHashCode();
            }
            if (!(withCtesAndXmlNamespaces is null)) {
                h = h * 23 + withCtesAndXmlNamespaces.GetHashCode();
            }
            h = h * 23 + optimizerHints.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DeleteStatement);
        } 
        
        public bool Equals(DeleteStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<DeleteSpecification>.Default.Equals(other.DeleteSpecification, deleteSpecification)) {
                return false;
            }
            if (!EqualityComparer<WithCtesAndXmlNamespaces>.Default.Equals(other.WithCtesAndXmlNamespaces, withCtesAndXmlNamespaces)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<OptimizerHint>>.Default.Equals(other.OptimizerHints, optimizerHints)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DeleteStatement left, DeleteStatement right) {
            return EqualityComparer<DeleteStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DeleteStatement left, DeleteStatement right) {
            return !(left == right);
        }
    
        public static DeleteStatement FromMutable(ScriptDom.DeleteStatement fragment) {
            return (DeleteStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
