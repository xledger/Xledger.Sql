using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ExternalCreateLoginSource : CreateLoginSource, IEquatable<ExternalCreateLoginSource> {
        protected IReadOnlyList<PrincipalOption> options;
    
        public IReadOnlyList<PrincipalOption> Options => options;
    
        public ExternalCreateLoginSource(IReadOnlyList<PrincipalOption> options = null) {
            this.options = options is null ? ImmList<PrincipalOption>.Empty : ImmList<PrincipalOption>.FromList(options);
        }
    
        public ScriptDom.ExternalCreateLoginSource ToMutableConcrete() {
            var ret = new ScriptDom.ExternalCreateLoginSource();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.PrincipalOption)c.ToMutable()));
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
            return Equals(obj as ExternalCreateLoginSource);
        } 
        
        public bool Equals(ExternalCreateLoginSource other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<PrincipalOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ExternalCreateLoginSource left, ExternalCreateLoginSource right) {
            return EqualityComparer<ExternalCreateLoginSource>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ExternalCreateLoginSource left, ExternalCreateLoginSource right) {
            return !(left == right);
        }
    
    }

}
