using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modules.DataBase.Custom.Datas;
using Modules.DataBase.Custom.Datas.Events;
using Modules.Game.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tests.DataBase.Tests
{
    [TestClass]
    public class EventsTests
    {
        private const string EVENTS_PATH = @"Events\";

        private List<EventData> _events;

        [TestMethod]
        public void EventsTagTest()
        {
            InitEvents();
            InitEnemies();

            foreach (var e in _events)
            {
                //Корректный тег - парсится в перечисление
                Assert.IsTrue(Enum.TryParse<EventType>(e.Tag, out var tag), $"File {e.Id} has invalid Tag \"{e.Tag}\"!");

                //Проверки на соответствие пар Type-SettingsId
                switch (e.Type)
                {
                    case EventType.Enemy:
                        Assert.IsTrue(_enemies.FirstOrDefault(x => x.Id.Equals(e.SettingsId)) != null, $"File {e.Id} has invalid SettingsId \"{e.SettingsId}\" - not found enemies settings!");
                        break;

                    default:
                        throw new Exception($"File {e.Id} has not supported Type: {e.Type}!");
                }
            }
        }

        private void InitEvents()
        {
            _events = new List<EventData>();

            foreach (var path in DataBaseHelper.FindAllJsonFiles(EVENTS_PATH))
            {
                var jsonString = File.ReadAllText(path);
                var data = DataBaseHelper.Deserialize<EventData>(jsonString);
                data.Id = Path.GetFileNameWithoutExtension(path);
                _events.Add(data);
            }
        }


        private const string ENEMIES_PATH = @"EventsEnemies\";

        private List<EnemySettings> _enemies;

        //TODO: Тесты для Enemies
        //...

        private void InitEnemies()
        {
            _enemies = new List<EnemySettings>();

            foreach (var path in DataBaseHelper.FindAllJsonFiles(ENEMIES_PATH))
            {
                var jsonString = File.ReadAllText(path);
                var data = DataBaseHelper.Deserialize<EnemySettings>(jsonString);
                data.Id = Path.GetFileNameWithoutExtension(path);
                _enemies.Add(data);
            }
        }
    }
}
