using wakeonlan_server.Db;
using wakeonlan_server.Models;

namespace wakeonlan_server.Services
{
    public class DeviceService
    {
        private ILogger<DeviceService> logger;
        private WakeOnLanContext context;

        public DeviceService(ILogger<DeviceService> logger, WakeOnLanContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public IEnumerable<Device> GetAllDevices()
        {
            var devices = this.context.Devices
                .OrderBy(d => d.Name)
                .ToList();

            return devices;
        }

        
    }
}
