using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateServerAuditStatement : ServerAuditStatement, IEquatable<CreateServerAuditStatement> {
        public CreateServerAuditStatement(Identifier auditName = null, AuditTarget auditTarget = null, IReadOnlyList<AuditOption> options = null, BooleanExpression predicateExpression = null) {
            this.auditName = auditName;
            this.auditTarget = auditTarget;
            this.options = options is null ? ImmList<AuditOption>.Empty : ImmList<AuditOption>.FromList(options);
            this.predicateExpression = predicateExpression;
        }
    
        public ScriptDom.CreateServerAuditStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateServerAuditStatement();
            ret.AuditName = (ScriptDom.Identifier)auditName.ToMutable();
            ret.AuditTarget = (ScriptDom.AuditTarget)auditTarget.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.AuditOption)c.ToMutable()));
            ret.PredicateExpression = (ScriptDom.BooleanExpression)predicateExpression.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(auditName is null)) {
                h = h * 23 + auditName.GetHashCode();
            }
            if (!(auditTarget is null)) {
                h = h * 23 + auditTarget.GetHashCode();
            }
            h = h * 23 + options.GetHashCode();
            if (!(predicateExpression is null)) {
                h = h * 23 + predicateExpression.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateServerAuditStatement);
        } 
        
        public bool Equals(CreateServerAuditStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.AuditName, auditName)) {
                return false;
            }
            if (!EqualityComparer<AuditTarget>.Default.Equals(other.AuditTarget, auditTarget)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<AuditOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<BooleanExpression>.Default.Equals(other.PredicateExpression, predicateExpression)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateServerAuditStatement left, CreateServerAuditStatement right) {
            return EqualityComparer<CreateServerAuditStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateServerAuditStatement left, CreateServerAuditStatement right) {
            return !(left == right);
        }
    
        public static CreateServerAuditStatement FromMutable(ScriptDom.CreateServerAuditStatement fragment) {
            return (CreateServerAuditStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
