using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateExternalFileFormatStatement : ExternalFileFormatStatement, IEquatable<CreateExternalFileFormatStatement> {
        public CreateExternalFileFormatStatement(Identifier name = null, ScriptDom.ExternalFileFormatType formatType = ScriptDom.ExternalFileFormatType.DelimitedText, IReadOnlyList<ExternalFileFormatOption> externalFileFormatOptions = null) {
            this.name = name;
            this.formatType = formatType;
            this.externalFileFormatOptions = ImmList<ExternalFileFormatOption>.FromList(externalFileFormatOptions);
        }
    
        public ScriptDom.CreateExternalFileFormatStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateExternalFileFormatStatement();
            ret.Name = (ScriptDom.Identifier)name?.ToMutable();
            ret.FormatType = formatType;
            ret.ExternalFileFormatOptions.AddRange(externalFileFormatOptions.SelectList(c => (ScriptDom.ExternalFileFormatOption)c?.ToMutable()));
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
            h = h * 23 + formatType.GetHashCode();
            h = h * 23 + externalFileFormatOptions.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateExternalFileFormatStatement);
        } 
        
        public bool Equals(CreateExternalFileFormatStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.ExternalFileFormatType>.Default.Equals(other.FormatType, formatType)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<ExternalFileFormatOption>>.Default.Equals(other.ExternalFileFormatOptions, externalFileFormatOptions)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateExternalFileFormatStatement left, CreateExternalFileFormatStatement right) {
            return EqualityComparer<CreateExternalFileFormatStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateExternalFileFormatStatement left, CreateExternalFileFormatStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateExternalFileFormatStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.formatType, othr.formatType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.externalFileFormatOptions, othr.externalFileFormatOptions);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (CreateExternalFileFormatStatement left, CreateExternalFileFormatStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateExternalFileFormatStatement left, CreateExternalFileFormatStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateExternalFileFormatStatement left, CreateExternalFileFormatStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateExternalFileFormatStatement left, CreateExternalFileFormatStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
    }

}
