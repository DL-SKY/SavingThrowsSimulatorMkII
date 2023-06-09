using Modules.Game.Actions;
using System;

namespace Modules.Game.SavingThrows
{
    [Serializable]
    public class SavingThrowResult
    {
        public ActionData[] SuccessActions;
        public ActionData[] FailureActions;
    }
}
