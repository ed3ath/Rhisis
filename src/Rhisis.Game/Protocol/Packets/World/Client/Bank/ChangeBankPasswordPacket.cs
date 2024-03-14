using Rhisis.Protocol;

namespace Rhisis.Game.Protocol.Packets.World.Client.Bank;

public class ChangeBankPinPacket
{
    /// <summary>
    /// Gets the old bank pin.
    /// </summary>
    public string OldBankPin { get; private set; }

    /// <summary>
    /// Gets the new bank pin.
    /// </summary>
    public string NewBankPin { get; private set; }

    /// <summary>
    /// Gets the id.
    /// </summary>
    public uint Id { get; private set; }

    /// <summary>
    /// Gets the item id.
    /// </summary>
    public uint ItemId { get; private set; }

    public ChangeBankPinPacket(FFPacket packet)
    {
        OldBankPin = packet.ReadString();
        NewBankPin = packet.ReadString();
        Id = packet.ReadUInt32();
        ItemId = packet.ReadUInt32();
    }
}