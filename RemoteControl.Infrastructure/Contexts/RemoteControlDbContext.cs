using Microsoft.EntityFrameworkCore;
using RemoteControl.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteControl.Infrastructure.Contexts
{
    public class RemoteControlDbContext : DbContext
    {
        public RemoteControlDbContext(DbContextOptions<RemoteControlDbContext> options)
            : base(options) { }

        public DbSet<Device> Device { get; set; }
    }
}
