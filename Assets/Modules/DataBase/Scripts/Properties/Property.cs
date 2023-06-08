using Modules.DataBase.Custom.Properties;
using System;

namespace Modules.DataBase.Properties
{
    [Serializable]
    public class Property
    {
        public PropertyType Type;
        public string SerializedData;
        public PropertyData Data;
    }
}
