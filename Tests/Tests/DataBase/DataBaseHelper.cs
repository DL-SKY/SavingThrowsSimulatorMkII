using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modules.DataBase.Custom.Datas;
using Modules.DataBase.Datas;
using System.IO;
using System.Text.Json;

namespace Tests.DataBase
{
    [TestClass]
    public class DataBaseHelper
    {
        public const string DATA_BASE_PATH = @"..\..\..\..\..\Assets\Modules\DataBase\Custom\Resources\DataBase\";

        [TestMethod]
        public void Ggg()
        {
                              //@"D:\GIT\SavingThrowsSimulatorMkII\Tests\Tests\bin\Debug\"
            //string fileName = @"D:\GIT\SavingThrowsSimulatorMkII\Assets\Modules\DataBase\Custom\Resources\DataBase\Races\Human.json";
            string fileName = DATA_BASE_PATH + @"Races\Human.json";
            string jsonString = File.ReadAllText(Directory.GetCurrentDirectory() + fileName);
            

            RaceData person = Deserialize<RaceData>(jsonString);

            Assert.IsTrue(false, $"{person?.Id ?? "ID NULL"} : Bonus: {person?.Bonus?.Length ?? -1} : {person.Bonus[0]} : {person.Bonus[1]} : { person.Bonus[2]}");
            //Assert.IsTrue(false, $"GetCurrentDirectory: {Directory.GetCurrentDirectory()}");
        }

        public static T Deserialize<T>(string jsonString) where T : DataBaseData
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                IncludeFields = true,
            };

            return JsonSerializer.Deserialize<T>(jsonString, options);
        }
    }







    //[TestClass]
    //public class DataBaseTests
    //{
    //    [TestMethod]
    //    public void Ggg()
    //    {
    //        //ЕЩВЩ

    //        //var assets = UnityEngine.Resources.LoadAll<TextAsset>(Path.Combine(_databasePath, "Races"));
    //        //FillDictionary(Races, assets);

    //        //var f = JsonUtility.FromJson<T>(asset.text);

    //        Assert.IsTrue(false, "Error FALSE!!!");
    //    }
    //}
}
