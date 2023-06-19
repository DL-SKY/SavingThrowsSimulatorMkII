using Modules.Game.Custom.Context;
using System;

namespace Modules.Core.Initializing.Subtasks
{
    public class LoadContextTask : Subtask
    {
        public override int Weight => _weight;
        private int _weight;

        public LoadContextTask(int weight = 10)
        {
            _weight = weight;
        }

        public override void Run()
        {
            //TODO: имплементация
            throw new NotImplementedException();

            var context = new Context();
            context.Init();
        }
    }
}
