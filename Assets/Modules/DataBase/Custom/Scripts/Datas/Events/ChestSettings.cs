using Modules.DataBase.Datas;
using Modules.Game.SavingThrows;
using System;

namespace Modules.DataBase.Custom.Datas.Events
{
    [Serializable]
    public class ChestSettings : DataBaseData
    {
        public SavingThrow[] SavingThrows;

        public VisualData Visual;
    }
}
