using Rhisis.Game.Entities;
using Rhisis.Protocol;

namespace Rhisis.Game.Protocol.Packets.World.Server.Snapshots.Skills;

public class DoApplyUseSkillSnapshot : FFSnapshot
{
    private Npc buffer;
    private object id1;
    private int id2;
    private int buffLevel;

    public DoApplyUseSkillSnapshot(Mover mover, uint targetId, int skillId, int skillLevel)
        : base(SnapshotType.DOAPPLYUSESKILL, mover.ObjectId)
    {
        WriteUInt32(targetId);
        WriteInt32(skillId);
        WriteInt32(skillLevel);
    }

    public DoApplyUseSkillSnapshot(Npc buffer, object id1, int id2, int buffLevel)
    {
        this.buffer = buffer;
        this.id1 = id1;
        this.id2 = id2;
        this.buffLevel = buffLevel;
    }
}
