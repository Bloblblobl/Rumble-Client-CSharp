using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RumbleClientLib
{
    public class RumbleClient
    {
        public void Run()
        {
            RunAsync().Wait();
        }

        public async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                // TODO - Send HTTP requests
            }
        }

        private void Send(Dictionary<string, string> data)
        {
            var comment = "hello world";
            var questionId = 1;

            var formContent = new FormUrlEncodedContent(data);

            var myHttpClient = new HttpClient();
            var response = await myHttpClient.PostAsync(uri.ToString(), formContent);
        }

        public void Register(string username, string password, string handle)
        {
        }

        public void Login(string username, string password)
        {
        }

        public void Logout()
        {
        }

        public void SendMessage(string roomName, string message)
        {
        }
        
        public void GetMessages(string roomName, DateTime start, DateTime end)
        {
        }

        public void CreateRoom(string roomName)
        {
        }

        public void DestroyRoom(string roomName)
        {
        }

        public void JoinRoom(string roomName)
        {
        }

        public void LeaveRoom(string roomName)
        {
        }

        public void GetRooms()
        {
        }

        public void GetRoomMembers(string roomName)
        {
        }
    }
}
