using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using System.Text.Json.Serialization;
using System.Xml.Linq;



namespace AIS.Data
{
    public class OsebaDbContext : DbContext
    {
        public DbSet<Oseba> osebe { get; set; }
       // public string Dbpath { get; }

        public OsebaDbContext(DbContextOptions<OsebaDbContext> options)
        : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        //{
        //    string startupPath = System.IO.Directory.GetCurrentDirectory();
        //    Dbpath = System.IO.Path.Join(startupPath, "OsebeDb.db");
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //     options.UseSqlite($"Data Source = {Dbpath}");
        //}
    }
}




