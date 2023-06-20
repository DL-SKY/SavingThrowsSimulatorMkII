using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modules.DataBase.Custom.Datas;
using Modules.Game.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tests.DataBase.Tests
{
    [TestClass]
    public class RacesTests
    {
        private const string PATH = @"Races\";

        private List<RaceData> _races;


        [TestMethod]
        public void VisualTest()
        {
            Init();

            //TODO: RacesTests.VisualTest()
        }

        [TestMethod]
        public void BonusTest()
        {
            Init();

            foreach (var race in _races)
            {
                //Не пустое значение бонусов
                Assert.IsTrue(race.Bonus != null && race.Bonus.Length > 0, $"File {race.Id} has empty Bonus!");

                foreach (var bonus in race.Bonus)
                {
                    //Корректность типа бонуса
                    Assert.IsTrue(Enum.TryParse<ParameterType>(bonus.Tag, out var type), $"File {race.Id} has invalid Bonus Tag: \"{bonus.Tag}\"!");

                    //Нет повторение бонуса
                    Assert.IsTrue(race.Bonus.Count(x => x.Type == bonus.Type) == 1, $"File {race.Id} has double Bonus Type \"{bonus.Type}\"!");
                }
            }
        }


        private void Init()
        {
            _races = new List<RaceData>();

            foreach (var path in DataBaseHelper.FindAllJsonFiles(PATH))
            {
                var jsonString = File.ReadAllText(path);
                var data = DataBaseHelper.Deserialize<RaceData>(jsonString);
                data.Id = Path.GetFileNameWithoutExtension(path);
                _races.Add(data);
            }
        }
    }
}
