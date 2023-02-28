using RestSharp;
using static ChannelKit.ReadOnly;

namespace ChannelKit
{
    public class ChannelSpace
    {
        public static string GetMessages(string token, string session, string channelId, int limit = 1)
        {
            var url = $"https://{Base}/v1/spaces/{SpaceID}/channels/{channelId}/messages?limit={limit}";
            var client = new RestClient(url);
            var request = new RestRequest();

            request.AddHeader("Authorization", $"Ubi_v1 t={token}");
            request.AddHeader("User-Agent", "Massgate");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Ubi-AppId", "f68a4bb5-608a-4ff2-8123-be8ef797e0a6");
            request.AddHeader("Ubi-SessionId", session);
            RestResponse response = client.GetAsync(request).Result;
            if (response.Content != null)
            {
                Console.WriteLine(response.StatusCode);
                return response.Content;
            }
            return string.Empty;
        }

        public static string CreateChannel(string token, string session, string channelType, List<string> members)
        {
            var url = $"https://{Base}/v1/spaces/{SpaceID}/channels";
            var client = new RestClient(url);
            var request = new RestRequest();

            request.AddHeader("Authorization", $"Ubi_v1 t={token}");
            request.AddHeader("User-Agent", "Massgate");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Ubi-AppId", "f68a4bb5-608a-4ff2-8123-be8ef797e0a6");
            request.AddHeader("Ubi-SessionId", session);

            request.AddBody("{\"channel\":{\"type\":\"{" + channelType + "}\"},\"members\":[\"" + string.Join(",", members) + "\"]}");

            RestResponse response = client.PostAsync(request).Result;
            if (response.Content != null)
            {
                Console.WriteLine(response.StatusCode);
                return response.Content;
            }
            return string.Empty;
        }
    }
}
