using Modules.Game.Enums;
using System;

namespace Modules.Game.Actions
{
    [Serializable]
    public class ActionData
    {
        public ActionType Type;
        public string SerializedData;
    }
}
