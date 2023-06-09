using Modules.DataBase.Datas;
using Modules.Game.Enums;
using Modules.Game.SavingThrows;
using System;

namespace Modules.DataBase.Custom.Datas.Events
{
    [Serializable]
    public class EnemySettings : DataBaseData
    {
        public int ChallengeRating;
        public string[] Tags;
        public ParameterType MainParameter;        

        public SavingThrow[] SavingThrows;
        public SavingThrowResult Result;

        public VisualData Visual;
    }
}
