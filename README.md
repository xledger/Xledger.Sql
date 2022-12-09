# Xledger.Sql

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
