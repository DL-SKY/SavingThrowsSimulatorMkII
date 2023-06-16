using System;

namespace Modules.Game.Enums
{
    [Serializable]
    public enum EventType
    {
        NA = -1,

        Enemy = 1,
        Trap = 2,
        
        Chest = 101,

        Npc = 201,
    }
}
