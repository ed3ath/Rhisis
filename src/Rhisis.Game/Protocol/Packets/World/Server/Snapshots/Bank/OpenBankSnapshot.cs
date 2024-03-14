using Rhisis.Protocol;

namespace Rhisis.Game.Protocol.Packets.World.Server.Snapshots.Bank;

public class OpenBankSnapshot : FFSnapshot
{
    public OpenBankSnapshot(int mode, uint objectId, uint itemId)
        : base(SnapshotType.OPEN_BANK, objectId)
    {
        WriteInt32(mode);
        WriteUInt32(objectId);
        WriteUInt32(itemId);
    }
}
