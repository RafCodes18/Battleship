using HiddenBattleship.BL.Models;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using PB.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HiddenBattleShip.WPFUI
{
    /// <summary>
    /// Interaction logic for GameList.xaml
    /// </summary>
    public partial class GameList : Window
    {

        // list of entities
        List<Game> games = new List<Game>();
        List<Player> players = new List<Player>();
        List<ChatHistory> chatHistories = new List<ChatHistory>();
        List<GameMoves> gameMoves = new List<GameMoves>();
        List<Ship> ships = new List<Ship>();

        string selectedEntity;

        string APIAddress = "https://localhost:7270/api/";
        ApiClient apiClient;
        
        private readonly ILogger<GameList> logger;

        public GameList()
        {
            InitializeComponent();
            apiClient = new ApiClient(APIAddress);
            string selectedEntity = "";
        }

        public GameList(ILogger<GameList> logger)
        {
            InitializeComponent();
            apiClient = new ApiClient(APIAddress);
            this.logger = logger;
            string selectedEntity = "";
        }

        private void btnGetGames_Click(object sender, RoutedEventArgs e)
        {
            selectedEntity = "Game";

            try
            {
                games = apiClient.GetList<Game>(typeof(Game).Name);

                dgGames.ItemsSource = null;
                dgGames.ItemsSource = games;

                throw new Exception("Dependency Injection is cool. I have " + games.Count + " games.");

            }
            catch (Exception ex)
            {
                logger.LogWarning("Error: {UserId}", " ");
            }
        }

        private void btnGetChatHistory_Click(object sender, RoutedEventArgs e)
        {

            selectedEntity = "ChatHistory";

            try
            {

                chatHistories = apiClient.GetList<ChatHistory>(typeof(ChatHistory).Name);

                dgGames.ItemsSource = null;
                dgGames.ItemsSource = chatHistories;

                throw new Exception("Dependency Injection is cool. I have " + chatHistories.Count + " chat messages.");

            }
            catch (Exception ex)
            {
                logger.LogWarning("Error: {UserId}", " ");
            }

        }

        private void btnGetPlayers_Click(object sender, RoutedEventArgs e)
        {
            selectedEntity = "Player";

            try
            {
                players = apiClient.GetList<Player>(typeof(Player).Name);

                dgGames.ItemsSource = null;
                dgGames.ItemsSource = players;


                throw new Exception("Dependency Injection is cool. I have " + players.Count + " players.");

            }
            catch (Exception ex)
            {
                logger.LogWarning("Error: {UserId}", " ");
            }

        }

        private void btnGameMoves_Click(object sender, RoutedEventArgs e)
        {
            selectedEntity = "GameMove";
            try
            {
                gameMoves = apiClient.GetList<GameMoves>(typeof(GameMoves).Name);

                dgGames.ItemsSource = null;
                dgGames.ItemsSource = gameMoves;


                throw new Exception("Dependency Injection is cool. I have " + gameMoves.Count + " players.");

            }
            catch (Exception ex)
            {
                logger.LogWarning("Error: {UserId}", " ");
            }

        }

        private void btnGetShips_Click(object sender, RoutedEventArgs e)
        {
            selectedEntity = "Ship";
            try
            {
                ships = apiClient.GetList<Ship>(typeof(Ship).Name);

                dgGames.ItemsSource = null;
                dgGames.ItemsSource = ships;


                throw new Exception("Dependency Injection is cool. I have " + ships.Count + " players.");

            }
            catch (Exception ex)
            {
                logger.LogWarning("Error: {UserId}", " ");
            }
        }



        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (selectedEntity == "Game")
            {
                var selectedGame = dgGames.SelectedItem as Game;
                if (selectedGame != null)
                {

                    var result = apiClient.Put(selectedGame, "Game", selectedGame.Id);

                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Update successful");
                        btnGetGames_Click(sender, e); 
                    }
                    else
                    {
                        MessageBox.Show("Update failed");
                    }

                    // old way
                    //games = apiClient.GetList<Game>(typeof(Game).Name);
                    //dgGames.ItemsSource = null;
                    //dgGames.ItemsSource = games;

                }
            }
            else if (selectedEntity == "ChatHistory")
            {
                var selectedChatHistory = dgGames.SelectedItem as ChatHistory;
                if (selectedChatHistory != null)
                {

                    var result = apiClient.Put(selectedChatHistory, "ChatHistory", selectedChatHistory.Id);

                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Update successful");
                        btnGetChatHistory_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Update failed");
                    }
                }
            }
            else if (selectedEntity == "Player")
            {
                var selectedPlayer = dgGames.SelectedItem as Player;
                if (selectedPlayer != null)
                {

                    var result = apiClient.Put(selectedPlayer, "Player", selectedPlayer.Id);

                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Update successful");
                        btnGetPlayers_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Update failed");
                    }
                }
            }
            else if (selectedEntity == "GameMove")
            {
                var selectedGameMove = dgGames.SelectedItem as GameMoves;
                if (selectedGameMove != null)
                {

                    var result = apiClient.Put(selectedGameMove, "GameMoves", selectedGameMove.MoveId);

                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Update successful");
                        btnGameMoves_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Update failed");
                    }
                }
            }
            else if (selectedEntity == "Ship")
            {
                var selectedShip = dgGames.SelectedItem as Ship;
                if (selectedShip != null)
                {

                    var result = apiClient.Put(selectedShip, "Ship", selectedShip.Id);
                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Update successful");
                        btnGetShips_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Update failed");
                    }

                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedEntity == "Game")
            {
                var selectedGame = dgGames.SelectedItem as Game;
                if (selectedGame != null)
                {
                    
                    var result = apiClient.Delete("Game", selectedGame.Id);
                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Delete successful");
                        btnGetGames_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Delete failed");
                    }

                }
            } 
            else if (selectedEntity == "ChatHistory")
            {
                var selectedChatHistory = dgGames.SelectedItem as ChatHistory;
                if (selectedChatHistory != null)
                {

                    var result = apiClient.Delete("ChatHistory", selectedChatHistory.Id);
                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Delete successful");
                        btnGetChatHistory_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Delete failed");
                    }
                    
                }
            }
            else if (selectedEntity == "Player")
            {
                var selectedPlayer = dgGames.SelectedItem as Player;
                if (selectedPlayer != null)
                {

                    var result = apiClient.Delete("Player", selectedPlayer.Id);

                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Delete successful");
                        btnGetPlayers_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Delete failed");
                    }
                }
            }
            else if (selectedEntity == "GameMove")
            {
                var selectedGameMove = dgGames.SelectedItem as GameMoves;
                if (selectedGameMove != null)
                {

                    var result = apiClient.Delete("GameMoves", selectedGameMove.MoveId);

                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Delete successful");
                        btnGameMoves_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Delete failed");
                    }
                }
            }
            else if (selectedEntity == "Ship")
            {
                var selectedShip = dgGames.SelectedItem as Ship;
                if (selectedShip != null)
                {

                    var result = apiClient.Delete("Ship", selectedShip.Id);

                    if (result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Delete successful");
                        btnGetShips_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Delete failed");
                    }
                }
            }

        }

        
    }
}