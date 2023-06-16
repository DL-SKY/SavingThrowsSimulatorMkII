using Modules.Game.Actions.Data;
using Modules.Game.Context;
using Modules.Game.Custom.Actions.Data;
using Modules.Game.Custom.State.GameState;
using Modules.Game.Enums;
using System;

namespace Modules.Game.Custom.Actions
{
    public class DamageAction : Game.Actions.Action
    {
        private DamageActionData _data;


        public DamageAction(ActionData data) : base(data)
        {
            _data = GetData<DamageActionData>(data.SerializedData);
        }


        public override void Execute(IContext context)
        {
            var state = context.States[typeof(GameState)] as GameState;
            var oldHitPoints = state.Character.Parameters[ParameterType.HitPoints];
            var newHitPoints = Math.Max(0, oldHitPoints - GetDamage(state.Character));

            state.Character.Parameters[ParameterType.HitPoints] = newHitPoints;
            state.Character.SendChangeParameter(ParameterType.HitPoints, oldHitPoints, newHitPoints);
        }

        public override bool Validate(IContext context)
        {
            var isDataValid = _data != null;
            var isDamageValid = _data != null ? _data.Damage > 0 : false;
            var isStateValid = context.States.TryGetValue(typeof(GameState), out var state);
            var isHasParameter = (state as GameState).Character.Parameters.ContainsKey(ParameterType.HitPoints);

            return isDataValid && isDamageValid && isStateValid && isHasParameter;
        }


        private int GetDamage(Character character)
        {
            //TODO: подсчет урона с учетом тегов, уязвимостей, защиты и т.д.
            return _data.Damage;
        }
    }
}
