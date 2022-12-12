using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterApplicationRoleStatement : ApplicationRoleStatement, IEquatable<AlterApplicationRoleStatement> {
        public AlterApplicationRoleStatement(Identifier name = null, IReadOnlyList<ApplicationRoleOption> applicationRoleOptions = null) {
            this.name = name;
            this.applicationRoleOptions = applicationRoleOptions is null ? ImmList<ApplicationRoleOption>.Empty : ImmList<ApplicationRoleOption>.FromList(applicationRoleOptions);
        }
    
        public ScriptDom.AlterApplicationRoleStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterApplicationRoleStatement();
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.ApplicationRoleOptions.AddRange(applicationRoleOptions.SelectList(c => (ScriptDom.ApplicationRoleOption)c.ToMutable()));
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
            h = h * 23 + applicationRoleOptions.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterApplicationRoleStatement);
        } 
        
        public bool Equals(AlterApplicationRoleStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ApplicationRoleOption>>.Default.Equals(other.ApplicationRoleOptions, applicationRoleOptions)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterApplicationRoleStatement left, AlterApplicationRoleStatement right) {
            return EqualityComparer<AlterApplicationRoleStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterApplicationRoleStatement left, AlterApplicationRoleStatement right) {
            return !(left == right);
        }
    
    }

}
