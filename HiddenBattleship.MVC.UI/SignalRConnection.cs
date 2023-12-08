 
using Microsoft.AspNetCore.SignalR.Client;

namespace HiddenBattleship.MVC.UI
{
    public class SignalRConnection
    {
        private string hubAddress;
        HubConnection _connection;
 
 
        public SignalRConnection(string hubAddress)
        {
            this.hubAddress = hubAddress;
        }
        public void Start()
        {
            _connection = new HubConnectionBuilder().Build();

            _connection.On<string, string>("RecieveMessage", (s1, s2) => OnSend(s1, s2));
            _connection.StartAsync();
        }

        private static void OnSend(string user, object message)
        {
            Console.WriteLine(user + " " + message);
        }
    }
}
