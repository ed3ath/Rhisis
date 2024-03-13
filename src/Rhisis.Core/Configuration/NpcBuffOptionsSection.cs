using System;
using System.Collections.Generic;
using System.Linq;

namespace Rhisis.Core.Configuration;
/// <summary>
/// Provides a data structure for configuring the buff pang system.
/// </summary>
public sealed class NpcBuffOptionsSection
{
    /// <summary>
    /// Gets or sets the default npc buff configuration.
    /// </summary>
    public NpcBuffOptions Default { get; set; }

    /// <summary>
    /// Gets or sets the additionnal npc buff configuration.
    /// </summary>
    public IEnumerable<NpcBuffOptions> Additional { get; set; }

    /// <summary>
    /// Gets the npc buff configuration based on the given name.
    /// </summary>
    /// <param name="name">NPC name key.</param>
    /// <returns>Buff configuration or default configuration.</returns>
    public NpcBuffOptions Get(string name)
        => Additional.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)) ?? Default;
}