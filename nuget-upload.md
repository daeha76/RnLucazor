# nuget 업로드 방법

## Window
``` powershell
dotnet pack Daeha.Lucazor\Daeha.Lucazor.csproj -c Release
dotnet pack Daeha.Lucazor.Blazor\Daeha.Lucazor.Blazor.csproj -c Release
```

``` powershell
dotnet nuget push nupkgs\*.nupkg `
  --api-key YOUR_API_KEY `
  --source https://api.nuget.org/v3/index.json
```

## Mac/Linux
``` zsh
dotnet pack Daeha.Lucazor/Daeha.Lucazor.csproj -c Release
dotnet pack Daeha.Lucazor.Blazor/Daeha.Lucazor.Blazor.csproj -c Release
```

``` zsh
dotnet nuget push nupkgs/*.nupkg \
  --api-key YOUR_API_KEY \
  --source https://api.nuget.org/v3/index.json
```