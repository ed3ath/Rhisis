using Microsoft.Extensions.Logging;
using Rhisis.Game.Entities;
using Rhisis.Game.Protocol.Packets.World.Client;
using Rhisis.Protocol;
using Rhisis.Protocol.Handlers;
using System;

namespace Rhisis.WorldServer.Handlers;

[PacketHandler(PacketType.QUERYGETPOS)]
internal sealed class QueryGetPosHandler : WorldPacketHandler


{
    private readonly ILogger<QueryGetPosHandler> _logger;

    public QueryGetPosHandler(ILogger<QueryGetPosHandler> logger)
    {
        _logger = logger;
    }
    public void Execute(QueryGetPosPacket packet)
    {
        if (packet.ObjectId <= 0)
        {
            throw new InvalidOperationException($"Invalid object id: '{packet.ObjectId}'.");
        }


         Mover mover = Player.GetVisibleObject<Mover>(packet.ObjectId)
         ?? throw new InvalidOperationException($"Cannot find target object with id: '{packet.ObjectId}'.");

        _logger.LogWarning($"Received packet {PacketType.QUERYGETPOS} mover {mover.ObjectId}.");
    }
}
