using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TimerApp.WebForms.Data;


public class TimerAppDbContext : DbContext
{
    public TimerAppDbContext(DbContextOptions<TimerAppDbContext> options) : base(options)
    {

    }

public DbSet<Models.TimerItem> CountdownTimer { get; set; } = default!;
}

