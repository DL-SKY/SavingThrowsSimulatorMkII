using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modules.DataBase.Datas;
using Modules.Game.Actions.Data;
using System.IO;
using System.Text.Json;

namespace Tests.DataBase
{
    [TestClass]
    public class DataBaseHelper
    {
        public const string DATA_BASE_PATH = @"..\..\..\..\..\Assets\Modules\DataBase\Custom\Resources\DataBase\";

        public static T Deserialize<T>(string jsonString) where T : DataBaseData
        {
            return DeserializeFromString<T>(jsonString);
        }

        public static T DeserializeAction<T>(string jsonString) where T : AbstractActionData
        {
            return DeserializeFromString<T>(jsonString);
        }

        public static string[] FindAllJsonFiles(string localPath)
        {
            return Directory.GetFiles(Directory.GetCurrentDirectory() + DATA_BASE_PATH + localPath, "*.json");
        }


        private static T DeserializeFromString<T>(string jsonString)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                IncludeFields = true,
            };

            return JsonSerializer.Deserialize<T>(jsonString, options);
        }
    }
}
