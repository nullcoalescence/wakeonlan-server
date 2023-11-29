using Microsoft.AspNetCore.Mvc;
using wakeonlan_server.Db;
using wakeonlan_server.Services;

namespace wakeonlan_server.Controllers
{
    public class WakeController : Controller
    {
        private readonly ILogger<WakeController> logger;
        private readonly DeviceService deviceService;
        private readonly WakeOnLanService wakeOnLanService;
        private readonly WakeOnLanContext context;

        public WakeController(ILogger<WakeController> logger,
            DeviceService deviceService,
            WakeOnLanService wakeOnLanService,
            WakeOnLanContext context)
        {
            this.logger = logger;
            this.deviceService = deviceService;
            this.wakeOnLanService = wakeOnLanService;
            this.context = context;
        }

        /*
         * INDEX
         */
        public IActionResult Index()
        {
            var devices = this.deviceService.GetAllDevices();

            return View(devices);
        }

        /*
         * UP
         * Wake a device up
         */

        public IActionResult Up(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = this.context.Devices
                .FirstOrDefault(d => d.Id == id);

            if (device == null)
            {
                return NotFound();
            }

            var macAddress = this.deviceService.GetMacAddressForDeviceId(id);
            this.wakeOnLanService.SendMagicPacket(macAddress);

            return View();

        }
    }
}
