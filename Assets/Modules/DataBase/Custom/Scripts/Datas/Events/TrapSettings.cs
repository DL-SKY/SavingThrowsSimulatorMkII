using Modules.DataBase.Datas;
using Modules.Game.SavingThrows;
using System;

namespace Modules.DataBase.Custom.Datas.Events
{
    [Serializable]
    public class TrapSettings : DataBaseData
    {
        public int ChallengeRating;

        public SavingThrow[] SavingThrows;

        public VisualData Visual;
    }
}
