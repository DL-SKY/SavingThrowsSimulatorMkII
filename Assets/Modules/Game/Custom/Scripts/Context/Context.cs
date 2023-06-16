using Modules.Game.Context;
using Modules.Game.State;
using System;
using System.Collections.Generic;

namespace Modules.Game.Custom.Context
{
    public class Context : IContext
    {
        public Dictionary<Type, IState> States => _states;
        private Dictionary<Type, IState> _states = new Dictionary<Type, IState>();
    }
}

