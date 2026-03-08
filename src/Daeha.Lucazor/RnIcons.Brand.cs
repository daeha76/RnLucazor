using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RnLucazor;

/// <summary>
/// Brand/social icons (Google, Naver, KakaoTalk) that supplement the Lucide icon set.
/// These icons use fill="currentColor" and stroke="none" so they render as solid shapes.
/// </summary>
public static partial class RnIcons
{
    /// <summary>Google "G" logo icon.</summary>
    public static IconData Google { get; } = new IconData("google", new IconElement[]
    {
        new IconElement("path", new ReadOnlyDictionary<string, string>(new Dictionary<string, string>
        {
            { "d", "M12.48 10.92v3.28h7.84c-.24 1.84-.853 3.187-1.787 4.133-1.147 1.147-2.933 2.4-6.053 2.4-4.827 0-8.6-3.893-8.6-8.72s3.773-8.72 8.6-8.72c2.6 0 4.507 1.027 5.907 2.347l2.307-2.307C18.747 1.44 16.133 0 12.48 0 5.867 0 .307 5.387.307 12s5.56 12 12.173 12c3.573 0 6.267-1.173 8.373-3.36 2.16-2.16 2.84-5.213 2.84-7.667 0-.76-.053-1.467-.173-2.053H12.48z" },
            { "fill", "currentColor" },
            { "stroke", "none" }
        }))
    });

    /// <summary>Naver "N" logo icon.</summary>
    public static IconData Naver { get; } = new IconData("naver", new IconElement[]
    {
        new IconElement("path", new ReadOnlyDictionary<string, string>(new Dictionary<string, string>
        {
            { "d", "M16.273 12.845L7.376 0H0v24h7.727V11.155L16.624 24H24V0h-7.727z" },
            { "fill", "currentColor" },
            { "stroke", "none" }
        }))
    });

    /// <summary>KakaoTalk speech-bubble logo icon.</summary>
    public static IconData KakaoTalk { get; } = new IconData("kakaotalk", new IconElement[]
    {
        new IconElement("path", new ReadOnlyDictionary<string, string>(new Dictionary<string, string>
        {
            { "d", "M12 3C6.477 3 2 6.477 2 10.8c0 2.695 1.604 5.071 4.037 6.474-.126.484-.578 2.21-.646 2.54-.084.413.151.407.318.296 2.054-1.367 2.255-1.502 3.444-2.313.405.052.824.079 1.247.079 5.523 0 10-3.477 10-7.776C22 6.477 17.523 3 12 3z" },
            { "fill", "currentColor" },
            { "stroke", "none" }
        }))
    });

    // -----------------------------------------------------------------------
    // Auto-registration via static constructor
    // -----------------------------------------------------------------------

    static RnIcons()
    {
        RnIconRegistry.Register("google", Google);
        RnIconRegistry.Register("naver", Naver);
        RnIconRegistry.Register("kakaotalk", KakaoTalk);
    }
}
