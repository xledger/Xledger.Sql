using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateDatabaseAuditSpecificationStatement : AuditSpecificationStatement, IEquatable<CreateDatabaseAuditSpecificationStatement> {
        public CreateDatabaseAuditSpecificationStatement(ScriptDom.OptionState auditState = ScriptDom.OptionState.NotSet, IReadOnlyList<AuditSpecificationPart> parts = null, Identifier specificationName = null, Identifier auditName = null) {
            this.auditState = auditState;
            this.parts = ImmList<AuditSpecificationPart>.FromList(parts);
            this.specificationName = specificationName;
            this.auditName = auditName;
        }
    
        public ScriptDom.CreateDatabaseAuditSpecificationStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateDatabaseAuditSpecificationStatement();
            ret.AuditState = auditState;
            ret.Parts.AddRange(parts.SelectList(c => (ScriptDom.AuditSpecificationPart)c?.ToMutable()));
            ret.SpecificationName = (ScriptDom.Identifier)specificationName?.ToMutable();
            ret.AuditName = (ScriptDom.Identifier)auditName?.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + auditState.GetHashCode();
            h = h * 23 + parts.GetHashCode();
            if (!(specificationName is null)) {
                h = h * 23 + specificationName.GetHashCode();
            }
            if (!(auditName is null)) {
                h = h * 23 + auditName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateDatabaseAuditSpecificationStatement);
        } 
        
        public bool Equals(CreateDatabaseAuditSpecificationStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.OptionState>.Default.Equals(other.AuditState, auditState)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<AuditSpecificationPart>>.Default.Equals(other.Parts, parts)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.SpecificationName, specificationName)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.AuditName, auditName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateDatabaseAuditSpecificationStatement left, CreateDatabaseAuditSpecificationStatement right) {
            return EqualityComparer<CreateDatabaseAuditSpecificationStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateDatabaseAuditSpecificationStatement left, CreateDatabaseAuditSpecificationStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateDatabaseAuditSpecificationStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.auditState, othr.auditState);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.parts, othr.parts);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.specificationName, othr.specificationName);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.auditName, othr.auditName);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CreateDatabaseAuditSpecificationStatement left, CreateDatabaseAuditSpecificationStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateDatabaseAuditSpecificationStatement left, CreateDatabaseAuditSpecificationStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateDatabaseAuditSpecificationStatement left, CreateDatabaseAuditSpecificationStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateDatabaseAuditSpecificationStatement left, CreateDatabaseAuditSpecificationStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateDatabaseAuditSpecificationStatement FromMutable(ScriptDom.CreateDatabaseAuditSpecificationStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreateDatabaseAuditSpecificationStatement)) { throw new NotImplementedException("Unexpected subtype of CreateDatabaseAuditSpecificationStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateDatabaseAuditSpecificationStatement(
                auditState: fragment.AuditState,
                parts: fragment.Parts.SelectList(ImmutableDom.AuditSpecificationPart.FromMutable),
                specificationName: ImmutableDom.Identifier.FromMutable(fragment.SpecificationName),
                auditName: ImmutableDom.Identifier.FromMutable(fragment.AuditName)
            );
        }
    
    }

}
