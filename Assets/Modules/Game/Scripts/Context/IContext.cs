using Modules.Game.State;
using System;
using System.Collections.Generic;

namespace Modules.Game.Context
{
    public interface IContext
    {
        public Dictionary<Type, IState> States { get; }
    }
}
