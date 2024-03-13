using Rhisis.Protocol;

namespace Rhisis.Game.Protocol.Packets.World.Client;

public class BuffPangPacket
{
    /// <summary>
    /// Gets the buffing NPC key.
    /// </summary>
    public string NpcKey { get; private set; }

    public BuffPangPacket(FFPacket packet)
    {
        NpcKey = packet.ReadString();
    }
}