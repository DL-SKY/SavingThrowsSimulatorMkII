using Modules.DataBase.Datas;
using Modules.Game.Enums;
using Modules.Game.Parameters;
using System;

namespace Modules.DataBase.Custom.Datas
{
    [Serializable]
    public class RaceData : DataBaseData
    {
        public Parameter[] Bonus;
        public VisualData Visual;
    }
}

namespace Modules.DataBase.Datas
{
    public abstract class DataBaseData
    {
        public string Id;
    }
}

namespace Modules.Game.Parameters
{
    [Serializable]
    public class Parameter
    {
        public string Tag;
        public int Value;

        public ParameterType Type => GetParameterType();
        private ParameterType _type = ParameterType.NA;


        public override string ToString()
        {
            return $"({Type}: {Value})";
        }


        private ParameterType GetParameterType()
        {
            if (_type == ParameterType.NA)
                Enum.TryParse(Tag, out _type);

            return _type;
        }
    }
}

namespace Modules.DataBase.Custom.Datas
{
    [Serializable]
    public class VisualData
    {
        public string Name;
        public string Description;
    }
}

namespace Modules.Game.Enums
{
    [Serializable]
    public enum ParameterType
    {
        NA = -1,

        /// <summary>
        /// Используется для обозначения, что подразумевается MainParameter класса. Абстракция "Основная боевая характеристика
        /// </summary>
        Main = 0,

        //Сила
        Strenght = 1,
        //Ловкость
        Dexterity = 2,
        //Магия
        Magic = 3,
        //Внимание
        Perception = 4,

        //Ячейки/слоты персонажа и инвентаря
        Slot = 100,

        //Здоровье
        HitPoints = 500,
        MaxHitPoints = 501,
    }
}