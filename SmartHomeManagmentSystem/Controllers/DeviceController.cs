﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data;
using SmartHome.Data.Models;
using SmartHomeManagmentSystem.Models;
using Device = SmartHome.Data.Models.Device;

namespace SmartHomeManagmentSystem.Controllers
{
    public class DeviceController : Controller
    {
        private readonly SmartHomeDbContext dbContext;
        public DeviceController(SmartHomeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Device> allDevices = this.dbContext.Devices.ToList();
            return View(allDevices);
        }

       
    }
}
