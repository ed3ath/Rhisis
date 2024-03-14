using Rhisis.Game.Entities;
using Rhisis.Protocol;

namespace Rhisis.Game.Protocol.Packets.World.Server.Snapshots;

public class QueryPlayerDataSnapshot : FFSnapshot
{
    public QueryPlayerDataSnapshot(Player player)
        : base(SnapshotType.REPLACE, uint.MaxValue)
    {
        WriteUInt32(player.ObjectId);
        // WriteString(player.Position.X);
        // WriteSingle(player.Position.Y);
        // WriteSingle(player.Position.Z);
    }
}
