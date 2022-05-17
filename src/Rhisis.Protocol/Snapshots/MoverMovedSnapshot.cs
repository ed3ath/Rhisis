﻿using Rhisis.Core.Structures;
using Rhisis.Abstractions.Entities;
using Rhisis.Game.Common;

namespace Rhisis.Protocol.Snapshots
{
    public class MoverMovedSnapshot : FFSnapshot
    {
        public MoverMovedSnapshot(IMover mover, Vector3 beginPosition, Vector3 destinationPosition, float angle, int state, int stateFlag, int motion, int motionEx, int loop, int motionOption, long tickCount)
            : base(SnapshotType.MOVERMOVED, mover.Id)
        {
            WriteSingle(beginPosition.X);
            WriteSingle(beginPosition.Y);
            WriteSingle(beginPosition.Z);
            WriteSingle(destinationPosition.X);
            WriteSingle(destinationPosition.Y);
            WriteSingle(destinationPosition.Z);
            WriteSingle(angle);

            if (mover is IPlayer player)
            {
                if (player.Mode.HasFlag(ModeType.TRANSPARENT_MODE))
                {
                    WriteInt32((int)ObjectState.OBJSTA_STAND);
                }
                else
                {
                    WriteInt32(state);
                }
            }
            else
            {
                WriteInt32(state);
            }

            WriteInt32(stateFlag);
            WriteInt32(motion);
            WriteInt32(motionEx);
            WriteInt32(loop);
            WriteInt32(motionOption);
            WriteInt64(tickCount);
        }
    }
}