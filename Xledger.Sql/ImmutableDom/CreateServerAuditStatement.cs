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
            this.options = ImmList<AuditOption>.FromList(options);
            this.predicateExpression = predicateExpression;
        }
    
        public ScriptDom.CreateServerAuditStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateServerAuditStatement();
            ret.AuditName = (ScriptDom.Identifier)auditName?.ToMutable();
            ret.AuditTarget = (ScriptDom.AuditTarget)auditTarget?.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.AuditOption)c?.ToMutable()));
            ret.PredicateExpression = (ScriptDom.BooleanExpression)predicateExpression?.ToMutable();
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
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateServerAuditStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.auditName, othr.auditName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.auditTarget, othr.auditTarget);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.predicateExpression, othr.predicateExpression);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CreateServerAuditStatement left, CreateServerAuditStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateServerAuditStatement left, CreateServerAuditStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateServerAuditStatement left, CreateServerAuditStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateServerAuditStatement left, CreateServerAuditStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateServerAuditStatement FromMutable(ScriptDom.CreateServerAuditStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreateServerAuditStatement)) { throw new NotImplementedException("Unexpected subtype of CreateServerAuditStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateServerAuditStatement(
                auditName: ImmutableDom.Identifier.FromMutable(fragment.AuditName),
                auditTarget: ImmutableDom.AuditTarget.FromMutable(fragment.AuditTarget),
                options: fragment.Options.SelectList(ImmutableDom.AuditOption.FromMutable),
                predicateExpression: ImmutableDom.BooleanExpression.FromMutable(fragment.PredicateExpression)
            );
        }
    
    }

}
