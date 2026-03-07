``` powershell
dotnet pack Daeha.Lucazor\Daeha.Lucazor.csproj -c Release
dotnet pack Daeha.Lucazor.Blazor\Daeha.Lucazor.Blazor.csproj -c Release
```

``` powershell
dotnet nuget push nupkgs\*.nupkg `
  --api-key YOUR_API_KEY `
  --source https://api.nuget.org/v3/index.json
```
