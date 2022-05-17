﻿using Rhisis.Abstractions.Protocol;

namespace Rhisis.Protocol.Packets.Client.World.Party
{
    public class PartyChangeItemModePacket : IPacketDeserializer
    {

        /// <summary>
        /// Gets the player id.
        /// </summary>
        public uint PlayerId { get; private set; }

        /// <summary>
        /// Gets the item mode.
        /// </summary>
        public int ItemMode { get; private set; }

        /// <inheritdoc />
        public void Deserialize(IFFPacket packet)
        {
            PlayerId = packet.ReadUInt32();
            ItemMode = packet.ReadInt32();
        }
    }
}