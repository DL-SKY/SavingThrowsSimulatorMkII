using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modules.DataBase.Custom.Datas;
using Modules.DataBase.Custom.Datas.Events;
using Modules.Game.Actions.Data;
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

        [TestMethod]
        public void EnemiesVisualTest()
        {
            InitEnemies();

            //TODO: EnemiesVisualTest()
        }

        [TestMethod]
        public void EnemiesTagTest()
        {
            InitEnemies();

            foreach (var enemy in _enemies)
            {
                //Корректный тег - парсится в перечисление
                Assert.IsTrue(Enum.TryParse<ParameterType>(enemy.Tag, out var tag), $"File {enemy.Id} has invalid main parameter Tag \"{enemy.Tag}\"!");

                //Тип является допустимой основной характеристикой
                Assert.IsTrue(enemy.MainParameter == ParameterType.Strenght
                            || enemy.MainParameter == ParameterType.Dexterity
                            || enemy.MainParameter == ParameterType.Magic,
                            $"File {enemy.Id} has incorrect MainParameter. \"{enemy.MainParameter}\" is not MainParameter!");
            }
        }

        [TestMethod]
        public void EnemiesSavingThrowsTest()
        {
            InitEnemies();

            foreach (var enemy in _enemies)
            {
                foreach (var savingThrow in enemy.SavingThrows)
                {
                    //Корректный тег - парсится в перечисление
                    Assert.IsTrue(Enum.TryParse<ParameterType>(savingThrow.Tag, out var tag), $"File {enemy.Id} has invalid Tag \"{savingThrow.Tag}\"!");

                    //Тип является допустимой для проверки характеристикой
                    Assert.IsTrue( savingThrow.MainParameter == ParameterType.Main
                                || savingThrow.MainParameter == ParameterType.Strenght
                                || savingThrow.MainParameter == ParameterType.Dexterity
                                || savingThrow.MainParameter == ParameterType.Magic
                                || savingThrow.MainParameter == ParameterType.Perception,
                                $"File {enemy.Id} has incorrect SavingThrow type: \"{savingThrow.MainParameter}\"!");

                    //Корректная сложность
                    Assert.IsTrue(savingThrow.Difficulty > 0, $"File {enemy.Id} has invalid Difficulty: {savingThrow.Difficulty}!");
                }
            }
        }

        [TestMethod]
        public void EnemiesSavingThrowResultTest()
        {
            InitEnemies();

            var tester = new ActionsTester();
            foreach (var enemy in _enemies)
            {
                var actions = new List<ActionData[]> { enemy.Result.SuccessActions, enemy.Result.FailureActions };

                foreach (var actionsPull in actions)
                    foreach (var action in actionsPull)
                    {
                        //Корректный экшен
                        Assert.IsTrue(tester.Check(action, out var error), $"File {enemy.Id} has actions error: {error}");
                    }

                //Наличие "финализатора" - команды NextTurn
                Assert.IsTrue( enemy.Result.SuccessActions.Any(x => x.Type == ActionType.NextTurn)
                            && enemy.Result.FailureActions.Any(x => x.Type == ActionType.NextTurn),
                            $"File {enemy.Id} has not Action with Type \"ActionType.NextTurn\"!");
            }
        }

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
