using Modules.DataBase.Datas;
using System;

namespace Modules.DataBase.Custom.Datas
{
    [Obsolete]
    [Serializable]
    public class GameplayData : DataBaseData
    {
        /// <summary>
        /// Speed points per action
        /// </summary>
        public int StepCost;
    }
}
