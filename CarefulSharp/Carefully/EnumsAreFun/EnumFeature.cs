using Carefully.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carefully.EnumsAreFun
{

    public class EnumFeature : IDisposable
    {
        private DbContextOptions<DefaultContext> _contextOptions;
        private DefaultContext _context;

        public EnumFeature()
        {
            var builder = new DbContextOptionsBuilder<DefaultContext>();
            builder.UseInMemoryDatabase("enumtest");
            _contextOptions = builder.Options;

            _context = new DefaultContext(_contextOptions);
            
            if (_context.Database.EnsureCreated())
            {
                _context.AddRange(new EnumPayload(), new EnumPayload());
                _context.SaveChanges();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public EnumPayload? GetId(int i)
        {
            return _context.Find<EnumPayload>(i);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
