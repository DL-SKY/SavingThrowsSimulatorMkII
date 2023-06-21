using Modules.Game.Actions.Data;
using Modules.Game.Custom.Actions.Data;
using Modules.Game.Enums;
using System;
using System.Collections.Generic;

namespace Tests.DataBase.Tests
{
    public class ActionsTester
    {
        public bool Check(ActionData data, out string error)
        {
            error = "";

            //Корректный тег - парсится в перечисление
            if (!Enum.TryParse<ActionType>(data.Tag, out var tag))
            {
                error = $"Invalid Action Tag \"{data.Tag}\"!";
                return false;
            }

            //Индивидуальные проверки
            switch (data.Type)
            {
                case ActionType.Resource:
                    var resourceData = DataBaseHelper.DeserializeAction<ResourceActionData>(data.SerializedData);
                    //Десериализация
                    if (resourceData == null)
                    {
                        error = $"ResourceActionData is NULL! SerializedData: \"{data.SerializedData}\"";
                        return false;
                    }
                    //TODO: test for ActionType.Resource
                    break;
                case ActionType.Damage:
                    var damageData = DataBaseHelper.DeserializeAction<DamageActionData>(data.SerializedData);
                    //Десериализация
                    if (damageData == null)
                    {
                        error = $"DamageActionData is NULL! SerializedData: \"{data.SerializedData}\"";
                        return false;
                    }
                    //Урон должен быть больше 0
                    if (damageData.Damage <= 0)
                    {
                        error = $"Damage must be greater than zero! Damage: \"{data.SerializedData}\"";
                        return false;
                    }
                    break;

                default:
                    if (!string.IsNullOrEmpty(data.SerializedData))
                    {
                        error = $"For Type \"{data.Type}\" field \"SerializedData\" should be empty!";
                        return false;
                    }
                    break;
            }

            return true;
        }
    }
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

namespace Modules.Game.Custom.Actions.Data
{
    [Serializable]
    public class DamageActionData : AbstractActionData
    {
        public List<string> Tags;
        public int Damage;
    }
}

namespace Modules.Game.Custom.Actions.Data
{
    [Serializable]
    public class ResourceActionData : AbstractActionData
    {

    }
}
