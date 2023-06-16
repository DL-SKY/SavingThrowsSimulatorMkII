using Modules.Game.Actions.Data;
using Modules.Game.Enums;
using System;

namespace Modules.Game.Custom.Actions
{
    public class ActionFactory
    {
        public Modules.Game.Actions.Action Create(ActionData data)
        {
            return data.Type switch
            {
                ActionType.Resource =>      new ResourceAction(data),
                ActionType.Damage =>        new DamageAction(data),
                ActionType.NextTurn =>      new NextTurnAction(data),

                _ => throw new Exception($"Unknown action type {data.Type}!")
            };
        }
    }
}
