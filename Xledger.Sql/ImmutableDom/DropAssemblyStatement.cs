using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class DropAssemblyStatement : DropObjectsStatement, IEquatable<DropAssemblyStatement> {
        bool withNoDependents = false;
    
        public bool WithNoDependents => withNoDependents;
    
        public DropAssemblyStatement(bool withNoDependents = false, IReadOnlyList<SchemaObjectName> objects = null, bool isIfExists = false) {
            this.withNoDependents = withNoDependents;
            this.objects = objects is null ? ImmList<SchemaObjectName>.Empty : ImmList<SchemaObjectName>.FromList(objects);
            this.isIfExists = isIfExists;
        }
    
        public ScriptDom.DropAssemblyStatement ToMutableConcrete() {
            var ret = new ScriptDom.DropAssemblyStatement();
            ret.WithNoDependents = withNoDependents;
            ret.Objects.AddRange(objects.Select(c => (ScriptDom.SchemaObjectName)c.ToMutable()));
            ret.IsIfExists = isIfExists;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + withNoDependents.GetHashCode();
            h = h * 23 + objects.GetHashCode();
            h = h * 23 + isIfExists.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as DropAssemblyStatement);
        } 
        
        public bool Equals(DropAssemblyStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.WithNoDependents, withNoDependents)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<SchemaObjectName>>.Default.Equals(other.Objects, objects)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsIfExists, isIfExists)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(DropAssemblyStatement left, DropAssemblyStatement right) {
            return EqualityComparer<DropAssemblyStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(DropAssemblyStatement left, DropAssemblyStatement right) {
            return !(left == right);
        }
    
    }

}