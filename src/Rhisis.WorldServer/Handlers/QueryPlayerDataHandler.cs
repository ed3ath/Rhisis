using Microsoft.Extensions.Logging;
using Rhisis.Game.Protocol.Packets.World.Client;
using Rhisis.Protocol;
using Rhisis.Protocol.Handlers;
using System;

namespace Rhisis.WorldServer.Handlers;

[PacketHandler(PacketType.QUERY_PLAYER_DATA)]
internal sealed class QueryPlayerDataHandler : WorldPacketHandler


{
    private readonly ILogger<QueryPlayerDataHandler> _logger;

    public QueryPlayerDataHandler(ILogger<QueryPlayerDataHandler> logger)
    {
        _logger = logger;
    }
    public void Execute(QueryPlayerDataPacket packet)
    {
        if (packet.PlayerId < 0) {
            throw new InvalidOperationException($"Invalid player id '{packet.PlayerId}'.");
        }
        if (packet.Version < 0) {
            throw new InvalidOperationException($"Invalid version '{packet.Version}'.");
        }

        Console.WriteLine($"{packet.PlayerId} {packet.Version}");
    }
}
