using Modules.Game.State;
using System;

namespace Modules.Game.Custom.State.GameState
{
    public class GameState : IState
    {
        /// <summary>
        /// OnTurnChanged(int newTurn)
        /// </summary>
        public event Action<int> OnTurnChanged;

        //Текущий ход
        public int Turn { get; private set; }

        //Персонаж игрока
        public Character Character { get; private set; }

        //


        public void Load()
        {
            //TODO: доделать ЗАГРУЗКУ игрового стейта

            //throw new NotImplementedException();
        }

        public void Save()
        {
            //TODO: доделать СОХРАНЕНИЕ игрового стейта

            //throw new NotImplementedException();
        }


        public void NextTurn()
        {
            Turn++;
            OnTurnChanged?.Invoke(Turn);
        }
    }

    [Serializable]
    public class GameStateSave
    {
        public CharacterSave CharacterSave;

        //TODO: доделать сериализуемый класс игрового стейта
        //...

        public GameStateSave(GameState state)
        { 
            //TODO: доделать контсруктор сохранения игрового стейта
            //...
        }
    }
}
