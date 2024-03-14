using Microsoft.Extensions.Logging;
using Rhisis.Game.Protocol.Packets.World.Client.Bank;
using Rhisis.Game.Protocol.Packets.World.Server.Snapshots.Bank;
using Rhisis.Protocol;
using Rhisis.Protocol.Handlers;
using System;

namespace Rhisis.WorldServer.Handlers.Bank;

[PacketHandler(PacketType.OPEN_BANK)]
internal sealed class OpenBankHandler : WorldPacketHandler
{
    private readonly ILogger<OpenBankHandler> _logger;

    public OpenBankHandler(ILogger<OpenBankHandler> logger)
    {
        _logger = logger;
    }

    public void Execute(OpenBankWindowPacket packet)
    {
        if (packet.Id <= 0)
        {
            throw new InvalidOperationException("Request id not supplied.");
        }
        using var snapshot = new OpenBankSnapshot(Player.BankPin == 0000 ? 0 : 1, Player.ObjectId, packet.ItemId);
        Player.Send(snapshot);
    }
}