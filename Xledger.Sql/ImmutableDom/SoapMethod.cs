using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class SoapMethod : PayloadOption, IEquatable<SoapMethod> {
        protected Literal alias;
        protected Literal @namespace;
        protected ScriptDom.SoapMethodAction action = ScriptDom.SoapMethodAction.None;
        protected Literal name;
        protected ScriptDom.SoapMethodFormat format = ScriptDom.SoapMethodFormat.NotSpecified;
        protected ScriptDom.SoapMethodSchemas schema = ScriptDom.SoapMethodSchemas.NotSpecified;
    
        public Literal Alias => alias;
        public Literal Namespace => @namespace;
        public ScriptDom.SoapMethodAction Action => action;
        public Literal Name => name;
        public ScriptDom.SoapMethodFormat Format => format;
        public ScriptDom.SoapMethodSchemas Schema => schema;
    
        public SoapMethod(Literal alias = null, Literal @namespace = null, ScriptDom.SoapMethodAction action = ScriptDom.SoapMethodAction.None, Literal name = null, ScriptDom.SoapMethodFormat format = ScriptDom.SoapMethodFormat.NotSpecified, ScriptDom.SoapMethodSchemas schema = ScriptDom.SoapMethodSchemas.NotSpecified, ScriptDom.PayloadOptionKinds kind = ScriptDom.PayloadOptionKinds.None) {
            this.alias = alias;
            this.@namespace = @namespace;
            this.action = action;
            this.name = name;
            this.format = format;
            this.schema = schema;
            this.kind = kind;
        }
    
        public ScriptDom.SoapMethod ToMutableConcrete() {
            var ret = new ScriptDom.SoapMethod();
            ret.Alias = (ScriptDom.Literal)alias?.ToMutable();
            ret.Namespace = (ScriptDom.Literal)@namespace?.ToMutable();
            ret.Action = action;
            ret.Name = (ScriptDom.Literal)name?.ToMutable();
            ret.Format = format;
            ret.Schema = schema;
            ret.Kind = kind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            if (!(alias is null)) {
                h = h * 23 + alias.GetHashCode();
            }
            if (!(@namespace is null)) {
                h = h * 23 + @namespace.GetHashCode();
            }
            h = h * 23 + action.GetHashCode();
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + format.GetHashCode();
            h = h * 23 + schema.GetHashCode();
            h = h * 23 + kind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as SoapMethod);
        } 
        
        public bool Equals(SoapMethod other) {
            if (other is null) { return false; }
            if (!EqualityComparer<Literal>.Default.Equals(other.Alias, alias)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Namespace, @namespace)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.SoapMethodAction>.Default.Equals(other.Action, action)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.SoapMethodFormat>.Default.Equals(other.Format, format)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.SoapMethodSchemas>.Default.Equals(other.Schema, schema)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.PayloadOptionKinds>.Default.Equals(other.Kind, kind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(SoapMethod left, SoapMethod right) {
            return EqualityComparer<SoapMethod>.Default.Equals(left, right);
        }
        
        public static bool operator !=(SoapMethod left, SoapMethod right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (SoapMethod)that;
            compare = Comparer.DefaultInvariant.Compare(this.alias, othr.alias);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.@namespace, othr.@namespace);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.action, othr.action);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.format, othr.format);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.schema, othr.schema);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.kind, othr.kind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (SoapMethod left, SoapMethod right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(SoapMethod left, SoapMethod right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (SoapMethod left, SoapMethod right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(SoapMethod left, SoapMethod right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static SoapMethod FromMutable(ScriptDom.SoapMethod fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.SoapMethod)) { throw new NotImplementedException("Unexpected subtype of SoapMethod not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new SoapMethod(
                alias: ImmutableDom.Literal.FromMutable(fragment.Alias),
                @namespace: ImmutableDom.Literal.FromMutable(fragment.Namespace),
                action: fragment.Action,
                name: ImmutableDom.Literal.FromMutable(fragment.Name),
                format: fragment.Format,
                schema: fragment.Schema,
                kind: fragment.Kind
            );
        }
    
    }

}
