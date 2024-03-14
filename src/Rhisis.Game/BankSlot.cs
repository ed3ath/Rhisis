using Rhisis.Game.Common;
using Rhisis.Game.Entities;
using Rhisis.Game.Protocol.Packets.World.Server.Snapshots;
using Rhisis.Game.Protocol.Packets.World.Server.Snapshots.Bank;
using Rhisis.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rhisis.Game;

/// <summary>
/// Provides a mechanism to manage a player's bank.
/// </summary>
public sealed class BankSlot
{
    public static readonly int BankSize = 42;
    public static readonly int SlotSize = 3;

    private readonly Player _owner;

    private readonly IEnumerable<Bank> _bankSlots;

    /// <summary>
    /// Creates a new <see cref="Bank"/> instance.
    /// </summary>
    /// <param name="owner">Player owner.</param>
    public BankSlot(Player owner)
    {
        _owner = owner;
        List<Bank> bankSlots = new();
        for (int i = 0; i < SlotSize; i++)
        {
            bankSlots.Add(new Bank(owner, (byte)i));
        }
        _bankSlots = [.. bankSlots];
    }

    public Bank GetBank(byte slot, bool init = false)
    {
        if (slot > SlotSize)
        {
            throw new InvalidOperationException($"Bank slot is out of bounce: {slot}");
        }
        return _bankSlots.FirstOrDefault(x => x.Slot == slot) ?? (!init ? throw new InvalidOperationException($"Bank is not found for slot: {slot}") : null);
    }
}
