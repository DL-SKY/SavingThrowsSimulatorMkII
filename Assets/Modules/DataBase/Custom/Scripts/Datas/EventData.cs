using Modules.DataBase.Datas;
using Modules.DataBase.Properties;
using Modules.Game.Enums;
using System;

namespace Modules.DataBase.Custom.Datas
{
    [Serializable]
    public class EventData : DataBaseData
    {
        public EventType Type;
        public Property Content;

        public VisualData Visual;
    }
}
