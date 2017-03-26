using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNetworking
{
    public class UDP {

        public static string Recieve(int UDP_PORT, IPAddress IP) {

            IPEndPoint UDP_RECIEVE_ENDPOINT = new IPEndPoint(IP, UDP_PORT);
            string UDP_RESPONSE = string.Empty;
            using (UdpClient client = new UdpClient(UDP_PORT))
            {
                UDP_RESPONSE = Encoding.UTF8.GetString(client.Receive(ref UDP_RECIEVE_ENDPOINT));
            }
            return UDP_RESPONSE;
        }

        public static void Send(string Message, int UDP_PORT, IPAddress IP) {

            IPEndPoint UDP_SEND_ENDPOINT = new IPEndPoint(IP, UDP_PORT);
            using (UdpClient client = new UdpClient(UDP_PORT))
            {
                byte[] UDP_DATA = Encoding.UTF8.GetBytes(Message);
                client.Send(UDP_DATA, UDP_DATA.Length, UDP_SEND_ENDPOINT);
            }

        }

        public static string SendAndRecieve(string Message, int UDP_PORT, IPAddress IP) {

            IPEndPoint UDP_ENDPOINT = new IPEndPoint(IP, UDP_PORT);
            string UDP_RESPONSE = string.Empty;
            using (UdpClient client = new UdpClient(UDP_PORT))
            {
                byte[] UDP_DATA = Encoding.UTF8.GetBytes(Message);
                client.Send(UDP_DATA, UDP_DATA.Length, UDP_ENDPOINT);
                UDP_RESPONSE = Encoding.UTF8.GetString(client.Receive(ref UDP_ENDPOINT));
            }
            return UDP_RESPONSE;
        }

    }

    public class URLTools {

        public static IPAddress Resolve(string Hostname) {
            return IPAddress.Parse(Dns.GetHostAddresses(Hostname)[0].ToString());
        }

    }
}
