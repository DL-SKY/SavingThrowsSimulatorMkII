using System;

namespace Modules.Game.Enums
{
    [Serializable]
    public enum ActionType
    {
        NA = -1,

        Resource = 0,
        Damage,
        NextTurn,
    }
}
