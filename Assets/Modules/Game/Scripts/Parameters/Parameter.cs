using Modules.Game.Enums;
using System;

namespace Modules.Game.Parameters
{
    [Serializable]
    public class Parameter
    {
        public ParameterType Type;
        public int Value;


        public override string ToString()
        {
            return $"({Type}: {Value})";
        }
    }
}
