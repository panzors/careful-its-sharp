using Carefully.EnumsAreFun;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carefully.Database
{
    public class DefaultContext : DbContext
    {
        public DbSet<EnumPayload> Payloads { get; set; }
        public string DbPath { get; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite($"Data Source={DbPath}");

        public DefaultContext()
        {

        }

        public DefaultContext(DbContextOptions<DefaultContext> options)
        : base(options)
        {

        }
        //public DefaultContext(DbContextOptions options)
        //    : base(options)
        //{
        //    var folder = Environment.SpecialFolder.LocalApplicationData;
        //    var path = Environment.GetFolderPath(folder);
        //    DbPath = Path.Join(path, "test.db");
        //}
    }
}
