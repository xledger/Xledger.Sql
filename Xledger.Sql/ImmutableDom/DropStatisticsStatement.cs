using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropStatisticsStatement : DropChildObjectsStatement, IEquatable<DropStatisticsStatement> {
        public DropStatisticsStatement(IReadOnlyList<ChildObjectName> objects = null) {
            this.objects = objects is null ? ImmList<ChildObjectName>.Empty : ImmList<ChildObjectName>.FromList(objects);
        }
    
        public ScriptDom.DropStatisticsStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropStatisticsStatement();
            ret.Objects.AddRange(objects.SelectList(c => (ScriptDom.ChildObjectName)c.ToMutable()));
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + objects.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropStatisticsStatement);
        } 
        
        public bool Equals(DropStatisticsStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<IReadOnlyList<ChildObjectName>>.Default.Equals(other.Objects, objects)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropStatisticsStatement left, DropStatisticsStatement right) {
            return EqualityComparer<DropStatisticsStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropStatisticsStatement left, DropStatisticsStatement right) {
            return !(left == right);
        }
    
        public static DropStatisticsStatement FromMutable(ScriptDom.DropStatisticsStatement fragment) {
            return (DropStatisticsStatement)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
