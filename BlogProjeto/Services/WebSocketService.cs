using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlogProjeto.Services
{
    public class WebSocketService : IWebSocketService
    {
        private static WebSocket _webSocket;

        public async Task IniciarWebSocket(WebSocket webSocket)
        {
            _webSocket = webSocket;

            byte[] buffer = new byte[1024];
            WebSocketReceiveResult result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            while (!result.CloseStatus.HasValue)
            {
                string mensagemRecebida = Encoding.UTF8.GetString(buffer, 0, result.Count);
                Console.WriteLine($"Mensagem recebida: {mensagemRecebida}");
                result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }

            await _webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }

        public async Task EnviarMensagemWebSocket(string mensagem)
        {
            if (_webSocket != null && _webSocket.State == WebSocketState.Open)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(mensagem);
                await _webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, buffer.Length), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }

    public interface IWebSocketService
    {
        Task IniciarWebSocket(WebSocket webSocket);
        Task EnviarMensagemWebSocket(string mensagem);
    }
}
