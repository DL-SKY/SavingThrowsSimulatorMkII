using Modules.Game.Enums;
using System;

namespace Modules.Game.Actions.Data
{
    [Serializable]
    public class ActionData
    {
        public string Tag;
        public ActionType Type => GetActionType();
        private ActionType _type = ActionType.NA;

        public string SerializedData;


        private ActionType GetActionType()
        {
            if (_type == ActionType.NA)
                Enum.TryParse(Tag, out _type);

            return _type;
        }
    }

    public abstract class AbstractActionData { }
}
