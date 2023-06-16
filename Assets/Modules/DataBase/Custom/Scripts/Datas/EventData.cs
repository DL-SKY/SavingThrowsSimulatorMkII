using Modules.DataBase.Datas;
using Modules.Game.Enums;
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
                Enum.TryParse("Tag", out _type);

            return _type;
        }
    }
}
