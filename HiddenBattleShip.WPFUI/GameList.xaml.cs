using HiddenBattleship.BL.Models;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using PB.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
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
        List<Game> games = new List<Game>();
        List<Player> players = new List<Player>();
        List<ChatHistory> chatHistories = new List<ChatHistory>();
        string selectedEntity;

        string APIAddress = "https://localhost:7270/api/";
        ApiClient apiClient;
        int userInput;
        private readonly ILogger<GameList> logger;

        public GameList()
        {
            InitializeComponent();
            apiClient = new ApiClient(APIAddress);
            userInput = 0;
            string selectedEntity = "";
        }

        public GameList(ILogger<GameList> logger)
        {
            InitializeComponent();
            apiClient = new ApiClient(APIAddress);
            this.logger = logger;
            userInput = 0;
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

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var selectedGame = dgGames.SelectedItem as Game;
            if (selectedGame != null)
            {
                // Use 'selectedGame' for further operations

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

                    games = apiClient.GetList<Game>(typeof(Game).Name);
                    dgGames.ItemsSource = null;
                    dgGames.ItemsSource = games;

                }
            } else if (selectedEntity == )
            
        }
    }
}