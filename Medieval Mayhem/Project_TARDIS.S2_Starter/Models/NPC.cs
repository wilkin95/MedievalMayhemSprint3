using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    public class NPC : Character
    {
        public enum NPCType
        {
            LAME_BOY,
            MONK,
            TROLL,
            WIZARD,
            Goblin
        }

        private NPCType _nPCtype;

        private int _gameObjectID;

        public int GameObjectID
        {
            get { return _gameObjectID; }
            set { _gameObjectID = value; }
        }



        public NPCType Type
        {
            get { return _nPCtype; }
            set { _nPCtype = value; }
        }


        public bool HasMessage { get; set; }

        public string Message { get; set; }

        public NPC ()
        {

        }
        public NPC(string Name, NPCType Type, int RoomID, int GameObjectID)
        {
            _nPCtype = Type;
        }

    }
}
