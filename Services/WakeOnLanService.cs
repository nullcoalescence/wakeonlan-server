using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace wakeonlan_server.Services
{
    public class WakeOnLanService
    {
        public WakeOnLanService() { }

        public bool SendMagicPacket(string addr)
        {
            var address = ParseMacAddress(addr);

            var header = Enumerable.Repeat(byte.MaxValue, 6);
            var data = Enumerable.Repeat(address.GetAddressBytes(), 16)
                .SelectMany(macAddr => macAddr);

            var magicPacket = header.Concat(data).ToArray();

            try
            {
                using (var udpClient = new UdpClient())
                {
                    udpClient.Send(magicPacket,
                        magicPacket.Length,
                        new IPEndPoint(IPAddress.Broadcast, 9));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }


        private PhysicalAddress ParseMacAddress(string macAddress)
        {
            return PhysicalAddress.Parse(macAddress);
        }
    }
}
