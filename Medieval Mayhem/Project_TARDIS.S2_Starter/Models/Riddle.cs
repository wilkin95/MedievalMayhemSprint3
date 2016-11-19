using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    public class Riddle : GameObject
    {
        public enum RiddleType
        {
           RIDDLE1,
           RIDDLE2,
           RIDDLE3,
           RIDDLE4,
           RIDDLE5,
           RIDDLE6,
           RIDDLE7,
           RIDDLE8
        }

        private RiddleType _riddleType;

        public string Answer { get; set; }

        public RiddleType Type
        {
            get { return _riddleType; }
            set { _riddleType = value; }
        }


        public override int GameObjectID { get; set; }

        public override string Name { get; set; }

        public override string Description { get; set; }       

        public override int RoomID { get; set; }

        public override bool HasValue { get; set; }

        public override int Value { get; set; }

        public override bool CanAddToInventory { get; set; }


        public Riddle()
        {

        }
        public Riddle(string Name, RiddleType Type, int RoomID, string Answer)
        {
            _riddleType = Type;
        }
    }
}
