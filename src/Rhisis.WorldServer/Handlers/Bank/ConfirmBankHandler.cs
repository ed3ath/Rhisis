using Microsoft.Extensions.Logging;
using Rhisis.Game.Protocol.Packets.World.Client.Bank;
using Rhisis.Game.Protocol.Packets.World.Server.Snapshots.Bank;
using Rhisis.Protocol;
using Rhisis.Protocol.Handlers;
using System;

namespace Rhisis.WorldServer.Handlers.Bank;

[PacketHandler(PacketType.CONFIRM_BANK_PIN)]
internal sealed class ConfirmBankHandler : WorldPacketHandler
{
    private readonly ILogger<ConfirmBankHandler> _logger;

    public ConfirmBankHandler(ILogger<ConfirmBankHandler> logger)
    {
        _logger = logger;
    }

    public void Execute(ConfirmBankPacket packet)
    {
        if (packet.Id <= 0)
        {
            throw new InvalidOperationException("Request id not supplied.");
        }        
        if (packet.BankPin is null)
        {
            throw new InvalidOperationException("Bank pin is not supplied.");
        }
        if (!int.TryParse(packet.BankPin, out int BankPin))
        {
            throw new InvalidOperationException($"Failed to parse bank pin. {packet.BankPin}");
        }
        using var snapshot = new ConfirmBankSnapshot(Player.BankPin != BankPin ? 0 : 1, Player.ObjectId, packet.ItemId);
        Player.Send(snapshot);
    }
}