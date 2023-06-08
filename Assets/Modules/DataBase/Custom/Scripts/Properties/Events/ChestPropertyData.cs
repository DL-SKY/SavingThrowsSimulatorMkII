using Modules.DataBase.Properties;
using Modules.Game.SavingThrows;
using System;

namespace Modules.DataBase.Custom.Properties.Events
{
    [Serializable]
    public class ChestPropertyData : PropertyData
    {
        public SavingThrow[] SavingThrows;
    }
}
