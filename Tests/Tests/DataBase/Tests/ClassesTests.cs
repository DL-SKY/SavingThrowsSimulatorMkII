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
        public void TagTest()
        {
            Init();

            foreach (var cl in _classes)
            {
                //Корректный тег - парсится в перечисление
                Assert.IsTrue(Enum.TryParse<ParameterType>(cl.Tag, out var tag), $"File {cl.Id} has invalid main parameter Tag \"{cl.Tag}\"!");

                //Тип является допустимой основной характеристикой
                Assert.IsTrue( cl.MainParameter == ParameterType.Strenght
                            || cl.MainParameter == ParameterType.Dexterity
                            || cl.MainParameter == ParameterType.Magic, 
                            $"File {cl.Id}");
            }
        }

        [TestMethod]
        public void BonusTest()
        {
            Init();

            foreach (var cl in _classes)
            {
                var levels = new HashSet<int>();

                foreach (var level in cl.Bonus)
                {
                    //Отсутствие повторного уровень
                    Assert.IsFalse(levels.Contains(level.Level), $"File {cl.Id} has double Level: {level.Level}!");
                    levels.Add(level.Level);

                    //Не пустое значение бонусов
                    Assert.IsTrue(level.Bonus != null && level.Bonus.Length > 0, $"File {cl.Id} has empty Bonus!");

                    foreach (var bonus in level.Bonus)
                    {
                        //Корректность типа
                        Assert.IsTrue(Enum.TryParse<ParameterType>(bonus.Tag, out var type), $"File {cl.Id} has invalid Bonus Tag: \"{bonus.Tag}\" in Level: {level.Level}");

                        //Нет повторение бонуса
                        Assert.IsTrue(level.Bonus.Count(x => x.Type == bonus.Type) == 1, $"File {cl.Id} has double Bonus Type \"{bonus.Type}\"");
                    }
                }

                //Заполненность интервала уровней
                for (int i = levels.Min(); i <= levels.Max(); i++)
                    Assert.IsTrue(levels.Contains(i), $"File {cl.Id} has not level: {i}!");
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
