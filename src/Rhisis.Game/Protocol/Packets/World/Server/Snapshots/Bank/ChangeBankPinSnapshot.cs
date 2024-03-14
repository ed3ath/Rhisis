using Rhisis.Game.Entities;
using Rhisis.Protocol;

namespace Rhisis.Game.Protocol.Packets.World.Server.Snapshots.Bank;

public class ChangeBankPinSnapshot : FFSnapshot
{

    public ChangeBankPinSnapshot(int mode, uint objectId, uint itemId)
        : base(SnapshotType.CHANGE_BANK_PIN, objectId)
    {
        WriteInt32(mode);
        WriteUInt32(objectId);
        WriteUInt32(itemId);
    }
}