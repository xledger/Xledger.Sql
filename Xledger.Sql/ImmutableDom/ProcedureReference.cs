using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ProcedureReference : TSqlFragment, IEquatable<ProcedureReference> {
        SchemaObjectName name;
        Literal number;
    
        public SchemaObjectName Name => name;
        public Literal Number => number;
    
        public ProcedureReference(SchemaObjectName name = null, Literal number = null) {
            this.name = name;
            this.number = number;
        }
    
        public ScriptDom.ProcedureReference ToMutableConcrete() {
            var ret = new ScriptDom.ProcedureReference();
            ret.Name = (ScriptDom.SchemaObjectName)name.ToMutable();
            ret.Number = (ScriptDom.Literal)number.ToMutable();
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
            if (!(number is null)) {
                h = h * 23 + number.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ProcedureReference);
        } 
        
        public bool Equals(ProcedureReference other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Number, number)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ProcedureReference left, ProcedureReference right) {
            return EqualityComparer<ProcedureReference>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ProcedureReference left, ProcedureReference right) {
            return !(left == right);
        }
    
    }

}