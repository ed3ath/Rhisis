using Rhisis.Game.Entities;
using Rhisis.Protocol;

namespace Rhisis.Game.Protocol.Packets.World.Server.Snapshots.Bank;

public class GetBankItemSnapshot : FFSnapshot
{
    public GetBankItemSnapshot(Player player, Item item)
        : base(SnapshotType.GET_BANK_ITEM, player.ObjectId)
    {
        WriteInt32(-1);
        item.Serialize(this);
    }
}
