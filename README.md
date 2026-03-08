<div align="center">

# RnLucazor

**Blazor port of [Lucide Icons](https://lucide.dev)**
**(Rn + Lucide + razor)**

Beautiful & consistent open-source icon library for .NET and Blazor applications.

[![NuGet](https://img.shields.io/nuget/v/Daeha.RnLucazor?style=flat-square&logo=nuget&color=004880)](https://www.nuget.org/packages/Daeha.RnLucazor)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Daeha.RnLucazor?style=flat-square&logo=nuget&color=004880)](https://www.nuget.org/packages/Daeha.RnLucazor)
[![License](https://img.shields.io/github/license/daeha76/Lucazor?style=flat-square)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-standard2.0%20%7C%208.0%20%7C%209.0%20%7C%2010.0-512bd4?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com)

> 이 라이브러리는 딸 리안(Rian)의 이름을 담아 만든 Blazor 아이콘 라이브러리입니다. 💕

</div>

---

## Why RnLucazor?

- **1700+ icons** — Lucide의 모든 아이콘을 .NET에서 바로 사용
- **컴파일 타임 안전성** — `RnIcons.Activity`처럼 IntelliSense와 함께 정적 접근
- **제로 의존성** — Core 패키지는 외부 참조 없음 (`netstandard2.0`)
- **풀 커스터마이징** — Size, Color, StrokeWidth, Transform, CSS Class, 추가 어트리뷰트
- **플러그인 가능한 렌더러** — `ISvgRenderer`로 WPF, MAUI 등 어떤 타겟에도 렌더링
- **DI 지원** — `IIconProvider`로 테스트 및 커스텀 아이콘 확장 가능
- **멀티 타겟** — `netstandard2.0` (Core) / `.NET 8.0+` (Blazor)

---

## Packages

| Package | Target | Description |
|---------|--------|-------------|
| `Daeha.RnLucazor` | netstandard2.0 | Core icon data library (zero dependencies) |
| `Daeha.RnLucazor.Blazor` | net8.0+ | Blazor component with DI support |

---

## Quick Start

### 1. 패키지 설치

```bash
dotnet add package Daeha.RnLucazor
dotnet add package Daeha.RnLucazor.Blazor   # Blazor 앱의 경우
```

### 2. 서비스 등록

`Program.cs`에 다음을 추가합니다:

```csharp
using RnLucazor.Blazor;

builder.Services.AddRnLucazor();
```

### 3. Import 추가

`_Imports.razor`에 다음을 추가합니다:

```razor
@using RnLucazor
@using RnLucazor.Blazor
```

### 4. 컴포넌트 사용

```razor
<RnIcon Icon="RnIcons.Activity" />
<RnIcon Icon="RnIcons.Heart" Size="32" Color="red" />
```

---

## Usage Examples

### Direct SVG Output (any .NET app)

```csharp
using RnLucazor;

// 정적 접근 — 컴파일 타임 안전, IntelliSense 지원
var svg = RnIcons.Activity.ToSvg();
var svg2 = RnIcons.ArrowRight.ToSvg(size: 32, stroke: "red", strokeWidth: 1.5f);

// 이름으로 동적 조회 (kebab-case)
var icon = RnIconRegistry.GetIcon("activity");
Console.WriteLine(icon?.ToSvg());

// 사용 가능한 모든 아이콘 이름 나열
foreach (var name in RnIconRegistry.GetIconNames())
{
    Console.WriteLine(name);
}
```

### Advanced SVG Rendering

```csharp
// SvgRenderOptions로 세밀한 제어
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
        { "data-testid", "heart-icon" },
        { "aria-hidden", "true" },
    }
});

// 커스텀 렌더러 사용
ISvgRenderer renderer = new StringSvgRenderer();
var output = renderer.Render(RnIcons.Star, new SvgRenderOptions { Size = 16 });
```

### Icon Transforms

```csharp
// 기본 제공 Transform
RnIcons.ArrowRight.ToSvg(new SvgRenderOptions { Transform = IconTransform.Rotate90 });
RnIcons.ArrowRight.ToSvg(new SvgRenderOptions { Transform = IconTransform.FlipHorizontal });

// 커스텀 Transform
var transform = new IconTransform { Rotate = 45, FlipX = true };
RnIcons.Star.ToSvg(new SvgRenderOptions { Transform = transform });
```

### Blazor Component

```razor
@* 정적 참조 (컴파일 타임 안전) *@
<RnIcon Icon="RnIcons.Activity" />

@* 커스터마이즈 *@
<RnIcon Icon="RnIcons.Heart" Size="32" Color="red" StrokeWidth="1.5f" />

@* 이름으로 동적 참조 *@
<RnIcon Name="arrow-right" Size="16" />

@* Transform 적용 *@
<RnIcon Icon="RnIcons.ArrowUp" Transform="IconTransform.Rotate90" />

@* CSS 클래스와 추가 어트리뷰트 *@
<RnIcon Icon="RnIcons.Search" CssClass="icon-search" id="search-icon" />
```

### Custom Icon Registration

```csharp
// 커스텀 아이콘과 함께 등록
builder.Services.AddRnLucazor(provider =>
{
    provider.AddIcon("my-logo", new IconData("my-logo", new IconElement[]
    {
        new IconElement("circle", new ReadOnlyDictionary<string, string>(
            new Dictionary<string, string> { { "cx", "12" }, { "cy", "12" }, { "r", "10" } }))
    }));
});
```

### Dependency Injection

```csharp
public class MyService
{
    private readonly IIconProvider _icons;

    public MyService(IIconProvider icons) => _icons = icons;

    public string GetIconSvg(string name)
    {
        var icon = _icons.GetIcon(name);
        return icon?.ToSvg() ?? "";
    }
}
```

### Custom ISvgRenderer

```csharp
// 예시: WPF DrawingGroup 렌더러
public class WpfSvgRenderer : ISvgRenderer
{
    public string Render(IconData icon, SvgRenderOptions? options = null)
    {
        // IconData를 WPF 호환 XAML DrawingGroup으로 변환
        // ...
    }
}

// 커스텀 렌더러 등록
builder.Services.AddSingleton<ISvgRenderer, WpfSvgRenderer>();
```

---

## Icon Naming

| SVG 파일명 | C# 프로퍼티 |
|---|---|
| `activity.svg` | `RnIcons.Activity` |
| `arrow-right.svg` | `RnIcons.ArrowRight` |
| `circle-dot.svg` | `RnIcons.CircleDot` |

동적 조회 시에는 원래 kebab-case 이름을 사용합니다: `RnIconRegistry.GetIcon("arrow-right")`.

---

## Architecture

```
Daeha.RnLucazor (netstandard2.0)           namespace RnLucazor
├── IconData              — 아이콘 SVG 데이터 (확장 가능)
├── IconElement           — SVG 자식 요소 (path, circle 등)
├── RnIcons               — 1700+ 정적 아이콘 프로퍼티 (자동 생성)
├── RnIconRegistry        — 이름 기반 조회 (자동 초기화)
├── IIconProvider         — DI 친화적 아이콘 프로바이더 인터페이스
├── RnIconProvider        — 커스텀 아이콘 지원 기본 프로바이더
├── ISvgRenderer          — 플러그인 가능한 렌더링 인터페이스
├── StringSvgRenderer     — 기본 문자열 렌더러
├── SvgRenderOptions      — 렌더링 풀 커스터마이징
└── IconTransform         — 회전/뒤집기 Transform

Daeha.RnLucazor.Blazor (net8.0)            namespace RnLucazor.Blazor
├── RnIcon                — DI 주입을 지원하는 Blazor 컴포넌트
└── ServiceCollectionExtensions — AddRnLucazor() 확장 메서드
```

---

## Regenerating Icons

SVG 소스 아이콘이 업데이트된 경우:

```bash
node packages/lucide-dotnet/tools/generate-icons.mjs
```

---

## Contributing

기여를 환영합니다! 이슈나 풀 리퀘스트를 자유롭게 제출해 주세요.

1. 이 저장소를 Fork합니다
2. 피처 브랜치를 생성합니다 (`git checkout -b feature/amazing-feature`)
3. 변경 사항을 커밋합니다 (`git commit -m 'feat: Add amazing feature'`)
4. 브랜치에 Push합니다 (`git push origin feature/amazing-feature`)
5. Pull Request를 생성합니다

---

## License

[ISC](LICENSE)

---

<div align="center">

Made with ❤️ for the Blazor community

</div>
