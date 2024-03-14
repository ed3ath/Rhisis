using Rhisis.Game.Common;
using Rhisis.Game.Entities;
using Rhisis.Protocol;

namespace Rhisis.Game.Protocol.Packets.World.Server.Snapshots.Bank;

public class UpdateBankItemSnapshot : FFSnapshot
{
    public UpdateBankItemSnapshot(Player player, byte slot, byte itemIndex, UpdateItemType updateItemType, short value)
        : base(SnapshotType.UPDATE_BANK_ITEM, player.ObjectId)
    {
        WriteByte(slot);
        WriteByte(itemIndex);
        WriteChar((char)updateItemType);
        WriteInt16(value);
    }
}
