using Modules.DataBase.Datas;
using Modules.Game.Actions.Data;
using Modules.Game.Enums;
using Modules.Game.SavingThrows;
using System;

namespace Modules.DataBase.Custom.Datas
{
    [Serializable]
    public class EventData : DataBaseData
    {
        public string Tag;
        public EventType Type => GetEventType();
        private EventType _type = EventType.NA;

        public string SettingsId;


        private EventType GetEventType()
        {
            if (_type == EventType.NA)
                Enum.TryParse(Tag, out _type);

            return _type;
        }
    }
}

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

namespace Modules.DataBase.Custom.Datas.Events
{
    [Serializable]
    public class EnemySettings : DataBaseData
    {
        public int ChallengeRating;
        public string[] Tags;

        public string Tag;
        public ParameterType MainParameter => GetMainParameter();
        private ParameterType _mainParameter = ParameterType.NA;

        public SavingThrow[] SavingThrows;
        public SavingThrowResult Result;

        public VisualData Visual;


        private ParameterType GetMainParameter()
        {
            if (_mainParameter == ParameterType.NA)
                Enum.TryParse(Tag, out _mainParameter);

            return _mainParameter;
        }
    }
}

namespace Modules.Game.SavingThrows
{
    [Serializable]
    public class SavingThrow
    {
        public string Tag;
        public ParameterType MainParameter => GetMainParameter();
        private ParameterType _mainParameter = ParameterType.NA;

        public int Difficulty;


        private ParameterType GetMainParameter()
        {
            if (_mainParameter == ParameterType.NA)
                Enum.TryParse(Tag, out _mainParameter);

            return _mainParameter;
        }
    }
}

namespace Modules.Game.SavingThrows
{
    [Serializable]
    public class SavingThrowResult
    {
        public ActionData[] SuccessActions;
        public ActionData[] FailureActions;
    }
}

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
