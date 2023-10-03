using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TestWindowsApp.POC
{
    public class UDPHolePunch
    {
        public void Server(int port)
        {
            using (UdpClient udpListener = new UdpClient(port))
            {
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, port);

                byte[] receivedBytes = udpListener.Receive(ref ipEndPoint);
                string clientMessage = Encoding.UTF8.GetString(receivedBytes);

                byte[] response = Encoding.UTF8.GetBytes("Ping 1");
                udpListener.Send(response, response.Length, ipEndPoint);
            }
        }

        public string SendMessageToServer(string message, IPEndPoint serverAddress)
        {
            string serverResponse = string.Empty;

            using (UdpClient client = new UdpClient())
            {
                byte[] data = Encoding.UTF8.GetBytes(message);
                client.Send(data, data.Length, serverAddress);
                serverResponse = Encoding.UTF8.GetString(client.Receive(ref serverAddress));
            }
            return serverResponse;
        }
    }
}
