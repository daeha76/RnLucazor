# Daeha.RnLucazor

1700+ [Lucide](https://lucide.dev) icons for .NET and Blazor. Zero dependencies. Full IntelliSense.

## Quick Start

```bash
dotnet add package Daeha.RnLucazor
```

```csharp
using RnLucazor;

// Compile-time safe with IntelliSense
var svg = RnIcons.Heart.ToSvg();
var svg2 = RnIcons.ArrowRight.ToSvg(size: 32, stroke: "red");

// Dynamic lookup by name
var icon = RnIconRegistry.GetIcon("activity");
```

## Blazor

```bash
dotnet add package Daeha.RnLucazor.Blazor
```

```csharp
// Program.cs
builder.Services.AddRnLucazor();
```

```razor
@using RnLucazor
@using RnLucazor.Blazor

<RnIcon Icon="RnIcons.Heart" Size="32" Color="red" />
<RnIcon Name="arrow-right" Size="16" />
<RnIcon Icon="RnIcons.ArrowUp" Transform="IconTransform.Rotate90" />
```

## Features

- **1700+ icons** — all [Lucide](https://lucide.dev) icons as strongly-typed C# properties
- **Zero dependencies** — core library targets `netstandard2.0`
- **IntelliSense** — full autocompletion for every icon name
- **Customizable** — size, color, fill, stroke width, CSS class, custom attributes
- **Transforms** — rotation (90/180/270) and flip (horizontal/vertical)
- **DI support** — `IIconProvider` interface for dependency injection and testing
- **Pluggable rendering** — implement `ISvgRenderer` for WPF, MAUI, SkiaSharp, etc.
- **Custom icons** — register your own icons alongside built-in ones
- **Blazor component** — `<RnIcon>` with full parameter binding

## Advanced Usage

### SvgRenderOptions

```csharp
var svg = RnIcons.Heart.ToSvg(new SvgRenderOptions
{
    Size = 48,
    Stroke = "#ff0000",
    Fill = "pink",
    StrokeWidth = 1.5f,
    CssClass = "icon-heart",
    Transform = IconTransform.Rotate90,
    Attributes = new Dictionary<string, string>
    {
        { "aria-hidden", "true" }
    }
});
```

### Dependency Injection

```csharp
public class MyService
{
    private readonly IIconProvider _icons;
    public MyService(IIconProvider icons) => _icons = icons;

    public string GetIconSvg(string name) => _icons.GetIcon(name)?.ToSvg() ?? "";
}
```

### Custom Icons

```csharp
builder.Services.AddRnLucazor(provider =>
{
    provider.AddIcon("my-logo", new IconData("my-logo", new IconElement[] { ... }));
});
```

## Icon Naming

Icons use PascalCase in C#. For dynamic lookup, use the original kebab-case name.

| SVG | C# | Dynamic |
|-----|-----|---------|
| `activity.svg` | `RnIcons.Activity` | `"activity"` |
| `arrow-right.svg` | `RnIcons.ArrowRight` | `"arrow-right"` |

## Packages

| Package | Target | Description |
|---------|--------|-------------|
| [`Daeha.RnLucazor`](https://www.nuget.org/packages/Daeha.RnLucazor) | netstandard2.0 | Core library (zero dependencies) |
| [`Daeha.RnLucazor.Blazor`](https://www.nuget.org/packages/Daeha.RnLucazor.Blazor) | net8.0+ | Blazor component with DI |

## License

ISC — [Lucide Icons](https://lucide.dev)
