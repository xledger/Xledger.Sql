using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xledger.Sql.Collections;
using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;


namespace Xledger.Sql.ImmutableDom {
    public class ListenerIPEndpointProtocolOption : EndpointProtocolOption, IEquatable<ListenerIPEndpointProtocolOption> {
        protected bool isAll = false;
        protected Literal iPv6;
        protected IPv4 iPv4PartOne;
        protected IPv4 iPv4PartTwo;
    
        public bool IsAll => isAll;
        public Literal IPv6 => iPv6;
        public IPv4 IPv4PartOne => iPv4PartOne;
        public IPv4 IPv4PartTwo => iPv4PartTwo;
    
        public ListenerIPEndpointProtocolOption(bool isAll = false, Literal iPv6 = null, IPv4 iPv4PartOne = null, IPv4 iPv4PartTwo = null, ScriptDom.EndpointProtocolOptions kind = ScriptDom.EndpointProtocolOptions.None) {
            this.isAll = isAll;
            this.iPv6 = iPv6;
            this.iPv4PartOne = iPv4PartOne;
            this.iPv4PartTwo = iPv4PartTwo;
            this.kind = kind;
        }
    
        public ScriptDom.ListenerIPEndpointProtocolOption ToMutableConcrete() {
            var ret = new ScriptDom.ListenerIPEndpointProtocolOption();
            ret.IsAll = isAll;
            ret.IPv6 = (ScriptDom.Literal)iPv6.ToMutable();
            ret.IPv4PartOne = (ScriptDom.IPv4)iPv4PartOne.ToMutable();
            ret.IPv4PartTwo = (ScriptDom.IPv4)iPv4PartTwo.ToMutable();
            ret.Kind = kind;
            return ret;
        }
        
        public override ScriptDom.TSqlFragment ToMutable() {
            return ToMutableConcrete();
        }
    
        public override int GetHashCode() {
            var h = 17;
            h = h * 23 + isAll.GetHashCode();
            if (!(iPv6 is null)) {
                h = h * 23 + iPv6.GetHashCode();
            }
            if (!(iPv4PartOne is null)) {
                h = h * 23 + iPv4PartOne.GetHashCode();
            }
            if (!(iPv4PartTwo is null)) {
                h = h * 23 + iPv4PartTwo.GetHashCode();
            }
            h = h * 23 + kind.GetHashCode();
            return h;
        }
    
        public override bool Equals(object obj) {
            return Equals(obj as ListenerIPEndpointProtocolOption);
        } 
        
        public bool Equals(ListenerIPEndpointProtocolOption other) {
            if (other is null) { return false; }
            if (!EqualityComparer<bool>.Default.Equals(other.IsAll, isAll)) {
                return false;
            }
            if (!EqualityComparer<Literal>.Default.Equals(other.IPv6, iPv6)) {
                return false;
            }
            if (!EqualityComparer<IPv4>.Default.Equals(other.IPv4PartOne, iPv4PartOne)) {
                return false;
            }
            if (!EqualityComparer<IPv4>.Default.Equals(other.IPv4PartTwo, iPv4PartTwo)) {
                return false;
            }
            if (!EqualityComparer<ScriptDom.EndpointProtocolOptions>.Default.Equals(other.Kind, kind)) {
                return false;
            }
            return true;
        } 
        
        public static bool operator ==(ListenerIPEndpointProtocolOption left, ListenerIPEndpointProtocolOption right) {
            return EqualityComparer<ListenerIPEndpointProtocolOption>.Default.Equals(left, right);
        }
        
        public static bool operator !=(ListenerIPEndpointProtocolOption left, ListenerIPEndpointProtocolOption right) {
            return !(left == right);
        }
    
        public override int CompareTo(object that) {
            return CompareTo((TSqlFragment)that);
        } 
        
        public override int CompareTo(TSqlFragment that) {
            var compare = 1;
            if (that == null) { return compare; }
            if (this.GetType() != that.GetType()) { return this.GetType().Name.CompareTo(that.GetType().Name); }
            var othr = (ListenerIPEndpointProtocolOption)that;
            compare = Comparer.DefaultInvariant.Compare(this.isAll, othr.isAll);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.iPv6, othr.iPv6);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.iPv4PartOne, othr.iPv4PartOne);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.iPv4PartTwo, othr.iPv4PartTwo);
            if (compare != 0) { return compare; }
            compare = Comparer.DefaultInvariant.Compare(this.kind, othr.kind);
            if (compare != 0) { return compare; }
            return compare;
        } 
        public static bool operator < (ListenerIPEndpointProtocolOption left, ListenerIPEndpointProtocolOption right) => Comparer.DefaultInvariant.Compare(left, right) <  0;
        public static bool operator <=(ListenerIPEndpointProtocolOption left, ListenerIPEndpointProtocolOption right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;
        public static bool operator > (ListenerIPEndpointProtocolOption left, ListenerIPEndpointProtocolOption right) => Comparer.DefaultInvariant.Compare(left, right) >  0;
        public static bool operator >=(ListenerIPEndpointProtocolOption left, ListenerIPEndpointProtocolOption right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;
    
        public static ListenerIPEndpointProtocolOption FromMutable(ScriptDom.ListenerIPEndpointProtocolOption fragment) {
            return (ListenerIPEndpointProtocolOption)TSqlFragment.FromMutable(fragment);
        }
    
    }

}
