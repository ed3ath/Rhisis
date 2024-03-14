using Rhisis.Protocol;

namespace Rhisis.Game.Protocol.Packets.World.Client.Bank;

public class GetBankItemPacket
{
    /// <summary>
    /// Gets the slot.
    /// </summary>
    public byte Slot { get; }

    /// <summary>
    /// Gets the item index.
    /// </summary>
    public byte ItemIndex { get; }

    /// <summary>
    /// Gets the item quantity.
    /// </summary>
    public short Quantity { get; }

    public GetBankItemPacket(FFPacket packet)
    {
        Slot = packet.ReadByte();
        ItemIndex = packet.ReadByte();
        Quantity = packet.ReadInt16();
    }
}