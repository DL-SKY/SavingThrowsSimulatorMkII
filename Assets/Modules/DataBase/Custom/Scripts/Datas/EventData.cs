using Modules.DataBase.Datas;
using Modules.Game.Enums;
using System;

namespace Modules.DataBase.Custom.Datas
{
    [Serializable]
    public class EventData : DataBaseData
    {
        public EventType Type;
        public string SettingsId;        
    }
}
