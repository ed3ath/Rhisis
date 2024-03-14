using Rhisis.Game.Entities;
using Rhisis.Protocol;

namespace Rhisis.Game.Protocol.Packets.World.Server.Snapshots.Bank;

public class PutBankItemSnapshot : FFSnapshot
{
    public PutBankItemSnapshot(Player player, byte slot, Item item)
        : base(SnapshotType.PUT_BANK_ITEM, player.ObjectId)
    {
        WriteByte(slot);
        WriteInt32(-1);
        item.Serialize(this);
    }
}
