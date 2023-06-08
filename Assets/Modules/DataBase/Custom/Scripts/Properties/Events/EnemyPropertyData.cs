using Modules.DataBase.Properties;
using Modules.Game.Enums;
using Modules.Game.SavingThrows;
using System;

namespace Modules.DataBase.Custom.Properties.Events
{
    [Serializable]
    public class EnemyPropertyData : PropertyData
    {
        public ParameterType MainParameter;
        public EnemyType Type;

        public SavingThrow[] SavingThrows;
        public SavingThrowResult Result;
    }
}
