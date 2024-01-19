<Query Kind="Program">
  <NuGetReference>Microsoft.SqlServer.TransactSql.ScriptDom</NuGetReference>
  <Namespace>Microsoft.SqlServer.TransactSql.ScriptDom</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>

void Main() {
    var types = FragmentTypes();
    var path = Path.GetDirectoryName(LINQPad.Util.CurrentQueryPath);
    path = Path.Combine(path, "../Xledger.Sql/ImmutableDom");
    path = Path.GetFullPath(path);
    path.Dump("Base path");

    var pathsToDelete = new HashSet<string>();

    foreach (var f in Directory.EnumerateFiles(path, "*.cs", SearchOption.AllDirectories)) {
        pathsToDelete.Add(f);
    }

	foreach (var t in types) {
		Subtypes[t.Name] = new HashSet<string>();
	}

	foreach (var t in types) {
		var newClassDef = GetImmClassdef(t);
		ImmClassdefs[newClassDef.Name] = newClassDef;
		if (!string.IsNullOrEmpty(newClassDef.ParentTypeName)) {
			Subtypes[newClassDef.ParentTypeName].Add(newClassDef.Name);
		}
	}
	
	foreach (var t in types) {
        //if (t.Name != "TSqlFragment") {
        //    continue;
        //}
        var newClassDef = ImmClassdefs[t.Name];
        newClassDef.Dump();
        newClassDef.FieldDefs().Dump("Field defs");
        newClassDef.PropsDecls().Dump("Prop Decls");
        newClassDef.Ctor().Dump("ctor");
        newClassDef.ToMutableMethod().Dump("toMutable");
        newClassDef.GetHashCodeMethod().Dump("getHashCode");
        newClassDef.GetEqualsMethods().Dump("equals");
		newClassDef.GetCompareToMethods().Dump("compareTo");

        var fullFileDef = newClassDef.FullFileDef();
        var f = Path.Combine(path, $"{t.Name}.cs");
        f = Path.GetFullPath(f);
        File.WriteAllText(f, fullFileDef);

        pathsToDelete.Remove(f);

        fullFileDef.Dump("Full");
    }

    //foreach (var f in pathsToDelete) {
    //    File.Delete(path);
    //}
    // TODO: TsqlFragment.FromCs
}

static HashSet<string> SkipPropNames = new HashSet<string> {
    "FirstTokenIndex",
    "LastTokenIndex",
    "ScriptTokenStream"
};

static Dictionary<string, HashSet<string>> Subtypes = new Dictionary<string, HashSet<string>>();
static Dictionary<string, ClassDef> ImmClassdefs = new Dictionary<string, ClassDef>();

static ClassDef GetImmClassdef(Type t) {
    var d = new ClassDef { Name = t.Name, IsAbstract = t.IsAbstract };

    if (t.BaseType is Type baseTyp && typeof(TSqlFragment).IsAssignableFrom(baseTyp)) {
        d.ParentTypeName = baseTyp.Name;
    }

    var props = t.GetProperties();
    foreach (var prop in props) {
        if (SkipProp(prop)) {
            continue;
        }
        d.Props.Add(GetPropDef(t, prop));
    }
    return d;
}

static PropDef GetPropDef(Type t, PropertyInfo p) {
    var pd = new PropDef {
        Name = p.Name,
        TypeLiteral = GetPropTypeLiteral(p.PropertyType),
        IsList = p.PropertyType.GetInterfaces().Any(it => it.IsGenericType && it.Name == "ICollection`1"),
    };
    pd.DefaultLiteral = GetDefaultLiteral(t, p, pd.IsList);
    pd.IsScriptDomType =
        pd.IsList
        ? typeof(TSqlFragment).IsAssignableFrom(p.PropertyType.GetGenericArguments()[0])
        : typeof(TSqlFragment).IsAssignableFrom(p.PropertyType);
    pd.InnerTypeLiteral =
        pd.IsList
        ? GetPropTypeLiteral(p.PropertyType.GetGenericArguments()[0])
        : null;
    pd.IsNullable = !p.PropertyType.IsValueType;
    pd.IsInherited =
        p.DeclaringType != t;
    return pd;
}

static Dictionary<Type, TSqlFragment> DefaultInstanceByType = new Dictionary<Type, TSqlFragment>();

static TSqlFragment GetDefaultInstance(Type t) {
    if (t.IsAbstract) {
        return null;
    }
    if (DefaultInstanceByType.TryGetValue(t, out var inst)) {
        return inst;
    }
    inst = DefaultInstanceByType[t] = (TSqlFragment)Activator.CreateInstance(t);
    return inst;
}

static string GetDefaultLiteral(Type onType, PropertyInfo prop, bool isList) {
    if (isList) {
        return null;
    }
    var inst = GetDefaultInstance(onType);
    if (inst is null) {
        return null;
    }

    var defaultV = prop.GetValue(inst);

    if (defaultV is bool b) {
        return b ? "true" : "false";
    } else if (defaultV is int || defaultV is long || defaultV is string) {
        return defaultV.ToString();
    } else if (prop.PropertyType.IsEnum) {
        if (int.TryParse(defaultV.ToString(), out var n)) {
            return defaultV.ToString();
        }
        return GetPropTypeLiteral(prop.PropertyType) + "." + defaultV.ToString();
    } else {
        return null;
    }
}

static string GetPropTypeLiteral(Type type) {
    if (typeof(TSqlFragment).IsAssignableFrom(type)) {
        return type.Name;
    } else if (type.IsEnum) {
        var sdIdx = type.FullName.IndexOf(".ScriptDom.");
        if (sdIdx == -1) {
            return type.Name;
        }

        var tname = type.FullName.Substring(sdIdx + 1).Replace('+', '.');
        return tname;
    } else if (type == typeof(bool)) {
        return "bool";
    } else if (type == typeof(string)) {
        return "string";
    } else if (type == typeof(int)) {
        return "int";
    } else if (type == typeof(long)) {
        return "long";
    } else if (type == typeof(float)) {
        return "float";
    } else if (type == typeof(double)) {
        return "double";
    } else if (type.IsGenericType) {
        var listTyp = typeof(IList<>);
        var td = type.GetGenericTypeDefinition();
        if (td == listTyp) {
            return $"IReadOnlyList<{GetPropTypeLiteral(type.GetGenericArguments()[0])}>";
        } else if (td == typeof(Nullable<>)) {
            return $"{GetPropTypeLiteral(type.GetGenericArguments()[0])}?";
        }
        return type.ToString();
        //if (type.Name == "IList`1")
    }
    throw new Exception($"Unexpected type {type.FullName}");
}

public bool IsList(Type t) {
    return t.GetInterfaces().Any(it => it.IsGenericType && it.Name == "ICollection`1");
}

static bool SkipProp(PropertyInfo p) {
    if (!p.CanRead
        || (!p.CanWrite && !p.PropertyType.GetInterfaces().Any(it => it.IsGenericType && it.Name == "ICollection`1"))
        || p.GetIndexParameters().Any()) {
        return true;
    }
    if (SkipPropNames.Contains(p.Name)) {
        return true;
    }
    return false;
}

public class ClassDef {
    public string Name;
    public string ParentTypeName;
    public bool IsAbstract;
    public List<PropDef> Props { get; set; } = new List<PropDef>();

    string InstanceVariableName(string propName) {
        return $"_{LowerName(propName)}";
    }

    static HashSet<string> ReservedNames = new[] {
        "value",
        "object",
        "namespace",
        "string",
        "abstract",
        "as",
        "base",
        "bool",
        "break",
        "byte",
        "case",
        "catch",
        "char",
        "checked",
        "class",
        "const",
        "continue",
        "decimal",
        "default",
        "delegate",
        "do",
        "double",
        "else",
        "enum",
        "event",
        "explicit",
        "extern",
        "false",
        "finally",
        "fixed",
        "float",
        "for",
        "foreach",
        "goto",
        "if",
        "implicit",
        "in",
        "int",
        "interface",
        "internal",
        "is",
        "lock",
        "long",
        "namespace",
        "new",
        "null",
        "object",
        "operator",
        "out",
        "override",
        "params",
        "private",
        "protected",
        "public",
        "readonly",
        "ref",
        "return",
        "sbyte",
        "sealed",
        "short",
        "sizeof",
        "stackalloc",
        "static",
        "string",
        "struct",
        "switch",
        "this",
        "throw",
        "true",
        "try",
        "typeof",
        "uint",
        "ulong",
        "unchecked",
        "unsafe",
        "ushort",
        "using",
        "virtual",
        "void",
        "volatile",
        "while",
    }.ToHashSet();

    static string LowerName(string name) {
        var sb = new StringBuilder(name.Length);

        for (int i = 0; i < name.Length; i++) {
            var c = name[i];
            if (i == 0) {
                c = Char.ToLower(c, CultureInfo.InvariantCulture);
            }
            sb.Append(c);
        }
        var s = sb.ToString();
        if (ReservedNames.Contains(s)) {
            s = "@" + s;
        }
        return s;
    }

    public string FieldDefs() {
        var sb = new StringBuilder();
        foreach (var prop in Props) {
            if (prop.IsInherited) { continue; }
            if (prop.DefaultLiteral is null) {
                sb.AppendLine($"protected {prop.TypeLiteral} {LowerName(prop.Name)};");
            } else {
                sb.AppendLine($"protected {prop.TypeLiteral} {LowerName(prop.Name)} = {prop.DefaultLiteral};");
            }
        }
        return sb.ToString();
    }

    public string PropsDecls() {
        var sb = new StringBuilder();
        foreach (var prop in Props) {
            if (prop.IsInherited) { continue; }
            var newStr = prop.IsInherited ? "new " : "";
            sb.AppendLine($"public {newStr}{prop.TypeLiteral} {prop.Name} => {LowerName(prop.Name)};");
        }
        return sb.ToString();
    }

    public string Ctor() {
        if (this.IsAbstract) {
            return "";
        }
        var parameters = new List<string>();
        var assigns = new List<string>();

        foreach (var prop in Props) {
            var lowerName = LowerName(prop.Name);
            parameters.Add($"{prop.TypeLiteral} {lowerName} = {prop.DefaultLiteral ?? "null"}");
            if (prop.IsList) {
                assigns.Add($"    this.{lowerName} = ImmList<{prop.InnerTypeLiteral}>.FromList({lowerName});");
            } else {
                assigns.Add($"    this.{lowerName} = {lowerName};");
            }
        }

        return $"public {Name}({parameters.StringJoin(", ")}) {{\n{assigns.StringJoin("\n")}\n}}\n";
    }

	public string ToMutableMethod() {
		var sb = new StringBuilder();
		if (this.IsAbstract) {
            if (Name == "TSqlFragment") {
				sb.AppendLine("public abstract ScriptDom.TSqlFragment ToMutable();");
				sb.AppendLine();
				sb.AppendLine("public T ToMutable<T>() where T : ScriptDom.TSqlFragment {");
				sb.AppendLine("    return (T)ToMutable();");
				sb.AppendLine("}");
			}
            return sb.ToString();
        }

		if (ImmClassdefs.TryGetValue(ParentTypeName, out var parentType) && !parentType.IsAbstract) {
			sb.AppendLine($"public new ScriptDom.{Name} ToMutableConcrete() {{");
		} else {
			sb.AppendLine($"public ScriptDom.{Name} ToMutableConcrete() {{");
		}
        sb.AppendLine($"    var ret = new ScriptDom.{Name}();");
        foreach (var prop in this.Props) {
            if (prop.IsScriptDomType && prop.IsList) {
                sb.AppendLine($"    ret.{prop.Name}.AddRange({LowerName(prop.Name)}.SelectList(c => (ScriptDom.{prop.InnerTypeLiteral})c?.ToMutable()));");
            } else if (prop.IsScriptDomType) {
                sb.AppendLine($"    ret.{prop.Name} = (ScriptDom.{prop.TypeLiteral}){LowerName(prop.Name)}?.ToMutable();");
            } else {
                sb.AppendLine($"    ret.{prop.Name} = {LowerName(prop.Name)};");
            }
        }
        sb.AppendLine($"    return ret;");
        sb.AppendLine($"}}");

        sb.AppendLine($"");
        sb.AppendLine($"public override ScriptDom.TSqlFragment ToMutable() {{");
        sb.AppendLine($"    return ToMutableConcrete();");
        sb.AppendLine($"}}");

        return sb.ToString();
    }

    public string GetHashCodeMethod() {
        if (this.IsAbstract) {
            return "";
        }
        var sb = new StringBuilder();
        sb.AppendLine($"public override int GetHashCode() {{");
        sb.AppendLine($"    var h = 17;");
        foreach (var prop in Props) {
            if (prop.IsNullable && !prop.IsList) {
                sb.AppendLine($"    if (!({LowerName(prop.Name)} is null)) {{");
                sb.AppendLine($"        h = h * 23 + {LowerName(prop.Name)}.GetHashCode();");
                sb.AppendLine($"    }}");
            } else {
                sb.AppendLine($"    h = h * 23 + {LowerName(prop.Name)}.GetHashCode();");
            }
        }
        sb.AppendLine($"    return h;");
        sb.AppendLine($"}}");

        return sb.ToString();
    }

    public string GetEqualsMethods() {
        if (this.IsAbstract) {
            return "";
        }
        var sb = new StringBuilder();

        void wl(string s) { sb.AppendLine(s); }

        wl($"public override bool Equals(object obj) {{");
        wl($"    return Equals(obj as {Name});");
        wl($"}} ");
        wl($"");

        wl($"public bool Equals({Name} other) {{");
        wl($"    if (other is null) {{ return false; }}");
        foreach (var prop in Props) {
            wl($"    if (!EqualityComparer<{prop.TypeLiteral}>.Default.Equals(other.{prop.Name}, {LowerName(prop.Name)})) {{");
            wl($"        return false;");
            wl($"    }}");
        }
        wl($"    return true;");
        wl($"}} ");
        wl($"");

        wl($"public static bool operator ==({Name} left, {Name} right) {{");
        wl($"    return EqualityComparer<{Name}>.Default.Equals(left, right);");
        wl($"}}");
        wl($"");

        wl($"public static bool operator !=({Name} left, {Name} right) {{");
        wl($"    return !(left == right);");
        wl($"}}");

        return sb.ToString();
    }

	public string GetCompareToMethods()	{
		if (this.IsAbstract && Name != "TSqlFragment") {
			return "";
		}
		var sb = new StringBuilder();

		void wl(string s) { sb.AppendLine(s); }

		if (Name == "TSqlFragment") {
			wl($@"public abstract int CompareTo(object that);");
			wl($@"public abstract int CompareTo(TSqlFragment that);");
		} else {
			wl($"public override int CompareTo(object that) {{");
			wl($"    return CompareTo((TSqlFragment)that);");
			wl($"}} ");
			wl($"");

			wl($"public override int CompareTo(TSqlFragment that) {{");
			wl($"    var compare = 1;");
			wl($"    if (that == null) {{ return compare; }}");
			wl($"    if (this.GetType() != that.GetType()) {{ return this.GetType().Name.CompareTo(that.GetType().Name); }}");
			wl($"    var othr = ({Name})that;");
			foreach (var prop in Props) {
				if (prop.TypeLiteral == "string") {
					wl($"    compare = CaseInsensitiveComparer.DefaultInvariant.Compare(this.{LowerName(prop.Name)}, othr.{LowerName(prop.Name)});");	
				} else {
					wl($"    compare = Comparer.DefaultInvariant.Compare(this.{LowerName(prop.Name)}, othr.{LowerName(prop.Name)});");	
				}
				wl($"    if (compare != 0) {{ return compare; }}");
			}
			wl($"    return compare;");
			wl($"}} ");
			wl($"");

			wl($"public static bool operator < ({Name} left, {Name} right) => Comparer.DefaultInvariant.Compare(left, right) <  0;");
			wl($"public static bool operator <=({Name} left, {Name} right) => Comparer.DefaultInvariant.Compare(left, right) <= 0;");
			wl($"public static bool operator > ({Name} left, {Name} right) => Comparer.DefaultInvariant.Compare(left, right) >  0;");
			wl($"public static bool operator >=({Name} left, {Name} right) => Comparer.DefaultInvariant.Compare(left, right) >= 0;");
		}
		
		return sb.ToString();
	}

	public string FullClassDef()
	{
        var sb = new StringBuilder();
        void wl(string s, bool extraNewline = false) {
            if (s is null) {
                return;
            }
            sb.AppendLine(s);
            if (!string.IsNullOrWhiteSpace(s) && extraNewline) {
                sb.AppendLine("");
            }
        }

        var baseTyps = new List<string>();
        if (!string.IsNullOrWhiteSpace(ParentTypeName)) {
            baseTyps.Add(ParentTypeName);
        }
        if (!IsAbstract) {
            baseTyps.Add($"IEquatable<{Name}>");
        }
		if (Name == "TSqlFragment") {
			baseTyps.Add("IComparable");
			baseTyps.Add($"IComparable<TSqlFragment>");
		}
        var baseTypStr =
            baseTyps.Count == 0
            ? ""
            : $" : {string.Join(", ", baseTyps)}";

        var inherit =
            string.IsNullOrWhiteSpace(ParentTypeName)
            ? ""
            : $" : {ParentTypeName}";

        if (IsAbstract) {
            wl($"public abstract class {Name}{baseTypStr} {{");
        } else {
            wl($"public class {Name}{baseTypStr} {{");
        }

        wl(FieldDefs().IndentLines(4).NullIfBlank(), false);

        wl(PropsDecls().IndentLines(4).NullIfBlank(), false);

        wl(Ctor().IndentLines(4).NullIfBlank(), false);

        wl(ToMutableMethod().IndentLines(4).NullIfBlank(), false);

        wl(GetHashCodeMethod().IndentLines(4).NullIfBlank(), false);

        wl(GetEqualsMethods().IndentLines(4).NullIfBlank(), false);
		
		wl(GetCompareToMethods().IndentLines(4).NullIfBlank(), false);
        
        if (Name == "TSqlFragment") {
            wl(TagDict().IndentLines(4));
		}
		wl(FromMutableFunction().IndentLines(4));

		wl($"}}");

        return sb.ToString();
    }
    
    public static string TagDict() {
        var sb = new StringBuilder();
        void wl(string s) { sb.AppendLine(s); }
        
        wl($"static readonly IReadOnlyDictionary<string, int> TagNumberByTypeName = new Dictionary<string, int> {{");
        foreach ((var idx, var typ)  in TaggedConcreteFragmentTypes()) {
             wl($"    [\"{typ.Name}\"] = {idx},");
        }
        
        wl($"}};");
        
        return sb.ToString();
    }

    public string FromMutableFunction() {
        var sb = new StringBuilder();
        void wl(string s) { sb.AppendLine(s); }
		
		if (Name == "TSqlFragment") {
			wl($"public static TSqlFragment FromMutable(ScriptDom.TSqlFragment fragment) {{");
			wl($"    if (fragment is null) {{ return null; }}");
			wl($"    if (!TagNumberByTypeName.TryGetValue(fragment.GetType().Name, out var tag)) {{");
			wl($"        throw new NotImplementedException(\"Type not implemented: \" + fragment.GetType().Name + \". Regenerate immutable type library.\");");
			wl($"    }}");
			wl($"");

			wl($"    switch (tag) {{");
			foreach ((var idx, var typ) in TaggedConcreteFragmentTypes()) {
				var node = $"fragment as ScriptDom.{typ.Name}";
				wl($"        case {idx}: return {typ.Name}.FromMutable({node});");
			}
			wl($"        default: throw new NotImplementedException(\"Type not implemented: \" + fragment.GetType().Name + \". Regenerate immutable type library.\");");
			wl($"    }}");
			wl($"}}");
		} else if (IsAbstract) {
			// With Subtypes we could generate a less needlessly recursive version of this.
			wl($"public static {Name} FromMutable(ScriptDom.{Name} fragment) => ({Name})TSqlFragment.FromMutable(fragment);");
		} else {
			wl($"public static {Name} FromMutable(ScriptDom.{Name} fragment) {{");
			wl($"    if (fragment is null) {{ return null; }}");
			if (Subtypes.TryGetValue(Name, out var subtypes) && subtypes.Count > 0) {
				// With Subtypes we could generate a less needlessly recursive version of this.
				wl($"    if (fragment.GetType() != typeof(ScriptDom.{Name})) {{ return TSqlFragment.FromMutable(fragment) as {Name}; }}");
			} else {
				wl($"    if (fragment.GetType() != typeof(ScriptDom.{Name})) {{ throw new NotImplementedException(\"Unexpected subtype of {Name} not implemented: \" + fragment.GetType().Name + \". Regenerate immutable type library.\"); }}");
			}
			wl($"    return new {Name}(");
			var ctorPms = new List<string>();
			foreach (var prop in Props) {
				if (prop.IsScriptDomType && prop.IsList) {
					ctorPms.Add($"{LowerName(prop.Name)}: fragment.{prop.Name}.SelectList(ImmutableDom.{prop.InnerTypeLiteral}.FromMutable)");
				} else if (prop.IsList) {
					ctorPms.Add($"{LowerName(prop.Name)}: ImmList<{prop.TypeLiteral}>.FromList(fragment.{prop.Name})");
				} else if (prop.IsScriptDomType) {
					ctorPms.Add($"{LowerName(prop.Name)}: ImmutableDom.{prop.TypeLiteral}.FromMutable(fragment.{prop.Name})");
				} else {
					ctorPms.Add($"{LowerName(prop.Name)}: fragment.{prop.Name}");
				}
			}
			wl(ctorPms.StringJoin(",\n").IndentLines(8));
			wl($"    );");
			wl($"}}");
		}

        return sb.ToString();
    }

    public string FullFileDef() {
        var sb = new StringBuilder();
        void wl(string s) { sb.AppendLine(s); }
        wl($"using System;");
        wl($"using System.Collections;");
        wl($"using System.Collections.Generic;");
        wl($"using System.Linq;");
        wl($"using Xledger.Sql.Collections;");
        wl($"using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;");
        wl($"\n");

        wl($"namespace Xledger.Sql.ImmutableDom {{");
        wl(this.FullClassDef().IndentLines(4));
        wl($"}}");

        return sb.ToString();

    }
}

public static IEnumerable<(int idx, Type typ)> TaggedConcreteFragmentTypes() {
    var i = 1;
    foreach (var typ in FragmentTypes().OrderBy(t => t.Name)) {
        if (typ.IsAbstract) { continue; }
        yield return (i, typ);
        i += 1;
    }
}

public static IEnumerable<(int idx, Type typ)> TaggedAbstractFragmentTypes() {
	var i = 1;
	foreach (var typ in FragmentTypes().OrderBy(t => t.Name)) {
		if (!typ.IsAbstract) { continue; }
		yield return (i, typ);
		i += 1;
	}
}

public class PropDef {
    public string Name { get; set; }
    public bool IsList { get; set; }
    public bool IsScriptDomType { get; set; }
    public bool IsNullable { get; set; }
    public string DefaultLiteral { get; set; }
    public string TypeLiteral { get; set; }
    public string InnerTypeLiteral { get; set; }
    public bool IsInherited { get; set; }
}

static List<Type> FragmentTypes() {
    var asm = typeof(TSqlFragment).Assembly;
    var types = asm.GetTypes();
    return types
        .Where(t => typeof(TSqlFragment).IsAssignableFrom(t))
        .ToList();
}

public static class Exts {
    public static string StringJoin(this IEnumerable<string> @this, string sep) {
        return string.Join(sep, @this);
    }

    public static string IndentLines(this string txt, int indent) {
        var sb = new StringBuilder(txt.Length * 2);
        var indentStr = new string(' ', indent);
        sb.Append(indentStr);
        for (int i = 0; i < txt.Length; i++) {
            var c = txt[i];
            if (c == '\n') {
                if (i < txt.Length - 1) {
                    sb.Append(c);
                    if (txt[i + 1] != '\n') {
                        sb.Append(indentStr);
                    }
                } else {
                    sb.Append(c);
                }
            } else {
                sb.Append(c);
            }
        }
        return sb.ToString();

		//var lines = txt.Split(new char[] { '\n' }, opts);
		//var indentStr = new String(' ', indent);
		//for (int i = 0; i < lines.Length; i++) {
		//    lines[i] = (indentStr + lines[i]).TrimEnd();
		//}
		//return string.Join("\n", lines);
	}

	public static string NullIfBlank(this string s) {
		return string.IsNullOrWhiteSpace(s) ? null : s;
	}
}