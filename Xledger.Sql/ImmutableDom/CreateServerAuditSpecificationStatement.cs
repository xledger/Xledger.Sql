using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateServerAuditSpecificationStatement : AuditSpecificationStatement, IEquatable<CreateServerAuditSpecificationStatement> {
        public CreateServerAuditSpecificationStatement(ScriptDom.OptionState auditState = ScriptDom.OptionState.NotSet, IReadOnlyList<AuditSpecificationPart> parts = null, Identifier specificationName = null, Identifier auditName = null) {
            this.auditState = auditState;
            this.parts = parts is null ? ImmList<AuditSpecificationPart>.Empty : ImmList<AuditSpecificationPart>.FromList(parts);
            this.specificationName = specificationName;
            this.auditName = auditName;
        }
    
        public ScriptDom.CreateServerAuditSpecificationStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateServerAuditSpecificationStatement();
            ret.AuditState = auditState;
            ret.Parts.AddRange(parts.Select(c => (ScriptDom.AuditSpecificationPart)c.ToMutable()));
            ret.SpecificationName = (ScriptDom.Identifier)specificationName.ToMutable();
            ret.AuditName = (ScriptDom.Identifier)auditName.ToMutable();
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
            return Equals(obj as CreateServerAuditSpecificationStatement);
        } 
        
        public bool Equals(CreateServerAuditSpecificationStatement other) {
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
        
        public static bool operator ==(CreateServerAuditSpecificationStatement left, CreateServerAuditSpecificationStatement right) {
            return EqualityComparer<CreateServerAuditSpecificationStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateServerAuditSpecificationStatement left, CreateServerAuditSpecificationStatement right) {
            return !(left == right);
        }
    
    }

}