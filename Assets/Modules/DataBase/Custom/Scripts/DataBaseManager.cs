using Modules.DataBase.Custom.Datas;
using Modules.DataBase.Custom.Datas.Events;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Modules.Custom.DataBase
{
    public class DataBaseManager : Modules.DataBase.DataBaseManager
    {
        public Dictionary<string, RaceData> Races = new Dictionary<string, RaceData>();

        public Dictionary<string, ClassData> Classes = new Dictionary<string, ClassData>();
        
        public Dictionary<string, EventData> Events = new Dictionary<string, EventData>();
        public Dictionary<string, EnemySettings> Enemies = new Dictionary<string, EnemySettings>();
        public Dictionary<string, TrapSettings> Traps = new Dictionary<string, TrapSettings>();
        public Dictionary<string, ChestSettings> Chests = new Dictionary<string, ChestSettings>();        
        public Dictionary<string, NpcSettings> Npcs = new Dictionary<string, NpcSettings>();


        public override void Init(Action completedCallback, Action<int> failedCallback)
        {
            _completedCallback = completedCallback;
            _failedCallback = failedCallback;

            LoadDataBase();
        }


        private void LoadDataBase()
        {
            LoadRaces();
            LoadClasses();
            
            LoadEvents();
            LoadEventsSettings();

            _completedCallback?.Invoke();
        }        

        private void LoadRaces()
        {
            var assets = Resources.LoadAll<TextAsset>(Path.Combine(_databasePath, "Races"));
            FillDictionary(Races, assets);
        }

        private void LoadClasses()
        {
            var assets = Resources.LoadAll<TextAsset>(Path.Combine(_databasePath, "Classes"));
            FillDictionary(Classes, assets);
            foreach (var race in Classes)
                race.Value.Initialize();
        }

        private void LoadEvents()
        {
            var assets = Resources.LoadAll<TextAsset>(Path.Combine(_databasePath, "Events"));
            FillDictionary(Events, assets);
            //foreach (var e in Events)
            //    FillProperty(e.Value.Content);
        }

        private void LoadEventsSettings()
        {
            var assets = Resources.LoadAll<TextAsset>(Path.Combine(_databasePath, "EventsEnemies"));
            FillDictionary(Enemies, assets);

            assets = Resources.LoadAll<TextAsset>(Path.Combine(_databasePath, "EventsTraps"));
            FillDictionary(Traps, assets);

            assets = Resources.LoadAll<TextAsset>(Path.Combine(_databasePath, "EventsChests"));
            FillDictionary(Chests, assets);

            assets = Resources.LoadAll<TextAsset>(Path.Combine(_databasePath, "EventsNpcs"));
            FillDictionary(Npcs, assets);
        }
    }
}
