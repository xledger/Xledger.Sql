using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class CreateOrAlterTriggerStatement : TriggerStatementBody, IEquatable<CreateOrAlterTriggerStatement> {
        public CreateOrAlterTriggerStatement(SchemaObjectName name = null, TriggerObject triggerObject = null, IReadOnlyList<TriggerOption> options = null, ScriptDom.TriggerType triggerType = ScriptDom.TriggerType.Unknown, IReadOnlyList<TriggerAction> triggerActions = null, bool withAppend = false, bool isNotForReplication = false, StatementList statementList = null, MethodSpecifier methodSpecifier = null) {
            this.name = name;
            this.triggerObject = triggerObject;
            this.options = ImmList<TriggerOption>.FromList(options);
            this.triggerType = triggerType;
            this.triggerActions = ImmList<TriggerAction>.FromList(triggerActions);
            this.withAppend = withAppend;
            this.isNotForReplication = isNotForReplication;
            this.statementList = statementList;
            this.methodSpecifier = methodSpecifier;
        }
    
        public ScriptDom.CreateOrAlterTriggerStatement ToMutableConcrete() {
            var ret = new ScriptDom.CreateOrAlterTriggerStatement();
            ret.Name = (ScriptDom.SchemaObjectName)name?.ToMutable();
            ret.TriggerObject = (ScriptDom.TriggerObject)triggerObject?.ToMutable();
            ret.Options.AddRange(options.SelectList(c => (ScriptDom.TriggerOption)c?.ToMutable()));
            ret.TriggerType = triggerType;
            ret.TriggerActions.AddRange(triggerActions.SelectList(c => (ScriptDom.TriggerAction)c?.ToMutable()));
            ret.WithAppend = withAppend;
            ret.IsNotForReplication = isNotForReplication;
            ret.StatementList = (ScriptDom.StatementList)statementList?.ToMutable();
            ret.MethodSpecifier = (ScriptDom.MethodSpecifier)methodSpecifier?.ToMutable();
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
            if (!(triggerObject is null)) {
                h = h * 23 + triggerObject.GetHashCode();
            }
            h = h * 23 + options.GetHashCode();
            h = h * 23 + triggerType.GetHashCode();
            h = h * 23 + triggerActions.GetHashCode();
            h = h * 23 + withAppend.GetHashCode();
            h = h * 23 + isNotForReplication.GetHashCode();
            if (!(statementList is null)) {
                h = h * 23 + statementList.GetHashCode();
            }
            if (!(methodSpecifier is null)) {
                h = h * 23 + methodSpecifier.GetHashCode();
            }
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as CreateOrAlterTriggerStatement);
        } 
        
        public bool Equals(CreateOrAlterTriggerStatement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<SchemaObjectName>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<TriggerObject>.Default.Equals(other.TriggerObject, triggerObject)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<TriggerOption>>.Default.Equals(other.Options, options)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.TriggerType>.Default.Equals(other.TriggerType, triggerType)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<TriggerAction>>.Default.Equals(other.TriggerActions, triggerActions)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.WithAppend, withAppend)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsNotForReplication, isNotForReplication)) {
                return false;
            }
            if (!EqualityComparer<StatementList>.Default.Equals(other.StatementList, statementList)) {
                return false;
            }
            if (!EqualityComparer<MethodSpecifier>.Default.Equals(other.MethodSpecifier, methodSpecifier)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(CreateOrAlterTriggerStatement left, CreateOrAlterTriggerStatement right) {
            return EqualityComparer<CreateOrAlterTriggerStatement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(CreateOrAlterTriggerStatement left, CreateOrAlterTriggerStatement right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (CreateOrAlterTriggerStatement)that;
            compare = Comparer.DefaultInvariant.Compare(this.name, othr.name);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.triggerObject, othr.triggerObject);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.options, othr.options);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.triggerType, othr.triggerType);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.triggerActions, othr.triggerActions);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.withAppend, othr.withAppend);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.isNotForReplication, othr.isNotForReplication);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.statementList, othr.statementList);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.methodSpecifier, othr.methodSpecifier);
            if (compare != 0) { return compare; }
            return compare;
        } 
        
        public static bool operator < (CreateOrAlterTriggerStatement left, CreateOrAlterTriggerStatement right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(CreateOrAlterTriggerStatement left, CreateOrAlterTriggerStatement right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (CreateOrAlterTriggerStatement left, CreateOrAlterTriggerStatement right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(CreateOrAlterTriggerStatement left, CreateOrAlterTriggerStatement right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static CreateOrAlterTriggerStatement FromMutable(ScriptDom.CreateOrAlterTriggerStatement fragment) {
            if (fragment is null) { return null; }
            if (fragment.GetType() != typeof(ScriptDom.CreateOrAlterTriggerStatement)) { throw new NotImplementedException("Unexpected subtype of CreateOrAlterTriggerStatement not implemented: " + fragment.GetType().Name + ". Regenerate immutable type library."); }
            return new CreateOrAlterTriggerStatement(
                name: ImmutableDom.SchemaObjectName.FromMutable(fragment.Name),
                triggerObject: ImmutableDom.TriggerObject.FromMutable(fragment.TriggerObject),
                options: fragment.Options.SelectList(ImmutableDom.TriggerOption.FromMutable),
                triggerType: fragment.TriggerType,
                triggerActions: fragment.TriggerActions.SelectList(ImmutableDom.TriggerAction.FromMutable),
                withAppend: fragment.WithAppend,
                isNotForReplication: fragment.IsNotForReplication,
                statementList: ImmutableDom.StatementList.FromMutable(fragment.StatementList),
                methodSpecifier: ImmutableDom.MethodSpecifier.FromMutable(fragment.MethodSpecifier)
            );
        }
    
    }

}
