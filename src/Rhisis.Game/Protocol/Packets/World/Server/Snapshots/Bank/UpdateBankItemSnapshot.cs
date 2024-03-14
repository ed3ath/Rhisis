using System;
using Rhisis.Game.Common;
using Rhisis.Game.Entities;
using Rhisis.Protocol;

namespace Rhisis.Game.Protocol.Packets.World.Server.Snapshots.Bank;

public class UpdateBankItemSnapshot : FFSnapshot
{
    public UpdateBankItemSnapshot(Player player, byte slot, byte itemIndex, int value)
        : base(SnapshotType.UPDATE_BANK_ITEM, player.ObjectId)
    {
        WriteByte(slot);
        WriteByte(itemIndex);
        WriteByte((byte)UpdateItemType.UI_NUM);
        WriteInt32(value);
    }
}
