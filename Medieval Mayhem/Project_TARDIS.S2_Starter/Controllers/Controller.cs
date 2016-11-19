using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    public class Controller
    {
        #region FIELDS

        private bool _usingGame;

        //
        // declare all objects required for the game
        // Note - these field objects do not require properties since they
        //        are not accessed outside of the controller
        //
        private ConsoleView _gameConsoleView;
        private Player _gamePlayer;
        private Castle _gameCastle;

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            InitializeGame();

            //
            // instantiate a Player object
            //
            _gamePlayer = new Player();

            //
            // instantiate a ConsoleView object
            //
            _gameConsoleView = new ConsoleView(_gamePlayer, _gameCastle);

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the game 
        /// </summary>
        private void InitializeGame()
        {
            _usingGame = true;
            _gameCastle = new Castle();
            _gamePlayer = new Player();
            _gameConsoleView = new ConsoleView(_gamePlayer, _gameCastle);

        }

        /// <summary>
        /// method to manage the application setup and control loop
        /// </summary>
        private void ManageGameLoop()
        {
            PlayerAction travelerActionChoice;

            _gameConsoleView.DisplayWelcomeScreen();

            InitializeMission();

            //
            // game loop
            //
            while (_usingGame)
            {
                int health = _gamePlayer.Health;

                // get a menu choice from the ConsoleView object
                //
                travelerActionChoice = _gameConsoleView.DisplayGetPlayerActionChoice();
                if (health <= 0)
                {
                    ConsoleUtil.DisplayReset();
                    Console.WriteLine();
                    ConsoleUtil.DisplayMessage("The last goblin attack was too much for your level of health.");
                    ConsoleUtil.DisplayMessage("Game Over");
                    _gameConsoleView.DisplayContinuePrompt();
                    break;
                }
                //
                // choose an action based on the user's menu choice
                //
                switch (travelerActionChoice)
                {
                    case PlayerAction.NONE:
                        break;
                    case PlayerAction.BuyItem:
                        _gameConsoleView.BuyItem();
                        break;
                    case PlayerAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        break;
                    case PlayerAction.LookAtItem:
                        _gameConsoleView.DisplayLookAtItems();
                        break;
                    case PlayerAction.LookAtTreasure:
                        _gameConsoleView.DisplayLookAtTreasure();
                        break;
                    case PlayerAction.PickUpItem:
                        _gameConsoleView.DisplayPickUpItem();
                        break;
                    case PlayerAction.PickUpTreasure:
                        _gameConsoleView.DisplayPickUpTreasure();
                        break;
                    case PlayerAction.PutDownItem:
                        _gameConsoleView.DisplayPutDownItem();
                        break;
                    case PlayerAction.PutDownTreasure:
                        _gameConsoleView.DisplayPutDownTreasure();
                        break;
                    case PlayerAction.Travel:
                        _gamePlayer.RoomID = _gameConsoleView.DisplayGetPlayersNewDestination().RoomID;
                        break;
                    case PlayerAction.SpeakToNPC:
                        _gameConsoleView.DisplaySpeakToNPC();
                        break;
                    case PlayerAction.PlayerInfo:
                        _gameConsoleView.DisplayTravelerInfo();
                        break;
                    case PlayerAction.PlayerItems:
                        _gameConsoleView.DisplayPlayerItemInventory();
                        break;
                    case PlayerAction.PlayerTreasure:
                        _gameConsoleView.DisplayPlayerTreasureInventory();
                        break;
                    case PlayerAction.ListCastleRooms:
                        _gameConsoleView.DisplayListAllCastleRooms();
                        break;
                    case PlayerAction.ListItems:
                        _gameConsoleView.DisplayListAllGameItems();
                        break;
                    case PlayerAction.ListTreasures:
                        _gameConsoleView.DisplayListAllGameTreasures();
                        break;
                    case PlayerAction.Exit:
                        _usingGame = false;
                        break;
                    default:
                        break;
                }
            }

            _gameConsoleView.DisplayExitPrompt();

            //
            // close the application
            //
            Environment.Exit(1);
        }





        /// <summary>
        /// initialize the traveler's starting mission  parameters
        /// </summary>
        private void InitializeMission()
        {
            _gameConsoleView.DisplayGameSetupIntro();
            _gamePlayer.Name = _gameConsoleView.DisplayGetPlayersName();
            _gamePlayer.Rank = _gameConsoleView.DisplayGetPlayersRank();
            _gamePlayer.Health = 80;
            _gamePlayer.RoomID = _gameConsoleView.DisplayGetPlayersNewDestination().RoomID;

            // 
            // add initial items to the player's inventory
            //
            AddTreasureToPlayersTreasure(1);
            _gamePlayer.CoinValue = 25;
        }

        /// <summary>
        /// add a game item to the player's inventory
        /// </summary>
        /// <param name="itemID">game item ID</param>
        private void AddItemToPlayersInventory(int itemID)
        {
            Item item;

            item = _gameCastle.GetItemByID(itemID);
            item.RoomID = 0;

            _gamePlayer.PlayersItems.Add(item);
        }

        /// <summary>
        /// add a game treasure to the traveler's inventory
        /// </summary>
        /// <param name="itemID">game item ID</param>
        private void AddTreasureToPlayersTreasure(int treasureID)
        {
            Treasure treasure;

            treasure = _gameCastle.GetTreasureByID(treasureID);
            treasure.RoomID = 0;

            _gamePlayer.PlayersTreasures.Add(treasure);
        }

        #endregion
    }
}
