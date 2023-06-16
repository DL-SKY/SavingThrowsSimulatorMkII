using Modules.Game.Actions.Data;
using System;
using System.Collections.Generic;

namespace Modules.Game.Custom.Actions.Data
{
    [Serializable]
    public class DamageActionData : AbstractActionData
    {
        public List<string> Tags;
        public int Damage;
    }
}
