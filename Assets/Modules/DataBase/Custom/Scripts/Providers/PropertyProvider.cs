using Modules.DataBase.Custom.Properties;
using Modules.DataBase.Properties;
using System;

namespace Modules.DataBase.Custom.Providers
{
    public class PropertyProvider : Modules.DataBase.Providers.PropertyProvider
    {
        public override PropertyData GetPropertyData(PropertyType type, string text)
        {
            switch (type)
            {
                //Events
                //case PropertyType.EventEnemy:
                //    return DeserializePropertyByText<EnemyPropertyData>(text);
                //case PropertyType.EventTrap:
                //    return DeserializePropertyByText<TrapPropertyData>(text);
                //case PropertyType.EventChest:
                //    return DeserializePropertyByText<ChestPropertyData>(text);
                //case PropertyType.EventNpc:
                //    return DeserializePropertyByText<NpcPropertyData>(text);                

                default:
                    throw new Exception($"Unexpected property type {type}!");
            }
        }
    }
}
