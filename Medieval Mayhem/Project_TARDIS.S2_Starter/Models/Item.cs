using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    public class Item : GameObject
    {
        public enum Type
        {
            Shield,
            Sword,
            Food,
            Water,
            BagA,
            BagB,
            Potion,
            Key,
            LockedBox
        }
        public override int GameObjectID { get; set; }

        public override string Name { get; set; }

        public override string Description { get; set; }

        public Type ItemType { get; set; }

        public override int RoomID { get; set; }

        public override bool HasValue { get; set; }

        public override int Value { get; set; }

        public override bool CanAddToInventory { get; set; }

       

    }
}
