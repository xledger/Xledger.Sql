<Query Kind="Program">
  <NuGetReference>Microsoft.SqlServer.TransactSql.ScriptDom</NuGetReference>
  <Namespace>Microsoft.SqlServer.TransactSql.ScriptDom</Namespace>
</Query>

void Main() {
    //////////////////////////////////////////////////////////////////////
    // Generate ScopedFragmentTransformer class
    //////////////////////////////////////////////////////////////////////
    var className = "ScopedFragmentTransformer";
    var sb = new StringBuilder();
    sb.AppendLine($"// GENERATED via script ({Path.GetFileName(Util.CurrentQueryPath)})");
    sb.AppendLine("// DO NOT EDIT DIRECTLY.");
    sb.AppendLine($"public class {className} : TSqlConcreteFragmentVisitor {{");
    sb.AppendLine("    public bool VisitParentTypes { get; set; }");
    sb.AppendLine("    public bool ShouldStop { get; set; }");
    sb.AppendLine("    int skipRequests;");
    sb.AppendLine("    public Stack<TSqlFragment> Parents { get; set; } = new Stack<TSqlFragment>(30);");
    sb.AppendLine("    public HashSet<TSqlFragment> SkipList { get; } = new HashSet<TSqlFragment>();");
    sb.AppendLine("    ///<summary>Actions to perform when leaving a node.</summary>");
    sb.AppendLine("    public Dictionary<TSqlFragment, Queue<Action<TSqlFragment>>> PendingOnLeaveActionsByFragment { get; set; } = new Dictionary<TSqlFragment, Queue<Action<TSqlFragment>>>();");
    sb.AppendLine("    Dictionary<ushort, object> visitorByTypeTag = new Dictionary<ushort, object>();");

    var varNameByType = new Dictionary<Type, string>();
    sb.AppendLine();
    foreach (var t in VisitableTypes().OrderBy(t => t.Type.Name)) {
        var varName = VisitFnName(t.Type);
        varNameByType[t.Type] = varName;
        sb.AppendLine($"    public Action<{className}, {t.Type.Name}> {varName} {{");
        sb.AppendLine($"        get => this.visitorByTypeTag.TryGetValue({t.tag}, out object v) ? (Action<{className}, {t.Type.Name}>)v : default;");
        sb.AppendLine($"        set => this.visitorByTypeTag[{t.tag}] = value;");
        sb.AppendLine($"    }}");
    }
    sb.AppendLine();

    sb.AppendLine($"    public {className}() : base() {{}}");

    sb.AppendLine("");

    sb.AppendLine("    void PushContext(TSqlFragment node) {");
    sb.AppendLine("        Parents.Push(node);");
    sb.AppendLine("    }");
    sb.AppendLine("");

    sb.AppendLine("    void PopContext() {");
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
    var visitableTypes = VisitableTypes().OrderBy(t => t.Type.Name).ToArray();
    foreach (var t in visitableTypes.Where(t => t.HasExplicitVisitMethod).Select(t => t.Type)) {
        if (!first) {
            sb.AppendLine($"\n");
        }
        sb.AppendLine($"    public override void ExplicitVisit({t.Name} node) {{");
        sb.AppendLine($"        if (SkipList.Contains(node)) {{ return; }}");
        sb.AppendLine($"        if (ShouldStop) {{ return; }}");
        sb.AppendLine($"        var skipRequests = this.skipRequests;");
        if (t.BaseType is Type parentType
            && parentType != typeof(object)) {
            sb.AppendLine($"        if (VisitParentTypes) {{");
            sb.AppendLine($"            this.ExplicitBaseVisit(({parentType.Name})node);");
            sb.AppendLine($"            if (ShouldStop) {{ return; }}");
            sb.AppendLine($"        }}");
        }
        sb.AppendLine($"        {VisitFnName(t)}?.Invoke(this, node);");
        sb.AppendLine($"        if (ShouldStop) {{ return; }}");
        sb.AppendLine($"");
        
        sb.AppendLine($"        if (skipRequests == this.skipRequests) {{");
        sb.AppendLine($"            PushContext(node);");
        sb.AppendLine($"            base.ExplicitVisit(node);");
        sb.AppendLine($"            PopContext();");
        sb.AppendLine($"        }}");
        sb.AppendLine($"");
        
        sb.AppendLine($"        HandleOnLeave(node);");



        sb.AppendLine($"    }}");
        first = false;
    }

    foreach (var t in visitableTypes.Where(t => !t.HasExplicitVisitMethod).Select(t => t.Type)) {
        sb.AppendLine($"\n");
        sb.AppendLine($"    public void ExplicitBaseVisit({t.Name} node) {{");
        sb.AppendLine($"        if (ShouldStop) {{ return; }}");
        if (t.BaseType is Type parentType
            && parentType != typeof(object)) {
            sb.AppendLine($"        if (VisitParentTypes) {{ this.ExplicitBaseVisit(({parentType.Name})node); }}");
        }
        sb.AppendLine($"        {VisitFnName(t)}?.Invoke(this, node);");

        sb.AppendLine($"    }}");
        first = false;
    }
    
    sb.AppendLine($"    public void SkipChildrenForCurrentNode() {{");
    sb.AppendLine($"        this.skipRequests += 1;");
    sb.AppendLine($"    }}");
    
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

record TypeInfo(Type Type, bool HasExplicitVisitMethod, ushort tag);


List<TypeInfo> VisitableTypes() {
    var types = new HashSet<Type>();
    var ret = new List<TypeInfo>();
    var t = typeof(TSqlConcreteFragmentVisitor);
    foreach (var x in t.GetMethods(BindingFlags.Instance | BindingFlags.Public)) {
        if (x.Name != "ExplicitVisit" || x.IsFinal) {
            continue;
        }
        var typ = x.GetParameters().Single().ParameterType;
        if (types.Add(typ)) {
            ret.Add(new TypeInfo(typ, true, (ushort)ret.Count));
        }
    }
    
    foreach (var typInfo in ret.ToArray()) {
        var parent = typInfo.Type.BaseType;
        while (parent != typeof(object)) {
            if (types.Add(parent)) {
                ret.Add(new TypeInfo(parent, false, (ushort)ret.Count));
            } else {
                break;
            }
            parent = parent.BaseType;
        }
    }
    
    
    return ret;
}

public static class Exts {
    public static string IndentLines(this string txt, int indent) {
        var lines = txt.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        var indentStr = new String(' ', indent);
        for (int i = 0; i < lines.Length; i++) {
            lines[i] = (indentStr + lines[i]).TrimEnd();
        }
        return string.Join("\n", lines);
    }
}