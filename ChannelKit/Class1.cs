using RestSharp;

namespace ChannelKit
{
    public class Class1
    {
        public static string WebSocketCon = "public-ws-ubiservices.ubi.com/v2/websocket?SpaceIds=e17be87d-2996-4f3b-97c4-19bb2dae2933,45d58365-547f-4b45-ab5b-53ed14cc79ed,c0539e9c-90ab-4af8-a2d6-ef7b3883f430&NotificationTypes=upc_remote_actions,upc_free_games_updated,upc_shareplay_guest_invite,upc_shareplay_guest_invite_rsp,FRIENDS_STATUS_CHANGED,upc_shareplay_guest_interrupts_session,upc_shareplay_stop_session,wallet-balance-update,upc_channel_metadata_updated,upc_channel_created,upc_channel_membership_deleted,upc_channel_message_created,upc_channel_memberships_created";



        public static string Base = "channel-service.upc.ubi.com";
        public static void Test(string token,string session)
        {
            var client = new RestClient($"https://{Base}/v1/profiles/me/channels?membershipType=ACTIVE&spaceId=c0539e9c-90ab-4af8-a2d6-ef7b3883f430");
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
                Console.WriteLine(response.Content);
            }

        }

    }
}