using Modules.DataBase.Datas;
using Modules.Game.Parameters;
using System;

namespace Modules.DataBase.Custom.Datas
{
    [Serializable]
    public class RaceData : DataBaseData
    {
        public Parameter[] Bonus; 
        public VisualData Visual;
    }
}
