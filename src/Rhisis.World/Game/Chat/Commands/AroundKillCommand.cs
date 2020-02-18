using Microsoft.Extensions.Logging;
using Rhisis.Core.Common;
using Rhisis.World.Game.Entities;
using Rhisis.World.Systems.PlayerData;
using Rhisis.World.Systems.Battle;
using Rhisis.Core.Data;
using Rhisis.World.Systems.Follow;

namespace Rhisis.World.Game.Chat
{
    [ChatCommand("/aroundkill", AuthorityType.GameMaster)]
    [ChatCommand("/ak", AuthorityType.GameMaster)]
    public class AroundKillChatCommand : IChatCommand
    {
        private readonly ILogger<AroundKillChatCommand> _logger;
        private readonly IPlayerDataSystem _playerDataSystem;
        private readonly IBattleSystem _battleSystem;
        private readonly IFollowSystem _followSystem;

        /// <summary>
        /// Creates a new <see cref="AroundKillChatCommand"/> instance.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="playerDataSystem">Player data system.</param>
        /// <param name="battlePacketFactory">Battle packet factory.</param>
        public AroundKillChatCommand(ILogger<AroundKillChatCommand> logger, IPlayerDataSystem playerDataSystem, IBattleSystem battleSystem,IFollowSystem followSystem)
        {
            _logger = logger;
            _playerDataSystem = playerDataSystem;
            _battleSystem = battleSystem;
            _followSystem = followSystem;
        }

        /// <inheritdoc />
        public void Execute(IPlayerEntity player, object[] parameters)
        {
            ObjectMessageType defaultAttackType = ObjectMessageType.OBJMSG_ATK1;
            float defaultAttackSpeed = 1.0f;

            for (int i = 0; i < player.Object.Entities.Count; i++)
            {
                if (player.Object.Entities[i] is IMonsterEntity monsterEntity) 
                {
                    if (!monsterEntity.Follow.IsFollowing) {
                        _followSystem.Follow(monsterEntity, player);
                    }
                    _battleSystem.MeleeAttack(player, monsterEntity, defaultAttackType, defaultAttackSpeed);
                }
            }
        }
    }
}