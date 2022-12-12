using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class AlterTableDropTableElement : TSqlFragment, IEquatable<AlterTableDropTableElement> {
        protected ScriptDom.TableElementType tableElementType = ScriptDom.TableElementType.NotSpecified;
        protected Identifier name;
        protected IReadOnlyList<DropClusteredConstraintOption> dropClusteredConstraintOptions;
        protected bool isIfExists = false;
    
        public ScriptDom.TableElementType TableElementType => tableElementType;
        public Identifier Name => name;
        public IReadOnlyList<DropClusteredConstraintOption> DropClusteredConstraintOptions => dropClusteredConstraintOptions;
        public bool IsIfExists => isIfExists;
    
        public AlterTableDropTableElement(ScriptDom.TableElementType tableElementType = ScriptDom.TableElementType.NotSpecified, Identifier name = null, IReadOnlyList<DropClusteredConstraintOption> dropClusteredConstraintOptions = null, bool isIfExists = false) {
            this.tableElementType = tableElementType;
            this.name = name;
            this.dropClusteredConstraintOptions = dropClusteredConstraintOptions is null ? ImmList<DropClusteredConstraintOption>.Empty : ImmList<DropClusteredConstraintOption>.FromList(dropClusteredConstraintOptions);
            this.isIfExists = isIfExists;
        }
    
        public ScriptDom.AlterTableDropTableElement ToMutableConcrete() {
            var ret = new ScriptDom.AlterTableDropTableElement();
            ret.TableElementType = tableElementType;
            ret.Name = (ScriptDom.Identifier)name.ToMutable();
            ret.DropClusteredConstraintOptions.AddRange(dropClusteredConstraintOptions.SelectList(c => (ScriptDom.DropClusteredConstraintOption)c.ToMutable()));
            ret.IsIfExists = isIfExists;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + tableElementType.GetHashCode();
            if (!(name is null)) {
                h = h * 23 + name.GetHashCode();
            }
            h = h * 23 + dropClusteredConstraintOptions.GetHashCode();
            h = h * 23 + isIfExists.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as AlterTableDropTableElement);
        } 
        
        public bool Equals(AlterTableDropTableElement other) {
            if (other is null) { return false; }
            if (!EqualityComparer<ScriptDom.TableElementType>.Default.Equals(other.TableElementType, tableElementType)) {
                return false;
            }
            if (!EqualityComparer<Identifier>.Default.Equals(other.Name, name)) {
                return false;
            }
            if (!EqualityComparer<IReadOnlyList<DropClusteredConstraintOption>>.Default.Equals(other.DropClusteredConstraintOptions, dropClusteredConstraintOptions)) {
                return false;
            }
            if (!EqualityComparer<bool>.Default.Equals(other.IsIfExists, isIfExists)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(AlterTableDropTableElement left, AlterTableDropTableElement right) {
            return EqualityComparer<AlterTableDropTableElement>.Default.Equals(left, right);
        }
        
        public static bool operator !=(AlterTableDropTableElement left, AlterTableDropTableElement right) {
            return !(left == right);
        }
    
    }

}
