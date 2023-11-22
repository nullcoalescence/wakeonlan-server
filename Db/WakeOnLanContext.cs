namespace wakeonlan_server.Db
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.IO;

    using wakeonlan_server.Models;

    public class WakeOnLanContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }

        public string DbPath { get; set; }

        private string dbName = "wakeonlan_server.db";

        public WakeOnLanContext() 
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);

            DbPath = Path.Join(path, dbName);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
    }
}
