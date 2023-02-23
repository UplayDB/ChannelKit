using System.Text;

using WatsonWebsocket;

namespace ChannelKit
{
    public class WebSocket
    {
        public WatsonWsClient _Client;
        //upc_remote_actions,upc_free_games_updated,upc_shareplay_guest_invite,upc_shareplay_guest_invite_rsp,FRIENDS_STATUS_CHANGED,upc_shareplay_guest_interrupts_session,upc_shareplay_stop_session,wallet-balance-update,upc_channel_metadata_updated,upc_channel_created,upc_channel_membership_deleted,upc_channel_message_created,upc_channel_memberships_created
        public WebSocket(string sessionId,string token)
        {
            string Con = "wss://public-ws-ubiservices.ubi.com/v2/websocket?" +
                "NotificationTypes=upc_remote_actions,upc_free_games_updated,upc_shareplay_guest_invite,upc_shareplay_guest_invite_rsp,FRIENDS_STATUS_CHANGED,upc_shareplay_guest_interrupts_session,upc_shareplay_stop_session,wallet-balance-update,upc_channel_metadata_updated,upc_channel_created,upc_channel_membership_deleted,upc_channel_message_created,upc_channel_memberships_created" +
                "&SpaceIds=e17be87d-2996-4f3b-97c4-19bb2dae2933,45d58365-547f-4b45-ab5b-53ed14cc79ed,c0539e9c-90ab-4af8-a2d6-ef7b3883f430" +
                "&Ubi-AppId=f35adcb5-1911-440c-b1c9-48fdc1701c68" +
                "&Ubi-SessionId="+ sessionId +
                "&Authorization=Ubi_v1%20t%3D" + token;

            _Client = new(new Uri(Con));
            _Client.ServerConnected += _Client_ServerConnected;
            _Client.ServerDisconnected += _Client_ServerDisconnected;
            _Client.MessageReceived += _Client_MessageReceived;
        }
        public void Start()
        {
            _Client.Start();
        }

        public void Stop()
        {
            _Client.Stop();
        }

        private void _Client_ServerDisconnected(object? sender, EventArgs e)
        {
            Console.WriteLine("Disconnected from Server");
        }

        private void _Client_ServerConnected(object? sender, EventArgs e)
        {
            Console.WriteLine("Connected to Server");
        }

        private void _Client_MessageReceived(object? sender, MessageReceivedEventArgs e)
        {
            Console.WriteLine(e.MessageType);
            switch (e.MessageType)
            {   
                case System.Net.WebSockets.WebSocketMessageType.Text:
                    var x = UTF8Encoding.UTF8.GetString(e.Data);
                    Console.WriteLine(x);
                    break;
                case System.Net.WebSockets.WebSocketMessageType.Binary:
                    Console.WriteLine(BitConverter.ToString(e.Data.ToArray()));
                    break;
                case System.Net.WebSockets.WebSocketMessageType.Close:
                    break;
                default:
                    break;
            }
        }
    }
}
