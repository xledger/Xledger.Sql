using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class XmlForClause : ForClause, IEquatable<XmlForClause> {
        IReadOnlyList<XmlForClauseOption> options;
    
        public IReadOnlyList<XmlForClauseOption> Options => options;
    
        public XmlForClause(IReadOnlyList<XmlForClauseOption> options = null) {
            this.options = options is null ? ImmList<XmlForClauseOption>.Empty : ImmList<XmlForClauseOption>.FromList(options);
        }
    
        public ScriptDom.XmlForClause ToMutableConcrete() {
            var ret = new ScriptDom.XmlForClause();
            ret.Options.AddRange(options.Select(c => (ScriptDom.XmlForClauseOption)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + options.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as XmlForClause);
        } 
        
        public bool Equals(XmlForClause other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<XmlForClauseOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(XmlForClause left, XmlForClause right) {
            return EqualityComparer<XmlForClause>.Default.Equals(left, right);
        }
        
        public static bool operator !=(XmlForClause left, XmlForClause right) {
            return !(left == right);
        }
    
    }

}