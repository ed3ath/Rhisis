using Microsoft.Extensions.Logging;
using Rhisis.Game.Protocol.Packets.World.Client.Bank;
using Rhisis.Game.Protocol.Packets.World.Server.Snapshots.Bank;
using Rhisis.Protocol;
using Rhisis.Protocol.Handlers;
using System;

namespace Rhisis.WorldServer.Handlers.Bank;

[PacketHandler(PacketType.CHANGE_BANK_PIN)]
internal sealed class ChangeBankPinHandler : WorldPacketHandler
{
    private readonly ILogger<ChangeBankPinHandler> _logger;

    public ChangeBankPinHandler(ILogger<ChangeBankPinHandler> logger)
    {
        _logger = logger;
    }

    public void Execute(ChangeBankPinPacket packet)
    {

        if (packet.Id <= 0)
        {
            throw new InvalidOperationException("Request id not supplied.");
        }
        if (packet.OldBankPin is null)
        {
            throw new InvalidOperationException($"Old bank pin is not supplied.");
        }        
        if (packet.NewBankPin is null)
        {
            throw new InvalidOperationException($"New bank pin is not supplied.");
        }
        if (!int.TryParse(packet.OldBankPin, out int OldBankPin))
        {
            throw new InvalidOperationException($"Failed to parse old bank pin. {packet.OldBankPin}");
        }
        if (!int.TryParse(packet.NewBankPin, out int NewBankPin))
        {
            throw new InvalidOperationException($"Failed to parse new bank pin. {packet.NewBankPin}");
        }
        bool canChange = Player.BankPin == OldBankPin;
        if (canChange)
        {
            Player.BankPin = NewBankPin;
        }
        using var snapshot = new ConfirmBankSnapshot(canChange ? 1 : 0, packet.Id, packet.ItemId);
        Player.Send(snapshot);

    }
}