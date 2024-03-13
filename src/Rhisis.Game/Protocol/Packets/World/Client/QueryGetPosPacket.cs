using Rhisis.Protocol;

namespace Rhisis.Game.Protocol.Packets.World.Client;

public class QueryGetPosPacket
{
    /// <summary>
    /// Gets the quest id.
    /// </summary>
    public uint ObjectId { get; private set; }

    public QueryGetPosPacket(FFPacket packet)
    {
        ObjectId = packet.ReadUInt32();
    }
}
