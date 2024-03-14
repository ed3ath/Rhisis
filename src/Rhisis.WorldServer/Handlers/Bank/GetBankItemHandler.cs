using Microsoft.Extensions.Logging;
using Rhisis.Game.Protocol.Packets.World.Client.Bank;
using Rhisis.Protocol;
using Rhisis.Protocol.Handlers;
using System;
using Rhisis.Game;

namespace Rhisis.WorldServer.Handlers.Bank;

[PacketHandler(PacketType.GET_BANK_ITEM)]
internal sealed class GetBankItemHandler : WorldPacketHandler
{
    private readonly ILogger<GetBankItemHandler> _logger;

    public GetBankItemHandler(ILogger<GetBankItemHandler> logger)
    {
        _logger = logger;
    }

    public void Execute(GetBankItemPacket packet)
    {
        Console.WriteLine($"Get bank item {packet.Slot} {packet.ItemIndex} {packet.Quantity}");
        if (packet.ItemIndex < 0)
        {
            throw new InvalidOperationException("Request id not supplied.");
        }

        if (packet.Slot >= 3)
        {
            throw new InvalidOperationException($"Slot index was out of bounds. Slot: {packet.Slot}");
        }

        if (packet.Quantity < 1)
        {
            throw new InvalidOperationException($"Quantity not supplied. Quantity: {packet.Quantity}");
        }



        ItemContainerSlot itemSlot = Player.Bank.GetBank(packet.Slot).GetAtIndex(packet.ItemIndex) ??
            throw new InvalidOperationException($"Slot unavailable: {packet.Slot}.");

        if (!itemSlot.HasItem)
        {
            throw new InvalidOperationException($"No item found. Slot: {packet.Slot}");
        }

        Player.Bank.GetBank(packet.Slot).GetItem(itemSlot, packet.Quantity, packet.ItemIndex);

        ItemContainer playerBank = Player.Bank.GetBank(packet.Slot);

        Console.WriteLine("=========Withdraw ITEM============");
        foreach (ItemContainerSlot slot in playerBank.GetItems())
        {
            Console.WriteLine($"{slot.Index} {slot.Item.Id} {slot.Item.Quantity}");
        }
        Console.WriteLine("=================================");

    }
}