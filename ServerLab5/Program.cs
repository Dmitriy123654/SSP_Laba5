using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace ServerLab5
{
    internal class Program
    {
        private const string Url = "http://localhost:8000/";
        private static Dictionary<string, double> prices = new Dictionary<string, double>
        {
            {"apple", 1.5},
            {"banana", 2.0},
            {"orange", 1.8}
        };

        static void Main(string[] args)
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(Url);
            listener.Start();
            Console.WriteLine("Server started. Listening on " + Url);

            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                // Получаем IP-адрес и порт клиента
                IPEndPoint clientEndPoint = request.RemoteEndPoint;
                string clientIp = clientEndPoint.Address.ToString();
                int clientPort = clientEndPoint.Port;

                Console.WriteLine($"Client connected: IP={clientIp}, Port={clientPort}");

                if (request.HttpMethod == "POST" && request.Url.AbsolutePath == "/get_price")
                {
                    StreamReader reader = new StreamReader(request.InputStream, request.ContentEncoding);
                    string requestBody = reader.ReadToEnd();
                    Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(requestBody);

                    string productName = data["product_name"];
                    Dictionary<string, object> responseData = new Dictionary<string, object>();

                    if (prices.ContainsKey(productName))
                    {
                        double price = prices[productName];
                        responseData["product_name"] = productName;
                        responseData["price"] = price;
                        Console.WriteLine($"Client requested price for: {productName}");
                    }
                    else
                    {
                        responseData["error"] = "Product not found";
                        Console.WriteLine($"Client requested price for unknown product: {productName}");
                    }

                    string responseBody = JsonConvert.SerializeObject(responseData);
                    byte[] buffer = Encoding.UTF8.GetBytes(responseBody);
                    response.ContentLength64 = buffer.Length;
                    response.OutputStream.Write(buffer, 0, buffer.Length);
                }

                response.Close();
                Console.WriteLine($"Client disconnected: IP={clientIp}, Port={clientPort}");
            }
        }
    }
}