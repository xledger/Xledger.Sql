using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AddFileSpec : TSqlFragment, IEquatable<AddFileSpec> {
        protected ScalarExpression file;
        protected Literal fileName;
    
        public ScalarExpression File => file;
        public Literal FileName => fileName;
    
        public AddFileSpec(ScalarExpression file = null, Literal fileName = null) {
            this.file = file;
            this.fileName = fileName;
        }
    
        public ScriptDom.AddFileSpec ToMutableConcrete() {
            var ret = new ScriptDom.AddFileSpec();
            ret.File = (ScriptDom.ScalarExpression)file.ToMutable();
            ret.FileName = (ScriptDom.Literal)fileName.ToMutable();
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(file is null)) {
                h = h * 23 + file.GetHashCode();
            }
            if (!(fileName is null)) {
                h = h * 23 + fileName.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AddFileSpec);
        } 
        
        public bool Equals(AddFileSpec other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScalarExpression>.Default.Equals(other.File, file)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.FileName, fileName)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AddFileSpec left, AddFileSpec right) {
            return EqualityComparer<AddFileSpec>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AddFileSpec left, AddFileSpec right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (AddFileSpec)that;
            compare = Comparer.DefaultInvariant.Compare(this.file, othr.file);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.fileName, othr.fileName);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (AddFileSpec left, AddFileSpec right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(AddFileSpec left, AddFileSpec right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (AddFileSpec left, AddFileSpec right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(AddFileSpec left, AddFileSpec right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static AddFileSpec FromMutable(ScriptDom.AddFileSpec fragment) {
            return (AddFileSpec)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
