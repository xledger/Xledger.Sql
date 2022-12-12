using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterSequenceStatement : SequenceStatement, IEquatable<AlterSequenceStatement> {
        public AlterSequenceStatement(SchemaObjectName name = null, IReadOnlyList<SequenceOption> sequenceOptions = null) {
            this.name = name;
            this.sequenceOptions = sequenceOptions is null ? ImmList<SequenceOption>.Empty : ImmList<SequenceOption>.FromList(sequenceOptions);
        }
    
        public ScriptDom.AlterSequenceStatement ToMutableConcrete() {
            var ret = new ScriptDom.AlterSequenceStatement();
            ret.Name = (ScriptDom.SchemaObjectName)name.ToMutable();
            ret.SequenceOptions.AddRange(sequenceOptions.SelectList(c => (ScriptDom.SequenceOption)c.ToMutable()));
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
            h = h * 23 + sequenceOptions.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterSequenceStatement);
        } 
        
        public bool Equals(AlterSequenceStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<SequenceOption>>.Default.Equals(other.SequenceOptions, sequenceOptions)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterSequenceStatement left, AlterSequenceStatement right) {
            return EqualityComparer<AlterSequenceStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterSequenceStatement left, AlterSequenceStatement right) {
            return !(left == right);
        }
    
    }

}
