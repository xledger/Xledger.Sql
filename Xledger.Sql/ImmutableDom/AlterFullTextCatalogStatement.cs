using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterFullTextCatalogStatement : FullTextCatalogStatement, IEquatable<AlterFullTextCatalogStatement> {
        protected ScriptDom.AlterFullTextCatalogAction action = ScriptDom.AlterFullTextCatalogAction.None;
    
        public ScriptDom.AlterFullTextCatalogAction Action => action;
    
        public AlterFullTextCatalogStatement(ScriptDom.AlterFullTextCatalogAction action = ScriptDom.AlterFullTextCatalogAction.None, Identifier name = null, IReadOnlyList<FullTextCatalogOption> options = null) {
            this.action = action;
            this.name = name;
            this.options = options is null ? ImmList<FullTextCatalogOption>.Empty : ImmList<FullTextCatalogOption>.FromList(options);
        }
    
        public ScriptDom.AlterFullTextCatalogStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterFullTextCatalogStatement();
            ret.Action = action;
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.FullTextCatalogOption)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + action.GetHashCode();
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + options.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterFullTextCatalogStatement);
        } 
        
        public bool Equals(AlterFullTextCatalogStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.AlterFullTextCatalogAction>.Default.Equals(other.Action, action)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<FullTextCatalogOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterFullTextCatalogStatement left, AlterFullTextCatalogStatement right) {
            return EqualityComparer<AlterFullTextCatalogStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterFullTextCatalogStatement left, AlterFullTextCatalogStatement right) {
            return !(left == right);
        }
    
    }

}
