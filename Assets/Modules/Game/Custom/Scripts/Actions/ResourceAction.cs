using Modules.Game.Actions.Data;
using Modules.Game.Context;
using Modules.Game.Custom.Actions.Data;
using System;

namespace Modules.Game.Custom.Actions
{
    public class ResourceAction : Game.Actions.Action
    {
        private ResourceActionData _data;


        public ResourceAction(ActionData data) : base(data)
        {
            _data = GetData<ResourceActionData>(data.SerializedData);
        }


        public override void Execute(IContext context)
        {
            //TODO: доделать ResourceAction.Execute()
            throw new NotImplementedException();
        }

        public override bool Validate(IContext context)
        {
            //TODO: доделать ResourceAction.Validate()
            throw new NotImplementedException();
        }
    }
}
