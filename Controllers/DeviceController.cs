using Microsoft.AspNetCore.Mvc;
using wakeonlan_server.Models;
using wakeonlan_server.Services;

namespace wakeonlan_server.Controllers
{
    public class DeviceController : Controller
    {
        private readonly ILogger<DeviceController> logger;
        private readonly DeviceService deviceService;

        public DeviceController(ILogger<DeviceController> logger, DeviceService deviceService)
        {
            this.logger = logger;
            this.deviceService = deviceService;
        }

        public IActionResult Index()
        {
            var devices = this.deviceService.GetAllDevices();

            //ViewData["devices"] = devices;
            return View(devices);
        }
    }
}