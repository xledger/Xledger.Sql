<Query Kind="Program">
  <NuGetReference>Microsoft.SqlServer.DacFx</NuGetReference>
  <Namespace>Microsoft.SqlServer.TransactSql.ScriptDom</Namespace>
</Query>

void Main() {
	//////////////////////////////////////////////////////////////////////
	// Generate Extensions ReplaceScalar class
	//////////////////////////////////////////////////////////////////////
	var className = "Extensions";
	var sb = new StringBuilder();
	sb.AppendLine($"// GENERATED via script ({Path.GetFileName(Util.CurrentQueryPath)})");
	sb.AppendLine("// DO NOT EDIT DIRECTLY.");
	sb.AppendLine($"public static class {className} {{");
	(string replaceScalarFn, string replaceScalarDict) = GetReplaceScalarMembers();
	sb.AppendLine(replaceScalarFn.IndentLines(4));
	sb.AppendLine();
	sb.AppendLine(replaceScalarDict.IndentLines(4));
	sb.AppendLine("}");

	var txt = sb.ToString();
	txt = txt.IndentLines(4);
	txt = @"using System;
using System.Collections.Generic;
using Microsoft.SqlServer.TransactSql.ScriptDom;
namespace Xledger.Sql {" + "\n" + txt + "\n}";
	var outputFile = Path.GetDirectoryName(Util.CurrentQueryPath) + $"/../Xledger.Sql/{className}.cs";
	File.WriteAllText(outputFile, txt, new System.Text.UTF8Encoding(false));
	Console.WriteLine($"Wrote {className} to {outputFile}.\n");
}

string VisitFnName(Type t) => $"VisFor{t.Name}";

(string fn, string dict) GetReplaceScalarMembers() {
    var sb = new StringBuilder();
   
    var tsqlFragmentTyp = typeof(TSqlFragment);
    var scalarExprTyp = typeof(ScalarExpression);
    var baseProps = tsqlFragmentTyp.GetProperties().ToHashSet();
    
    var dictEntries = new List<string>();
    var cases = new List<string>();
    var i = 1;
    foreach (var typ in VisitableTypes().OrderBy(t => t.Name)) {
        var checks = new List<string>();
        foreach (var prop in typ.GetProperties()) {
            if (!prop.CanRead || baseProps.Contains(prop)) {
                continue;
            }

			var propType = prop.PropertyType;
			var node = $"(parent as {typ.Name})";
            if (propType.IsAssignableFrom(scalarExprTyp)) {
                checks.Add(
                    $"if (Equals({node}.{prop.Name}, toReplace)) {{\n" +
                    $"    {node}.{prop.Name} = replacement;\n" +
                    $"    success = true;\n" +
                    $"}}");
            }
            
            if (!propType.IsGenericType) {
                continue;
            }
            var td = propType.GetGenericTypeDefinition();
            if (td.FullName != "System.Collections.Generic.IList`1") {
                continue;
            }
            var listTyp = propType.GenericTypeArguments.Single();
            if (listTyp.IsAssignableFrom(scalarExprTyp)) {
				var s =
					$"for (var i = 0; i < {node}.{prop.Name}.Count; i++) {{\n" +
                    $"    if (Equals({node}.{prop.Name}[i], toReplace)) {{\n" +
                    $"        {node}.{prop.Name}[i] = replacement;\n" +
                    $"        success = true;\n" + 
                    $"    }}\n" +
                    $"}}";
                checks.Add(s);
            }
            
        }
        if (checks.Any()) {
            var s = string.Join("\n", checks) + "\nbreak;";
            cases.Add($"case {i}: {{\n{s.IndentLines(4)}\n}}");
            dictEntries.Add($"[nameof({typ.Name})] = {i}");
            i += 1;
        }        
    }
    
    cases.Add("default: throw new NotImplementedException($\"Type {parent.GetType().FullName} not implemented.\");");
    
    var fnBody = string.Join("\n\n", cases);
    
    var fn = new [] {
        $"public static bool ReplaceScalar(this TSqlFragment parent, ScalarExpression toReplace, ScalarExpression replacement) {{",
        $"    var success = false;",
        $"    _ = ReplaceCaseNumberByType.TryGetValue(parent.GetType().Name, out var caseNum);",
        $"    switch (caseNum) {{",
        fnBody.IndentLines(8),
        $"    }}",
        $"    return success;",
        "}"
    };

    var dictStr = string.Join(",\n", dictEntries).IndentLines(4);
    dictStr = $"new Dictionary<string, int> {{\n{dictStr}\n}}".IndentLines(4);
    dictStr = $"static readonly IReadOnlyDictionary<string, int> ReplaceCaseNumberByType =\n{dictStr};";
    
    return (string.Join("\n", fn), dictStr);
}

IEnumerable<Type> VisitableTypes() {
    var t = typeof(TSqlConcreteFragmentVisitor);
    foreach (var x in t.GetMethods(BindingFlags.Instance | BindingFlags.Public)) {
        if (x.Name != "ExplicitVisit" || x.IsFinal) {
            continue;
        }
        yield return x.GetParameters().Single().ParameterType;
    }
}

public static class Exts {
    public static string IndentLines(this string txt, int indent) {
        var lines = txt.Split(new char[] { '\n'}, StringSplitOptions.RemoveEmptyEntries);
        var indentStr = new String(' ', indent);
        for (int i = 0; i < lines.Length; i++) {
            lines[i] = (indentStr + lines[i]).TrimEnd();
        }
        return string.Join("\n", lines);
    }
}