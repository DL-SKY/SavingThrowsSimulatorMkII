using Modules.DataBase.Datas;
using Modules.Game.Enums;
using Modules.Game.Parameters;
using System;
using System.Collections.Generic;

namespace Modules.DataBase.Custom.Datas
{
    [Serializable]
    public class ClassData : DataBaseData
    {
        public string Tag;
        public ParameterType MainParameter => GetMainParameter();
        private ParameterType _mainParameter = ParameterType.NA;

        public DiceType HitDice;
        public LevelParameters[] Bonus;

        public Dictionary<int, Parameter[]> BonusDic;

        public VisualData Visual;


        public void Initialize()
        {
            FillBonusDictionary();
        }


        private void FillBonusDictionary()
        {
            BonusDic = new Dictionary<int, Parameter[]>();
            foreach (var bonus in Bonus)
                if (!BonusDic.ContainsKey(bonus.Level))
                    BonusDic.Add(bonus.Level, bonus.Bonus);
        }

        private ParameterType GetMainParameter()
        {
            if (_mainParameter == ParameterType.NA)
                Enum.TryParse(Tag, out _mainParameter);

            return _mainParameter;
        }
    }
}

namespace Modules.Game.Enums
{
    [Serializable]
    public enum DiceType
    {
        d4 = 4,
        d6 = 6,
        d8 = 8,
        d10 = 10,
        d12 = 12,
        d20 = 20,
        d100 = 100,
    }
}

namespace Modules.Game.Parameters
{
    [Serializable]
    public class LevelParameters
    {
        public int Level;
        public Parameter[] Bonus;
    }
}
