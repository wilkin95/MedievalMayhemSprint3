using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    /// <summary>
    /// base class for the player and all game characters
    /// </summary>
    public class Character
    {
        #region ENUMERABLES

        public enum RankType
        {
            NONE,
            FRIAR,
            LORD,
            LADY,
            KNIGHT,
            MINSTREL,
            PEASANT
        }

        #endregion

        #region FIELDS

        private string _name;
        private int _RoomID;
        private RankType _rank;

        #endregion


        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int RoomID
        {
            get { return _RoomID; }
            set { _RoomID = value; }
        }

        public RankType Rank
        {
            get { return _rank; }
            set { _rank = value; }
        }

        #endregion


        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(string name, RankType rank, int RoomID)
        {
            _name = name;
            _rank = rank;
            _RoomID = RoomID;
        }

        #endregion


        #region METHODS



        #endregion




    }
}
