using Modules.Game.Actions.Data;
using Modules.Game.Context;
using Modules.Game.Custom.State.GameState;
using System;

namespace Modules.Game.Custom.Actions
{
    public class NextTurnAction : Game.Actions.Action
    {
        public NextTurnAction(ActionData data) : base(data)
        { 
        
        }

        public override void Execute(IContext context)
        {
            var state = context.States[typeof(GameState)] as GameState;
            state.NextTurn();
        }

        public override bool Validate(IContext context)
        {
            return context.States.ContainsKey(typeof(GameState));
        }
    }
}
