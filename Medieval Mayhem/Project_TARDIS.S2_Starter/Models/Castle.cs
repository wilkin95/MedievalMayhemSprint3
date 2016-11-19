using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    /// <summary>
    /// the Castle class manages all of the game elements
    /// </summary>
    public class Castle
    {
        #region ***** define all lists to be maintained by the Castle object *****
        //
        // list of NPCs
        //
        public List<NPC> NPCs { get; set; }

        //
        // list of all rooms
        //
        public List<Room> Rooms { get; set; }

        //
        // list of all items
        //
        public List<Item> Items { get; set; }


        //
        // list of all treasure
        //
        public List<Treasure> Treasures { get; set; }

        //
        // list of all riddles
        public List<Riddle> Riddles { get; set; }
        #endregion

        #region ***** constructor *****

        //
        // default Castle constructor
        //
        public Castle()
        {
            //
            // instantiate the lists of rooms and game objects
            //
            this.Rooms = new List<Room>();
            this.Items = new List<Item>();
            this.Treasures = new List<Treasure>();
            this.NPCs = new List<NPC>();
            this.Riddles = new List<Riddle>();

            //
            // add all of the rooms and game objects to their lists
            // 
            IntializeCastleRooms();
            IntializeCastleItems();
            IntializeCastleTreasures();
            InitializeCastleNPCs();
            InitializeCastleRiddles();
        }

        #endregion

        #region ***** define methods to get the next available ID for game elements *****

        /// <summary>
        /// return the next available ID for a Room object
        /// </summary>
        /// <returns>next RoomObjectID </returns>
        private int GetNextRoomID()
        {
            int MaxID = 0;

            foreach (Room Room in Rooms)
            {
                if (Room.RoomID > MaxID)
                {
                    MaxID = Room.RoomID;
                }
            }

            return MaxID + 1;
        }

        /// <summary>
        /// return the next available ID for an item
        /// </summary>
        /// <returns>next GameObjectID </returns>
        private int GetNextItemID()
        {
            int MaxID = 0;

            foreach (Item item in Items)
            {
                if (item.GameObjectID > MaxID)
                {
                    MaxID = item.GameObjectID;
                }
            }

            return MaxID + 1;
        }

        /// <summary>
        /// return the next available ID for a treasure
        /// </summary>
        /// <returns>next GameObjectID </returns>
        private int GetNextTreasureID()
        {
            int MaxID = 0;

            foreach (Treasure treasure in Treasures)
            {
                if (treasure.GameObjectID > MaxID)
                {
                    MaxID = treasure.GameObjectID;
                }
            }

            return MaxID + 1;
        }

        #endregion

        #region ***** define methods to return game element objects *****

        /// <summary>
        /// get a Room object using an ID
        /// </summary>
        /// <param name="ID">room location ID</param>
        /// <returns>requested room location</returns>
        public Room GetRoomByID(int ID)
        {
            Room room = null;

            //
            // run through the room location list and grab the correct one
            //
            foreach (Room location in Rooms)
            {
                if (location.RoomID == ID)
                {
                    room = location;
                }
            }

            //
            // the specified ID was not found in the Castle
            // throw and exception
            //
            if (room == null)
            {
                string feedbackMessage = $"The Room Location ID {ID} does not exist in the current Castle.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return room;
        }

        public NPC GetNPCByID(int ID)
        {
            NPC requestedNPC = null;

            //
            // run through the item list and grab the correct one
            //
            foreach (NPC npc in NPCs)
            {
                if (npc.GameObjectID == ID)
                {
                    requestedNPC = npc;
                }
            }

            //
            // the specified ID was not found in the Castle
            // throw and exception
            //
            if (requestedNPC == null)
            {
                string feedbackMessage = $"The item ID {ID} does not exist in the current Castle.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return requestedNPC;
        }
        /// <summary>
        /// get an item using an ID
        /// </summary>
        /// <param name="ID">game object ID</param>
        /// <returns>requested item object</returns>
        public Item GetItemByID(int ID)
        {
            Item requestedItem = null;

            //
            // run through the item list and grab the correct one
            //
            foreach (Item item in Items)
            {
                if (item.GameObjectID == ID)
                {
                    requestedItem = item;
                }
            }

            //
            // the specified ID was not found in the Castle
            // throw and exception
            //
            if (requestedItem == null)
            {
                string feedbackMessage = $"The item ID {ID} does not exist in the current Castle.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return requestedItem;
        }

        /// <summary>
        /// get a treasure using an ID
        /// </summary>
        /// <param name="ID">game object ID</param>
        /// <returns>requested treasure object</returns>
        public Treasure GetTreasureByID(int ID)
        {
            Treasure requestedTreasure = null;

            //
            // run through the item list and grab the correct one
            //
            foreach (Treasure treasure in Treasures)
            {
                if (treasure.GameObjectID == ID)
                {
                    requestedTreasure = treasure;
                };
            }

            //
            // the specified ID was not found in the Castle
            // throw and exception
            //
            if (requestedTreasure == null)
            {
                string feedbackMessage = $"The treasure ID {ID} does not exist in the current Castle.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return requestedTreasure;
        }
        public Riddle GetRiddleByID(int ID)
        {
            Riddle requestedRiddle = null;

            //
            // run through the item list and grab the correct one
            //
            foreach (Riddle riddle in Riddles)
            {
                if (riddle.GameObjectID == ID)
                {
                    requestedRiddle = riddle;
                    break;
                };
            }

            //
            // the specified ID was not found in the Castle
            // throw and exception
            //
            if (requestedRiddle == null)
            {
                string feedbackMessage = $"The riddle ID {ID} does not exist in the current Castle.";
                throw new ArgumentException(ID.ToString(), feedbackMessage);
            }

            return requestedRiddle;
        }

        #endregion

        #region ***** define methods to get lists of game elements by location *****

        //
        // get NPCs by room ID
        //
        public List<NPC> GetNPCsByRoomID(int ID)
        {
            List<NPC> npcsInRoom = new List<NPC>();

            foreach (NPC npc in NPCs)
            {
                if (npc.RoomID == ID)
                {
                    npcsInRoom.Add(npc);
                }
            }
            return npcsInRoom;

        }

        /// get a list of items using a room location ID
        /// </summary>
        /// <param name="ID">room location ID</param>
        /// <returns>list of items in the specified location</returns>
        public List<Item> GetItemsByRoomID(int ID)
        {          
            List<Item> itemsInRoom = new List<Item>();

            //
            // run through the item list and put all items in the current location
            // into a list
            //
            foreach (Item item in Items)
            {
                if (item.RoomID == ID)
                {
                    itemsInRoom.Add(item);
                }
            }

            return itemsInRoom;
        }

   

        /// get a list of treasures using a room location ID
        /// </summary>
        /// <param name="ID">room location ID</param>
        /// <returns>list of treasures in the specified location</returns>
        public List<Treasure> GetTreasuresByRoomID(int ID)
        {
            List<Treasure> treasuresInRoom = new List<Treasure>();

            //
            // run through the treasure list and put all items in the current location
            // into a list
            //
            foreach (Treasure treasure in Treasures)
            {
                if (treasure.RoomID == ID)
                {
                    treasuresInRoom.Add(treasure);
                }
            }

            return treasuresInRoom;
        }

        #endregion

        #region ***** define methods to initialize all game elements *****
       
        //
        //initialize riddles
        //
        private void InitializeCastleRiddles()
        {
            Riddles.Add(new Riddle
            {
                Name = "Riddle 1",
                GameObjectID = 1,
                Description =
                Environment.NewLine + "\tMy first is in blood and also in battle, " + Environment.NewLine +
                              "\tMy second is in acorn, oak, and apple, " + Environment.NewLine +
                "\t My third and fourth are both the same, " + Environment.NewLine +
                "\tIn the center of sorrow and twice in refrain, " + Environment.NewLine +
                "\tMy fifth starts eternity ending here," + Environment.NewLine +
                "\tMy last is the first of last, Oh dear!",                  
                Answer = "BARREL",
                RoomID = 3,
                HasValue = false,
                Value = 0,
                CanAddToInventory = false
            });
            Riddles.Add(new Riddle
            {
                Name = "Riddle 2",
                GameObjectID = 2,
                Description = Environment.NewLine + "\tIt occurs once in every minute, " + Environment.NewLine +
                              "\tTwice in every moment, " + Environment.NewLine +
                              "\tAnd yet never in one hundred thousand years.", 
                Answer = "M",
                RoomID = 3,
                HasValue = false,
                Value = 0,
                CanAddToInventory = false
            });
            Riddles.Add(new Riddle
            {
                Name = "Riddle 3",
                GameObjectID = 3,
                Description = Environment.NewLine + "\tYou feed it, it lives, " + Environment.NewLine +
                              "\tYou give it something to drink, it dies. ", 
                Answer = "FIRE",
                RoomID = 3,
                HasValue = false,
                Value = 0,
                CanAddToInventory = false
            });
            Riddles.Add(new Riddle
            {
                Name = "Riddle 4",
                GameObjectID = 4,
                Description = Environment.NewLine + "\tWhat can travel around the world while staying in a corner? ",
                Answer = "STAMP",
                RoomID = 3,
                HasValue = false,
                Value = 0,
                CanAddToInventory = false
            });
            Riddles.Add(new Riddle
            {
                Name = "Riddle 5",
                GameObjectID = 5,
                Description = Environment.NewLine + "\tWhat has a head and a tail, but no body?  ",
                Answer = "COIN",
                RoomID = 3,
                HasValue = false,
                Value = 0,
                CanAddToInventory = false
            });
            Riddles.Add(new Riddle
            {
                Name = "Riddle 6",
                GameObjectID = 6,
                Description = Environment.NewLine + "\tForward I am heavy, but backward I am not. What am I?",
                Answer = "TON",
                RoomID = 3,
                HasValue = false,
                Value = 0,
                CanAddToInventory = false
            });
            Riddles.Add(new Riddle
            {
                Name = "Riddle 7",
                GameObjectID = 7,
                Description = Environment.NewLine + "\tWhat gets wetter and wetter the more it dries? ",
                Answer = "TOWEL",
                RoomID = 3,
                HasValue = false,
                Value = 0,
                CanAddToInventory = false
            });
            Riddles.Add(new Riddle
            {
                Name = "Riddle 8",
                GameObjectID = 8,
                Description = Environment.NewLine + "\tTake off my skin - I won't cry, but you will! What am I? ",
                Answer = "ONION",
                RoomID = 3,
                HasValue = false,
                Value = 0,
                CanAddToInventory = false
            });
        }
        
        //
        // initialize the NPCs
        //
        private void InitializeCastleNPCs()
        {
            NPCs.Add(new NPC
            {
                Name = "Troll",
                RoomID = 3,
                Type = NPC.NPCType.TROLL,
                HasMessage = true,
                Message = Environment.NewLine + "\t" + "To the depths of the dungeon you dared to go," + Environment.NewLine +
                "\t" + "But fear not, for mercy I'm inclined to show." + Environment.NewLine + 
                "\t" + "3 guesses you'll get for a Riddle I'll give;" + Environment.NewLine +
                "\t" + "You must answer correctly if you want to live." +Environment.NewLine + 
                "\t" + "For after guess 3, if you're wrong you're dead;" + Environment.NewLine +
                "\t" + "For my newly sharpened guillotine will chop off your head!" 
            });
            NPCs.Add(new NPC
            {
                Name = "Monk",
                RoomID = 1,
                Type = NPC.NPCType.MONK,
                HasMessage = true,
                Message = Environment.NewLine + "\t" + "If healing magic is what you seek, " + Environment.NewLine +
                           "\t" + "Then listen carefully to what I speak," + Environment.NewLine +
                           "\t" + "For 200 coin value you'll get your choice," + Environment.NewLine + 
                           "\t" + "Of bag A or bag B, but heed my voice." + Environment.NewLine + 
                           "\t" + "A roll of the dice is what you'll get," + Environment.NewLine +
                           "\t" + "To live, or die, a 50/50 bet." + Environment.NewLine +
                           "\t" + "If a guarantee is what you crave," + Environment.NewLine + 
                           "\t" + "And 300 coin value you have saved," + Environment.NewLine +
                           "\t" + "Then a healing potion you can buy," + Environment.NewLine +
                           "\t" + "Drink this, and today, you will not die!" 
            });
            NPCs.Add(new NPC
            {
                Name = "Wizard",
                RoomID = 6,
                Type = NPC.NPCType.WIZARD,
                HasMessage = true,
                Message = Environment.NewLine + "\t" + "The tower's my sanctuary, where my secrets I do keep, \n" + Environment.NewLine +
                          "\t" + "On guard a fierce dragon, it never ever does sleep, \n" + Environment.NewLine +
                          "\t" + "If you take or touch an item, that belongs to me, \n" + Environment.NewLine +
                          "\t" + "My beloved pet will inevitably see. \n" + Environment.NewLine +
                          "\t" + "You'd have to be invisible to escape from his flame, \n" + Environment.NewLine +
                          "\t" + "A gift only gotten from the boy who is lame. \n" + Environment.NewLine
                                      });
            NPCs.Add(new NPC
            {
                Name = "Lame Boy",
                RoomID = 4,
                Type = NPC.NPCType.LAME_BOY,
                HasMessage = true,
                Message = Environment.NewLine + "\t" + "In the kitchen I'm bound to stay, " + Environment.NewLine +
                          "\t" + "I can't go out to run and play, " + Environment.NewLine +
                          "\t" + "My legs they do not work you see, " + Environment.NewLine +
                          "\t" + "A miserable wretch I'll always be, " + Environment.NewLine +
                          "\t" + "Wherein my hope in you does lie, " + Environment.NewLine +
                          "\t" + "Should a healing potion you go and buy, " + Environment.NewLine +
                          "\t" + "Bring it back to me, a reward I'll give," + Environment.NewLine +
                          "\t" + "A cloak of invisibility so you may live ," + Environment.NewLine 
            });

            NPCs.Add(new NPC
            { 
            Name = "Goblin",
                RoomID = -1,
                Type = NPC.NPCType.Goblin,
                GameObjectID = 5,
                HasMessage = true,
                Message = Environment.NewLine + "\t" + "Mischief making is our game;" + Environment.NewLine +
                          "\t" + "We love to hurt and cause you pain, " + Environment.NewLine +
                          "\t" + "We freely move from room to room, " + Environment.NewLine +
                          "\t" + "To spread fear and endless gloom, " + Environment.NewLine +
                          "\t" + "Each time we strike, your health will drop, " + Environment.NewLine +
                          "\t" + "So make the kitchen your next stop, " + Environment.NewLine +
                          "\t" + "Where a plate of food you can buy," + Environment.NewLine +
                          "\t" + "To improve your health, lest you die." + Environment.NewLine
            });
        }
        /// <summary>
        /// initialize the Castle with all of the rooms
        /// </summary>
        private void IntializeCastleRooms()
        {
            Rooms.Add(new Room
            {
                Name = "Apothecary",
                RoomID = 1,
                Description = Environment.NewLine + "\t" + "If a remedy is what you seek, " + Environment.NewLine +
                            "\t" + "For aching joints, wounds or disease; " + Environment.NewLine +
                            "\t" + "To the apothecary go, " + Environment.NewLine +
                            "\t" + "You'll get no promises though; " + Environment.NewLine +
                            "\t" + "A potion, paste, or powder we'll give, " + Environment.NewLine +
                            "\t" + "You'll have a 50/50 chance to live.",
                Accessible = true
            });

            Rooms.Add(new Room
            {
                Name = "Armory",
                RoomID = 2,
                Description = Environment.NewLine + "\t" + "When the sounds of war call your name, " + Environment.NewLine +
                             "\t" + "The armory will give you fame. " + Environment.NewLine +
                          "\t" + "From sword and shield and mace to boot, " + Environment.NewLine +
                            "\t" + "To truest arrows in flight to shoot. " + Environment.NewLine +
                           "\t" + "We'll gladly provide all you need, " + Environment.NewLine +
                            "\t" + "To protect yourself, squire and steed.",
                Accessible = true
            });

            Rooms.Add(new Room
            {
                Name = "Dungeon",
                RoomID = 3,
                Description = Environment.NewLine + "\t" + "A place where all men loathe to dwell, " + Environment.NewLine +
                 "\t" + "Our dungeon master invokes a yell; " + Environment.NewLine +
                 "\t" + "A moan, a scream, a tear to eye, " + Environment.NewLine +
                 "\t" + "A pain so deep you'll plead to die. " + Environment.NewLine +
                 "\t" + "Sympathy here you will not find; " + Environment.NewLine +
                 "\t" + "Only manic peace as you lose your mind.",
                Accessible = true
            });
            Rooms.Add(new Room
            {
                Name = "Kitchen",
                RoomID = 4,
                Description = Environment.NewLine + "\t" + "The castle kitchen is always bustling, " + Environment.NewLine +
             "\t" + "With servants, bakers, and cooks all hustling. " + Environment.NewLine +
             "\t" + "Preparing a feast for king so great, " + Environment.NewLine +
              "\t" + "Of delightful delicacies filling your plate. " + Environment.NewLine +
              "\t" + "Of delightful delicacies filling your plate. " + Environment.NewLine +
              "\t" + "Stag, veal, chicken, and a whole roe-deer, " + Environment.NewLine +
              "\t" + "Hare, goat, and pig, hurrah, give a cheer! " + Environment.NewLine +
              "\t" + "For cheese, bread, and wine, to make the guests merry; " + Environment.NewLine +
              "\t" + "For sugar-plums, pies, and rich cream with sweet berries. " + Environment.NewLine +
              "\t" + "So come to the kitchen our food here is grand, " + Environment.NewLine +
               "\t" + "But don't take without asking or you may lose a hand! ",
                Accessible = true
            });
            Rooms.Add(new Room
            {
                Name = "Stable",
                RoomID = 5,
                Description = Environment.NewLine + "\t" + "The mighty destrier tall, majestic, and strong; " + Environment.NewLine +
              "\t" + "The light and swift coursers when the battle is long. " + Environment.NewLine +
             "\t" + " The all-purpose rouncey is always just right, " + Environment.NewLine +
              "\t" + "To be used by a squire, men-at-arms, and poor knights. " + Environment.NewLine +
              "\t" + "The palfrey for nobles and great knights was the trait, " + Environment.NewLine +
              "\t" + "Because ambling was a comfortable, smooth-flowing gait. " + Environment.NewLine +
              "\t" + "The hobby a lightweight reaching less than five feet, " + Environment.NewLine +
              "\t" + "Was perfect for skirmishing with its fast agile feet. " + Environment.NewLine +
              "\t" + "So come visit the stable it's a glorious sight, " + Environment.NewLine +
              "\t" + "But please watch your step lest you slip in some shite. ",
                Accessible = true
            });
            Rooms.Add(new Room
            {
                Name = "Tower",
                RoomID = 6,
                Description = Environment.NewLine + "\t" + "The tower's a mystery in the heavens above, " + Environment.NewLine +
               "\t" + "Some go to share secrets, some go to share love. " + Environment.NewLine +
              "\t" + "But for those who journey up its long winding stair, " + Environment.NewLine +
              "\t" + "Will surely uncover the treasure that's there. ",
                Accessible = true
            });
            Rooms.Add(new Room
            {
                Name = "Hidden Room",
                RoomID = -1,
                Description = " ",
                Accessible = false
            });
        }

        /// <summary>
        /// initialize the Castle with all of the items
        /// </summary>
        private void IntializeCastleItems()
        {
            Items.Add(new Item
            {
                Name = "Sword",
                GameObjectID = 1,
                Description = Environment.NewLine + "\t" + "A heavy sword with no markings. But don't be fooled." + Environment.NewLine +
                "\tIf you are strong enough to wield this weapon, it will destroy anything in its path. ",
                RoomID = 2,
                HasValue = false,
                Value = 0,
                CanAddToInventory = true
            });

            Items.Add(new Item
            {
                Name = "Shield",
                GameObjectID = 2,
                Description = Environment.NewLine + "\t" + "A round, metal Buckler whose only adornment was an engraved eye in the center." + Environment.NewLine +
                "\tEasily carried by hooking onto a belt, it will deflect any blow in battle. ",
                RoomID = 2,
                HasValue = true,
                Value = 500,
                CanAddToInventory = true
            });
            Items.Add(new Item
            {
                Name = "Bag A",
                GameObjectID = 3,
                Description = Environment.NewLine + "\t" + "A mix of herbs blended into a powder that must be mixed with water. " + Environment.NewLine + 
                "\tIt will either heal you or kill you. ",
                RoomID = 1,
                HasValue = true,
                Value = 200,
                CanAddToInventory = false
            });
            Items.Add(new Item
            {
                Name = "Bag B",
                GameObjectID = 4,
                Description = Environment.NewLine + "\t" + "A mix of herbs blended into a powder that must be mixed with water." + Environment.NewLine + 
                "\tIt will either heal you or kill you.",
                RoomID = 1,
                HasValue = true,
                Value = 200,
                CanAddToInventory = false
            });
            Items.Add(new Item
            {
                Name = "Potion",
                GameObjectID = 5,
                Description = Environment.NewLine + "\t" + "An elixir in a small blue vial." + Environment.NewLine +
                "\tDrink this and your health will be restored.",
                RoomID = 1,
                HasValue = true,
                Value = 300,
                CanAddToInventory = false
            });
            Items.Add(new Item
            {
                Name = "Key",
                GameObjectID = 6,
                Description = Environment.NewLine + "\t" + "Made of iron with a decorative trefoil bow, and a rusted bit showing lack of use." + Environment.NewLine + 
                "\tThis skeleton key will come in handy when you have a lock to open. ",
                RoomID = 5,
                HasValue = true,
                Value = 500,
                CanAddToInventory = true
            });
            Items.Add(new Item
            {
                Name = "Food",
                GameObjectID = 7,
                Description = Environment.NewLine + "\t" + "A warm meal is the perfect pick-me-up for anyone's health. ",
                RoomID = 4,
                HasValue = true,
                Value = 200,
                CanAddToInventory = false
            });
         
            Items.Add(new Item
            {
                Name = "Cloak of Invisibility",
                GameObjectID = 8,
                Description = Environment.NewLine + "\t" + "With this cloak you can get past the dragon!",
                RoomID = 4,
                HasValue = true,
                Value = 500,
                CanAddToInventory = false
            });
            Items.Add(new Item
            {
                Name = "Locked Box",
                GameObjectID = 9,
                Description = Environment.NewLine + "\t" + "He who holds the object within, shall rule the kingdom!",
                RoomID = 6,
                HasValue = true,
                Value = 5000,
                CanAddToInventory = false
            });
            Items.Add(new Item
            {
                Name = "Water",
                GameObjectID = 10,
                Description = "\t" + "A goblet of water to drink." + Environment.NewLine +
                "\t" + "Mix in the contents of Bag A or Bag B from the Apothecary," + Environment.NewLine +
                "\t" + "and your health might increase by 30.........or you might die!",
                RoomID = 4,
                HasValue = true,
                Value = 25,
                CanAddToInventory = false
            });

        }

        /// <summary>
        /// initialize the Castle with all of the treasures
        /// </summary>
        private void IntializeCastleTreasures()
        {
            Treasures.Add(new Treasure
            {
                Name = "Denari",
                TreasureType = Treasure.Coin.Denari,
                GameObjectID = 1,
                Description = Environment.NewLine + "\t" + "A small silver coin.",
                RoomID = 1,
                HasValue = true,
                Value = 25,
                CanAddToInventory = true
            });
            Treasures.Add(new Treasure
            {
                Name = "Denari",
                TreasureType = Treasure.Coin.Denari,
                GameObjectID = 2,
                Description = Environment.NewLine + "\t" + "A small silver coin.",
                RoomID = 2,
                HasValue = true,
                Value = 25,
                CanAddToInventory = true
            });
            Treasures.Add(new Treasure
            {
                Name = "Denari",
                TreasureType = Treasure.Coin.Denari,
                GameObjectID = 3,
                Description = Environment.NewLine + "\t" + "A small silver coin.",
                RoomID = 4,
                HasValue = true,
                Value = 25,
                CanAddToInventory = true
            });
            Treasures.Add(new Treasure
            {
                Name = "Denari",
                TreasureType = Treasure.Coin.Denari,
                GameObjectID = 4,
                Description = Environment.NewLine + "\t" + "A small silver coin.",
                RoomID = 5,
                HasValue = true,
                Value = 25,
                CanAddToInventory = true
            });
            Treasures.Add(new Treasure
            {
                Name = "Denari",
                TreasureType = Treasure.Coin.Denari,
                GameObjectID = 5,
                Description = Environment.NewLine + "\t" + "A small silver coin.",
                RoomID = 5,
                HasValue = true,
                Value = 25,
                CanAddToInventory = true
            });
            Treasures.Add(new Treasure
            {
                Name = "Florin",
                TreasureType = Treasure.Coin.Florin,
                GameObjectID = 6,
                Description = Environment.NewLine + "\t" + "A gold coin decorated with a fleur-de-lis on one side and an image of St. John the Baptist on the other.",
                RoomID = 6,
                HasValue = true,
                Value = 100,
                CanAddToInventory = true
            });
            Treasures.Add(new Treasure
            {
                Name = "Florin",
                TreasureType = Treasure.Coin.Florin,
                GameObjectID = 7,
                Description = Environment.NewLine + "\t" + "A gold coin decorated with a fleur-de-lis on one side and an image of St. John the Baptist on the other.",
                RoomID = 3,
                HasValue = true,
                Value = 100,
                CanAddToInventory = true
            });
            Treasures.Add(new Treasure
            {
                Name = "Florin",
                TreasureType = Treasure.Coin.Florin,
                GameObjectID = 8,
                Description = Environment.NewLine + "\t" + "A gold coin decorated with a fleur-de-lis on one side and an image of St. John the Baptist on the other.",
                RoomID = -1,
                HasValue = true,
                Value = 100,
                CanAddToInventory = true
            });
            Treasures.Add(new Treasure
            {
                Name = "Florin",
                TreasureType = Treasure.Coin.Florin,
                GameObjectID = 9,
                Description = Environment.NewLine + "\t" + "A gold coin decorated with a fleur-de-lis on one side and an image of St. John the Baptist on the other.",
                RoomID = -1,
                HasValue = true,
                Value = 100,
                CanAddToInventory = true
            }); Treasures.Add(new Treasure
            {
                Name = "Florin",
                TreasureType = Treasure.Coin.Florin,
                GameObjectID = 10,
                Description = Environment.NewLine + "\t" + "A gold coin decorated with a fleur-de-lis on one side and an image of St. John the Baptist on the other.",
                RoomID = -1,
                HasValue = true,
                Value = 100,
                CanAddToInventory = true
            }); Treasures.Add(new Treasure
            {
                Name = "Florin",
                TreasureType = Treasure.Coin.Florin,
                GameObjectID = 11,
                Description = Environment.NewLine + "\t" + "A gold coin decorated with a fleur-de-lis on one side and an image of St. John the Baptist on the other.",
                RoomID = -1,
                HasValue = true,
                Value = 100,
                CanAddToInventory = true
            }); Treasures.Add(new Treasure
            {
                Name = "Florin",
                TreasureType = Treasure.Coin.Florin,
                GameObjectID = 12,
                Description = Environment.NewLine + "\t" + "A gold coin decorated with a fleur-de-lis on one side and an image of St. John the Baptist on the other.",
                RoomID = -1,
                HasValue = true,
                Value = 100,
                CanAddToInventory = true
            }); Treasures.Add(new Treasure
            {
                Name = "Florin",
                TreasureType = Treasure.Coin.Florin,
                GameObjectID = 13,
                Description = Environment.NewLine + "\t" + "A gold coin decorated with a fleur-de-lis on one side and an image of St. John the Baptist on the other.",
                RoomID = -1,
                HasValue = true,
                Value = 100,
                CanAddToInventory = true
            }); Treasures.Add(new Treasure
            {
                Name = "Florin",
                TreasureType = Treasure.Coin.Florin,
                GameObjectID = 14,
                Description = Environment.NewLine + "\t" + "A gold coin decorated with a fleur-de-lis on one side and an image of St. John the Baptist on the other.",
                RoomID = -1,
                HasValue = true,
                Value = 100,
                CanAddToInventory = true
            }); Treasures.Add(new Treasure
            {
                Name = "Florin",
                TreasureType = Treasure.Coin.Florin,
                GameObjectID = 15,
                Description = Environment.NewLine + "\t" + "A gold coin decorated with a fleur-de-lis on one side and an image of St. John the Baptist on the other.",
                RoomID = -1,
                HasValue = true,
                Value = 100,
                CanAddToInventory = true
            });

         
        }
        
            #endregion

        }
    }

