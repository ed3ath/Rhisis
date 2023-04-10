﻿using Rhisis.Protocol;

namespace Rhisis.Game.Protocol.Packets.World.Client.Bank;

public class PutGoldBankPacket
{
    /// <summary>
    /// Gets the slot.
    /// </summary>
    public byte Slot { get; }

    /// <summary>
    /// Gets the amount of gold.
    /// </summary>
    public uint Gold { get; }

    /// <inheritdoc />
    public PutGoldBankPacket(FFPacket packet)
    {
        Slot = packet.ReadByte();
        Gold = packet.ReadUInt32();
    }
}