<Query Kind="Program">
  <Reference Relative="..\XLibFs\Binaries\FsSqlDom.dll">C:\src\xledger\XLibFs\Binaries\FsSqlDom.dll</Reference>
  <Reference Relative="..\XLibFs\Binaries\Microsoft.SqlServer.TransactSql.ScriptDom.dll">C:\src\xledger\XLibFs\Binaries\Microsoft.SqlServer.TransactSql.ScriptDom.dll</Reference>
  <Reference Relative="..\XLibFs\Binaries\Microsoft.SqlServer.Types.dll">C:\src\xledger\XLibFs\Binaries\Microsoft.SqlServer.Types.dll</Reference>
  <NuGetReference Version="5.0.2">FSharp.Core</NuGetReference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <NuGetReference>System.Threading.Channels</NuGetReference>
  <Namespace>FsSqlDom</Namespace>
  <Namespace>Microsoft.SqlServer.TransactSql.ScriptDom</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>System.Threading.Channels</Namespace>
</Query>

void Main() {
    var sb = new StringBuilder();
    sb.AppendLine("// GENERATED via script (Generate_SqlRawVisitorWithContext.linq)");
    sb.AppendLine("// DO NOT EDIT DIRECTLY.");
    sb.AppendLine("public class SqlRawVisitorWithContext : TSqlConcreteFragmentVisitor {");
    sb.AppendLine("    public bool ShouldStop { get; set;}");
    sb.AppendLine("    public Stack<TSqlFragment> Parents { get; set; } = new Stack<TSqlFragment>(30);");
    sb.AppendLine("    public HashSet<TSqlFragment> SkipList { get; } = new HashSet<TSqlFragment>();");
    sb.AppendLine("    ///<summary>Actions to perform when leaving a node.</summary>");
    sb.AppendLine("    public Dictionary<TSqlFragment, Queue<Action<TSqlFragment>>> PendingOnLeaveActionsByFragment { get; set; } = new Dictionary<TSqlFragment, Queue<Action<TSqlFragment>>>();");

    var varNameByType = new Dictionary<Type, string>();
    sb.AppendLine();
    foreach (var t in VisitableTypes()) {
        var varName = VisitFnName(t);
        varNameByType[t] = varName;
        sb.AppendLine($"    public Action<SqlRawVisitorWithContext, {t.Name}> {varName};");
    }
    sb.AppendLine();

    sb.AppendLine("    public SqlRawVisitorWithContext() : base() {}");
    sb.AppendLine("");
    
    sb.AppendLine("    void PushContext(TSqlFragment node) {");
    sb.AppendLine("        Parents.Push(node);");
    sb.AppendLine("    }");
    sb.AppendLine("");

    sb.AppendLine("    void PopContext(TSqlFragment node) {");
    sb.AppendLine("        Parents.Pop();");
    sb.AppendLine("    }");
    sb.AppendLine("");

    sb.AppendLine("    public void EnqueueOnLeave(TSqlFragment node, Action<TSqlFragment> edit) {");
    sb.AppendLine("        if (!PendingOnLeaveActionsByFragment.TryGetValue(node, out var edits)) {");
    sb.AppendLine("            edits = PendingOnLeaveActionsByFragment[node] = new Queue<Action<TSqlFragment>>();");
    sb.AppendLine("        }");
    sb.AppendLine("        edits.Enqueue(edit);");
    sb.AppendLine("    }");
    sb.AppendLine("");

    sb.AppendLine("    public void HandleOnLeave(TSqlFragment node) {");
    sb.AppendLine("        if (!PendingOnLeaveActionsByFragment.TryGetValue(node, out var actions)) {");
    sb.AppendLine("            return;");
    sb.AppendLine("        }");
    sb.AppendLine("        while (actions.Count > 0) {");
    sb.AppendLine("            actions.Dequeue().Invoke(node);");
    sb.AppendLine("        }");
    sb.AppendLine("");
    sb.AppendLine("        PendingOnLeaveActionsByFragment.Remove(node);");
    sb.AppendLine("    }");
    sb.AppendLine("");

    var first = true;
    foreach (var t in VisitableTypes()) {
        if (!first) {
            sb.AppendLine($"\n");
        }
        sb.AppendLine($"    public override void ExplicitVisit({t.Name} node) {{");
        sb.AppendLine($"        if (SkipList.Contains(node)) {{ return; }}");
        sb.AppendLine($"        if (ShouldStop) {{ return; }}");
        sb.AppendLine($"        {VisitFnName(t)}?.Invoke(this, node);");
        sb.AppendLine($"        if (ShouldStop) {{ return; }}");
        sb.AppendLine($"");
        sb.AppendLine($"        PushContext(node);");
        sb.AppendLine($"        base.ExplicitVisit(node);");
        sb.AppendLine($"        PopContext(node);");
        sb.AppendLine($"");
        sb.AppendLine($"        HandleOnLeave(node);");
        sb.AppendLine($"    }}");
        first = false;
    }
   

    (string replaceScalarFn, string replaceScalarDict) = GetReplaceScalarMembers();
    sb.AppendLine();
    sb.AppendLine(replaceScalarDict.IndentLines(4));
    sb.AppendLine();

    sb.AppendLine(replaceScalarFn.IndentLines(4));
    
    sb.AppendLine("}");

    var txt = sb.ToString();
    txt = txt.IndentLines(4);
    txt = @"using System;
using System.Collections.Generic;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace X.Data.DB {" + "\n" + txt + "\n}";
    File.WriteAllText("C:\\src\\xledger\\XLib\\Data\\DB\\SqlRawVisitorWithContext.cs", txt);
    
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
    foreach (var typ in VisitableTypes()) {
        var checks = new List<string>();
        foreach (var prop in typ.GetProperties()) {
            if (!prop.CanRead || baseProps.Contains(prop)) {
                continue;
            }
            
            var propType = prop.PropertyType;
            if (propType.IsAssignableFrom(scalarExprTyp)) {
                checks.Add(
                    $"if (Equals(parent2.{prop.Name}, toReplace)) {{\n" +
                    $"    parent2.{prop.Name} = replacement;\n" +
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
                    $"for (int i = 0; i < parent2.{prop.Name}.Count; i++) {{\n" +
                    $"    if (Equals(parent2.{prop.Name}[i], toReplace)) {{\n" +
                    $"        parent2.{prop.Name}[i] = replacement;\n" +
                    $"        success = true;\n" + 
                    $"    }}\n" +
                    $"}}";
                checks.Add(s);
            }
            
        }
        if (checks.Any()) {
            var s = string.Join("\n", checks) + "\nbreak;";
            cases.Add($"case {i}: {{\n    var parent2 = ({typ.Name})parent;\n{s.IndentLines(4)}\n}}");
            dictEntries.Add($"[nameof({typ.Name})] = {i}");
            i += 1;
        }        
    }
    
    cases.Add("default: throw new NotImplementedException($\"Type {parent.GetType().FullName} not implemented.\");");
    
    var fnBody = string.Join("\n\n", cases);
    
    var fn = new [] {
        $"public static bool ReplaceScalarInParent(TSqlFragment parent, ScalarExpression toReplace, ScalarExpression replacement) {{",
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
    var i = 0;
    foreach (var x in t.GetMethods(BindingFlags.Instance | BindingFlags.Public)) {
        if (x.Name != "ExplicitVisit" || x.IsFinal) {
            continue;
        }
        yield return x.GetParameters().Single().ParameterType;
        //i += 1;
        //if (i > 2) {
        //    break;
        //}
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