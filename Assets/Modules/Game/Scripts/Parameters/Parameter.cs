using Modules.Game.Enums;
using System;

namespace Modules.Game.Parameters
{
    [Serializable]
    public class Parameter
    {
        public string Tag;
        public int Value;

        public ParameterType Type => GetParameterType();
        private ParameterType _type = ParameterType.NA;


        public override string ToString()
        {
            return $"({Type}: {Value})";
        }


        private ParameterType GetParameterType()
        {
            if (_type == ParameterType.NA)
                Enum.TryParse(Tag, out _type);

            return _type;
        }
    }
}
