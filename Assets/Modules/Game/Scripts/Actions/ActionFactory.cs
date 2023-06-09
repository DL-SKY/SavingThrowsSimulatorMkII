using Modules.Game.Enums;
using System;

namespace Modules.Game.Actions
{
    public class ActionFactory
    {
        public Action Create(ActionData data)
        {
            switch (data.Type)
            {
                case ActionType.Resource:
                    //...
                case ActionType.Damage:
                    //...

                default:
                    throw new Exception($"Unknown action type {data.Type}!");
            }
        }
    }
}
