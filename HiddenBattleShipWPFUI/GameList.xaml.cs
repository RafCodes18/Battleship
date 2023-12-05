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
        string APIAddress = "https://localhost:7270/swagger/v1/swagger.json";
        ApiClient apiClient;
        private readonly ILogger<GameList> logger;

        public GameList()
        {
            InitializeComponent();
            apiClient = new ApiClient(APIAddress);
        }

        public GameList(ILogger<GameList> logger)
        {
            InitializeComponent();
            apiClient = new ApiClient(APIAddress);
            this.logger = logger;
        }

        private void btnGetGames_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                games = apiClient.GetList<Game>(typeof(Game).Name);

                dgGames.ItemsSource = null;
                dgGames.ItemsSource = games;

                throw new Exception("Dependency Injection is cool. I have " + games.Count + " movies.");

            }
            catch (Exception ex)
            {
                logger.LogWarning("Error: {UserId}", " ");
            }
        }
    }
}
