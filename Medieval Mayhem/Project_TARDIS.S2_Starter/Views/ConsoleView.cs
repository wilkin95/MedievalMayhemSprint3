using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    /// <summary>
    /// Console class for the MVC pattern
    /// </summary>
    public class ConsoleView
    {
        #region FIELDS

        //
        // declare a Castle and Player object for the ConsoleView object to use
        //
        Castle _gameCastle;
        Player _gamePlayer;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Player gamePlayer, Castle gameCastle)
        {
            _gamePlayer = gamePlayer;
            _gameCastle = gameCastle;

            InitializeConsole();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize all console settings
        /// </summary>
        private void InitializeConsole()
        {
            ConsoleUtil.WindowTitle = "Medieval Mayhem";
            ConsoleUtil.HeaderText = "Medieval Mayhem";
        }

        /// <summary>
        /// display the Continue prompt
        /// </summary>
        public void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;

            Console.WriteLine();

            ConsoleUtil.DisplayMessage("Press any key to continue.");
            ConsoleKeyInfo response = Console.ReadKey();

            Console.WriteLine();

            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the Exit prompt on a clean screen
        /// </summary>
        public void DisplayExitPrompt()
        {
            ConsoleUtil.HeaderText = "Exit";
            ConsoleUtil.DisplayReset();

            Console.CursorVisible = false;

            Console.WriteLine();
            ConsoleUtil.DisplayMessage("Thank you for playing Medieval Mayhem. Press any key to Exit.");

            Console.ReadKey();

            System.Environment.Exit(1);
        }

        /// <summary>
        /// display the welcome screen
        /// </summary>
        public void DisplayWelcomeScreen()
        {
            StringBuilder sb = new StringBuilder();

            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Medieval Mayhem");
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("modified by Terri Wilkinson");
            ConsoleUtil.DisplayMessage("Northwestern Michigan College");
            Console.WriteLine();

            //
            // TODO update opening screen
            //

            sb.Clear();
            sb.AppendFormat("You are traveling with a caravan late at night ");
            sb.AppendFormat("when your group is viciously attacked. You are the only survivor. ");
            sb.AppendFormat("You flee from the carnage and find yourself completely lost. ");
            sb.AppendFormat("Up ahead in the distance a faint glow outlines castle turrets ");
            sb.AppendFormat("through the dense fog. You make your way to the entrance ");
            sb.AppendFormat("where you are granted refuge for the night.");
            ConsoleUtil.DisplayMessage(sb.ToString());
            Console.WriteLine();

            sb.Clear();
            sb.AppendFormat("As you enter the castle gates you are stopped by two guards. ");
            ConsoleUtil.DisplayMessage(sb.ToString());

            DisplayContinuePrompt();
        }

        /// <summary>
        /// setup the new Player object
        /// </summary>
        public void DisplayGameSetupIntro()
        {
            //
            // display header
            //
            ConsoleUtil.HeaderText = "Game Setup";
            ConsoleUtil.DisplayReset();

            //
            // display intro
            //
            ConsoleUtil.DisplayMessage("Before the guards will let you pass you must give them some information.");
            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a message confirming game setup
        /// </summary>
        public void DisplayGameSetupConfirmation()
        {
            //
            // display header
            //
            ConsoleUtil.HeaderText = "Game Setup";
            ConsoleUtil.DisplayReset();
            ConsoleUtil.HeaderText = "Game Setup";
            ConsoleUtil.DisplayReset();

            //
            // display confirmation
            //
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Your game setup is complete.");
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("To view your Medieval Mayhem information use the Main Menu.");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// get player's name
        /// </summary>
        /// <returns>name as a string</returns>
        public string DisplayGetPlayersName()
        {
            string playersName = "";
            bool validResponse = false;

            //
            // display header
            //
            ConsoleUtil.HeaderText = "Player's Name";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayPromptMessage("Enter your name: ");
            playersName = Console.ReadLine();

            while (!validResponse)
            {
                if (playersName.Length > 0)
                {
                    validResponse = true;
                    break;
                }
                else
                {
                    Console.WriteLine();
                    ConsoleUtil.DisplayMessage("That is not a valid response. ");
                    DisplayContinuePrompt();
                    ConsoleUtil.DisplayReset();
                    ConsoleUtil.DisplayPromptMessage("Please enter your name: ");
                    playersName = Console.ReadLine();
                }
            }

            ConsoleUtil.DisplayReset();
            ConsoleUtil.DisplayMessage($"Thank you, {playersName}. ");

            DisplayContinuePrompt();

            return playersName;
        }

        /// <summary>
        /// get and validate the player's rank
        /// </summary>
        /// <returns>rank as a RankType</returns>
        public Player.RankType DisplayGetPlayersRank()
        {
            bool usingMenu = true;
            Player.RankType playersRank = Player.RankType.NONE;

            while (usingMenu)
            {
                //
                // display header
                //
                ConsoleUtil.HeaderText = "Player's Rank";
                ConsoleUtil.DisplayReset();

                //
                // display all ranks
                //
                Console.WriteLine();
                Console.WriteLine(
                    "\t" + "1. Lord" + Environment.NewLine +
                    "\t" + "2. Lady" + Environment.NewLine +
                    "\t" + "3. Knight" + Environment.NewLine +
                    "\t" + "4. Minstrel" + Environment.NewLine +
                    "\t" + "5. Friar" + Environment.NewLine +
                    "\t" + "6. Peasant" + Environment.NewLine);
                Console.WriteLine();
                ConsoleUtil.DisplayPromptMessage("What is your rank? (Type number): ");

                //get user response for rank
                //
                ConsoleKeyInfo userResponse = Console.ReadKey();
                switch (userResponse.KeyChar)
                {
                    case '1':
                        playersRank = Character.RankType.LORD;
                        usingMenu = false;
                        break;
                    case '2':
                        playersRank = Character.RankType.LADY;
                        usingMenu = false;
                        break;
                    case '3':
                        playersRank = Character.RankType.KNIGHT;
                        usingMenu = false;
                        break;
                    case '4':
                        playersRank = Character.RankType.MINSTREL;
                        usingMenu = false;
                        break;
                    case '5':
                        playersRank = Character.RankType.FRIAR;
                        usingMenu = false;
                        break;
                    case '6':
                        playersRank = Character.RankType.PEASANT;
                        usingMenu = false;
                        break;
                    default:
                        ConsoleUtil.DisplayMessage("That is not a valid choice." + Environment.NewLine +
                            "Please enter a 1, 2, 3, 4, 5, or 6.");
                        break;
                }
                DisplayContinuePrompt();
            }
            Console.CursorVisible = true;
            return playersRank;
        }

        /// <summary>
        /// get and validate the player's Castle destination
        /// </summary>
        /// <returns>room location</returns>
        public Room DisplayGetPlayersNewDestination()
        {
            bool validResponse = false;
            Room nextRoom = new Room();

            while (!validResponse)
            {
                //
                // display header
                //
                ConsoleUtil.HeaderText = "Room Destination";
                ConsoleUtil.DisplayReset();

                //
                // display a table of rooms
                //
                DisplayRoomDestinationsTable();

                //
                // get and validate user's response for a room location
                //
                Console.WriteLine();
                ConsoleUtil.DisplayPromptMessage("Choose the Castle destination by entering the Room ID: ");
                int ID;
                string response = Console.ReadLine();
                //
                // user's response is an integer
                //
                if (Int32.TryParse(response, out ID) && ID < 7 && ID > 0)
                {
                    nextRoom = _gameCastle.GetRoomByID(ID);
                    ConsoleUtil.DisplayReset();
                    Console.WriteLine();
                    ConsoleUtil.DisplayMessage($"You are now in the {nextRoom.Name}.");

                    int gob = RandomGoblin();
                    NPC goblin = _gameCastle.GetNPCByID(5);
                    goblin.RoomID = gob;
                    if (_gamePlayer.RoomID == goblin.RoomID)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        ConsoleUtil.DisplayMessage("You were just attacked by a goblin! 10 health point will be deducted.");
                        Console.WriteLine();
                        _gamePlayer.Health = _gamePlayer.Health - 10;
                    }
                    if (nextRoom.RoomID == 6)
                    {
                        Console.WriteLine();
                        ConsoleUtil.DisplayMessage("I recommend talking to the NPC before you touch anything.");
                        Console.WriteLine();
                    }
                    validResponse = true;
                }
                else
                {
                    Console.WriteLine();
                    ConsoleUtil.DisplayMessage("That is not a valid Room ID.");
                    Console.WriteLine();
                    ConsoleUtil.DisplayMessage("A valid ID is 1, 2, 3, 4, 5, or 6.");
                }

                DisplayContinuePrompt();
            }

            return nextRoom;
        }

        /// <summary>
        /// generate a table of room location names and ids
        /// </summary>
        public void DisplayRoomDestinationsTable()
        {
            int locationNumber = 1;

            //
            // table headings
            //
            ConsoleUtil.DisplayMessage("ID".PadRight(10) + "Name".PadRight(20));
            ConsoleUtil.DisplayMessage("---".PadRight(10) + "-------------".PadRight(20));

            //
            // location name and id
            //
            foreach (Room location in _gameCastle.Rooms)
            {
                ConsoleUtil.DisplayMessage(location.RoomID.ToString().PadRight(10) + location.Name.PadRight(20));
                locationNumber++;
            }

        }

        /// <summary>
        /// get the action choice from the user
        /// </summary>
        public PlayerAction DisplayGetPlayerActionChoice()
        {
            PlayerAction playerActionChoice = PlayerAction.NONE;
            bool usingMenu = true;
            int health = _gamePlayer.Health;

            while (usingMenu)
            {
                //
                // set up display area
                //
                ConsoleUtil.DisplayReset();
                ConsoleUtil.HeaderText = "Player Action Choice";

                Console.CursorVisible = false;
                Console.WriteLine($"\t\t\t\t\t\t\t\tHealth: {_gamePlayer.Health}");
                Console.WriteLine($"\t\t\t\t\t\t\t\tCoin Value: {_gamePlayer.CoinValue}");

                // display the menu
                //
                ConsoleUtil.DisplayPromptMessage("What would you like to do (Type Letter).");
                Console.WriteLine();
                Console.WriteLine(
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "Player Actions" + Environment.NewLine +
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "A. Buy Item" + Environment.NewLine +
                    "\t" + "B. Look Around" + Environment.NewLine +
                    "\t" + "C. Look At Item" + Environment.NewLine +
                    "\t" + "D. Look At Treasure" + Environment.NewLine +
                    "\t" + "E. Pick Up Item" + Environment.NewLine +
                    "\t" + "F. Pick Up Treasure" + Environment.NewLine +
                    "\t" + "G. Put Down Item" + Environment.NewLine +
                    "\t" + "H. Put Down Treasure" + Environment.NewLine +
                    "\t" + "I. Travel" + Environment.NewLine +
                    "\t" + "J. Speak to NPC" + Environment.NewLine +
                    "\t" + Environment.NewLine +
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "Player Information" + Environment.NewLine +
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "K. Display General Player Info" + Environment.NewLine +
                    "\t" + "L. Display Player's Items" + Environment.NewLine +
                    "\t" + "M. Display Player's Treasures" + Environment.NewLine +
                    "\t" + Environment.NewLine +
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "Game Information" + Environment.NewLine +
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "N. Display All Castle Rooms" + Environment.NewLine +
                    "\t" + "O. Display All Game Items" + Environment.NewLine +
                    "\t" + "P. Display All Game Treasures" + Environment.NewLine +
                    "\t" + Environment.NewLine +
                    "\t" + "**************************" + Environment.NewLine +
                    "\t" + "Q. Quit" + Environment.NewLine);

                //
                // get and process the user's response
                // note: ReadKey argument set to "true" disables the echoing of the key press
                //
                ConsoleKeyInfo userResponse = Console.ReadKey(true);
                switch (userResponse.KeyChar)
                {
                    case 'A':
                    case 'a':
                        playerActionChoice = PlayerAction.BuyItem;
                        usingMenu = false;
                        break;
                    case 'B':
                    case 'b':
                        playerActionChoice = PlayerAction.LookAround;
                        usingMenu = false;
                        break;
                    case 'C':
                    case 'c':
                        playerActionChoice = PlayerAction.LookAtItem;
                        usingMenu = false;
                        break;
                    case 'D':
                    case 'd':
                        playerActionChoice = PlayerAction.LookAtTreasure;
                        usingMenu = false;
                        break;
                    case 'E':
                    case 'e':
                        playerActionChoice = PlayerAction.PickUpItem;
                        usingMenu = false;
                        break;
                    case 'F':
                    case 'f':
                        playerActionChoice = PlayerAction.PickUpTreasure;
                        usingMenu = false;
                        break;
                    case 'G':
                    case 'g':
                        playerActionChoice = PlayerAction.PutDownItem;
                        usingMenu = false;
                        break;
                    case 'H':
                    case 'h':
                        playerActionChoice = PlayerAction.PutDownTreasure;
                        usingMenu = false;
                        break;
                    case 'I':
                    case 'i':
                        playerActionChoice = PlayerAction.Travel;
                        usingMenu = false;
                        break;
                    case 'J':
                    case 'j':
                        playerActionChoice = PlayerAction.SpeakToNPC;
                        usingMenu = false;
                        break;
                    case 'K':
                    case 'k':
                        playerActionChoice = PlayerAction.PlayerInfo;
                        usingMenu = false;
                        break;
                    case 'L':
                    case 'l':
                        playerActionChoice = PlayerAction.PlayerItems;
                        usingMenu = false;
                        break;
                    case 'M':
                    case 'm':
                        playerActionChoice = PlayerAction.PlayerTreasure;
                        usingMenu = false;
                        break;
                    case 'N':
                    case 'n':
                        playerActionChoice = PlayerAction.ListCastleRooms;
                        usingMenu = false;
                        break;
                    case 'O':
                    case 'o':
                        playerActionChoice = PlayerAction.ListItems;
                        usingMenu = false;
                        break;
                    case 'P':
                    case 'p':
                        playerActionChoice = PlayerAction.ListTreasures;
                        usingMenu = false;
                        break;
                    case 'Q':
                    case 'q':
                        playerActionChoice = PlayerAction.Exit;
                        usingMenu = false;
                        break;
                    default:
                        Console.WriteLine(
                            "It appears you have selected an incorrect choice." + Environment.NewLine +
                            "Press any key to continue or the ESC key to quit the application.");

                        userResponse = Console.ReadKey(true);
                        if (userResponse.Key == ConsoleKey.Escape)
                        {
                            usingMenu = false;
                        }                      
                        break;

                }
            }
            Console.CursorVisible = true;

            return playerActionChoice;
        }

        /// <summary>
        /// display information about the current room location
        /// </summary>
        public void DisplayLookAround()
        {
            ConsoleUtil.HeaderText = "Current Room Location Info";
            ConsoleUtil.DisplayReset();

            Console.WriteLine(_gameCastle.GetRoomByID(_gamePlayer.RoomID).Description);

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("******************************************************************");
            ConsoleUtil.DisplayMessage("Items in current location:");
            foreach (Item item in _gameCastle.GetItemsByRoomID(_gamePlayer.RoomID))
            {
                if (item.CanAddToInventory == true)
                {
                    Console.WriteLine();
                    ConsoleUtil.DisplayMessage(item.Name);
                    Console.WriteLine(item.Description);
                }
                else if (item.CanAddToInventory == false && item.GameObjectID != 8)
                {
                    Console.WriteLine();
                    ConsoleUtil.DisplayMessage(item.Name + " - $" + item.Value);
                    Console.WriteLine(item.Description);
                }
               
                
            }

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("******************************************************************");
            ConsoleUtil.DisplayMessage("Treasures in current location:");
            foreach (Treasure treasure in _gameCastle.GetTreasuresByRoomID(_gamePlayer.RoomID))
            {
                Console.WriteLine();
                ConsoleUtil.DisplayMessage(treasure.Name);
                Console.WriteLine(treasure.Description);
            }

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("******************************************************************");
            ConsoleUtil.DisplayMessage("NPCs in current location:");

            foreach (NPC npc in _gameCastle.GetNPCsByRoomID(_gamePlayer.RoomID))
            {
                Console.WriteLine();
                ConsoleUtil.DisplayMessage(npc.Name);
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a list of all Castle Rooms
        /// <summary>
        public void DisplayListAllCastleRooms()
        {
            ConsoleUtil.HeaderText = "rooms";
            ConsoleUtil.DisplayReset();

            foreach (Room location in _gameCastle.Rooms)
            {
                ConsoleUtil.DisplayMessage("ID: " + location.RoomID);
                ConsoleUtil.DisplayMessage("Name: " + location.Name);
                Console.WriteLine("Description: " + location.Description);
                ConsoleUtil.DisplayMessage("Accessible: " + location.Accessible);
                ConsoleUtil.DisplayMessage("");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a list of all game items
        /// <summary>
        public void DisplayListAllGameItems()
        {
            ConsoleUtil.HeaderText = "Game Items";
            ConsoleUtil.DisplayReset();

            foreach (Item item in _gameCastle.Items)
            {
                ConsoleUtil.DisplayMessage("ID: " + item.GameObjectID);
                ConsoleUtil.DisplayMessage("Name: " + item.Name);
                Console.WriteLine("Description: " + item.Description);

                //
                // all treasure in the traveler's inventory have a RoomID of 0
                //
                if (item.RoomID != 0)
                {
                    ConsoleUtil.DisplayMessage("Location: " + _gameCastle.GetRoomByID(item.RoomID).Name);
                }
                else
                {
                    ConsoleUtil.DisplayMessage("Location: Player's Inventory");
                }


                ConsoleUtil.DisplayMessage("Value: " + item.Value);
                ConsoleUtil.DisplayMessage("Can Add to Inventory: " + item.CanAddToInventory.ToString().ToUpper());
                ConsoleUtil.DisplayMessage("");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a list of all game treasures
        /// <summary>
        public void DisplayListAllGameTreasures()
        {
            ConsoleUtil.HeaderText = "Game Treasures";
            ConsoleUtil.DisplayReset();

            foreach (Treasure treasure in _gameCastle.Treasures)
            {
                ConsoleUtil.DisplayMessage("ID: " + treasure.GameObjectID);
                ConsoleUtil.DisplayMessage("Name: " + treasure.Name);
                Console.WriteLine("Description: " + treasure.Description);

                //
                // all treasure in the traveler's inventory have a RoomID of 0
                //
                if (treasure.RoomID != 0)
                {
                    ConsoleUtil.DisplayMessage("Location: " + _gameCastle.GetRoomByID(treasure.RoomID).Name);
                }
                else
                {
                    ConsoleUtil.DisplayMessage("Location: Player's Inventory");
                }

                ConsoleUtil.DisplayMessage("Value: " + treasure.Value);
                ConsoleUtil.DisplayMessage("Can Add to Inventory: " + treasure.CanAddToInventory.ToString().ToUpper());
                ConsoleUtil.DisplayMessage("");
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display the current traveler information
        /// </summary>
        public void DisplayTravelerInfo()
        {
            ConsoleUtil.HeaderText = "Player Info";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage($"Player's Name: {_gamePlayer.Name}");
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage($"Player's Rank: {_gamePlayer.Rank}");
            ConsoleUtil.DisplayMessage("");
            string RoomName = _gameCastle.GetRoomByID(_gamePlayer.RoomID).Name;
            ConsoleUtil.DisplayMessage($"Player's Current Location: {RoomName}");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display the current traveler inventory
        /// </summary>
        public void DisplayPlayerItemInventory()
        {
            ConsoleUtil.HeaderText = "Player Item Inventory";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Player's Items");
            ConsoleUtil.DisplayMessage("");

            List<int> itemInInventory = new List<int>();
            List<Item> itemsInLocation = _gameCastle.GetItemsByRoomID(0);


            if (itemsInLocation.Count != 0)
            {
                foreach (Item item in itemsInLocation)
                {
                    ConsoleUtil.DisplayMessage("Item Name: " + item.Name);
                    Console.WriteLine("Item Description: " + item.Description);
                    Console.WriteLine();
                }
            }
            else
            {
                ConsoleUtil.DisplayMessage("There are no items in your inventory at this time.");
            }
            DisplayContinuePrompt();
        }

        /// <summary>
        /// display treasure in player's inventory
        /// </summary>
        public void DisplayPlayerTreasureInventory()
        {
            ConsoleUtil.HeaderText = "Player's Treasure Inventory";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Player's Treasures");
            ConsoleUtil.DisplayMessage("");

            List<int> itemInInventory = new List<int>();
            List<Treasure> treasureInLocation = _gameCastle.GetTreasuresByRoomID(0);


            if (treasureInLocation.Count != 0)
            {
                foreach (Treasure treasure in treasureInLocation)
                {
                    ConsoleUtil.DisplayMessage("Treasure Name: " + treasure.Name);
                    Console.WriteLine("Treasure Description: " + treasure.Description);
                    Console.WriteLine();
                }
            }
            else
            {
                ConsoleUtil.DisplayMessage("There are no treasures in your inventory at this time.");
            }
            DisplayContinuePrompt();
        }

        public void DisplayLookAtItems()
        {
            ConsoleUtil.HeaderText = "Items in Current Location";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Items in Room");
            ConsoleUtil.DisplayMessage("");
            bool validResponse = false;
            int ID;
            int locationID;
            locationID = _gamePlayer.RoomID;
            List<int> validItemIds = new List<int>();

            List<Item> itemsInLocation = _gameCastle.GetItemsByRoomID(locationID);

            if (itemsInLocation.Count != 0)
            {
                while (!validResponse)
                {
                    foreach (Item item in itemsInLocation)
                    {
                        ConsoleUtil.DisplayMessage("Item Name: " + item.Name);
                        ConsoleUtil.DisplayMessage("Item ID: " + item.GameObjectID);
                        Console.WriteLine();
                        validItemIds.Add(item.GameObjectID);
                    }
                    Console.WriteLine();
                    ConsoleUtil.DisplayPromptMessage("Type the ID of the item you would like to look at and hit enter. ");
                    string response = Console.ReadLine();
                    if (Int32.TryParse(response, out ID))
                    {
                        if (validItemIds.Contains(ID))
                        {
                            Item theItem = _gameCastle.GetItemByID(ID);

                            Console.WriteLine();
                            Console.WriteLine();

                            Console.WriteLine(theItem.Description);
                            validResponse = true;
                        }
                        else
                        {
                            ConsoleUtil.DisplayReset();
                            Console.WriteLine();
                            ConsoleUtil.DisplayMessage("Invalid ID.");
                            DisplayContinuePrompt();
                        }
                    }
                    else
                    {
                        ConsoleUtil.DisplayReset();
                        Console.WriteLine();
                        ConsoleUtil.DisplayMessage("Invalid ID.");
                        DisplayContinuePrompt();
                    }
                }



            }
            else
            {
                Console.WriteLine();
                ConsoleUtil.DisplayMessage("There are no items in the room at this time. ");
            }
            DisplayContinuePrompt();

        }

        public void DisplayLookAtTreasure()
        {
            ConsoleUtil.HeaderText = "Treasure in Current Location";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Treasure in Room");
            ConsoleUtil.DisplayMessage("");

            bool validResponse = false;
            int ID;
            int locationID = _gamePlayer.RoomID;

            List<int> validTreasureIds = new List<int>();
            List<Treasure> treasureInLocation = _gameCastle.GetTreasuresByRoomID(locationID);

            if (treasureInLocation.Count != 0)
            {
                while (!validResponse)
                {
                    foreach (Treasure treasure in treasureInLocation)
                    {
                        Console.WriteLine();
                        ConsoleUtil.DisplayMessage("Treasure Name: " + treasure.Name);
                        ConsoleUtil.DisplayMessage("Treasure ID: " + treasure.GameObjectID);
                        Console.WriteLine();
                        validTreasureIds.Add(treasure.GameObjectID);
                    }
                    Console.WriteLine();
                    ConsoleUtil.DisplayPromptMessage("Type the ID of the treasure you would like to look at and hit enter. ");
                    string response = Console.ReadLine();
                    if (Int32.TryParse(response, out ID))
                    {
                        if (validTreasureIds.Contains(ID))
                        {
                            Treasure theTreasure = _gameCastle.GetTreasureByID(ID);

                            Console.WriteLine();
                            Console.WriteLine();

                            Console.WriteLine(theTreasure.Description);
                            validResponse = true;
                        }
                        else
                        {
                            ConsoleUtil.DisplayReset();
                            Console.WriteLine();
                            ConsoleUtil.DisplayMessage("Invalid ID.");
                            DisplayContinuePrompt();
                        }
                    }
                    else
                    {
                        ConsoleUtil.DisplayReset();
                        Console.WriteLine();
                        ConsoleUtil.DisplayMessage("Invalid ID.");
                        DisplayContinuePrompt();
                    }
                }
            }
            else
            {
                Console.WriteLine();
                ConsoleUtil.DisplayMessage("There is no treasure in the room at this time. ");
            }
            DisplayContinuePrompt();

        }

        public int DisplayCheckForItem()
        {
            int locationID;
            locationID = _gamePlayer.RoomID;
            int inRoom = 0;

            foreach (Item item in _gameCastle.Items)
            {
                if (item.RoomID == locationID)
                {
                    inRoom = 1;
                    break;
                }
            }
            return inRoom;
        }
        public int DisplayCheckForItemInventory()
        {
            int itemID = 0;
            _gameCastle.GetItemsByRoomID(itemID);
            int inRoom = 0;

            foreach (Item item in _gameCastle.Items)
            {
                if (item.RoomID == 0)
                {
                    inRoom = 1;
                    break;
                }
            }
            return inRoom;
        }
        public int DisplayCheckForTreasureInventory()
        {
            int itemID = 0;
            _gameCastle.GetTreasuresByRoomID(itemID);
            int inRoom = 0;

            foreach (Treasure treasure in _gameCastle.Treasures)
            {
                if (treasure.RoomID == 0)
                {
                    inRoom = 1;
                    break;
                }
            }
            return inRoom;
        }
        public int DisplayCheckForTreasure()
        {
            int locationID;
            int inRoom = 0;
            locationID = _gamePlayer.RoomID;


            foreach (Treasure treasure in _gameCastle.Treasures)
            {
                if (treasure.RoomID == locationID)
                {
                    inRoom = 1;
                    break;
                }
            }
            return inRoom;
        }



        public void DisplayPickUpItem()
        {
            ConsoleUtil.HeaderText = "Pick Up Item";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Items in room:");
            Console.WriteLine();

            bool validResponse = false;
            int locationID = _gamePlayer.RoomID;

            List<int> validItemIds = new List<int>();
            List<Item> itemsInLocation = _gameCastle.GetItemsByRoomID(locationID);

            if (itemsInLocation.Count != 0)
            {
                while (!validResponse)
                {
                    foreach (Item item in itemsInLocation)
                    {
                        Console.WriteLine();
                        ConsoleUtil.DisplayMessage("Item Name: " + item.Name);
                        ConsoleUtil.DisplayMessage("Item ID: " + item.GameObjectID);
                        Console.WriteLine();
                        validItemIds.Add(item.GameObjectID);
                    }
                    Console.WriteLine();
                    ConsoleUtil.DisplayPromptMessage("Type the ID of the item you would like to pick up and hit enter.");
                    int ID;
                    string response = Console.ReadLine();
                    if (Int32.TryParse(response, out ID))
                    {
                        if (validItemIds.Contains(ID))
                        {
                            Item theItem = _gameCastle.GetItemByID(ID);
                            if (_gamePlayer.RoomID == 4)
                            {
                                if (theItem.CanAddToInventory == true)
                                {
                                    _gamePlayer.PlayersItems.Add(theItem);
                                    theItem.RoomID = 0;
                                    validResponse = true;
                                }
                                else
                                {
                                    Console.WriteLine();
                                    ConsoleUtil.DisplayMessage("You must get that item from the Lame Boy.");
                                    Console.WriteLine();
                                    ConsoleUtil.DisplayMessage("Choose Speak to NPC from the menu.");
                                    Console.WriteLine();
                                    break;
                                }
                            }
                            if (_gamePlayer.RoomID == 6)
                            {
                                Item cloak = _gameCastle.GetItemByID(8);

                                if (cloak.RoomID == 0)
                                {
                                    if (theItem.CanAddToInventory == true)
                                    {
                                        _gamePlayer.PlayersItems.Add(theItem);
                                        theItem.RoomID = 0;
                                        validResponse = true;
                                    }
                                    else if (theItem.CanAddToInventory == false)
                                    {
                                        Item lockedBox = _gameCastle.GetItemByID(9);
                                        Item key = _gameCastle.GetItemByID(6);
                                        if (key.RoomID == 0)
                                        {
                                            Console.WriteLine();
                                            ConsoleUtil.DisplayMessage("You must put the key down to open the box.");
                                            Console.WriteLine();
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine();
                                            ConsoleUtil.DisplayMessage("You need to find and pick up the key to open the box.");
                                            Console.WriteLine();
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    ConsoleUtil.HeaderText = "Caught By The Dragon";
                                    ConsoleUtil.DisplayReset();
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    ConsoleUtil.DisplayMessage("You dared to try to take one of my Master's treasures?");
                                    Console.WriteLine();
                                    ConsoleUtil.DisplayMessage("I am the mighty dragon Morgoth, Guardian of the Tower.");
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    ConsoleUtil.DisplayMessage("***************************************");
                                    Console.WriteLine();
                                    ConsoleUtil.DisplayMessage("          Prepare to die!              ");
                                    Console.WriteLine();
                                    ConsoleUtil.DisplayMessage("***************************************");

                                    DisplayContinuePrompt();
                                    DisplayDeathByFireScreen();
                                }

                            }
                            if (theItem.CanAddToInventory == true)
                            {
                                _gamePlayer.PlayersItems.Add(theItem);
                                theItem.RoomID = 0;
                                validResponse = true;
                            }
                            if (theItem.CanAddToInventory == false && theItem.GameObjectID != 9)
                            {
                                Console.WriteLine();
                                ConsoleUtil.DisplayMessage("That item must be purchased.");
                                Console.WriteLine();
                                ConsoleUtil.DisplayMessage("Please choose \"Buy Item\" from the main menu.");
                                Console.WriteLine();
                                break;
                            }
                        }
                        else
                        {
                            ConsoleUtil.DisplayReset();
                            Console.WriteLine();
                            ConsoleUtil.DisplayMessage("Invalid ID");
                            DisplayContinuePrompt();
                        }
                    }
                    else
                    {
                        ConsoleUtil.DisplayReset();
                        Console.WriteLine();
                        ConsoleUtil.DisplayMessage("Invalid ID.");
                        DisplayContinuePrompt();
                    }
                }
            }

            else
            {
                Console.WriteLine();
                ConsoleUtil.DisplayMessage("There are no items in the room at this time.");
            }

            DisplayContinuePrompt();
        }


        public void DisplayPutDownItem()
        {
            ConsoleUtil.HeaderText = "Put Down Item";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Player's Items");
            ConsoleUtil.DisplayMessage("");

            bool validResponse = false;
            int locationID = _gamePlayer.RoomID;

            List<int> validItemIDs = new List<int>();
            List<Item> itemsInInventory = _gameCastle.GetItemsByRoomID(0);

            if (itemsInInventory.Count != 0)
            {
                while (!validResponse)
                {
                    foreach (Item item in itemsInInventory)
                    {
                        Console.WriteLine();
                        ConsoleUtil.DisplayMessage("Item Name: " + item.Name);
                        ConsoleUtil.DisplayMessage("Item ID: " + item.GameObjectID);
                        Console.WriteLine();
                        validItemIDs.Add(item.GameObjectID);
                    }
                    Console.WriteLine();
                    ConsoleUtil.DisplayPromptMessage("Type the ID of the item you would like to put down.");
                    int ID;
                    string response = Console.ReadLine();
                    if (Int32.TryParse(response, out ID))
                    {
                        if (validItemIDs.Contains(ID))
                        {
                            Item theItem = _gameCastle.GetItemByID(ID);
                            if (theItem.Name == "Key" && _gamePlayer.RoomID == 6)
                            {
                                DisplayWinnersScreen();
                            }
                            if (theItem.Name == "Potion" && _gamePlayer.RoomID == 4)
                            {
                                _gamePlayer.PlayersItems.Remove(theItem);
                                theItem.RoomID = -1;
                                Item theCloak = _gameCastle.GetItemByID(8);
                                theCloak.RoomID = 0;
                                Console.WriteLine();
                                ConsoleUtil.DisplayMessage("Thank you for the potion. The Cloak of Invisibility is now in your inventory.");
                                Console.WriteLine();
                                validResponse = true;

                            }
                            if (theItem.GameObjectID == 3 || theItem.GameObjectID == 4 && _gameCastle.GetItemByID(10).RoomID == 0)
                            {
                                int rand = RandomNumber();
                                if (rand == 1 || rand == 3 || rand == 5)
                                {
                                    Console.WriteLine();
                                    ConsoleUtil.DisplayMessage("I'm sorry, you chose the wrong bag of herbs.");
                                    Console.WriteLine();
                                    ConsoleUtil.DisplayMessage("That bag contained Poison Hemlock.");
                                    Console.WriteLine();
                                    ConsoleUtil.DisplayMessage("Your body is starting to exhibit complete paralysis.");
                                    Console.WriteLine();
                                    ConsoleUtil.DisplayMessage("Your lungs are the last to go with the exception of your mind.");
                                    Console.WriteLine();
                                    ConsoleUtil.DisplayMessage("You are completely aware of your surroundings as the gravediggers throw your seemingly lifeless body into the grave and bury you......alive!");
                                    Console.WriteLine();
                                    ConsoleUtil.DisplayMessage("So sorry.");
                                    _gamePlayer.Health = 10;
                                    DisplayExitPrompt();

                                }
                                else
                                {
                                    Console.WriteLine();
                                    ConsoleUtil.DisplayMessage("Well done. You chose the correct bag.");
                                    Console.WriteLine();
                                    ConsoleUtil.DisplayMessage("30 points has been added to your health.");
                                    _gamePlayer.PlayersItems.Remove(theItem);
                                    theItem.RoomID = -1;
                                    validResponse = true;
                                }
                            }
                            else
                            {
                                _gamePlayer.PlayersItems.Remove(theItem);
                                theItem.RoomID = -1;
                                validResponse = true;
                            }
                        }
                        else
                        {
                            ConsoleUtil.DisplayReset();
                            Console.WriteLine();
                            ConsoleUtil.DisplayMessage("Invalid ID.");
                            DisplayContinuePrompt();
                        }
                    }
                    else
                    {
                        ConsoleUtil.DisplayReset();
                        Console.WriteLine();
                        ConsoleUtil.DisplayMessage("Invalid ID.");
                        DisplayContinuePrompt();
                    }
                }
            }
            else
            {
                Console.WriteLine();
                ConsoleUtil.DisplayMessage("There are no items in your inventory at this time.");
            }
            DisplayContinuePrompt();
        }




        public void DisplayItemAll()
        {
            int locationID;
            locationID = _gamePlayer.RoomID;

            foreach (Item item in _gameCastle.Items)
            {
                if (item.RoomID == locationID)
                {
                    Console.WriteLine();
                    ConsoleUtil.DisplayMessage("Item Name: " + item.Name);
                    ConsoleUtil.DisplayMessage("Item ID: " + item.GameObjectID);
                    Console.WriteLine();
                    ConsoleUtil.DisplayMessage("Item Description: " + item.Description);
                    Console.WriteLine();
                }
            }
        }
        public void DisplayPickUpTreasure()
        {
            ConsoleUtil.HeaderText = "Pick Up Treasure";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Treasure in room:");
            ConsoleUtil.DisplayMessage("");

            bool validResponse = false;
            int ID;
            int locationID = _gamePlayer.RoomID;
            int gold = _gamePlayer.NumberOfGoldCoins;
            int silver = _gamePlayer.NumberOfSilverCoins;

            List<int> validTreasureIDs = new List<int>();
            List<Treasure> treasureInLocation = _gameCastle.GetTreasuresByRoomID(locationID);

            if (treasureInLocation.Count != 0)
            {
                while (!validResponse)
                {
                    foreach (Treasure treasure in treasureInLocation)
                    {
                        Console.WriteLine();
                        ConsoleUtil.DisplayMessage("Treasure Name: " + treasure.Name);
                        ConsoleUtil.DisplayMessage("Treasure ID: " + treasure.GameObjectID);
                        Console.WriteLine();
                        validTreasureIDs.Add(treasure.GameObjectID);
                    }
                    Console.WriteLine();
                    ConsoleUtil.DisplayPromptMessage("Type the ID of the treasure you would like to pick up and hit enter.");

                    string response = Console.ReadLine();
                    if (Int32.TryParse(response, out ID))
                    {
                        if (validTreasureIDs.Contains(ID))
                        {

                            Treasure theTreasure = _gameCastle.GetTreasureByID(ID);
                            _gamePlayer.PlayersTreasures.Add(theTreasure);
                            theTreasure.RoomID = 0;
                            if (theTreasure.Name == "Florin")
                            {
                                _gamePlayer.NumberOfGoldCoins++;
                                _gamePlayer.CoinValue = _gamePlayer.CoinValue + 100;
                            }
                            if (theTreasure.Name == "Denari")
                            {
                                _gamePlayer.NumberOfSilverCoins++;
                                _gamePlayer.CoinValue = _gamePlayer.CoinValue + 25;
                            }
                            validResponse = true;
                        }
                        else
                        {
                            ConsoleUtil.DisplayReset();
                            Console.WriteLine();
                            ConsoleUtil.DisplayMessage("Invalid ID.");
                            DisplayContinuePrompt();
                        }
                    }
                    else
                    {
                        ConsoleUtil.DisplayReset();
                        Console.WriteLine();
                        ConsoleUtil.DisplayMessage("Invalid ID.");
                        DisplayContinuePrompt();
                    }
                }
            }
            else
            {
                ConsoleUtil.DisplayMessage("There is no treasure in the room at this time.");
            }
            Console.WriteLine();
            ConsoleUtil.DisplayMessage($"Your coin value is ${_gamePlayer.CoinValue} .");
            Console.WriteLine();
            DisplayContinuePrompt();
        }


        public void DisplayPutDownTreasure()
        {
            ConsoleUtil.HeaderText = "Put Down Treasure";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Player's Treasure");
            ConsoleUtil.DisplayMessage("");

            bool validResponse = false;
            int locationID = _gamePlayer.RoomID;

            List<int> validTreasureIDs = new List<int>();
            List<Treasure> treasureInInventory = _gameCastle.GetTreasuresByRoomID(0);

            if (treasureInInventory.Count != 0)
            {
                while (!validResponse)
                {
                    foreach (Treasure treasure in treasureInInventory)
                    {
                        Console.WriteLine();
                        ConsoleUtil.DisplayMessage("Treasure Name: " + treasure.Name);
                        ConsoleUtil.DisplayMessage("Treasure ID: " + treasure.GameObjectID);
                        Console.WriteLine();
                        validTreasureIDs.Add(treasure.GameObjectID);
                    }
                    Console.WriteLine();
                    ConsoleUtil.DisplayPromptMessage("Type the ID of the treasure you would like to put down.");
                    int ID;
                    string response = Console.ReadLine();
                    if (Int32.TryParse(response, out ID))
                    {
                        if (validTreasureIDs.Contains(ID))
                        {
                            Treasure theTreasure = _gameCastle.GetTreasureByID(ID);
                            _gamePlayer.PlayersTreasures.Remove(theTreasure);
                            theTreasure.RoomID = -1;
                            if (theTreasure.Name == "Florin")
                            {
                                _gamePlayer.NumberOfGoldCoins--;
                            }
                            if (theTreasure.Name == "Denari")
                            {
                                _gamePlayer.NumberOfSilverCoins--;
                            }
                            validResponse = true;
                        }
                        else
                        {
                            ConsoleUtil.DisplayReset();
                            Console.WriteLine();
                            ConsoleUtil.DisplayMessage("Invalid ID.");
                            DisplayContinuePrompt();
                        }
                    }
                    else
                    {
                        ConsoleUtil.DisplayReset();
                        Console.WriteLine();
                        ConsoleUtil.DisplayMessage("Invalid ID.");
                        DisplayContinuePrompt();
                    }
                }
            }
            else
            {
                Console.WriteLine();
                ConsoleUtil.DisplayMessage("There are no treasures in your inventory at this time.");
            }
            DisplayContinuePrompt();
        }

        public void DisplaySpeakToNPC()
        {
            ConsoleUtil.HeaderText = "Speak to NPC";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("NPC in room:");
            Console.WriteLine();

            int locationID = _gamePlayer.RoomID;

            List<Treasure> treasuresInRoom = new List<Treasure>();
            List<int> validNPCIds = new List<int>();
            List<NPC> npcsInLocation = _gameCastle.GetNPCsByRoomID(locationID);

            if (npcsInLocation.Count != 0)
            {
                if (locationID == 3)
                {
                    foreach (NPC npc in npcsInLocation)
                    {
                        Console.WriteLine();
                        ConsoleUtil.DisplayMessage(npc.Name);
                        Console.WriteLine();
                        Console.WriteLine(npc.Message);
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    ConsoleUtil.DisplayMessage("Answer this riddle if you wish to live. This answer is a single word.");
                    Console.WriteLine();
                    Console.WriteLine();
                    int rand = RandomNumber();

                    Console.WriteLine(_gameCastle.GetRiddleByID(rand).Description);
                    string userResponse = Console.ReadLine().Trim().ToUpper();

                    if (userResponse == _gameCastle.GetRiddleByID(rand).Answer)
                    {
                        Console.WriteLine();
                        ConsoleUtil.DisplayMessage("Congratulations, that is the correct answer!");
                        Console.WriteLine();
                        ConsoleUtil.DisplayMessage("Here is a gold florin for your troubles.");
                        ConsoleUtil.DisplayMessage("Look around and pick it up.");

                        Treasure theTreasure = _gameCastle.GetTreasureByID(8);
                        if (theTreasure.RoomID == 0)
                            theTreasure = _gameCastle.GetTreasureByID(9);
                        if (theTreasure.RoomID == 0)
                            theTreasure = _gameCastle.GetTreasureByID(10);
                        if (theTreasure.RoomID == 0)
                            theTreasure = _gameCastle.GetTreasureByID(11);
                        if (theTreasure.RoomID == 0)
                            theTreasure = _gameCastle.GetTreasureByID(12);
                        if (theTreasure.RoomID == 0)
                            theTreasure = _gameCastle.GetTreasureByID(13);
                        if (theTreasure.RoomID == 0)
                            theTreasure = _gameCastle.GetTreasureByID(14);
                        if (theTreasure.RoomID == 0)
                            theTreasure = _gameCastle.GetTreasureByID(15);
                        theTreasure.RoomID = 3;
                    }
                    else
                    {
                        Console.WriteLine();
                        ConsoleUtil.DisplayMessage("That answer is incorrect. Please try again. ");
                        Console.WriteLine();
                        string userResponse2 = Console.ReadLine().Trim().ToUpper();

                        if (userResponse2 == _gameCastle.GetRiddleByID(rand).Answer)
                        {
                            Console.WriteLine();
                            ConsoleUtil.DisplayMessage("Congratulations, that is the correct answer!");
                            Console.WriteLine();
                            ConsoleUtil.DisplayMessage("Here is a gold florin for your troubles.");
                            ConsoleUtil.DisplayMessage("Look around and pick it up.");
                            Console.WriteLine();

                            Treasure theTreasure = _gameCastle.GetTreasureByID(8);
                            if (theTreasure.RoomID == 0)
                                theTreasure = _gameCastle.GetTreasureByID(9);
                            if (theTreasure.RoomID == 0)
                                theTreasure = _gameCastle.GetTreasureByID(10);
                            if (theTreasure.RoomID == 0)
                                theTreasure = _gameCastle.GetTreasureByID(11);
                            if (theTreasure.RoomID == 0)
                                theTreasure = _gameCastle.GetTreasureByID(12);
                            if (theTreasure.RoomID == 0)
                                theTreasure = _gameCastle.GetTreasureByID(13);
                            if (theTreasure.RoomID == 0)
                                theTreasure = _gameCastle.GetTreasureByID(14);
                            if (theTreasure.RoomID == 0)
                                theTreasure = _gameCastle.GetTreasureByID(15);
                            theTreasure.RoomID = 3;
                        }
                        else
                        {
                            Console.WriteLine();
                            ConsoleUtil.DisplayMessage("That answer is incorrect. This is your last chance! ");
                            Console.WriteLine();
                            string userResponse3 = Console.ReadLine().Trim().ToUpper();

                            if (userResponse3 == _gameCastle.GetRiddleByID(rand).Answer)
                            {
                                Console.WriteLine();
                                ConsoleUtil.DisplayMessage("Congratulations, that is the correct answer!");
                                Console.WriteLine();
                                ConsoleUtil.DisplayMessage("Here is a gold florin for your troubles.");
                                ConsoleUtil.DisplayMessage("Look around and pick it up.");
                                Console.WriteLine();

                                Treasure theTreasure = _gameCastle.GetTreasureByID(8);
                                if (theTreasure.RoomID == 0)
                                    theTreasure = _gameCastle.GetTreasureByID(9);
                                if (theTreasure.RoomID == 0)
                                    theTreasure = _gameCastle.GetTreasureByID(10);
                                if (theTreasure.RoomID == 0)
                                    theTreasure = _gameCastle.GetTreasureByID(11);
                                if (theTreasure.RoomID == 0)
                                    theTreasure = _gameCastle.GetTreasureByID(12);
                                if (theTreasure.RoomID == 0)
                                    theTreasure = _gameCastle.GetTreasureByID(13);
                                if (theTreasure.RoomID == 0)
                                    theTreasure = _gameCastle.GetTreasureByID(14);
                                if (theTreasure.RoomID == 0)
                                    theTreasure = _gameCastle.GetTreasureByID(15);
                                theTreasure.RoomID = 3;

                            }
                            else
                            {
                                ConsoleUtil.DisplayReset();
                                ConsoleUtil.HeaderText = "Death By Guillotine";
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine();
                                ConsoleUtil.DisplayMessage("**************************************************************************");
                                Console.WriteLine();
                                ConsoleUtil.DisplayMessage("OFF WITH YOUR HEAD!");
                                ConsoleUtil.DisplayMessage("On this day, " + _gamePlayer.Name + " ,died a gruesome death by beheadding. ");
                                Console.WriteLine();
                                ConsoleUtil.DisplayMessage("**************************************************************************");

                                DisplayContinuePrompt();
                                DisplayExitPrompt();
                            }
                        }
                    }
                }
                else if (locationID == 4)
                {
                    Item potion = _gameCastle.GetItemByID(5);
                    if (potion.RoomID == 0)
                    {
                        Console.WriteLine();
                        ConsoleUtil.DisplayMessage("If you have the potion for me choose \"Put Item Down\" from the menu.");
                        Console.WriteLine();
                    }
                    else
                    {
                        foreach (NPC npc in npcsInLocation)
                        {
                            Console.WriteLine();
                            ConsoleUtil.DisplayMessage(npc.Name);
                            Console.WriteLine();
                            Console.WriteLine(npc.Message);
                            Console.WriteLine();
                        }
                    }
                }
                else
                {
                    foreach (NPC npc in npcsInLocation)
                    {
                        Console.WriteLine();
                        ConsoleUtil.DisplayMessage(npc.Name);
                        Console.WriteLine();
                        Console.WriteLine(npc.Message);
                        Console.WriteLine();
                    }
                }
            }

            else
            {
                Console.WriteLine();
                ConsoleUtil.DisplayMessage("There are no NPCs in the room at this time.");
            }
            Console.WriteLine();
            DisplayContinuePrompt();
        }

        public static int RandomGoblin()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 7);

            return randomNumber;
        }
        public static int RandomNumber()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 9);

            return randomNumber;
        }

        public void BuyItem()
        {
            ConsoleUtil.HeaderText = "Buy Item";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Items to buy in room:");
            Console.WriteLine();

            bool validResponse = false;
            int locationID = _gamePlayer.RoomID;

            List<int> validItemIds = new List<int>();
            List<Item> itemsInLocation = _gameCastle.GetItemsByRoomID(locationID);

            if (itemsInLocation.Count != 0)
            {
                while (!validResponse)
                {
                    foreach (Item item in itemsInLocation)
                    {
                        Console.WriteLine();
                        ConsoleUtil.DisplayMessage("Item Name: " + item.Name);
                        ConsoleUtil.DisplayMessage("Item ID: " + item.GameObjectID);
                        Console.WriteLine();
                        validItemIds.Add(item.GameObjectID);
                    }
                    Console.WriteLine();
                    ConsoleUtil.DisplayPromptMessage("Type the ID of the item you would like to buy and hit enter.");
                    int ID;
                    string response = Console.ReadLine();
                    if (Int32.TryParse(response, out ID))
                    {
                        if (validItemIds.Contains(ID))
                        {

                            Item theItem = _gameCastle.GetItemByID(ID);
                            if (theItem.CanAddToInventory == false)
                            {
                                if (theItem.GameObjectID == 8)
                                {
                                    Console.WriteLine();
                                    ConsoleUtil.DisplayMessage("That item is not for sale. Speak to the Lame Boy.");
                                    break;
                                }
                                if (_gamePlayer.CoinValue >= theItem.Value)
                                {
                                    theItem.CanAddToInventory = true;
                                    _gamePlayer.CoinValue = _gamePlayer.CoinValue - theItem.Value;

                                    if (theItem.GameObjectID == 7)
                                    {
                                        _gamePlayer.Health = _gamePlayer.Health + 30;
                                        Console.WriteLine();
                                        ConsoleUtil.DisplayMessage("A warm meal does wonders to cure what ails you.");
                                        Console.WriteLine();
                                        ConsoleUtil.DisplayMessage("Your health has increased by 30!");
                                        Console.WriteLine();
                                        break;
                                    }
                                    else if (theItem.GameObjectID == 3 || theItem.GameObjectID == 4)
                                    {
                                        theItem.RoomID = 0;
                                        Console.WriteLine();
                                        ConsoleUtil.DisplayMessage($"The {theItem.Name} has been added to your inventory.");
                                        Console.WriteLine();
                                        ConsoleUtil.DisplayMessage("You must buy a glass of water to mix the contents with.");
                                        break;
                                    }
                                    else if (theItem.GameObjectID == 10)
                                    {
                                        Item BagA = _gameCastle.GetItemByID(3);
                                        Item BagB = _gameCastle.GetItemByID(4);

                                        if (BagA.RoomID == 0 || BagB.RoomID == 0)
                                            Console.WriteLine();
                                        ConsoleUtil.DisplayMessage("Put down the bags of herbs to mix into the water.");
                                        Console.WriteLine();
                                        DisplayPutDownItem();
                                        break;
                                    }
                                    else
                                    {
                                        theItem.RoomID = 0;
                                        Console.WriteLine();
                                        ConsoleUtil.DisplayMessage($"The {theItem.Name} has been added to your inventory.");
                                        Console.WriteLine();
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                    ConsoleUtil.DisplayMessage($"You need {theItem.Value } in coin for that item, but you only have {_gamePlayer.CoinValue}.");
                                    ConsoleUtil.DisplayMessage("Please come back when you have more money.");
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine();
                                ConsoleUtil.DisplayMessage("You can simply pick up that item.");
                            }

                        }
                        else
                        {
                            ConsoleUtil.DisplayReset();
                            Console.WriteLine();
                            ConsoleUtil.DisplayMessage("Invalid ID");
                            Console.WriteLine();
                            DisplayContinuePrompt();
                        }
                    }
                    else
                    {
                        ConsoleUtil.DisplayReset();
                        Console.WriteLine();
                        ConsoleUtil.DisplayMessage("Invalid ID.");
                        DisplayContinuePrompt();
                    }
                }
            }

            else
            {
                Console.WriteLine();
                ConsoleUtil.DisplayMessage("There are no items in the room at this time.");
            }
            Console.WriteLine();
            DisplayContinuePrompt();
        }


        public void DisplayWinnersScreen()
        {
            ConsoleUtil.DisplayReset();
            ConsoleUtil.HeaderText = "The Winner";
            Console.WriteLine();
            ConsoleUtil.DisplayMessage($"Congratulations, {_gamePlayer.Name}, you have completed all the tasks in the castle!");
            Console.WriteLine();
            ConsoleUtil.DisplayMessage("The crown contained within is yours to wear as the new ruler of this kingdom.");
            Console.WriteLine();
            ConsoleUtil.DisplayMessage("We have been waiting for someone kind enough to help the Lame Boy,");
            ConsoleUtil.DisplayMessage("adventurous enough to search the castle and find the key,");
            ConsoleUtil.DisplayMessage("strong enough to survive the goblin attacks, ");
            ConsoleUtil.DisplayMessage("and smart enough to outwit the dragon.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("**********************************************************************************************"); 
            Console.WriteLine("*                                                                                            *");
            Console.WriteLine($"*           Long live {_gamePlayer.Name}, ruler of Medieval Mayhem!                         *");
            Console.WriteLine("*                                                                                            *");
            Console.WriteLine("**********************************************************************************************");
            DisplayContinuePrompt();
            DisplayExitPrompt();
        }

        public void DisplayDeathByFireScreen()
        {
            ConsoleUtil.DisplayReset();
            ConsoleUtil.HeaderText = "Death By Fire-Breathing Dragon";
            Console.WriteLine();
            Console.WriteLine();
            ConsoleUtil.DisplayMessage($"Here lies {_gamePlayer.Name}, the thieving, miserable, wretch who tried to steal from the castle.");
            Console.WriteLine();
            Console.WriteLine();
            ConsoleUtil.DisplayMessage("Burnt to a crisp, only ashes remain to serve as a warning for any who dare trespass into my domain.");
            Console.WriteLine();
            Console.WriteLine();
            DisplayContinuePrompt();
            DisplayExitPrompt();
        }

        public void DisplayHealth()
        {


            if (_gamePlayer.Health < 50)
            {
                Console.WriteLine("******************");
                Console.WriteLine("*                *");
                Console.WriteLine($"*  HEALTH = { _gamePlayer.Health}%  *");
                Console.WriteLine("*                *");
                Console.WriteLine("******************");
            }
            else
            {
                Console.WriteLine("******************");
                Console.WriteLine("*                *");
                Console.WriteLine($"*  HEALTH = { _gamePlayer.Health}%  *");
                Console.WriteLine("*                *");
                Console.WriteLine("******************");
            }
        }
        #endregion
    }
}
