using System;

namespace Modules.Game.Enums
{
    [Serializable]
    public enum ParameterType
    {
        /// <summary>
        /// Используется для обозначения, что подразумевается MainParameter класса
        /// </summary>
        //Абстракция "Основная боевая характеристика
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
