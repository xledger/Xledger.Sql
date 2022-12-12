using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CubeGroupingSpecification : GroupingSpecification, IEquatable<CubeGroupingSpecification> {
        protected IReadOnlyList<GroupingSpecification> arguments;
    
        public IReadOnlyList<GroupingSpecification> Arguments => arguments;
    
        public CubeGroupingSpecification(IReadOnlyList<GroupingSpecification> arguments = null) {
            this.arguments = arguments is null ? ImmList<GroupingSpecification>.Empty : ImmList<GroupingSpecification>.FromList(arguments);
        }
    
        public ScriptDom.CubeGroupingSpecification ToMutableConcrete() {
            var ret = new ScriptDom.CubeGroupingSpecification();
            ret.Arguments.AddRange(arguments.SelectList(c => (ScriptDom.GroupingSpecification)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + arguments.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CubeGroupingSpecification);
        } 
        
        public bool Equals(CubeGroupingSpecification other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<GroupingSpecification>>.Default.Equals(other.Arguments, arguments)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CubeGroupingSpecification left, CubeGroupingSpecification right) {
            return EqualityComparer<CubeGroupingSpecification>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CubeGroupingSpecification left, CubeGroupingSpecification right) {
            return !(left == right);
        }
    
    }

}
