using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Rhisis.Core.Configuration;
using Rhisis.Game;
using Rhisis.Game.Common;
using Rhisis.Game.Entities;
using Rhisis.Game.Protocol.Packets.World.Client;
using Rhisis.Game.Protocol.Packets.World.Server.Snapshots;
using Rhisis.Game.Protocol.Packets.World.Server.Snapshots.Skills;
using Rhisis.Game.Resources;
using Rhisis.Game.Resources.Properties;
using Rhisis.Protocol;
using Rhisis.Protocol.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rhisis.WorldServer.Handlers;

[PacketHandler(PacketType.NPC_BUFF)]
internal sealed class BuffPangHandler : WorldPacketHandler


{
    private readonly ILogger<BuffPangHandler> _logger;
    private readonly IOptions<WorldChannelServerOptions> _worldServerOptions;

    public BuffPangHandler(ILogger<BuffPangHandler> logger, IOptions<WorldChannelServerOptions> worldServerOptions)
    {
        _logger = logger;
        _worldServerOptions = worldServerOptions;
    }
    public void Execute(BuffPangPacket packet)
    {
        if (packet.NpcKey == "")
        {
            throw new InvalidOperationException($"Invalid npc key '{packet.NpcKey}'.");
        }

        NpcBuffOptions buffOptions = _worldServerOptions.Value.NpcBuff.Get(packet.NpcKey);

        if (buffOptions is null)
        {
            _logger.LogWarning($"Failed to find npc buff configuration with key '{packet.NpcKey}' or default.");
            return;
        }

        if (Player.Level < buffOptions.Min || Player.Level > buffOptions.Max)
        {
            using var defineTextSnapshot = new DefinedTextSnapshot(Player, DefineText.TID_GAME_NPCBUFF_LEVELLIMIT,
                $"{buffOptions.Min}", $"{buffOptions.Max}", $"\"\"");
            Player.Send(defineTextSnapshot);
            return;
        }

        Npc buffer = Player.VisibleObjects.OfType<Npc>().FirstOrDefault(x => x.Name == packet.NpcKey);

        if (buffer is null)
        {
            throw new InvalidOperationException($"Failed to find NPC buffer with name: '{packet.NpcKey}'.");
        }

        foreach (var buff in buffOptions.Buffs)
        {
            int skillId = GameResources.Current.GetDefinedValue(buff.SkillId);
            SkillProperties skillProperties = GameResources.Current.Skills.Get(skillId);

            if (skillProperties is null)
            {
                continue;
            }

            int buffLevel = Math.Clamp(buff.Level, 1, skillProperties.MaxLevel);
            SkillLevelProperties skillLevelData = skillProperties.SkillLevels.GetValueOrDefault(buffLevel);

            if (skillLevelData is null)
            {
                _logger.LogWarning($"Cannot find skill level data for skill: {skillProperties.Name} and level {buffLevel}");
                continue;
            }

            var attributes = new Dictionary<DefineAttributes, int>();

            if (skillLevelData.DestParam1 > 0)
            {
                attributes.Add(skillLevelData.DestParam1, skillLevelData.DestParam1Value);
            }
            if (skillLevelData.DestParam2 > 0)
            {
                attributes.Add(skillLevelData.DestParam2, skillLevelData.DestParam2Value);
            }

            var buffSkill = new BuffSkill(Player, attributes, skillProperties, buffLevel)
            {
                RemainingTime = buff.Time * 1000
            };

            Skill skill = new Skill(skillProperties, Player, buffLevel);

            skill.Use(Player);

            using var snapshot = new DoApplyUseSkillSnapshot(Player, (uint)Player.Id, skillProperties.Id, buffLevel);
            Player.Send(snapshot);
            Player.SendToVisible(snapshot);
        }

    }
}
