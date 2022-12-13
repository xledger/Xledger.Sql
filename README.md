# Xledger.Sql

Xledger.Sql provides tools for analyzing and transforming Transact SQL queries. This is provide in 3 main pieces:

1. [`Xledger.Sql.ScopedFragmentTransformer`](./Xledger.Sql/ScopedFragmentTransformer.cs): a `TSqlFragment` visitor that tracks the scope of visits to ease context-aware rewrites.
2. [`Xledger.Sql.Extensions`](./Xledger.Sql/Extensions.cs): providing a `ReplaceScalar` extension method to replace one scalar in its parent with a new scalar - without having to know exactly where in the parent the old scalar was present.
3. [`Xledger.Sql.ImmutableDom`](./Xledger.Sql/ImmutableDom/): an immutable version of `Microsoft.SqlServer.TransactSql.ScriptDom` to enable caching parts of a SQL DOM.

The tests in [Xledger.Sql.Test](./Xledger.Sql.Test) demonstrate how to use this library.

## Testing Locally

To generate a new NuGet package to verify that the package is sane.

1. Increment the `<VersionSuffix>` in [Xledger.Sql/Xledger.Sql.csproj]; or `<VersionPrefix>` if releasing a new major, minor, or patch version.
2. Run.
```powershell
cls; dotnet clean; dotnet pack
nuget init bin\Debug c:\packages
```
3. Update the project that depends on Xledger.Sql.
```powershell
dotnet add package Xledger.Sql --source c:\packages --prerelease
```
