using Modules.Game.Enums;
using System;

namespace Modules.Game.SavingThrows
{
    [Serializable]
    public class SavingThrow
    {
        public string Tag;
        public ParameterType MainParameter => GetMainParameter();
        private ParameterType _mainParameter = ParameterType.NA;

        public int Difficulty;


        private ParameterType GetMainParameter()
        {
            if (_mainParameter == ParameterType.NA)
                Enum.TryParse(Tag, out _mainParameter);

            return _mainParameter;
        }
    }
}
