using Modules.Game.Enums;
using System;
using System.Collections.Generic;

namespace Modules.Game.Custom.State.GameState
{
    public class Character
    {
        //public event Action<CharacterChangeType> OnChange;

        /// <summary>
        /// OnChangeParameter(ParameterType parameter, int oldValue, int newValue)
        /// </summary>
        public event Action<ParameterType, int, int> OnChangeParameter;



        public string Race { get; private set; }
        public string Class { get; private set; }
        public int Experience { get; private set; }
        public Dictionary<ParameterType, int> Parameters { get; private set; } = new Dictionary<ParameterType, int>();
        public Dictionary<string, Slot> Slots { get; private set; } = new Dictionary<string, Slot>();
        public List<Slot> Effects { get; private set; } = new List<Slot>();

        private Dictionary<ParameterType, int> _baseParameters = new Dictionary<ParameterType, int>();


        public Character(CharacterSave save)
        { 
            //TODO: доделать конструктор
            //...
        }


        public void SendChangeParameter(ParameterType parameter, int oldValue, int newValue)
        {
            OnChangeParameter?.Invoke(parameter, oldValue, newValue);
        }
    }

    [Serializable]
    public class CharacterSave
    {
        //TODO: доделать серриализуемый класс
        //...

        public CharacterSave(Character character)
        { 
            //TODO: доделать конструктор
            //...
        }
    }

    [Serializable]
    public class Slot
    {
        public string Card;
        public int Level;
        public int Amount;
        public int Cooldown;
    }
}
