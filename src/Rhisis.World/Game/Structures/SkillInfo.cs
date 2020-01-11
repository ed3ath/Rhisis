﻿using Rhisis.Core.Structures.Game;
using Rhisis.Network.Packets;
using Sylver.Network.Data;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Rhisis.World.Game.Structures
{
    [DebuggerDisplay("{Data.Name} Lv. {Level}")]
    public class SkillInfo : IEquatable<SkillInfo>, IPacketSerializer
    {
        /// <summary>
        /// Gets the skill id.
        /// </summary>
        public int SkillId { get; }

        /// <summary>
        /// Gets the character id owner of this skill.
        /// </summary>
        public int CharacterId { get; }

        /// <summary>
        /// Gets the skill database id.
        /// </summary>
        public int? DatabaseId { get; }

        /// <summary>
        /// Gets the skill data.
        /// </summary>
        public SkillData Data { get; }

        /// <summary>
        /// Gets the skill level.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Creates a new <see cref="SkillInfo"/> instance.
        /// </summary>
        /// <param name="skillId">Skill id.</param>
        /// <param name="characterId">Character Id.</param>
        /// <param name="skillData">Skill data.</param>
        /// <param name="databaseId">Database id.</param>
        public SkillInfo(int skillId, int characterId, SkillData skillData, int? databaseId = default)
        {
            this.SkillId = skillId;
            this.CharacterId = characterId;
            this.Data = skillData;
            this.DatabaseId = databaseId;
        }

        /// <summary>
        /// Compares two <see cref="SkillInfo"/> instances.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals([AllowNull] SkillInfo other) => SkillId == other?.SkillId && CharacterId == other?.CharacterId;

        /// <inheritdoc />
        public void Serialize(INetPacketStream packet)
        {
            packet.Write(SkillId);
            packet.Write(Level);
        }
    }
}