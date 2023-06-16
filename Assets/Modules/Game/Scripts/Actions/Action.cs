using Modules.Game.Actions.Data;
using Modules.Game.Context;
using UnityEngine;

namespace Modules.Game.Actions
{
    public abstract class Action
    {
        protected Action(ActionData data) { }

        public abstract void Execute(IContext context);
        public abstract bool Validate(IContext context);

        protected T GetData<T>(string text) where T : AbstractActionData
        {
            return JsonUtility.FromJson<T>(text);
        }
    }
}
