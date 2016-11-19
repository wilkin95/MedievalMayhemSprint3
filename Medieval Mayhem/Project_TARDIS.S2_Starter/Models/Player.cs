using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    public class Player : Character
    {
        #region FIELDS

        private List<Item> _playersItems;
        private List<Treasure> _playersTreasures;
        public int _numberOfGoldCoins =0;
        private int _numberOfSilverCoins;
        private int _coinValue;
        private int _health;







        #endregion
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public int CoinValue
        {
            get { return _coinValue; }
            set { _coinValue = value; }
        }

        public int NumberOfSilverCoins
        {
            get { return _numberOfSilverCoins; }
            set { _numberOfSilverCoins = value; }
        }


        public int NumberOfGoldCoins
        {
            get { return _numberOfGoldCoins; }
            set { _numberOfGoldCoins = value; }
        }

        public List<Item> PlayersItems
        {
            get { return _playersItems; }
            set { _playersItems = value; }
        }

        public List<Treasure> PlayersTreasures
        {
            get { return _playersTreasures; }
            set { _playersTreasures = value; }
        }

        #region PROPERTIES



        #endregion


        #region CONSTRUCTORS

        public Player()
        {
            _playersItems = new List<Item>();
            _playersTreasures = new List<Treasure>();
        }

        public Player(string name, RankType race, int RoomID) : base(name, race, RoomID)
        {

        }

        #endregion


        #region METHODS



        #endregion
    }
}
