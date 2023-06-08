using Modules.Game.Enums;
using System;

namespace Modules.Game.SavingThrows
{
    [Serializable]
    public class SavingThrow
    {
        public ParameterType Parameter;
        public int Difficulty;
    }
}
