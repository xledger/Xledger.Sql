using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class NextValueForExpression : PrimaryExpression, IEquatable<NextValueForExpression> {
        protected SchemaObjectName sequenceName;
        protected OverClause overClause;
    
        public SchemaObjectName SequenceName => sequenceName;
        public OverClause OverClause => overClause;
    
        public NextValueForExpression(SchemaObjectName sequenceName = null, OverClause overClause = null, Identifier collation = null) {
            this.sequenceName = sequenceName;
            this.overClause = overClause;
            this.collation = collation;
        }
    
        public ScriptDom.NextValueForExpression ToMutableConcrete() {
            var ret = new ScriptDom.NextValueForExpression();
            ret.SequenceName = (ScriptDom.SchemaObjectName)sequenceName.ToMutable();
            ret.OverClause = (ScriptDom.OverClause)overClause.ToMutable();
            ret.Collation = (ScriptDom.Identifier)collation.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(sequenceName is null)) {
                h = h * 23 + sequenceName.GetHashCode();
            }
            if (!(overClause is null)) {
                h = h * 23 + overClause.GetHashCode();
            }
            if (!(collation is null)) {
                h = h * 23 + collation.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as NextValueForExpression);
        } 
        
        public bool Equals(NextValueForExpression other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.SequenceName, sequenceName)) {
                return false;
            }
            if (!EqualityComparer<OverClause>.Default.Equals(other.OverClause, overClause)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Collation, collation)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(NextValueForExpression left, NextValueForExpression right) {
            return EqualityComparer<NextValueForExpression>.Default.Equals(left, right);
        }
        
        public static bool operator !=(NextValueForExpression left, NextValueForExpression right) {
            return !(left == right);
        }
    
        public static NextValueForExpression FromMutable(ScriptDom.NextValueForExpression fragment) {
            return (NextValueForExpression)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
