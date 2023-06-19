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
    public class ClassesTests
    {
        private const string PATH = @"Classes\";

        private List<ClassData> _classes;


        [TestMethod]
        public void VisualTest()
        {
            Init();

            //TODO: ClassesTests.VisualTest()
        }

        [TestMethod]
        public void BonusTest()
        {
            Init();

            foreach (var cl in _classes)
            {
                foreach (var level in cl.Bonus)
                {
                    foreach (var bonus in level.Bonus)
                    {
                        //Корректность типа
                        Assert.IsTrue(Enum.TryParse<ParameterType>(bonus.Tag, out var type), $"File {cl.Id} has invalid Bonus Tag: \"{bonus.Tag}\" in Level: {level.Level}");

                        //Повторение бонуса
                        //Assert.IsTrue(race.Bonus.Count(x => x.Type == bonus.Type) == 1, $"File {race.Id} has double Bonus Type \"{bonus.Type}\"");
                    }
                }
            }
        }


        private void Init()
        {
            _classes = new List<ClassData>();

            foreach (var path in DataBaseHelper.FindAllJsonFiles(PATH))
            {
                var jsonString = File.ReadAllText(path);
                var data = DataBaseHelper.Deserialize<ClassData>(jsonString);
                data.Id = Path.GetFileName(path);
                _classes.Add(data);
            }
        }
    }
}
