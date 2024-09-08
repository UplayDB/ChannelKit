using RestSharp;
using static ChannelKit.ReadOnly;

namespace ChannelKit
{
    public class ChannelProfile
    {

        public static string GetActiveChannels(string token,string session, int PageToken = 0)
        {
            var url = $"https://{Base}/v1/profiles/me/channels?membershipType=ACTIVE&spaceId={SpaceID}";

            if (PageToken != 0)
            {
                url += $"&pageToken={PageToken}";
            }
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

        public static string GetPendingChannels(string token, string session)
        {
            var client = new RestClient($"https://{Base}/v1/profiles/me/channels?membershipType=PENDING&spaceId={SpaceID}");
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

        public static string GetMessagesAck(string token, string session, string channelId)
        {
            var url = $"https://{Base}/v1/profiles/me/channels/{channelId}/messages/ack?spaceId={SpaceID}";
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
    }
}