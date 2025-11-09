using DBPMessanger.JSON.recevie;
using DBPMessanger.MessageProtocol.send;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace DBPMessanger.Managers
{
    internal class WebSocketManager
    {
        private ClientWebSocket? ws;
        public event Action<RChatJSON> OnMessageReceived;

        public static WebSocketManager Instance = new WebSocketManager();
        private WebSocketManager() { }

        public async Task Connect(string url, long userId)
        {
            try
            {
                ws = new ClientWebSocket();
                Uri serverUri = new Uri(url);
                await ws.ConnectAsync(serverUri, CancellationToken.None);
                await Send(new SAuthJSON(Constants.Auth, userId));

                // 
                _ = Task.Run(() => ReceiveLoop());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public async Task Send(SParentJSON msg)
        {
            if(ws != null && ws.State == WebSocketState.Open)
            {
                try
                {
                    string json = msg.SerializeJSON();
                    byte[] bytes = Encoding.UTF8.GetBytes(json);
                    await ws.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);

                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private async Task ReceiveLoop()
        {
            var buffer = new byte[Constants.BufSize];

            while (ws != null && ws.State == WebSocketState.Open)
            {
                try
                {
                    using var ms = new MemoryStream();
                    WebSocketReceiveResult result;

                    do
                    {
                        result = await ws.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                        ms.Write(buffer, 0, result.Count);
                    }
                    while (!result.EndOfMessage);

                    // 받는 메세지는 채팅 밖에 없기 때문에 바로 처리 
                    string json = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    var chatMsg = JsonSerializer.Deserialize<RChatJSON>(json);
                    if (chatMsg != null)
                        OnMessageReceived?.Invoke(chatMsg);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    break;
                }
            }
        }
    }
}
