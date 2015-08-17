using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace RumbleClientLib
{
    public class RumbleClient
    {
        private static HttpClient _client = null;
        private static string _baseUri = null;
        JavaScriptSerializer _serializer = null;

        public RumbleClient(string address)
        {
            // Create an HttpClient instance
            _client = new HttpClient();
            _baseUri = address;
            _serializer = new JavaScriptSerializer();
        }

        //static void Main(string[] args)
        //{


        //    // Send a request asynchronously continue when complete
        //    _client.GetAsync(_baseUri).ContinueWith(
        //        (requestTask) =>
        //        {
        //          // Get HTTP response from completed task.
        //          HttpResponseMessage response = requestTask.Result;

        //          // Check that response was successful or throw exception
        //          response.EnsureSuccessStatusCode();

        //          // Read response asynchronously as JsonValue and write out top facts for each country
        //          response.Content.ReadAsAsync<string>().ContinueWith(
        //                (readTask) =>
        //                {
        //                    Console.WriteLine("First 50 countries listed by The World Bank...");
        //                    foreach (var country in readTask.Result[1])
        //                    {
        //                        Console.WriteLine("   {0}, Country Code: {1}, Capital: {2}, Latitude: {3}, Longitude: {4}",
        //                            country.Value["name"],
        //                            country.Value["iso2Code"],
        //                            country.Value["capitalCity"],
        //                            country.Value["latitude"],
        //                            country.Value["longitude"]);
        //                    }
        //                });
        //        });

        //    Console.WriteLine("Hit ENTER to exit...");
        //    Console.ReadLine();
        //}

        //public async Task<string> GetAsync()
        //{
        //    // Send a request asynchronously continue when complete
        //    HttpResponseMessage response = await _client.GetAsync(_baseUri);

        //    // Check that response was successful or throw exception
        //    response.EnsureSuccessStatusCode();

        //    // Read response asynchronously as JsonValue and write out top facts for each country
        //    var content = response.Content.ReadAsStringAsync().Result;
        //    return content;
        //}

        //public async Task RunAsync()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        // TODO - Send HTTP requests
        //    }
        //}

        //private async void Send(string name, string message)
        //{ 
        //}

        //public async void Register(string username, string password, string handle)
        //{
        //}

        public async void Login(string username, string password)
        {
            var uri = string.Format("{0}/active_user", _baseUri);
            var data = new FormUrlEncodedContent(new Dictionary<string, string>{
                { "username", username },
                { "password", password }
            });
            var response = await _client.PostAsync(uri, data);

            response.EnsureSuccessStatusCode();
        }

        //public async void Logout()
        //{
        //}

        public async void SendMessage(string roomName, string message)
        {
            var uri = string.Format("{0}/message/{1}", _baseUri, roomName);
            var response = await _client.PostAsync(uri, new StringContent(message));

            response.EnsureSuccessStatusCode();
        }

        public async Task GetMessages(string roomName, DateTime start, DateTime end)
        {
            var httpClient = new HttpClient();
            var uri = string.Format("{0}/messages/{1}/{2}/{3}", roomName, start, end);
            var response = await httpClient.GetAsync(uri);

            //will throw an exception if not successful
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            await Task.Run(() => _serializer.Deserialize<object>(content));
        }

        //public async void createroom(string roomname)
        //{
        //}

        //public async void destroyroom(string roomname)
        //{
        //}

        //public async void joinroom(string roomname)
        //{
        //}

        //public async void leaveroom(string roomname)
        //{
        //}

        //public async void getrooms()
        //{
        //}

        //public async void getroommembers(string roomname)
        //{
        //}
    }
}
