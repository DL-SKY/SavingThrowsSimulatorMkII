using Modules.DataBase.Custom.Properties;
using Modules.DataBase.Properties;
using UnityEngine;

namespace Modules.DataBase.Providers
{
    public abstract class PropertyProvider : MonoBehaviour
    {
        public abstract PropertyData GetPropertyData(PropertyType type, string text);

        public T DeserializePropertyByText<T>(string text) where T : PropertyData
        {
            return JsonUtility.FromJson<T>(text);
        }
    }
}
