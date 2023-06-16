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
