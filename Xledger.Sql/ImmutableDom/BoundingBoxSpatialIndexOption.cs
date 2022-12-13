using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class BoundingBoxSpatialIndexOption : SpatialIndexOption, IEquatable<BoundingBoxSpatialIndexOption> {
        protected IReadOnlyList<BoundingBoxParameter> boundingBoxParameters;
    
        public IReadOnlyList<BoundingBoxParameter> BoundingBoxParameters => boundingBoxParameters;
    
        public BoundingBoxSpatialIndexOption(IReadOnlyList<BoundingBoxParameter> boundingBoxParameters = null) {
            this.boundingBoxParameters = boundingBoxParameters is null ? ImmList<BoundingBoxParameter>.Empty : ImmList<BoundingBoxParameter>.FromList(boundingBoxParameters);
        }
    
        public ScriptDom.BoundingBoxSpatialIndexOption ToMutableConcrete() {
            var ret = new ScriptDom.BoundingBoxSpatialIndexOption();
            ret.BoundingBoxParameters.AddRange(boundingBoxParameters.SelectList(c => (ScriptDom.BoundingBoxParameter)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + boundingBoxParameters.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as BoundingBoxSpatialIndexOption);
        } 
        
        public bool Equals(BoundingBoxSpatialIndexOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<BoundingBoxParameter>>.Default.Equals(other.BoundingBoxParameters, boundingBoxParameters)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(BoundingBoxSpatialIndexOption left, BoundingBoxSpatialIndexOption right) {
            return EqualityComparer<BoundingBoxSpatialIndexOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(BoundingBoxSpatialIndexOption left, BoundingBoxSpatialIndexOption right) {
            return !(left == right);
        }
    
        public static BoundingBoxSpatialIndexOption FromMutable(ScriptDom.BoundingBoxSpatialIndexOption fragment) {
            return (BoundingBoxSpatialIndexOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
