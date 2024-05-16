using BlogProjeto.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace BlogProjeto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebSocketController : ControllerBase
    {
        private readonly IWebSocketService _webSocketService;

        public WebSocketController(IWebSocketService webSocketService)
        {
            _webSocketService = webSocketService;
        }

        [HttpGet("ws")]
        public async Task WebSocket()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using (WebSocket webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync())
                {
                    await _webSocketService.IniciarWebSocket(webSocket);
                }
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }
        }
    }
}
