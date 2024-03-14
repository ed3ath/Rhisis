using Rhisis.Protocol;
using System;

namespace Rhisis.Game.Protocol.Packets.World.Client.Bank;

public class ConfirmBankPacket
{
    /// <summary>
    /// Gets the bank pin.
    /// </summary>
    public string BankPin { get; }

    /// <summary>
    /// Gets the id.
    /// </summary>
    public uint Id { get; }

    /// <summary>
    /// Gets the item id.
    /// </summary>
    public uint ItemId { get; }

    /// <inheritdoc />
    public ConfirmBankPacket(FFPacket packet)
    {
        BankPin = packet.ReadString();
        Id = packet.ReadUInt32();
        ItemId = packet.ReadUInt32();
    }
}