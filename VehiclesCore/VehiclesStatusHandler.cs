using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using WebSocketManager;
using Newtonsoft.Json;
using VehiclesCore.Models;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;

namespace VehiclesCore
{
    public class VehiclesStatusHandler : WebSocketHandler
    {
        public VehiclesStatusHandler(WebSocketConnectionManager webSocketConnectionManager) : base(webSocketConnectionManager)
        {
        }

        public override async Task OnConnected(WebSocket socket)
        {
            await base.OnConnected(socket);

            var socketId = WebSocketConnectionManager.GetId(socket);
            await SendMessageToAllAsync($"{socketId} is now connected");
        }

        public override async Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {
            //var socketId = WebSocketConnectionManager.GetId(socket);
            var jsonStr = Encoding.UTF8.GetString(buffer, 0, result.Count);
            
            Console.WriteLine(jsonStr);

            try {
                
                JObject obj = JObject.Parse(jsonStr);
                VehicleStatus status = obj.ToObject<VehicleStatus>();

                if(status != null){  
                    status.StatusTime = DateTime.Now;
                    jsonStr = JsonConvert.SerializeObject(status);
                    Console.WriteLine("valid json");
                    using (var db = new DataContext())
                    {    
                        var count = db.SaveStatus(status);
                        Console.WriteLine("{0} records saved to database", count);
                    }
                } else {
                    Console.WriteLine("NOT JSON");
                }
                
                await SendMessageToAllAsync(jsonStr);

            } catch (Exception ex){
                Console.WriteLine(ex.Message);
                Console.WriteLine("Invalid Json");
            }

        }
    }
}