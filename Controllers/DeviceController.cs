﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using wakeonlan_server.Db;
using wakeonlan_server.Models;
using wakeonlan_server.Services;

namespace wakeonlan_server.Controllers
{
    public class DeviceController : Controller
    {
        private readonly ILogger<DeviceController> logger;
        private readonly DeviceService deviceService;
        private readonly WakeOnLanContext context;

        public DeviceController(ILogger<DeviceController> logger, DeviceService deviceService, WakeOnLanContext context)
        {
            this.logger = logger;
            this.deviceService = deviceService;
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
         * CREATE
         */
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> Create(Device device)
        {
            if (ModelState.IsValid)
            {
                this.context.Add(device);
                await this.context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ModelState.Clear();
            return View(device);
        }

        /*
         * DETAILS
         */
        [HttpGet()]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await this.context.Devices
                .FindAsync(id);

            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        /*
         *  EDIT
         */

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await this.context.Devices
                .FindAsync(id);

            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(int id, Device device)
        {
            if (id != device.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.context.Update(device);
                    await this.context.SaveChangesAsync();
                }
                catch (DBConcurrencyException)
                {
                    if (!DeviceExists(device.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(device);
        }
        
        /*
         *  DELETE
         */
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await this.context.Devices
                .FirstOrDefaultAsync(d => d.Id == id);

            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var device = this.context.Devices
                .FirstOrDefault(d => d.Id == id);

            if (device != null)
            {
                this.context.Remove(device);
                await this.context.SaveChangesAsync();
            }


            return RedirectToAction(nameof(Index));
        }

        /*
         * INTERNAL
         */
        private bool DeviceExists(int id)
        {
            return this.context.Devices.Any(d => d.Id == id);
        }
    }

}