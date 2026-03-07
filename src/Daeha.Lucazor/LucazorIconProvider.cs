using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace RnLucazor;

/// <summary>
/// Default implementation of <see cref="IIconProvider"/> backed by the
/// generated <see cref="RnIcons"/> static class.
/// Supports registering custom icons alongside the built-in ones.
/// </summary>
public class RnIconProvider : IIconProvider
{
    private readonly ConcurrentDictionary<string, IconData> _customIcons
        = new ConcurrentDictionary<string, IconData>(StringComparer.OrdinalIgnoreCase);

    /// <inheritdoc/>
    public IconData? GetIcon(string name)
    {
        if (_customIcons.TryGetValue(name, out var custom))
            return custom;

        return RnIconRegistry.GetIcon(name);
    }

    /// <inheritdoc/>
    public IEnumerable<string> GetIconNames()
    {
        foreach (var name in _customIcons.Keys)
            yield return name;

        foreach (var name in RnIconRegistry.GetIconNames())
        {
            if (!_customIcons.ContainsKey(name))
                yield return name;
        }
    }

    /// <inheritdoc/>
    public int Count => RnIconRegistry.Count + _customIcons.Count;

    /// <summary>
    /// Registers a custom icon. Overrides any built-in icon with the same name.
    /// </summary>
    public void AddIcon(string name, IconData icon)
    {
        _customIcons[name] = icon ?? throw new ArgumentNullException(nameof(icon));
    }

    /// <summary>
    /// Removes a previously registered custom icon.
    /// </summary>
    public bool RemoveIcon(string name)
    {
        return _customIcons.TryRemove(name, out _);
    }
}
